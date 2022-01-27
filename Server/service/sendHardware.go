package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"log"
	"net"
	"strconv"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func SendPreassemblati(conn net.Conn, mongodb *mongo.Database, name *[3]string) {
	pc := make([]data.PcpreAssemblato, 3)
	for i := 0; i < 3; i++ {
		filter := bson.D{{Key: "nome", Value: name[i]}}
		utils.FindOne(filter, "preAssemblati", mongodb).Decode(&pc[i])
	}
	//trasformiamo l'oggetto in json e in byte
	prejson, _ := json.Marshal(pc)
	utils.Send(prejson, conn)

}

func SendBuildConsigliate(profile string, conn net.Conn, profiles *[5][8][3]data.Componente, lock *sync.RWMutex) {
	log.Println(profile)
	index, _ := strconv.Atoi(profile)
	lock.RLock()
	for _, categ := range profiles[index] {
		json_comp, _ := json.Marshal(categ)
		utils.Send(json_comp, conn)
	}
	lock.RUnlock()
}

func SendBuildSolo(conn net.Conn, mongodb *mongo.Database) {
	categoria := [8]string{"cpu", "schedaMadre", "casepc", "schedaVideo", "dissipatore", "alimentatore", "ram", "memoria"}
	for _, categ := range categoria {
		comp := getByCategoria(categ, conn, mongodb)
		json_comp, _ := json.Marshal(comp)
		utils.Send(json_comp, conn)
	}
}
