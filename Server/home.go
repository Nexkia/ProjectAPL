package main

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"net"
	"sync"

	//"net"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func homepage(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	ID := <-inputChannel
	Autentificazione(ID, mongodb)
	coll := mongodb.Collection("preAssemblati")

	//greater then, filtra per un prezzo maggiore di 300
	//filter := bson.D{{"prezzo", bson.D{{"$gt", 300}}}}
	filter := bson.D{{"prezzoTot", bson.D{{"$gt", 300}}}}
	/*var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)*/

	cursor, err := coll.Find(context.TODO(), filter)
	defer cursor.Close(context.TODO())
	//limit rappresenta il numero di risultati trovati
	limit := cursor.RemainingBatchLength()
	pc := make([]preAssemblato, limit)

	index := 0
	for cursor.Next(context.TODO()) {

		err = cursor.Decode(&pc[index])
		index++
		if err != nil {
			log.Fatal(err)
		}
	}

	//trasformiamo l'oggetto in json e in byte
	pcjson, err := json.Marshal(pc)

	size := len(pcjson)
	rest := size % 1024
	div := size / 1024
	for i := 0; i < div*1024; i = i + 1024 {
		fmt.Println(i, i+1024)
		conn.Write(pcjson[i : i+1024])
	}
	if rest > 0 {
		conn.Write(pcjson[div*1024 : size])
	}
	conn.Write([]byte("\n"))
	wait.Done()
	//test := preAssemblato{}
	//json.Unmarshal(pcjson, &test)
	//fmt.Println("test:", test)

	//fmt.Println("pc:", string(pcjson), " err: ", err, "\nfiltro: ", filter)
}
