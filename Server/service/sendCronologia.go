package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"net"
	"strconv"
	"strings"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
)

func SendCronologia(token string, conn net.Conn, mongodb *mongo.Database) {
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
	if err != nil {
		utils.Send([]byte("notFound"), conn)

		return
	}
	Pc := data.PcAssemblato{}
	var numberoAcquisti int
	for key := range result {
		if strings.Contains(key, "acquisto") {
			numberoAcquisti++
		}
	}
	numberoAcquistiStr := strconv.Itoa(numberoAcquisti)
	utils.Send([]byte(numberoAcquistiStr), conn)
	for key := range result {
		if strings.Contains(key, "acquisto") {
			PcAssemblati := []data.PcAssemblato{}
			PreAssemblati := []string{}
			acquisto := result[key]
			acquisto_internal := acquisto.(map[string]interface{})
			lista_acquisti := acquisto_internal["Lista"].(primitive.A)
			for _, elem := range lista_acquisti {
				pc1 := elem.(primitive.A)
				Pc = data.PcAssemblato{}
				for i, comp := range pc1 {
					if len(pc1) == 8 {
						filter = bson.D{{Key: "modello", Value: comp}}
						componente := data.Componente{}
						err = utils.FindOne(filter, "componenti", mongodb).Decode(&componente)
						if err == nil {
							Pc.Componenti[i] = componente
						}
					} else {
						PreAssemblati = append(PreAssemblati, comp.(string))
					}
				}
				Pc.PrezzoTot()
				if Pc.Prezzo != 0 {
					PcAssemblati = append(PcAssemblati, Pc)
				}
			}
			data := acquisto_internal["Data"].(string)
			prezzo := acquisto_internal["Prezzo"].(float64)
			prezzo_bytes := []byte(strconv.FormatFloat(prezzo, 'f', -1, 64))
			pcassemblati_bytes, _ := json.Marshal(PcAssemblati)
			pcpreassemblati_bytes, _ := json.Marshal(PreAssemblati)
			utils.Send(pcassemblati_bytes, conn)
			utils.Send(pcpreassemblati_bytes, conn)
			utils.Send(prezzo_bytes, conn)
			utils.Send([]byte(data), conn)
		}
	}

}
