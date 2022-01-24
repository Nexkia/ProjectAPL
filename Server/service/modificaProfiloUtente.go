package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"fmt"
	"log"
	"net"
	"strings"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func SendinfoModifica(token string, conn net.Conn, mongodb *mongo.Database) {
	filter := bson.D{{Key: "password", Value: token}}
	u := data.Utente{}

	utils.FindOne(filter, "utenti", mongodb).Decode(&u)
	user, err := json.Marshal(u)
	if err != nil {
		fmt.Println("error parsing")
	}
	utils.Send(user, conn)

}

func UpdateinfoModifica(out chan string, msg string, token string, conn net.Conn, mongodb *mongo.Database) {
	cred := strings.Split(msg, "###")
	email, password := cred[0], cred[1]
	password = strings.Trim(password, "\n")
	check_token := utils.Encoding(email, password)

	if token != check_token {
		utils.Send([]byte("err password diversa \n"), conn)

		return
	}
	utils.Send([]byte("utente Trovato\n"), conn)
	update_info := utils.Receive(conn)
	log.Println(update_info)
	u := data.Utente{}
	//conversione della stringa in byte
	json.Unmarshal([]byte(update_info), &u)
	u.Password = utils.Encoding(u.Email, u.Password)
	filter := bson.D{{Key: "password", Value: token}}
	updateMongo := bson.D{
		{Key: "$set", Value: bson.D{
			{Key: "email", Value: u.Email},
			{Key: "indirizzo", Value: u.Indirizzo},
			{Key: "nome", Value: u.NomeUtente},
			{Key: "password", Value: u.Password},
		}},
	}
	utils.UpdateOne("utenti", mongodb, filter, updateMongo)

	out <- u.Password

}
