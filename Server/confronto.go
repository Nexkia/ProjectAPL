package main

import (
	"context"
	"encoding/json"
	"fmt"
	"net"
	"strings"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func Confronto(msg string, conn net.Conn, mongodb *mongo.Database) {
	msg_split := strings.Split(msg, "!")
	modello1 := msg_split[0]
	modello2 := strings.Trim(msg_split[1], "\n")
	coll := mongodb.Collection("componenti")
	filter := bson.D{{"modello", "" + modello1 + ""}}

	comp := Componente{}
	err := coll.FindOne(context.TODO(), filter).Decode(&comp)
	fmt.Println("comp: ", comp, "filter: ", filter, "err: ", err)

	coll = mongodb.Collection("detail")

	filter = bson.D{{"modello_" + comp.Categoria + "", "" + modello1 + ""}}
	vetresult := make([]CpuDetail, 2)

	err = coll.FindOne(context.TODO(), filter).Decode(&vetresult[0])
	filter = bson.D{{"modello_" + comp.Categoria + "", "" + modello2 + ""}}

	err = coll.FindOne(context.TODO(), filter).Decode(&vetresult[1])

	fmt.Println("filtro: ", filter, "err: ", err)
	json_result, _ := json.Marshal(vetresult)
	conn.Write(json_result)

}
