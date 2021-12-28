package main

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"net"

	//"net"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func homepage(conn net.Conn, mongodb *mongo.Database) {
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
	rest := size % 256
	div := size / 256
	for i := 0; i < div*256; i = i + 256 {
		fmt.Println(i, i+256)
		conn.Write(pcjson[i : i+256])
	}
	if rest > 0 {
		conn.Write(pcjson[div*256 : size])
	}
	conn.Write([]byte("\n"))

	//test := preAssemblato{}
	//json.Unmarshal(pcjson, &test)
	//fmt.Println("test:", test)

	//fmt.Println("pc:", string(pcjson), " err: ", err, "\nfiltro: ", filter)
}
