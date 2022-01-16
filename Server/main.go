package main

import (
	"bufio"
	"context"
	"errors"
	"fmt"
	"net"
	"regexp"
	"strconv"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

const uri = "mongodb://127.0.0.1:27017"

// only needed below for sample processing

type Img struct {
	Img []byte
}

var rWlock = sync.RWMutex{}
var img = [3]Img{}

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
	go invio()

	for {

		// accept connection on port
		conn, err := ln.Accept()
		if err != nil {
			fmt.Println("Error accepting request:", err)
		}
		go handleRequest(conn, mongodb)
	}
}

func handleRequest(conn net.Conn, mongodb *mongo.Database) {
	inputChannel := make(chan string, 1000)
	var waitGroup = sync.WaitGroup{}
	for { // will listen for message to process ending in newline (\n)
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
			go register(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 1:
			fmt.Println("caso 1: ", MP)
			go login(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 2:
			fmt.Println("caso 2: ", MP)
			go homepage(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- ID
		case 3:
			fmt.Println("caso 3: ", MP)
			go getUtenteRoutine(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- ID
		case 4:
			fmt.Println("caso 4: ", MP)
			go updateUtente(inputChannel, ID, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 5:
			fmt.Println("caso 5: ", MP)
			go sendComponents(inputChannel, 3, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 6:
			fmt.Println("caso 6: ", MP)
			go listCatalogo(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 7:
			fmt.Println("caso 7:", MP)
			go Confronto(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 8:
			fmt.Println("caso 8:", MP)
			go sendComponents(inputChannel, 0, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 9:
			fmt.Println("caso 9", MP)
			close(inputChannel)
			conn.Close()
			return
		case 10:
			fmt.Println("case 10", MP)
			go getInfoPayment(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- ID
		case 11:
			fmt.Println("case 11", MP)
			go getPayment(inputChannel, ID, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 12:
			fmt.Println("case 12", MP)
			go getCronologia(ID, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
		case 13:
			fmt.Println("case 13", MP)
			go Inserimento(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 14:
			fmt.Println("case 14", MP)
			go Cancellazione(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 15:
			fmt.Println("case 15", MP)
			go Inserimento_pre(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 16:
			fmt.Println("case 16", MP)
			go Cancellazione_pre(inputChannel, conn, mongodb, &waitGroup)
			waitGroup.Add(1)
			inputChannel <- Mjson
		case 17:
			fmt.Println("case 17", MP)
			go getProfiles(conn, &waitGroup)
			waitGroup.Add(1)
		case 18:
			fmt.Println("case 18", MP)
			go getImages(conn, &waitGroup, img)
			waitGroup.Add(1)
		default:
			fmt.Println("CASO DI DEFAULT")
		}
		waitGroup.Wait()
	}
	// send new string back to client
	//conn.Write([]byte(message + "\n"))
}

func SplitFunc(message string) (r []string, err error) {
	if message == "" {
		return nil, errors.New("errore messaggio vuoto")
	}
	reg := regexp.MustCompile(`(\d*)\s(.{1,}=)?\s(.{1,})?`)
	res := reg.FindAllStringSubmatch(message, -1)
	vet := make([]string, 3)
	vet[0] = res[0][1]
	vet[1] = res[0][2]
	vet[2] = res[0][3]
	return vet, nil

}

func Autentificazione(data string, mongodb *mongo.Database) bool {
	coll := mongodb.Collection("utenti")
	//decodifichiamo il token
	filter := bson.D{{"password", data}}
	var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)

	return err == nil
}
