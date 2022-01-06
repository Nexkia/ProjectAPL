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
	msg_rcv := strings.Trim(msg, "\n")
	msg_split := strings.Split(msg_rcv, "!")
	modello1 := msg_split[0]
	coll := mongodb.Collection("componenti")
	filter := bson.D{{"modello", "" + modello1 + ""}}
	comp := Componente{}
	err := coll.FindOne(context.TODO(), filter).Decode(&comp)
	fmt.Println("comp: ", comp, "filter: ", filter, "err: ", err)

	coll = mongodb.Collection("detail")

	detail, _ := getDetailType(comp.Categoria)
	fmt.Printf("%T \n", detail)
	for _, elem := range msg_split {
		if elem != "" {
			ok := make([]byte, 16)
			conn.Read(ok)
			filter = bson.D{{"modello_" + comp.Categoria + "", "" + elem + ""}}
			err = coll.FindOne(context.TODO(), filter).Decode(detail)
			fmt.Println(detail)
			fmt.Println("filtro: ", filter, "err: ", err)
			json_result, _ := json.Marshal(detail)
			conn.Write(json_result)
		}
	}
	//modello2 := strings.Trim(msg_split[1], "\n")

	//vetresult := make([]CpuDetail, 2)

}
