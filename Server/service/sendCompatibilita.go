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
	msg_rcv := strings.Trim(msg, "\n")

	byte_categoria := utils.Receive(conn)
	categ_ := strings.Trim(string(byte_categoria), "\n")
	filter := bson.D{{"modello_" + categ_, msg_rcv}}
	detail := data.GetDetailType(categ_)
	err := utils.FindOne(filter, "detail", mongodb).Decode(detail)
	if err != nil {
		utils.Send([]byte("NotFound"), conn)
		return
	}
	json_result, _ := json.Marshal(detail)
	utils.Send(json_result, conn)

}
