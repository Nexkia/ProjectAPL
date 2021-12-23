package main

import (
	"context"
	"encoding/json"
	"log"
	"net"
	"strconv"

	//"net"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func homepage(conn net.Conn, mongodb *mongo.Database) {
	coll := mongodb.Collection("preAssemblati")

	//greater then, filtra per un prezzo maggiore di 300
	//filter := bson.D{{"prezzo", bson.D{{"$gt", 300}}}}
	filter := bson.D{{"pcassemblato.prezzoTot", 400}}
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

	conn.Write([]byte(strconv.Itoa(size)))
	conn.Write(pcjson)
	//test := preAssemblato{}
	//json.Unmarshal(pcjson, &test)
	//fmt.Println("test:", test)

	//fmt.Println("pc:", string(pcjson), " err: ", err, "\nfiltro: ", filter)
}
