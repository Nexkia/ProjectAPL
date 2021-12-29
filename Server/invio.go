package main

import (
	"context"
	"math/rand"
	"strconv"
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
	// //modello := [8]string{"i5-2780", "gtx 1660", "Evo 850", "CS550", "CX300", "Hi500", "CX900", "Ballistix"}
	index := 0
	diff := max - min + 1
	for i := 0; i < 8; i++ {
		for j := 0; j < 4; j++ {
			catalogo[index] = Componente{
				Prezzo:    float64(rand.Intn(diff) + min),
				Marca:     marca[i],
				Capienza:  rand.Intn(diff) + min,
				Img:       "",
				Modello:   strconv.Itoa(index),
				Categoria: categoria[i],
			}
			index++
		}
	}
	for _, comp := range catalogo {
		coll.InsertOne(context.TODO(), comp)
	}
	coll = client.Database("apl_database").Collection("detail")

	cpu1 := CpuDetail{Modello: "0"}
	cpu2 := CpuDetail{Modello: "1"}
	cpu3 := CpuDetail{Modello: "2"}
	cpu4 := CpuDetail{Modello: "3"}
	smb1 := SchedaMadreDetail{Modello: "4"}
	smb2 := SchedaMadreDetail{Modello: "5"}
	smb3 := SchedaMadreDetail{Modello: "6"}
	smb4 := SchedaMadreDetail{Modello: "7"}
	casepc1 := CasePCDetail{Modello: "8"}
	casepc2 := CasePCDetail{Modello: "9"}
	casepc3 := CasePCDetail{Modello: "10"}
	casepc4 := CasePCDetail{Modello: "11"}
	svd1 := SchedaVideoDetail{Modello: "12"}
	svd2 := SchedaVideoDetail{Modello: "13"}
	svd3 := SchedaVideoDetail{Modello: "14"}
	svd4 := SchedaVideoDetail{Modello: "15"}
	diss1 := DissipatoreDetail{Modello: "16"}
	diss2 := DissipatoreDetail{Modello: "17"}
	diss3 := DissipatoreDetail{Modello: "18"}
	diss4 := DissipatoreDetail{Modello: "19"}
	ali1 := AlimentatoreDetail{Modello: "20"}
	ali2 := AlimentatoreDetail{Modello: "21"}
	ali3 := AlimentatoreDetail{Modello: "22"}
	ali4 := AlimentatoreDetail{Modello: "23"}
	ram1 := RamDetail{Modello: "24"}
	ram2 := RamDetail{Modello: "25"}
	ram3 := RamDetail{Modello: "26"}
	ram4 := RamDetail{Modello: "27"}
	mem1 := MemoriaDetail{Modello: "28"}
	mem2 := MemoriaDetail{Modello: "29"}
	mem3 := MemoriaDetail{Modello: "30"}
	mem4 := MemoriaDetail{Modello: "31"}

	coll.InsertOne(context.TODO(), cpu1)
	coll.InsertOne(context.TODO(), cpu2)
	coll.InsertOne(context.TODO(), cpu3)
	coll.InsertOne(context.TODO(), cpu4)
	coll.InsertOne(context.TODO(), smb1)
	coll.InsertOne(context.TODO(), smb2)
	coll.InsertOne(context.TODO(), smb3)
	coll.InsertOne(context.TODO(), smb4)
	coll.InsertOne(context.TODO(), casepc1)
	coll.InsertOne(context.TODO(), casepc2)
	coll.InsertOne(context.TODO(), casepc3)
	coll.InsertOne(context.TODO(), casepc4)
	coll.InsertOne(context.TODO(), svd1)
	coll.InsertOne(context.TODO(), svd2)
	coll.InsertOne(context.TODO(), svd3)
	coll.InsertOne(context.TODO(), svd4)
	coll.InsertOne(context.TODO(), diss1)
	coll.InsertOne(context.TODO(), diss2)
	coll.InsertOne(context.TODO(), diss3)
	coll.InsertOne(context.TODO(), diss4)
	coll.InsertOne(context.TODO(), ali1)
	coll.InsertOne(context.TODO(), ali2)
	coll.InsertOne(context.TODO(), ali3)
	coll.InsertOne(context.TODO(), ali4)
	coll.InsertOne(context.TODO(), ram1)
	coll.InsertOne(context.TODO(), ram2)
	coll.InsertOne(context.TODO(), ram3)
	coll.InsertOne(context.TODO(), ram4)
	coll.InsertOne(context.TODO(), mem1)
	coll.InsertOne(context.TODO(), mem2)
	coll.InsertOne(context.TODO(), mem3)
	coll.InsertOne(context.TODO(), mem4)

}
