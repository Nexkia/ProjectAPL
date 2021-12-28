package main

import (
	"context"
	"math/rand"
	"time"

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

	//coll := client.Database("apl_database").Collection("preAssemblati")

	// pc1 := preAssemblato{
	// 	Nome:   "pc1",
	// 	Prezzo: 401,
	// 	Componenti: [8]Componente{
	// 		{Prezzo: 150, Marca: "intel", Modello: "i5-2780", Categoria: "cpu"},
	// 		{Prezzo: 100, Marca: "Gigabyte", Modello: "Hi500", Categoria: "schedaMadre"},
	// 		{Prezzo: 350, Marca: "nvidia", Modello: "gtx 1660", Categoria: "schedaVideo"},
	// 		{Prezzo: 60, Marca: "CoolerMaster", Modello: "CS550", Categoria: "casepc"},
	// 		{Prezzo: 35, Marca: "Artic", Modello: "Duos", Categoria: "dissipatore"},
	// 		{Prezzo: 30, Marca: "CoolerMaster", Modello: "CX300", Categoria: "alimentatore"},
	// 		{Prezzo: 50, Marca: "Samsung", Capienza: 500, Modello: "Evo 850", Categoria: "memoria"},
	// 		{Prezzo: 100, Marca: "Corsair", Capienza: 16, Modello: "Ballistix", Categoria: "ram"},
	// 	},
	// }
	// pc2 := preAssemblato{
	// 	Nome:   "pc2",
	// 	Prezzo: 402,
	// 	Componenti: [8]Componente{
	// 		{Prezzo: 150, Marca: "amd", Modello: "ryzen 3", Categoria: "cpu"},
	// 		{Prezzo: 100, Marca: "Gigabyte", Modello: "Hi500", Categoria: "schedaMadre"},
	// 		{Prezzo: 350, Marca: "nvidia", Modello: "gtx 1660", Categoria: "schedaVideo"},
	// 		{Prezzo: 60, Marca: "CoolerMaster", Modello: "CS550", Categoria: "casepc"},
	// 		{Prezzo: 35, Marca: "Artic", Modello: "Duos", Categoria: "dissipatore"},
	// 		{Prezzo: 30, Marca: "CoolerMaster", Modello: "CX300", Categoria: "alimentatore"},
	// 		{Prezzo: 50, Marca: "Samsung", Capienza: 500, Modello: "Evo 850", Categoria: "memoria"},
	// 		{Prezzo: 100, Marca: "Corsair", Capienza: 16, Modello: "Ballistix", Categoria: "ram"},
	// 	},
	// }
	// pc3 := preAssemblato{
	// 	Nome:   "pc3",
	// 	Prezzo: 402,
	// 	Componenti: [8]Componente{
	// 		{Prezzo: 150, Marca: "intel", Modello: "i5-2780", Categoria: "cpu"},
	// 		{Prezzo: 100, Marca: "Gigabyte", Modello: "Hi500", Categoria: "schedaMadre"},
	// 		{Prezzo: 350, Marca: "nvidia", Modello: "gtx 1660", Categoria: "schedaVideo"},
	// 		{Prezzo: 60, Marca: "CoolerMaster", Modello: "CS550", Categoria: "casepc"},
	// 		{Prezzo: 35, Marca: "Artic", Modello: "Duos", Categoria: "dissipatore"},
	// 		{Prezzo: 30, Marca: "CoolerMaster", Modello: "CX300", Categoria: "alimentatore"},
	// 		{Prezzo: 50, Marca: "Samsung", Capienza: 500, Modello: "Evo 850", Categoria: "memoria"},
	// 		{Prezzo: 100, Marca: "Corsair", Capienza: 16, Modello: "Ballistix", Categoria: "ram"},
	// 	},
	// }
	// pc4 := preAssemblato{
	// 	Nome:   "pc4",
	// 	Prezzo: 40,
	// 	Componenti: [8]Componente{
	// 		{Prezzo: 150, Marca: "intel", Modello: "i5-2780", Categoria: "cpu"},
	// 		{Prezzo: 100, Marca: "Gigabyte", Modello: "Hi500", Categoria: "schedaMadre"},
	// 		{Prezzo: 350, Marca: "nvidia", Modello: "gtx 1660", Categoria: "schedaVideo"},
	// 		{Prezzo: 60, Marca: "CoolerMaster", Modello: "CS550", Categoria: "casepc"},
	// 		{Prezzo: 35, Marca: "Artic", Modello: "Duos", Categoria: "dissipatore"},
	// 		{Prezzo: 30, Marca: "CoolerMaster", Modello: "CX300", Categoria: "alimentatore"},
	// 		{Prezzo: 50, Marca: "Samsung", Capienza: 500, Modello: "Evo 850", Categoria: "memoria"},
	// 		{Prezzo: 100, Marca: "Corsair", Capienza: 16, Modello: "Ballistix", Categoria: "ram"},
	// 	},
	// }
	coll := client.Database("apl_database").Collection("catalogo")
	rand.Seed(time.Now().UnixNano())
	categoria := [8]string{"cpu", "schedaMadre", "casepc", "schedaVideo", "dissipatore", "alimentatore", "ram", "memoria"}
	catalogo := make([]Componente, 32)
	min := 50
	max := 300
	marca := [8]string{"Samsung", "CoolerMaster", "intel", "nvidia", "Gigabyte", "Corsair", "Amd", "Truecolor"}
	modello := [8]string{"i5-2780", "gtx 1660", "Evo 850", "CS550", "CX300", "Hi500", "CX900", "Ballistix"}
	min_index := 0
	max_index := 7
	index := 0
	diff := max - min + 1
	diff1 := max_index - min_index + 1
	for i := 0; i < 8; i++ {
		for j := 0; j < 4; j++ {
			catalogo[index] = Componente{
				Prezzo:    float64(rand.Intn(diff) + min),
				Marca:     marca[i],
				Capienza:  rand.Intn(diff) + min,
				Img:       "",
				Modello:   modello[rand.Intn(diff1)+min_index],
				Categoria: categoria[rand.Intn(diff1)+min_index],
			}
			index++
		}
	}
	for _, comp := range catalogo {

		coll.InsertOne(context.TODO(), comp)
	}
	// coll.InsertOne(context.TODO(), pc1)
	// coll.InsertOne(context.TODO(), pc2)
	// coll.InsertOne(context.TODO(), pc3)
	// coll.InsertOne(context.TODO(), pc4)

}
