package main

import (
	"context"
	"encoding/json"
	"fmt"
	"net"
	"strconv"
	"strings"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func listCatalogo(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	msg := <-inputChannel
	categoria := strings.Trim(msg, "\n")
	coll := mongodb.Collection("componenti")
	filter := bson.D{{"categoria", categoria}}
	cursor, err := coll.Find(context.TODO(), filter)
	defer cursor.Close(context.TODO())
	fmt.Println(filter)
	//limit rappresenta il numero di risultati trovati
	comp := []Componente{}
	cursor.All(context.TODO(), &comp)
	nelem := len(comp)
	if err != nil {
		panic(err)
	}
	fmt.Println(nelem, ".....", comp)
	conn.Write([]byte(strconv.Itoa(nelem)))
	ok := make([]byte, 256)
	conn.Read(ok)
	byte_tosend, _ := json.Marshal(comp)
	size := len(byte_tosend)
	rest := size % 256
	div := size / 256
	for i := 0; i < div*256; i = i + 256 {
		conn.Write(byte_tosend[i : i+256])
	}
	if rest > 0 {
		conn.Write(byte_tosend[div*256 : size])
	}
	conn.Write([]byte("\n"))
	wait.Done()
}
