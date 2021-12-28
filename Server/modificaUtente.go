package main

import (
	"bufio"
	"context"
	"encoding/json"
	"fmt"
	"net"
	"strings"

	"go.mongodb.org/mongo-driver/bson"

	"go.mongodb.org/mongo-driver/mongo"
)

func getUtente(token string, conn net.Conn, mongodb *mongo.Database) {
	coll := mongodb.Collection("utenti")
	filter := bson.D{{"password", "" + token + ""}}
	u := Utente{}
	err := coll.FindOne(context.TODO(), filter).Decode(&u)
	if err != nil {
		fmt.Println("error not found")
	}
	user, err := json.Marshal(u)
	if err != nil {
		fmt.Println("error parsing")
	}
	conn.Write(user)
}

func updateUtente(data string, token string, conn net.Conn, mongodb *mongo.Database) {
	res := strings.Split(data, "-")
	email, password := res[0], res[1]
	password = strings.Trim(password, "\n")
	check_token := Encoding(email, password)
	if token != check_token {
		conn.Write([]byte("err password diversa"))
		return
	}
	conn.Write([]byte("ok"))
	update, _ := bufio.NewReader(conn).ReadString('\n')
	fmt.Println(update)
	u := Utente{}
	//conversione della stringa in byte
	json.Unmarshal([]byte(update), &u)
	u.Password = Encoding(u.Email, u.Password)
	coll := mongodb.Collection("utenti")
	filter := bson.D{{"password", "" + token + ""}}
	updateMongo := bson.D{
		{"$set", bson.D{
			{"email", "" + u.Email + ""},
			{"indirizzo", "" + u.Indirizzo + ""},
			{"nome", "" + u.NomeUtente + ""},
			{"password", "" + u.Password + ""},
		}},
	}
	coll.UpdateOne(context.TODO(), filter, updateMongo)
	conn.Write([]byte(u.Password))
}
