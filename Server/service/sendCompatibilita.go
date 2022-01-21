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
	msg_split := strings.Split(msg_rcv, "#")

	byte_categoria := utils.Receive(conn)
	categ_split := strings.Split(string(byte_categoria), "#")
	for i := 0; i < len(msg_split)-1; i++ {
		filter := bson.D{{"modello_" + categ_split[i], msg_split[i]}}
		detail := data.GetDetailType(categ_split[i])
		err := utils.FindOne(filter, "detail", mongodb).Decode(detail)
		if err != nil {
			utils.Send([]byte("NotFound"), conn)

			return
		}
		json_result, _ := json.Marshal(detail)
		utils.Send(json_result, conn)
	}

}
