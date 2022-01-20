package service

import (
	"Server/data"
	"Server/utils"
	"context"
	"encoding/json"
	"net"
	"strconv"
	"strings"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func SendCatalogo(out chan string, categoria string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	categ := strings.Trim(categoria, "\n")
	lock.Lock()
	comp := getByCategoria(categ, conn, mongodb)
	n_comp := strconv.Itoa(len(comp))
	utils.Send([]byte(n_comp), conn)
	json_comp, _ := json.Marshal(comp)
	utils.Send(json_comp, conn)
	lock.Unlock()
	out <- "done"
}

func getByCategoria(categoria string, conn net.Conn, mongodb *mongo.Database) []data.Componente {
	coll := mongodb.Collection("componenti")
	comp := []data.Componente{}
	filter := bson.D{{"categoria", categoria}}
	cursor, _ := coll.Find(context.TODO(), filter)
	defer cursor.Close(context.TODO())
	cursor.All(context.TODO(), &comp)
	return comp
}
