package service

import (
	"Server/data"
	"Server/utils"
	"log"
	"net"
	"strings"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func UpdateBuildConsigliate(out chan string, conn net.Conn, mongodb *mongo.Database, profiles *[5][8][3]data.Componente, name *[3]string, lock *sync.Mutex) {

	var profili int = 5
	var categorie int = 8
	var n_elem int = 3
	lock.Lock()
	for i := 0; i < profili; i++ {
		for j := 0; j < categorie; j++ {
			for k := 0; k < n_elem; k++ {
				response := utils.Receive(conn)
				modello := strings.Trim(string(response), "\n")
				filter := bson.D{{"modello", modello}}
				utils.FindOne(filter, "componenti", mongodb).Decode(&profiles[i][j][k])
			}
		}
	}
	for i := 0; i < 3; i++ {
		name_pc_bytes := utils.Receive(conn)
		name_pc := strings.Trim(string(name_pc_bytes), "\n")
		name[i] = name_pc
	}
	lock.Unlock()
	out <- "done"
}

func UpdateStatistics(out chan string, conn net.Conn, mongodb *mongo.Database, img *[3][]byte, lock *sync.Mutex) {
	lock.Lock()
	for i := 0; i < 3; i++ {
		byte_img := utils.Receive(conn)
		img[i] = byte_img
		log.Println(len(byte_img))
	}
	lock.Unlock()
	out <- "done"
}
