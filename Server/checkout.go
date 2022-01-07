package main

import (
	"context"
	"encoding/json"
	"fmt"
	"net"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

type CreditCard struct {
	number int `bson:"number" json:"number"`
	month  int `bson:"month" json:"month"`
	year   int `bson:"year" json:"year"`
	cvv    int `bson:"cvv" json:"cvv"`
}
type InfoPayment struct {
	email                 string `bson:"email" json:"email"`
	indirizzoFatturazione string `bson:"indirizzofatturazione" json:"indirizzofatturazione"`
	CreditCard            `bson:"creditcard" json:"creditcard"`
}

func getInfoPayment(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	token := <-inputChannel
	coll := mongodb.Collection("InfoPayment")
	u, err := getUtente(token, mongodb)
	if err == nil {
		filter := bson.D{{"email", "" + u.Email + ""}}
		Info := InfoPayment{}
		err := coll.FindOne(context.TODO(), filter).Decode(&Info)
		if err != nil {
			conn.Write([]byte("notFound"))
		}
		InfoJson, err := json.Marshal(Info)
		if err != nil {
			fmt.Println("error parsing")
		}
		conn.Write(InfoJson)
	} else {
		conn.Write([]byte("notFound"))
	}
	wait.Done()
}
func getPayment(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	elementiVenduti := <-inputChannel
	coll := mongodb.Collection("Venduti")
	vetVenduti := make([]byte, 256)
	conn.Read(vetVenduti)
	fmt.Println(elementiVenduti, coll)

}
