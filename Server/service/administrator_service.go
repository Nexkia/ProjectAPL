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

func Inserimento(jsonComp string, conn net.Conn, mongodb *mongo.Database) {
	comp := data.Componente{}
	json.Unmarshal([]byte(jsonComp), &comp)
	detail := data.GetDetailType(comp.Categoria)
	jsonDetail := utils.Receive(conn)
	json.Unmarshal(jsonDetail, detail)
	filter := bson.D{{"modello", comp.Modello}}
	var result bson.D

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

}

func Cancellazione(modello string, conn net.Conn, mongodb *mongo.Database) {
	comp := data.Componente{}
	filter := bson.D{{"modello", modello}}

	err := utils.FindOne(filter, "componenti", mongodb).Decode(&comp)
	if err != nil {
		utils.Send([]byte("NotFound"), conn)

		return
	}
	utils.DeleteOne("componenti", mongodb, filter)
	filter = bson.D{{"modello_" + comp.Categoria, comp.Modello}}
	utils.DeleteOne("detail", mongodb, filter)
	utils.Send([]byte("Done"), conn)

}

func Inserimento_pre(jsonPre string, conn net.Conn, mongodb *mongo.Database) {
	pre := data.PcpreAssemblato{}
	var result bson.D
	json.Unmarshal([]byte(jsonPre), &pre)
	filter := bson.D{{"nome", pre.Nome}}

	err := utils.FindOne(filter, "preAssemblati", mongodb).Decode(&result)
	if err != nil {
		utils.InsertOne("preAssemblati", mongodb, pre)

		return
	}
	bsonPre := createBson(pre)
	updateMongo := bson.D{
		{"$set", bsonPre},
	}
	utils.UpdateOne("preAssemblati", mongodb, filter, updateMongo)

}

func Cancellazione_pre(nome string, conn net.Conn, mongodb *mongo.Database) {
	var result bson.D
	filter := bson.D{{"nome", nome}}

	err := utils.FindOne(filter, "preAssemblati", mongodb).Decode(&result)
	if err != nil {
		utils.Send([]byte("NotFound"), conn)

		return
	}
	utils.DeleteOne("preAssemblati", mongodb, filter)
	utils.Send([]byte("Done"), conn)

}

func SendStatistics(conn net.Conn, img [3][]byte, lock *sync.RWMutex) {
	lock.RLock()
	for i := 0; i < 3; i++ {
		utils.Send(img[i], conn)
	}
	lock.RUnlock()
}

func createBson(interface_ interface{}) bson.D {
	var bsonD bson.D
	bsonMarshal, _ := bson.Marshal(interface_)
	bson.Unmarshal(bsonMarshal, &bsonD)
	return bsonD
}
