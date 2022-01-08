package main

import (
	"bufio"
	"context"
	"encoding/json"
	"fmt"
	"net"
	"strconv"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

type CreditCard struct {
	Number int `bson:"number" json:"number"`
	Month  int `bson:"month" json:"month"`
	Year   int `bson:"year" json:"year"`
	Cvv    int `bson:"cvv" json:"cvv"`
}
type InfoPayment struct {
	Email                 string     `bson:"email" json:"email"`
	IndirizzoFatturazione string     `bson:"indirizzoFatturazione" json:"indirizzoFatturazione"`
	CreditCard            CreditCard `bson:"creditCard" json:"creditCard"`
}

func getInfoPayment(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	token := <-inputChannel
	u, err := getUtente(token, mongodb)
	coll := mongodb.Collection("InfoPayment")
	if err != nil {
		conn.Write([]byte("notFound"))
		wait.Done()
		return
	}
	filter := bson.D{{"email", u.Email}}
	Info := InfoPayment{}
	err = coll.FindOne(context.TODO(), filter).Decode(&Info)
	if err != nil {
		conn.Write([]byte("notFound"))
		wait.Done()
		return
	}
	InfoJson, err := json.Marshal(Info)
	if err != nil {
		fmt.Println("error parsing")
		wait.Done()
		return
	}
	conn.Write(InfoJson)
	wait.Done()
}
func getPayment(inputChannel chan string, token string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	elementiVenduti := <-inputChannel
	// Ricerca email utente
	u, err := getUtente(token, mongodb)
	if err != nil {
		wait.Done()
		return
	}
	coll := mongodb.Collection("Venduti")
	conn.Write([]byte("received"))
	filter := bson.D{{"id_token", token}}
	var result map[string]interface{}
	err = coll.FindOne(context.TODO(), filter).Decode(&result)
	// La insert richiede un interface
	var dat map[string]interface{}
	json.Unmarshal([]byte(elementiVenduti), &dat)
	if err != nil {
		coll.InsertOne(context.TODO(), dat)
	} else {
		keys := make([]string, 0, len(result))
		fmt.Println(len(result))
		for k := range result {
			keys = append(keys, k)
		}
		fmt.Println(keys)
		new_buy := len(keys) - 1
		updateMongo := bson.D{
			{"$set", bson.D{
				{"acquisto_" + strconv.Itoa(new_buy), dat["acquisto"]},
			}},
		}
		coll.UpdateOne(context.Background(), filter, updateMongo)
	}
	// Inserimento o aggiornamento del metodo di pagamento
	coll = mongodb.Collection("InfoPayment")
	infoPayment := InfoPayment{}
	infoP, _ := bufio.NewReader(conn).ReadString('\n')
	json.Unmarshal([]byte(infoP), &infoPayment)
	// Ricerca prima di inserire
	infoPayment.Email = u.Email
	filter = bson.D{{"email", u.Email}}
	search := InfoPayment{}
	err = coll.FindOne(context.TODO(), filter).Decode(&search)
	if err != nil {
		coll.InsertOne(context.TODO(), infoPayment)
	} else {
		updateMongo := bson.D{
			{"$set", bson.D{
				{"indirizzoFatturazione", infoPayment.IndirizzoFatturazione},
				{"creditCard", infoPayment.CreditCard},
			}},
		}
		coll.UpdateOne(context.TODO(), filter, updateMongo)
	}
	conn.Write([]byte("payment done"))
	wait.Done()
}
