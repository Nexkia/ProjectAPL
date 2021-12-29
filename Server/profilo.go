package main

import (
	"context"
	"encoding/json"
	"fmt"
	"log"
	"net"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func sendComponents(profile string, conn net.Conn, mongodb *mongo.Database) {
	fmt.Println(profile)
	coll := mongodb.Collection("componenti")
	categoria := [8]string{"cpu", "schedaMadre", "casepc", "schedaVideo", "dissipatore", "alimentatore", "ram", "memoria"}
	for i := 0; i < 8; i++ {
		ok := make([]byte, 256)
		conn.Read(ok)
		filter := bson.D{{"categoria", "" + categoria[i] + ""}}
		cursor, err := coll.Find(context.TODO(), filter)
		defer cursor.Close(context.TODO())
		//limit rappresenta il numero di risultati trovati
		limit := 3
		comp := make([]Componente, limit)

		index := 0
		for cursor.Next(context.TODO()) {
			err = cursor.Decode(&comp[index])
			index++
			if limit == index {
				break
			}
			if err != nil {
				log.Fatal(err)
			}
		}
		json_comp, _ := json.Marshal(comp)
		size := len(json_comp)
		rest := size % 256
		div := size / 256
		for i := 0; i < div*256; i = i + 256 {
			conn.Write(json_comp[i : i+256])
		}
		if rest > 0 {
			conn.Write(json_comp[div*256 : size])
		}
		conn.Write([]byte("\n"))
	}
}
