package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"net"
	"strconv"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func SendInfoPayment(out chan string, token string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	filter := bson.D{{"password", token}}
	u := data.Utente{}
	lock.Lock()
	err := utils.FindOne(filter, "utenti", mongodb).Decode(&u)
	if err != nil {
		utils.Send([]byte("notFound"), conn)
		lock.Unlock()
		out <- "done"
		return
	}
	filter = bson.D{{"email", u.Email}}
	Info := data.InfoPayment{}
	err = utils.FindOne(filter, "InfoPayment", mongodb).Decode(&Info)
	if err != nil {
		utils.Send([]byte("notFound"), conn)
		lock.Unlock()
		out <- "done"
		return
	}
	InfoJson, _ := json.Marshal(Info)
	utils.Send(InfoJson, conn)
	lock.Unlock()
	out <- "done"
}

func DoPayment(out chan string, elementiVenduti string, token string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	// Ricerca email utente
	filter := bson.D{{"password", token}}
	u := data.Utente{}
	lock.Lock()
	err := utils.FindOne(filter, "utenti", mongodb).Decode(&u)
	if err != nil {
		utils.Send([]byte("notFound"), conn)
		lock.Unlock()
		out <- "done"
		return
	}
	filter = bson.D{{"email", u.Email}}
	var result map[string]interface{}
	err = utils.FindOne(filter, "Venduti", mongodb).Decode(&result)
	// La insert richiede un interface
	vend := data.Vendita{}
	var dat map[string]interface{}
	json.Unmarshal([]byte(elementiVenduti), &dat)
	if err != nil {
		vend.Email = u.Email
		vend.Acquisto = dat["acquisto"]
		utils.InsertOne("Venduti", mongodb, vend)
	} else {
		nuovo_acquisto := len(result) - 1
		updateMongo := bson.D{
			{"$set", bson.D{
				{"acquisto_" + strconv.Itoa(nuovo_acquisto), dat["acquisto"]},
			}},
		}
		utils.UpdateOne("Venduti", mongodb, filter, updateMongo)
	}
	// Inserimento o aggiornamento del metodo di pagamento
	infoPayment := data.InfoPayment{}
	infoPByte := utils.Receive(conn)
	json.Unmarshal([]byte(infoPByte), &infoPayment)
	// Ricerca prima di inserire
	infoPayment.Email = u.Email
	filter = bson.D{{"email", u.Email}}
	var search bson.D
	err = utils.FindOne(filter, "InfoPayment", mongodb).Decode(&search)
	if err != nil {
		utils.InsertOne("InfoPayment", mongodb, infoPayment)
	} else {
		updateMongo := bson.D{
			{"$set", bson.D{
				{"indirizzoFatturazione", infoPayment.IndirizzoFatturazione},
				{"creditCard", infoPayment.CreditCard},
			}},
		}
		utils.UpdateOne("InfoPayment", mongodb, filter, updateMongo)
	}
	utils.Send([]byte("payment done"), conn)
	lock.Unlock()
	out <- "done"
}
