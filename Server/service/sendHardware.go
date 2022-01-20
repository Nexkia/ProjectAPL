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

func SendPreassemblati(out chan string, conn net.Conn, mongodb *mongo.Database, name *[3]string, lock *sync.Mutex) {
	pc := make([]data.PcpreAssemblato, 3)
	lock.Lock()
	for i := 0; i < 3; i++ {
		filter := bson.D{{"nome", name[i]}}
		print(name[i])
		utils.FindOne(filter, "preAssemblati", mongodb).Decode(&pc[i])
	}
	//trasformiamo l'oggetto in json e in byte
	prejson, _ := json.Marshal(pc)
	utils.Send(prejson, conn)
	lock.Unlock()
	out <- "done"

}

func SendBuildConsigliate(out chan string, profile string, conn net.Conn, profiles *[5][8][3]data.Componente, lock *sync.Mutex) {
	log.Println(profile)
	index, _ := strconv.Atoi(profile)
	lock.Lock()
	for _, categ := range profiles[index] {
		json_comp, _ := json.Marshal(categ)
		utils.Send(json_comp, conn)
	}
	lock.Unlock()
	out <- "done"

}

func SendBuildSolo(out chan string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	categoria := [8]string{"cpu", "schedaMadre", "casepc", "schedaVideo", "dissipatore", "alimentatore", "ram", "memoria"}
	lock.Lock()
	for _, categ := range categoria {
		comp := getByCategoria(categ, conn, mongodb)
		n_comp := strconv.Itoa(len(comp))
		utils.Send([]byte(n_comp), conn)
		json_comp, _ := json.Marshal(comp)
		utils.Send(json_comp, conn)
	}
	lock.Unlock()
	out <- "done"
}
