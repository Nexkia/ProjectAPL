package main

import (
	"context"
	"encoding/json"
	"fmt"
	"log"

	//"net"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func homepage(token string /*conn net.Conn,*/, mongodb *mongo.Database) {
	coll := mongodb.Collection("preAssemblati")

	//greater then, filtra per un prezzo maggiore di 300
	//filter := bson.D{{"prezzo", bson.D{{"$gt", 300}}}}
	filter := bson.D{{"pcassemblato.prezzoTot", 400}}
	/*var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)*/

	cursor, err := coll.Find(context.TODO(), filter)
	defer cursor.Close(context.TODO())
	limit := cursor.RemainingBatchLength()
	pc := make([]preAssemblato, limit)

	for cursor.Next(context.TODO()) {
		index := 0
		err = cursor.Decode(&pc[index])
		if err != nil {
			log.Fatal(err)
		}
	}
	//limit rappresenta il numero di risultati trovati

	//trasformiamo l'oggetto in json e in byte
	pcjson, err := json.Marshal(pc)
	test := preAssemblato{}
	json.Unmarshal(pcjson, &test)
	fmt.Println("test:", test)
	//conn.Write(pcjson)

	fmt.Println("pc:", pc, " err: ", err, "\nfiltro: ", filter)
}
