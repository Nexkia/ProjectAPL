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

func SendCatalogo(categoria string, conn net.Conn, mongodb *mongo.Database) {
	categ := strings.Trim(categoria, "\n")
	comp := getByCategoria(categ, conn, mongodb)
	json_comp, _ := json.Marshal(comp)
	utils.Send(json_comp, conn)
}

func getByCategoria(categoria string, conn net.Conn, mongodb *mongo.Database) []data.Componente {
	comp := []data.Componente{}
	filter := bson.D{{Key: "categoria", Value: categoria}}
	utils.Find("componenti", mongodb, filter, &comp)
	return comp
}
