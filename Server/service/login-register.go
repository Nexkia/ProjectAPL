package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"log"
	"net"
	"strconv"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func Register(u_json string, conn net.Conn, mongodb *mongo.Database) {

	var result bson.D
	var msg string
	u := data.Utente{}
	// Conversione da json a Utente
	json.Unmarshal([]byte(u_json), &u)
	/*
		Prima dell'inserimento
		verifica che l'utente non sia già registrato
	*/
	filter := bson.D{{Key: "email", Value: u.Email}}

	err := utils.FindOne(filter, "utenti", mongodb).Decode(&result)
	/*
		Se l'errore è diverso da nil vuol dire che l'utente non è registrato
		per cui si può proceder all'inserimento
	*/
	if err != nil {
		encodedPsw := utils.Encoding(u.Email, u.Password)
		// aggiorno la password con il token
		u.Password = encodedPsw
		err = utils.InsertOne("utenti", mongodb, u)
		if err != nil {
			log.Println("Errore Inserimento")
		}
		msg = "Registrazione effettuata"
	} else {
		msg = "email gia' usata"
	}
	utils.Send([]byte(msg), conn)
}

func Login(out chan string, u_json string, conn net.Conn, mongodb *mongo.Database) {
	var result bson.D
	u := data.Utente{}
	/*
		Cerchiamo prima se è presente l'utente nel nostro database
	*/
	json.Unmarshal([]byte(u_json), &u)
	log.Println("utente: ", u_json, " utente_conv: ", u)
	u.Password = utils.Encoding(u.Email, u.Password)
	filter := bson.D{{Key: "email", Value: u.Email}, {Key: "password", Value: u.Password}}
	err := utils.FindOne(filter, "utenti", mongodb).Decode(&result)
	if err != nil {
		msg := "Errore utente non trovato"
		utils.Send([]byte(msg), conn)
		out <- ""
	} else {
		checkAdmin := (u.Password == "VlPUwbiQVA6j2OBXnVyL0GGbdR2EeMk9OUulJHi0YjE=")
		admin := strconv.FormatBool(checkAdmin)
		utils.Send([]byte(admin), conn)
		out <- u.Password
	}
}
