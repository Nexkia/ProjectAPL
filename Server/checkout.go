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
	number int
	month  int
	year   int
	ccv    int
}
type InfoPayment struct {
	email                 string
	indirizzoFatturazione string
	CreditCard
}

func getInfoPayment(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	email := <-inputChannel
	coll := mongodb.Collection("InfoPayment")
	filter := bson.D{{"email", "" + email + ""}}
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
	wait.Done()
}
func getPayment(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	elementiVenduti := <-inputChannel
	coll := mongodb.Collection("Venduti")
	vetVenduti := make([]byte, 256)
	conn.Read(vetVenduti)
	fmt.Println(elementiVenduti, coll)

}
