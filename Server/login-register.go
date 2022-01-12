package main

import (
	"context"
	"encoding/json"
	"fmt"
	"net"
	"strconv"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

type Utente struct {
	Email      string `bson:"email" json:"email"`
	Indirizzo  string `bson:"indirizzo" json:"indirizzo"`
	NomeUtente string `bson:"nome" json:"nomeutente"`
	Password   string `bson:"password" json:"password"`
}

func register(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	Mjson := <-inputChannel
	coll := mongodb.Collection("utenti")

	l1 := Utente{}
	//conversione della stringa in byte
	json.Unmarshal([]byte(Mjson), &l1)
	filter := bson.D{{"email", l1.Email}}
	var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)

	fmt.Println("result3: ", result, "\nerror3: ", err, "\nMS: ", Mjson, "\nfILTER3: ", filter)

	if err != nil {
		//inserimento dell'utente nel database
		encodedPsw := Encoding(l1.Email, l1.Password)
		l1.Password = encodedPsw
		res, err := coll.InsertOne(context.TODO(), l1)

		fmt.Println("utente:", res, " errore: ", err)

		conn.Write([]byte("Registrazione effettuata\n"))
	} else {

		conn.Write([]byte("email gia' usata\n"))

	}
	wait.Done()
}

func login(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	Mjson := <-inputChannel
	err := verificaUtente(Mjson, mongodb)
	oksmg := make([]byte, 256)
	if err != nil {
		conn.Write([]byte("errore: " + err.Error() + "\n"))
	} else {
		// `{"some":"json"}`
		l1 := Utente{}
		//conversione del Json in byte
		json.Unmarshal([]byte(Mjson), &l1)
		token := Encoding(l1.Email, l1.Password)
		conn.Write([]byte(token))
		conn.Read(oksmg)
		checkAdmin := (token == "VlPUwbiQVA6j2OBXnVyL0GGbdR2EeMk9OUulJHi0YjE=")
		admin := strconv.FormatBool(checkAdmin)
		conn.Write([]byte(admin))
	}

	fmt.Println("ho finito")
	wait.Done()
}

func verificaUtente(Mjson string, mongodb *mongo.Database) error {
	coll := mongodb.Collection("utenti")

	l1 := Utente{}

	//conversione del Json in byte
	json.Unmarshal([]byte(Mjson), &l1)
	fmt.Println("Mjson:", Mjson, " l1: ", l1)
	l1.Password = Encoding(l1.Email, l1.Password)
	filter := bson.D{{"email", l1.Email}, {"password", l1.Password}}

	var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)

	fmt.Println("result3: ", result, "\nerror3: ", err, "\nMS: ", Mjson, "\nfILTER3: ", filter)
	return err

}
