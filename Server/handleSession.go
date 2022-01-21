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
		lock  = sync.RWMutex{}
	)
	for {

		log.Println(conn.RemoteAddr())
		response := utils.Receive(conn)

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
			service.Register(Mjson, conn, mongodb)

		case login:
			log.Println("Login --")
			service.Login(inputChannel, Mjson, conn, mongodb)
			Token = <-inputChannel

		case sendPreassemblati:
			log.Println("sendPreassemblati --")
			service.SendPreassemblati(conn, mongodb, &namePre)

		case sendinfoModifica:
			log.Println("sendinfoModifica --")
			service.SendinfoModifica(Token, conn, mongodb)

		case updateinfoModifica:
			log.Println("updateinfoModifica --")
			service.UpdateinfoModifica(inputChannel, Mjson, Token, conn, mongodb)
			Token = <-inputChannel

		case sendBuildConsigliate:
			log.Println("sendBuildConsigliate --")
			service.SendBuildConsigliate(Mjson, conn, &profiles, &lock)

		case sendCatalogo:
			log.Println("sendCatalogo --")
			service.SendCatalogo(Mjson, conn, mongodb)

		case doConfronto:
			log.Println("doConfronto --")
			service.DoConfronto(Mjson, conn, mongodb)

		case sendBuildSolo:
			log.Println("sendBuildSolo --")
			service.SendBuildSolo(conn, mongodb)

		case sendinfoInfoPayment:
			log.Println("sendinfoInfoPayment --")
			service.SendInfoPayment(Token, conn, mongodb)

		case do_InfoPayment:
			log.Println("do_InfoPayment --")
			service.DoPayment(Mjson, Token, conn, mongodb)

		case sendCronologia:
			log.Println("getCronologia --")
			service.SendCronologia(Token, conn, mongodb)

		case adminInserimento:
			log.Println("adminInserimento --")
			service.Inserimento(Mjson, conn, mongodb)

		case adminInserimentoPre:
			log.Println("adminInserimentoPre --")
			service.Inserimento_pre(Mjson, conn, mongodb)

		case adminCancellazione:
			log.Println("adminCancellazione --")
			service.Cancellazione(Mjson, conn, mongodb)

		case adminCancellationPre:
			log.Println("adminCancellationPre --")
			service.Cancellazione_pre(Mjson, conn, mongodb)

		case closeConn:
			log.Println("close --")
			close(inputChannel)
			conn.Close()
			return

		case updateBuildConsigliate:
			log.Println("updateBuildConsigliate --")
			service.UpdateBuildConsigliate(conn, mongodb, &profiles, &namePre, &lock)

		case updateStatistics:
			log.Println("updateStatistics --")
			service.UpdateStatistics(conn, mongodb, &img, &lock)

		case sendStatistics:
			log.Println("sendStatistics --")
			service.SendStatistics(conn, img, &lock)

		case sendCompatibilita:
			service.SendCompatibilita(Mjson, conn, mongodb)
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
