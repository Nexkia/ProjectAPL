package service

import (
	"Server/data"
	"Server/utils"
	"encoding/json"
	"net"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func Inserimento(out chan string, jsonComp string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	comp := data.Componente{}
	json.Unmarshal([]byte(jsonComp), &comp)
	detail := data.GetDetailType(comp.Categoria)
	jsonDetail := utils.Receive(conn)
	json.Unmarshal(jsonDetail, detail)
	filter := bson.D{{"modello", comp.Modello}}
	var result bson.D
	lock.Lock()
	err := utils.FindOne(filter, "componenti", mongodb).Decode(&result)
	/*	Se non trova il componente lo inserisce ed inserisce il suo detail
		altrimenti ne aggiorna i valori
	*/
	if err != nil {
		utils.InsertOne("componenti", mongodb, comp)
		utils.InsertOne("detail", mongodb, detail)
	} else {
		bsonComp := createBson(comp)
		updateMongo := bson.D{
			{"$set", bsonComp},
		}
		utils.UpdateOne("componenti", mongodb, filter, updateMongo)
		bsonDetail := createBson(detail)
		filter = bson.D{{"modello_" + comp.Categoria, comp.Modello}}
		updateMongo = bson.D{
			{"$set", bsonDetail},
		}
		utils.UpdateOne("detail", mongodb, filter, updateMongo)
	}
	lock.Unlock()
	out <- "done"
}

func Cancellazione(out chan string, modello string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	comp := data.Componente{}
	filter := bson.D{{"modello", modello}}
	lock.Lock()
	err := utils.FindOne(filter, "componenti", mongodb).Decode(&comp)
	if err != nil {
		utils.Send([]byte("NotFound"), conn)
		lock.Unlock()
		out <- "done"
		return
	}
	utils.DeleteOne("componenti", mongodb, filter)
	filter = bson.D{{"modello_" + comp.Categoria, comp.Modello}}
	utils.DeleteOne("detail", mongodb, filter)
	utils.Send([]byte("Done"), conn)
	lock.Unlock()
	out <- "done"
}

func Inserimento_pre(out chan string, jsonPre string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	pre := data.PcpreAssemblato{}
	var result bson.D
	json.Unmarshal([]byte(jsonPre), &pre)
	filter := bson.D{{"nome", pre.Nome}}
	lock.Lock()
	err := utils.FindOne(filter, "preAssemblati", mongodb).Decode(&result)
	if err != nil {
		utils.InsertOne("preAssemblati", mongodb, pre)
		lock.Unlock()
		out <- "done"
		return
	}
	bsonPre := createBson(pre)
	updateMongo := bson.D{
		{"$set", bsonPre},
	}
	utils.UpdateOne("preAssemblati", mongodb, filter, updateMongo)
	lock.Unlock()
	out <- "done"
}

func Cancellazione_pre(out chan string, nome string, conn net.Conn, mongodb *mongo.Database, lock *sync.Mutex) {
	var result bson.D
	filter := bson.D{{"nome", nome}}
	lock.Lock()
	err := utils.FindOne(filter, "preAssemblati", mongodb).Decode(&result)
	if err != nil {
		utils.Send([]byte("NotFound"), conn)
		lock.Unlock()
		out <- "done"
		return
	}
	utils.DeleteOne("preAssemblati", mongodb, filter)
	utils.Send([]byte("Done"), conn)
	lock.Unlock()
	out <- "done"
}

func SendStatistics(out chan string, conn net.Conn, img [3][]byte, lock *sync.Mutex) {
	lock.Lock()
	for i := 0; i < 3; i++ {
		utils.Send(img[i], conn)
	}
	lock.Unlock()
	out <- "done"
}

func createBson(interface_ interface{}) bson.D {
	var bsonD bson.D
	bsonMarshal, _ := bson.Marshal(interface_)
	bson.Unmarshal(bsonMarshal, &bsonD)
	return bsonD
}
