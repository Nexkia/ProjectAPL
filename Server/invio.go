package main

import (
	"context"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

func invio() {
	//--------------CONNESSIONE DATABASE-----------------------------
	// Create a new client and connect to the server
	client, err := mongo.Connect(context.TODO(), options.Client().ApplyURI(uri))
	if err != nil {
		panic(err)
	}
	defer func() {
		if err = client.Disconnect(context.TODO()); err != nil {
			panic(err)
		}
	}()

	//-----------INSERIRE UNA STRUCT NEL DATABASE------------------------

	coll := client.Database("apl_database").Collection("preAssemblati")

	pc1 := preAssemblato{Nome: "pc1", PcAssemblato: PcAssemblato{Prezzo: 400}}
	pc2 := preAssemblato{Nome: "pc2", PcAssemblato: PcAssemblato{Prezzo: 400}}
	pc3 := preAssemblato{Nome: "pc3", PcAssemblato: PcAssemblato{Prezzo: 400}}
	pc4 := preAssemblato{Nome: "pc4", PcAssemblato: PcAssemblato{Prezzo: 40}}

	coll.InsertOne(context.TODO(), pc1)
	coll.InsertOne(context.TODO(), pc2)
	coll.InsertOne(context.TODO(), pc3)
	coll.InsertOne(context.TODO(), pc4)

}
