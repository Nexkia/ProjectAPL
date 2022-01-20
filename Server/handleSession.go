package main

import (
	"Server/data"
	"Server/service"
	"Server/utils"
	"log"
	"net"
	"regexp"
	"strconv"
	"sync"

	"go.mongodb.org/mongo-driver/mongo"
)

type MessagePT int

const (
	register MessagePT = iota
	login
	sendPreassemblati
	sendinfoModifica
	updateinfoModifica
	sendBuildConsigliate
	sendCatalogo
	doConfronto
	sendBuildSolo
	sendinfoInfoPayment
	do_InfoPayment
	sendCronologia
	adminInserimento
	adminInserimentoPre
	adminCancellazione
	adminCancellationPre
	closeConn
	updateBuildConsigliate
	updateStatistics
	sendStatistics
	sendCompatibilita
)

var img = [3][]byte{}
var profiles = [5][8][3]data.Componente{}
var namePre = [3]string{}

func handleSession(conn net.Conn, mongodb *mongo.Database) {
	inputChannel := make(chan string, 1000)
	var (
		MP    MessagePT
		Token string
		state string
		lock  = sync.Mutex{}
	)
	for {
		lock.Lock()
		log.Println(conn.RemoteAddr())
		response := utils.Receive(conn)
		lock.Unlock()
		message := string(response)
		log.Println("Message Received: ", message)
		pt, err := SplitProtocol(message)
		if err != nil {
			conn.Close()
			break
		}
		//conversione ad Int
		MP_conv, _ := (strconv.Atoi(pt[0]))
		MP = MessagePT(MP_conv)
		Mjson := pt[1]
		log.Println("Messaggio Protocollo: ", MP, "Messaggio: ", Mjson)
		switch MP {

		case register:
			log.Println("Register --")
			go service.Register(inputChannel, Mjson, conn, mongodb, &lock)
			state = <-inputChannel
			log.Println(state)

		case login:
			log.Println("Login --")
			go service.Login(inputChannel, Mjson, conn, mongodb, &lock)
			Token = <-inputChannel

		case sendPreassemblati:
			log.Println("sendPreassemblati --")
			go service.SendPreassemblati(inputChannel, conn, mongodb, &namePre, &lock)
			state = <-inputChannel

		case sendinfoModifica:
			log.Println("sendinfoModifica --")
			go service.SendinfoModifica(inputChannel, Token, conn, mongodb, &lock)
			state = <-inputChannel

		case updateinfoModifica:
			log.Println("updateinfoModifica --")
			go service.UpdateinfoModifica(inputChannel, Mjson, Token, conn, mongodb, &lock)
			Token = <-inputChannel

		case sendBuildConsigliate:
			log.Println("sendBuildConsigliate --")
			go service.SendBuildConsigliate(inputChannel, Mjson, conn, &profiles, &lock)
			state = <-inputChannel

		case sendCatalogo:
			log.Println("sendCatalogo --")
			go service.SendCatalogo(inputChannel, Mjson, conn, mongodb, &lock)
			state = <-inputChannel

		case doConfronto:
			log.Println("doConfronto --")
			go service.DoConfronto(inputChannel, Mjson, conn, mongodb, &lock)
			state = <-inputChannel

		case sendBuildSolo:
			log.Println("sendBuildSolo --")
			go service.SendBuildSolo(inputChannel, conn, mongodb, &lock)
			state = <-inputChannel

		case sendinfoInfoPayment:
			log.Println("sendinfoInfoPayment --")
			go service.SendInfoPayment(inputChannel, Token, conn, mongodb, &lock)
			state = <-inputChannel

		case do_InfoPayment:
			log.Println("do_InfoPayment --")
			go service.DoPayment(inputChannel, Mjson, Token, conn, mongodb, &lock)
			state = <-inputChannel

		case sendCronologia:
			log.Println("getCronologia --")
			go service.SendCronologia(inputChannel, Token, conn, mongodb, &lock)
			state = <-inputChannel

		case adminInserimento:
			log.Println("adminInserimento --")
			go service.Inserimento(inputChannel, Mjson, conn, mongodb, &lock)
			state = <-inputChannel

		case adminInserimentoPre:
			log.Println("adminInserimentoPre --")
			go service.Inserimento_pre(inputChannel, Mjson, conn, mongodb, &lock)
			state = <-inputChannel

		case adminCancellazione:
			log.Println("adminCancellazione --")
			go service.Cancellazione(inputChannel, Mjson, conn, mongodb, &lock)
			state = <-inputChannel

		case adminCancellationPre:
			log.Println("adminCancellationPre --")
			go service.Cancellazione_pre(inputChannel, Mjson, conn, mongodb, &lock)
			state = <-inputChannel

		case closeConn:
			log.Println("close --")
			close(inputChannel)
			conn.Close()
			return

		case updateBuildConsigliate:
			log.Println("updateBuildConsigliate --")
			go service.UpdateBuildConsigliate(inputChannel, conn, mongodb, &profiles, &namePre, &lock)
			state = <-inputChannel

		case updateStatistics:
			log.Println("updateStatistics --")
			go service.UpdateStatistics(inputChannel, conn, mongodb, &img, &lock)
			state = <-inputChannel

		case sendStatistics:
			log.Println("sendStatistics --")
			go service.SendStatistics(inputChannel, conn, img, &lock)
			state = <-inputChannel

		case sendCompatibilita:
			go service.SendCompatibilita(inputChannel, Mjson, conn, mongodb, &lock)
			state = <-inputChannel
		}
	}
}

func SplitProtocol(message string) ([]string, error) {
	/*
		Il protocollo ha il seguente formato
		| protocol id | space | message | newline |
	*/
	var err error
	reg := regexp.MustCompile(`(\d*)\s(.*)?`)
	// n = -1 indica al metodo di ritornare tutte le submatch
	res := reg.FindAllStringSubmatch(message, -1)
	pt := make([]string, 2)
	if len(res) > 0 {
		pt[0] = res[0][1]
		pt[1] = res[0][2]
	} else {
		err = net.ErrClosed
	}
	return pt, err
}
