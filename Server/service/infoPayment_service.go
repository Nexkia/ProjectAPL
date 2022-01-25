package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"log"
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
	if !Check(dat, mongodb) {
		utils.Send([]byte("Un elemento non presente"), conn)
		return
	}
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

func Check(dat map[string]interface{}, mongodb *mongo.Database) bool {
	var CheckExistence bool = true
	acquisto := dat["acquisto"]
	log.Println(acquisto)
	acquisto_internal := acquisto.(map[string]interface{})
	lista_acquisti := acquisto_internal["Lista"].([]interface{})
	log.Println(lista_acquisti)
	for _, elem := range lista_acquisti {
		pc1 := elem.([]interface{})
		for _, comp := range pc1 {
			if len(pc1) == 8 {
				filter := bson.D{{Key: "modello", Value: comp}}
				log.Println(filter)
				componente := data.Componente{}
				err := utils.FindOne(filter, "componenti", mongodb).Decode(&componente)
				// Se non lo trova
				if err != nil {
					CheckExistence = false
					return CheckExistence
				}
			} else {
				filter := bson.D{{Key: "name", Value: comp}}
				log.Println(filter)
				pre := data.PcpreAssemblato{}
				err := utils.FindOne(filter, "preAssemblati", mongodb).Decode(&pre)
				if err != nil {
					CheckExistence = false
					return CheckExistence
				}
			}
		}
	}
	return CheckExistence
}
