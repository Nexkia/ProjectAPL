package main

import (
	"context"
	"encoding/json"
	"fmt"
	"net"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

type Utente struct {
	Email      string `bson:"email" json:"email"`
	Indirizzo  string `bson:"indirizzo" json:"indirizzo"`
	NomeUtente string `bson:"nome" json:"nome"`
	Password   string `bson:"password" json:"passwrod"`
}

func register(Mjson string, conn net.Conn, mongodb *mongo.Database) {

	coll := mongodb.Collection("utenti")

	l1 := Utente{}

	//conversione della stringa in byte
	json.Unmarshal([]byte(Mjson), &l1)
	filter := bson.D{{"email", "" + l1.Email + ""}}

	var result4 bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result4)

	fmt.Println("result3: ", result4, "\nerror3: ", err, "\nMS: ", Mjson, "\nfILTER3: ", filter)

	if err != nil {
		//inserimento dell'utente nel database
		res, err := coll.InsertOne(context.TODO(), l1)

		fmt.Println("utente:", res, " errore: ", err)

		conn.Write([]byte("Registrazione effettuata"))
	} else {

		conn.Write([]byte("email gia' usata"))

	}

	conn.Close()

}

func login(Mjson string, conn net.Conn, mongodb *mongo.Database) {

	coll := mongodb.Collection("utenti")

	l1 := Utente{}

	//conversione del Json in byte
	json.Unmarshal([]byte(Mjson), &l1)
	filter := bson.D{{"email", "" + l1.Email + ""}, {"password", "" + l1.Password + ""}}

	var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)

	fmt.Println("result3: ", result, "\nerror3: ", err, "\nMS: ", Mjson, "\nfILTER3: ", filter)

	if err != nil {
		conn.Write([]byte("errore: " + err.Error()))

	} else {
		conn.Write([]byte("ok"))

	}
	conn.Close()
}
