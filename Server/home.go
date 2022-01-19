package main

import (
	"context"
	"encoding/json"
	"fmt"
	"net"
	"sync"

	//"net"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func homepage(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup, name *[3]string) {
	ID := <-inputChannel
	Autentificazione(ID, mongodb)
	coll := mongodb.Collection("preAssemblati")
	pc := make([]preAssemblato, 3)

	//greater then, filtra per un prezzo maggiore di 300
	//filter := bson.D{{"prezzo", bson.D{{"$gt", 300}}}}
	for i := 0; i < 3; i++ {
		filter := bson.D{{"nome", name[i]}}
		print(name[i])
		coll.FindOne(context.TODO(), filter).Decode(&pc[i])
	}
	//trasformiamo l'oggetto in json e in byte
	pcjson, _ := json.Marshal(pc)

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
