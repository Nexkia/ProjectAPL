package main

import (
	"context"
	"log"
	"net"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

const uri = "mongodb://127.0.0.1:27017"

func main() {
	log.Println("Launching server...")

	// listen on all interfaces
	ln, err := net.Listen("tcp", ":13000")
	if err != nil {
		log.Println("Error listening on port:", err)
	}

	//--------------CONNESSIONE DATABASE-----------------------------
	// Create a new client and connect to the server
	client, err := mongo.Connect(context.TODO(), options.Client().ApplyURI(uri))
	if err != nil {
		panic(err)
	}
	defer func() {
		if err = client.Disconnect(context.TODO()); err != nil {
			panic(err)
		}
	}()
	mongodb := client.Database("apl_database")
	//------------------------------------------------------------------
	//go invio()
	for {
		// accept connection on port
		conn, err := ln.Accept()
		if err != nil {
			log.Println("Error accepting request:", err)
		}
		go handleSession(conn, mongodb)
	}
}
