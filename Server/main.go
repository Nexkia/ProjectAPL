package main

import (
	"context"
	"log"
	"net"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

// Database URL
const uri = "mongodb://127.0.0.1:27017"

func main() {
	log.Println("Launching server...")
	ln, err := net.Listen("tcp", ":13000")
	if err != nil {
		log.Println("Error listening on port:", err)
	}

	//--------------CONNESSIONE DATABASE-----------------------------
	ctx := context.Background()
	client, err := mongo.Connect(ctx, options.Client().ApplyURI(uri))
	if err != nil {
		panic(err)
	}
	defer func() {
		if err = client.Disconnect(ctx); err != nil {
			panic(err)
		}
	}()
	mongodb := client.Database("apl_database")
	go invio(mongodb)
	//------------------------------------------------------------------
	for {
		conn, err := ln.Accept()
		if err != nil {
			log.Println("Error accepting request:", err)
		}
		go handleSession(conn, mongodb)
	}
}
