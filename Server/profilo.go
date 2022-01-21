package main

import (
	"context"
	"encoding/json"
	"fmt"
	"net"
	"strconv"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func sendComponents(inputChannel chan string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	profile := <-inputChannel
	fmt.Println(profile)
	coll := mongodb.Collection("componenti")
	categoria := [8]string{"cpu", "schedaMadre", "casepc", "schedaVideo", "dissipatore", "alimentatore", "ram", "memoria"}
	for i := 0; i < 8; i++ {
		ok := make([]byte, 256)
		conn.Read(ok)
		filter := bson.D{{"categoria", categoria[i]}}
		cursor, _ := coll.Find(context.TODO(), filter)
		defer cursor.Close(context.TODO())
		var json_comp []byte
		//limit rappresenta il numero di risultati trovati
		comp := []Componente{}
		cursor.All(context.TODO(), &comp)
		conn.Write([]byte(strconv.Itoa(len(comp))))
		conn.Read(ok)
		json_comp, _ = json.Marshal(comp)
		size := len(json_comp)
		rest := size % 1024
		div := size / 1024
		for i := 0; i < div*1024; i = i + 1024 {
			conn.Write(json_comp[i : i+1024])
		}
		if rest > 0 {
			conn.Write(json_comp[div*1024 : size])
		}
		conn.Write([]byte("\n"))
	}
	wait.Done()
}

func sendRecommendation(inputChannel chan string, conn net.Conn, wait *sync.WaitGroup, profiles *[5][8][3]Componente) {
	profile := <-inputChannel
	fmt.Println(profile)
	index, _ := strconv.Atoi(profile)
	ok := make([]byte, 256)
	for _, categ := range profiles[index] {
		conn.Read(ok)
		json_comp, _ := json.Marshal(categ)
		conn.Write(json_comp)
		conn.Write([]byte("\n"))
	}
	wait.Done()
}
