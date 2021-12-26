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

	pc1 := preAssemblato{
		Nome:   "pc1",
		Prezzo: 400,
		Componenti: [6]Componente{
			{Prezzo: 30, Marca: "intel", Img: "", Valutazione: 3, Modello: "modello cpu", Categoria: "cpu"},
			{Prezzo: 40, Marca: "marca scheda madre", Img: "", Valutazione: 3, Modello: "modello scheda madre", Categoria: "schedaMadre"},
			{Prezzo: 60, Marca: "nvidia", Img: "", Valutazione: 1, Modello: "gtx 1660", Categoria: "schedaVideo"},
			{Prezzo: 60, Marca: "telaio marca", Img: "", Valutazione: 4, Modello: "modello telaio", Categoria: "telaio"},
			{Prezzo: 34, Marca: "marca dissipatore", Img: "", Valutazione: 3, Modello: "modello dissipatore", Categoria: "dissipatore"},
			{Prezzo: 30, Marca: "marca alimentatore", Img: "", Valutazione: 3, Modello: "modello alimentatore", Categoria: "alimentatore"},
		},
		Ram: Ram{
			Componente: Componente{Prezzo: 40, Marca: "marca ram", Img: "", Valutazione: 2, Modello: "ram modello", Categoria: "ram"},
			Frequenza:  3000,
			Capienza:   12,
			Standard:   "ddr3",
		},
		Memoria: Memoria{
			Componente: Componente{Prezzo: 40, Marca: "marca ssd", Img: "", Valutazione: 7, Modello: "modello memoria", Categoria: "memoria"},
			Dimensione: 500,
			Tipo:       "ssd",
		},
	}

	pc2 := preAssemblato{
		Nome:   "pc2",
		Prezzo: 450,
		Componenti: [6]Componente{
			{Prezzo: 30, Marca: "amd", Img: "", Valutazione: 3, Modello: "modello cpu", Categoria: "cpu"},
			{Prezzo: 40, Marca: "marca scheda madre", Img: "", Valutazione: 3, Modello: "modello scheda madre", Categoria: "schedaMadre"},
			{Prezzo: 60, Marca: "amd", Img: "", Valutazione: 1, Modello: "ryzen", Categoria: "schedaVideo"},
			{Prezzo: 60, Marca: "telaio marca", Img: "", Valutazione: 4, Modello: "modello telaio", Categoria: "telaio"},
			{Prezzo: 34, Marca: "marca dissipatore", Img: "", Valutazione: 3, Modello: "modello dissipatore", Categoria: "dissipatore"},
			{Prezzo: 30, Marca: "marca alimentatore", Img: "", Valutazione: 3, Modello: "modello alimentatore", Categoria: "alimentatore"},
		},
		Ram: Ram{
			Componente: Componente{Prezzo: 40, Marca: "marca ram", Img: "", Valutazione: 2, Modello: "ram modello", Categoria: "ram"},
			Frequenza:  3000,
			Capienza:   16,
			Standard:   "ddr4",
		},
		Memoria: Memoria{
			Componente: Componente{Prezzo: 40, Marca: "marca hdd", Img: "", Valutazione: 7, Modello: "modello memoria", Categoria: "memoria"},
			Dimensione: 250,
			Tipo:       "hdd",
		},
	}
	pc3 := preAssemblato{Nome: "pc3", Prezzo: 400}
	pc4 := preAssemblato{Nome: "pc4", Prezzo: 40}

	coll.InsertOne(context.TODO(), pc1)
	coll.InsertOne(context.TODO(), pc2)
	coll.InsertOne(context.TODO(), pc3)
	coll.InsertOne(context.TODO(), pc4)

}
