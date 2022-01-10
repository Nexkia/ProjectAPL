package main

import (
	"context"
	"encoding/json"
	"fmt"
	"net"
	"strconv"
	"strings"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
)

type Acquisto struct {
	Lista  [][]string
	Prezzo float64
}

func getCronologia(token string, conn net.Conn, mongodb *mongo.Database, wait *sync.WaitGroup) {

	coll := mongodb.Collection("Venduti")
	okmsg := make([]byte, 256)
	filter := bson.D{{"id_token", token}}
	var result map[string]interface{}
	err := coll.FindOne(context.TODO(), filter).Decode(&result)
	if err != nil {
		conn.Write([]byte("notFound"))
	}

	Pc := PcAssemblato{}
	PcAssemblati := []PcAssemblato{}
	PreAssemblati := []string{}
	var numberoAcquisti int = 0
	for key := range result {
		if strings.Contains(key, "acquisto") {
			numberoAcquisti++
		}
	}
	conn.Write([]byte(strconv.Itoa(numberoAcquisti)))
	conn.Read(okmsg)
	for key := range result {
		if strings.Contains(key, "acquisto") {
			PcAssemblati = []PcAssemblato{}
			PreAssemblati = []string{}
			acquisto := result[key]
			acquisto_internal := acquisto.(map[string]interface{})
			lista_acquisti := acquisto_internal["Lista"].(primitive.A)
			for _, elem := range lista_acquisti {
				pc1 := elem.(primitive.A)
				for i, comp := range pc1 {
					fmt.Println(i)
					fmt.Println(len(pc1))
					if len(pc1) == 8 {
						coll = mongodb.Collection("componenti")
						filter = bson.D{{"modello", comp}}
						componente := Componente{}
						err = coll.FindOne(context.TODO(), filter).Decode(&componente)
						if err == nil {
							Pc.Componenti[i] = componente
						}
					} else {
						PreAssemblati = append(PreAssemblati, comp.(string))
					}
				}
				Pc.prezzoTot()
				if Pc.Prezzo != 0 {
					PcAssemblati = append(PcAssemblati, Pc)
				}
			}
			prezzo := acquisto_internal["Prezzo"].(float64)
			prezzo_bytes := []byte(strconv.FormatFloat(prezzo, 'f', -1, 64))
			pcassemblati_bytes, _ := json.Marshal(PcAssemblati)
			pcpreassemblati_bytes, _ := json.Marshal(PreAssemblati)
			size := len(pcassemblati_bytes)
			rest := size % 256
			div := size / 256
			for i := 0; i < div*256; i = i + 256 {
				conn.Write(pcassemblati_bytes[i : i+256])
			}
			if rest > 0 {
				conn.Write(pcassemblati_bytes[div*256 : size])
			}
			conn.Write([]byte("\n"))
			conn.Read(okmsg)
			conn.Write(pcpreassemblati_bytes)
			conn.Read(okmsg)
			conn.Write(prezzo_bytes)
			conn.Read(okmsg)
		}
	}
	wait.Done()
}
