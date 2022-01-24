package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"net"
	"strconv"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func SendInfoPayment(token string, conn net.Conn, mongodb *mongo.Database) {
	filter := bson.D{{Key: "password", Value: token}}
	u := data.Utente{}

	err := utils.FindOne(filter, "utenti", mongodb).Decode(&u)
	if err != nil {
		utils.Send([]byte("notFound"), conn)

		return
	}
	filter = bson.D{{Key: "email", Value: u.Email}}
	Info := data.InfoPayment{}
	err = utils.FindOne(filter, "InfoPayment", mongodb).Decode(&Info)
	if err != nil {
		utils.Send([]byte("notFound"), conn)

		return
	}
	InfoJson, _ := json.Marshal(Info)
	utils.Send(InfoJson, conn)

}

func DoPayment(elementiVenduti string, token string, conn net.Conn, mongodb *mongo.Database) {
	// Ricerca email utente
	filter := bson.D{{Key: "password", Value: token}}
	u := data.Utente{}

	err := utils.FindOne(filter, "utenti", mongodb).Decode(&u)
	if err != nil {
		utils.Send([]byte("notFound"), conn)

		return
	}
	filter = bson.D{{Key: "email", Value: u.Email}}
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
			{Key: "$set", Value: bson.D{
				{Key: "acquisto_" + strconv.Itoa(nuovo_acquisto), Value: dat["acquisto"]},
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
	filter = bson.D{{Key: "email", Value: u.Email}}
	var search bson.D
	err = utils.FindOne(filter, "InfoPayment", mongodb).Decode(&search)
	if err != nil {
		utils.InsertOne("InfoPayment", mongodb, infoPayment)
	} else {
		updateMongo := bson.D{
			{Key: "$set", Value: bson.D{
				{Key: "indirizzoFatturazione", Value: infoPayment.IndirizzoFatturazione},
				{Key: "creditCard", Value: infoPayment.CreditCard},
			}},
		}
		utils.UpdateOne("InfoPayment", mongodb, filter, updateMongo)
	}
	utils.Send([]byte("payment done"), conn)

}
