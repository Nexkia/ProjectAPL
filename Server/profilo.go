package main

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"net"
	"strconv"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func sendComponents(inputChannel chan string, limit int, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {
	profile := <-inputChannel
	fmt.Println(profile)
	coll := mongodb.Collection("componenti")
	categoria := [8]string{"cpu", "schedaMadre", "casepc", "schedaVideo", "dissipatore", "alimentatore", "ram", "memoria"}
	for i := 0; i < 8; i++ {
		ok := make([]byte, 256)
		conn.Read(ok)
		filter := bson.D{{"categoria", categoria[i]}}
		cursor, err := coll.Find(context.TODO(), filter)
		defer cursor.Close(context.TODO())
		var json_comp []byte
		//limit rappresenta il numero di risultati trovati
		comp := []Componente{}
		if limit == 3 {
			compguidata := make([]Componente, limit)
			index := 0
			for cursor.Next(context.TODO()) {
				err = cursor.Decode(&compguidata[index])
				index++
				if limit == index {
					fmt.Println(index)
					break
				}
				if err != nil {
					log.Fatal(err)
				}
			}
			json_comp, _ = json.Marshal(compguidata)
		} else {
			cursor.All(context.TODO(), &comp)
			conn.Write([]byte(strconv.Itoa(len(comp))))
			conn.Read(ok)
			json_comp, _ = json.Marshal(comp)
		}
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
