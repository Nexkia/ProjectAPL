package main

import (
	"bufio"
	"context"
	"errors"
	"fmt"
	"net"
	"strconv"
	"strings"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

const uri = "mongodb://127.0.0.1:27017"

// only needed below for sample processing

func main() {

	fmt.Println("Launching server...")

	// listen on all interfaces
	ln, err := net.Listen("tcp", ":13000")
	if err != nil {
		fmt.Println("Error listening on port:", err)
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
		go homepage("a" /*conn,*/, mongodb)
		// accept connection on port
		conn, err := ln.Accept()
		if err != nil {
			fmt.Println("Error accepting request:", err)
		}

		go handleRequest(conn, mongodb)
	}
}

func handleRequest(conn net.Conn, mongodb *mongo.Database) {
	// will listen for message to process ending in newline (\n)
	message, _ := bufio.NewReader(conn).ReadString('\n')
	// output message received
	fmt.Print("Message Received:", string(message))

	vetMessage, err := SplitFunc(message)

	fmt.Println("Messaggio Protocollo:", vetMessage[0], "Messaggio", vetMessage[1], "errore: ", err)

	//conversione ad Int
	MP, _ := strconv.Atoi(vetMessage[0])
	ID := vetMessage[1]
	Mjson := vetMessage[2]

	fmt.Println(ID)
	switch MP {
	case 0:
		fmt.Println("caso 0: ", MP)
		go register(Mjson, conn, mongodb)

	case 1:
		fmt.Println("caso 1: ", MP)

		go login(Mjson, conn, mongodb)
	case 2:
		fmt.Println("caso 2: ", MP)

	default:
		fmt.Println("CASO DI DEFAULT")
	}

	// send new string back to client
	//conn.Write([]byte(message + "\n"))
}

func SplitFunc(message string) (r []string, err error) {
	if message == "" {
		return nil, errors.New("errore messaggio vuoto")
	}
	vet := strings.Split(message, " ")
	return vet, nil

}
