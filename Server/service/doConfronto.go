package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"log"
	"net"
	"strings"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func DoConfronto(out chan string, msg string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	msg_rcv := strings.Trim(msg, "\n")
	modelli := strings.Split(msg_rcv, "#")
	modello1 := modelli[0]
	comp := data.Componente{}
	filter := bson.D{{"modello", modello1}}
	lock.Lock()
	err := utils.FindOne(filter, "componenti", mongodb).Decode(&comp)
	if err != nil {
		utils.Send([]byte("NotFound"), conn)
		lock.Unlock()
		out <- "done"
		return
	}
	log.Println("comp: ", comp)
	detail := data.GetDetailType(comp.Categoria)
	log.Printf("%T \n", detail)
	for _, mod := range modelli {
		if mod != "" {
			filter = bson.D{{"modello_" + comp.Categoria, mod}}
			err := utils.FindOne(filter, "detail", mongodb).Decode(detail)
			if err != nil {
				utils.Send([]byte("NotFound"), conn)
				lock.Unlock()
				out <- "done"
				return
			}
			log.Println(detail)
			json_result, _ := json.Marshal(detail)
			utils.Send(json_result, conn)
		}
	}
	lock.Unlock()
	out <- "done"
}
