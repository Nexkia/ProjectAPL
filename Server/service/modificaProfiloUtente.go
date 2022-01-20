package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"fmt"
	"log"
	"net"
	"strings"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func SendinfoModifica(out chan string, token string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	filter := bson.D{{"password", token}}
	u := data.Utente{}
	lock.Lock()
	utils.FindOne(filter, "utenti", mongodb).Decode(&u)
	user, err := json.Marshal(u)
	if err != nil {
		fmt.Println("error parsing")
	}
	utils.Send(user, conn)
	lock.Unlock()
	out <- "done"
}

func UpdateinfoModifica(out chan string, msg string, token string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	cred := strings.Split(msg, "###")
	email, password := cred[0], cred[1]
	password = strings.Trim(password, "\n")
	check_token := utils.Encoding(email, password)
	lock.Lock()
	if token != check_token {
		utils.Send([]byte("err password diversa \n"), conn)
		lock.Unlock()
		out <- "done"
		return
	}
	utils.Send([]byte("utente Trovato\n"), conn)
	update_info := utils.Receive(conn)
	log.Println(update_info)
	u := data.Utente{}
	//conversione della stringa in byte
	json.Unmarshal([]byte(update_info), &u)
	u.Password = utils.Encoding(u.Email, u.Password)
	filter := bson.D{{"password", token}}
	updateMongo := bson.D{
		{"$set", bson.D{
			{"email", u.Email},
			{"indirizzo", u.Indirizzo},
			{"nome", u.NomeUtente},
			{"password", u.Password},
		}},
	}
	utils.UpdateOne("utenti", mongodb, filter, updateMongo)
	lock.Unlock()
	out <- u.Password

}
