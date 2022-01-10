package main

import (
	"bufio"
	"context"
	"encoding/json"
	"fmt"
	"net"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func Inserimento(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	jsonComp := <-inputChannel
	comp := Componente{}
	coll := mongodb.Collection("componenti")
	colldt := mongodb.Collection("detail")
	json.Unmarshal([]byte(jsonComp), &comp)
	detail, _ := getDetailType(comp.Categoria)
	filter := bson.D{{"modello", comp.Modello}}
	var result bson.D
	conn.Write([]byte("ok"))
	bytesDetail, _ := bufio.NewReader(conn).ReadString('\n')
	json.Unmarshal([]byte(bytesDetail), detail)
	err := coll.FindOne(context.TODO(), filter).Decode(&result)
	if err != nil {
		coll.InsertOne(context.TODO(), comp)
		colldt.InsertOne(context.TODO(), detail)
	} else {
		updateMongo := bson.D{
			{"$set", bson.D{
				{"prezzo", comp.Prezzo},
				{"marca", comp.Marca},
				{"capienza", comp.Capienza},
				{"modello", comp.Modello},
				{"categoria", comp.Categoria},
			}},
		}
		coll.UpdateOne(context.Background(), filter, updateMongo)
		bsonDetail, _ := bson.Marshal(detail)
		var bsonD bson.D
		bson.Unmarshal(bsonDetail, &bsonD)
		filter = bson.D{{"modello_" + comp.Categoria, comp.Modello}}
		updateMongo = bson.D{
			{"$set", bsonD},
		}
		fmt.Println(filter)
		fmt.Println(updateMongo)
		colldt.UpdateOne(context.Background(), filter, updateMongo)
	}
	conn.Write([]byte("ok"))
	wait.Done()
}

func Cancellazione(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	modello := <-inputChannel
	coll := mongodb.Collection("componenti")
	colldt := mongodb.Collection("detail")
	filter := bson.D{{"modello", modello}}
	comp := Componente{}
	err := coll.FindOne(context.TODO(), filter).Decode(&comp)
	if err != nil {
		conn.Write([]byte("NotFound"))
		wait.Done()
		return
	}
	coll.DeleteOne(context.TODO(), filter)
	filter = bson.D{{"modello_" + comp.Categoria, comp.Modello}}
	colldt.DeleteOne(context.TODO(), filter)
	conn.Write([]byte("ok"))
	wait.Done()
}
