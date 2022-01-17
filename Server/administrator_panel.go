package main

import (
	"bufio"
	"context"
	"encoding/json"
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

func Inserimento_pre(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	jsonPre := <-inputChannel
	pre := preAssemblato{}
	json.Unmarshal([]byte(jsonPre), &pre)
	coll := mongodb.Collection("preAssemblati")
	filter := bson.D{{"nome", pre.Nome}}
	var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)
	if err != nil {
		coll.InsertOne(context.TODO(), pre)
		conn.Write([]byte("ok"))
		wait.Done()
		return
	}
	updateMongo := bson.D{
		{"$set", bson.D{
			{"nome", pre.Nome},
			{"prezzo", pre.Prezzo},
			{"componenti", pre.Componenti},
		}},
	}
	coll.UpdateOne(context.TODO(), filter, updateMongo)
	conn.Write([]byte("ok"))
	wait.Done()
}

func Cancellazione_pre(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	nome := <-inputChannel
	coll := mongodb.Collection("preAssemblati")
	filter := bson.D{{"nome", nome}}
	pre := preAssemblato{}
	err := coll.FindOne(context.TODO(), filter).Decode(&pre)
	if err != nil {
		conn.Write([]byte("NotFound"))
		wait.Done()
		return
	}
	coll.DeleteOne(context.TODO(), filter)
	conn.Write([]byte("ok"))
	wait.Done()
}

func admin_images(conn net.Conn, wait *sync.WaitGroup) {
	rWlock.RLock()
	for i := 0; i < 3; i++ {
		conn.Write(img[i].Img)
	}
	rWlock.RUnlock()
	wait.Done()
}
