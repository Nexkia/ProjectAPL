package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"net"
	"strings"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func SendCompatibilita(msg string, conn net.Conn, mongodb *mongo.Database) {
	/*
		Questa funzione si occupa di reperire i detail dei componenti
		la verifica effettiva della compatibilità viene effettuata lato client
	*/
	msg_rcv := strings.Trim(msg, "\n")
	byte_categoria := utils.Receive(conn)
	categ_ := strings.Trim(string(byte_categoria), "\n")
	filter := bson.D{{Key: "modello_" + categ_, Value: msg_rcv}}
	detail := data.GetDetailType(categ_)
	err := utils.FindOne(filter, "detail", mongodb).Decode(detail)
	if err != nil {
		utils.Send([]byte("NotFound"), conn)
		return
	}
	json_result, _ := json.Marshal(detail)
	utils.Send(json_result, conn)

}
