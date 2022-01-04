package main

import (
	"context"
	"fmt"
	"io/ioutil"
	"math/rand"
	"regexp"
	"strconv"
	"strings"
	"time"

	"go.mongodb.org/mongo-driver/bson"
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
	coll_comp := client.Database("apl_database").Collection("componenti")
	coll_detail := client.Database("apl_database").Collection("detail")
	rand.Seed(time.Now().UnixNano())
	min_price := 50
	max_price := 300
	min_val := 1
	max_val := 10
	min_ram := 3
	max_ram := 4
	limit := 80
	n_send := 0
	content, err := ioutil.ReadFile("db/case.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg := regexp.MustCompile(`(?m:(^\w{1,}).(.{1,})\s(Midi-Tower|Micro-ATX|Big-Tower).-.{1,}X.(0USD)?.(\d{1,}.\d{1,})?)`)
	result := reg.FindAllStringSubmatch(string(content), -1)
	cspc := Componente{}
	cspc_detail := CasePCDetail{}
	var flag_check bool
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit {
				n_send++
				cspc.Categoria = "casepc"
				cspc.Marca = elem[1]
				cspc.Modello = modello
				if elem[5] != "" {
					cspc.Prezzo, _ = strconv.ParseFloat(elem[5], 64)
				} else {
					cspc.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				cspc_detail.Modello = modello
				cspc_detail.Taglia = elem[3]
				cspc_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), cspc)
				coll_detail.InsertOne(context.TODO(), cspc_detail)
			}
		}
	}
	content, err = ioutil.ReadFile("db/cpu.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w{1,}).(.{1,}).Socket.(\w{1,}\+?).Clock.(\w?.\w?).\w{1,3}.(Turbo\s\w\.\w.\w{1,}.)?(\d{1,}).Cores.(\d{1,}).Threads.USD.(\d{1,}.\d{1,2}))`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	cpu := Componente{}
	cpu_detail := CpuDetail{}

	n_send = 0
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit {
				n_send++
				cpu.Categoria = "cpu"
				cpu.Marca = elem[1]
				cpu.Modello = modello
				if elem[8] != "" {
					cpu.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
				} else {
					cpu.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				cpu_detail.Modello = modello
				cpu_detail.Socket = elem[3]
				cpu_detail.Frequenza, _ = strconv.ParseFloat(elem[4], 64)
				cpu_detail.Core, _ = strconv.Atoi(elem[6])
				cpu_detail.Thread, _ = strconv.Atoi(elem[7])
				cpu_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), cpu)
				coll_detail.InsertOne(context.TODO(), cpu_detail)
			}
		}
	}

	n_send = 0
	content, err = ioutil.ReadFile("db/gpu.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w{1,}).(.{1,})\s(GeForce |Radeon).{1,}(\d{1,})(\sGB).(\d{1,})W.(USD.(\d{1,}.\d{1,}))?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	gpu := Componente{}
	gpu_detail := SchedaVideoDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit {
				n_send++
				gpu.Categoria = "schedaVideo"
				gpu.Marca = elem[1]
				gpu.Modello = modello
				if elem[8] != "" {
					gpu.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
				} else {
					gpu.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				gpu_detail.Modello = modello
				gpu_detail.Vram, _ = strconv.Atoi(elem[4])
				gpu_detail.Tdp, _ = strconv.Atoi(elem[6])
				gpu_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), gpu)
				coll_detail.InsertOne(context.TODO(), gpu_detail)
			}
		}
	}

	n_send = 0
	content, err = ioutil.ReadFile("db/psu.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w{1,})\s(\w{1,}\-?.{1,})\sATX.(\d{1,})W(.USD.)?(\d{1,}.\d{1,})?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	psu := Componente{}
	psu_detail := AlimentatoreDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit {
				n_send++
				psu.Categoria = "alimentatore"
				psu.Marca = elem[1]
				psu.Modello = modello
				if elem[5] != "" {
					psu.Prezzo, _ = strconv.ParseFloat(elem[5], 64)
				} else {
					psu.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				psu_detail.Modello = modello
				psu_detail.Watt, _ = strconv.Atoi(elem[3])
				psu_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), psu)
				coll_detail.InsertOne(context.TODO(), psu_detail)
			}
		}
	}

	n_send = 0
	content, err = ioutil.ReadFile("db/ram.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w{1,}).(.{1,}).\s(\d{1,2})\sGB.(DDR\d)-(\d{1,}).{1,}Kit.of.(1|2|4)(USD.)?(\d{1,}.\d{1,})?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	ram := Componente{}
	ram_detail := RamDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit {
				n_send++
				ram.Categoria = "ram"
				ram.Marca = elem[1]
				ram.Modello = modello
				ram.Capienza, _ = strconv.Atoi(elem[3])
				if elem[8] != "" {
					ram.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
				} else {
					ram.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				ram_detail.Modello = modello
				ram_detail.Standard = elem[5]
				ram_detail.Frequenza, _ = strconv.Atoi(elem[6])
				ram_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), ram)
				coll_detail.InsertOne(context.TODO(), ram_detail)
			}
		}
	}

	n_send = 0
	content, err = ioutil.ReadFile("db/hdd.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w{1,}).(.{1,}).(\d{1,}).TB.\d{1,4}.{1,}RPM(.{1,}USD.)?(USD.)?(\d{1,}.\d{1,})?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	hdd := Componente{}
	hdd_detail := MemoriaDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit/2 {
				n_send++
				hdd.Categoria = "memoria"
				hdd.Marca = elem[1]
				hdd.Modello = modello
				hdd.Capienza, _ = strconv.Atoi(elem[3])
				hdd.Capienza = hdd.Capienza * 1000
				if elem[6] != "" {
					ram.Prezzo, _ = strconv.ParseFloat(elem[6], 64)
				} else {
					ram.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				hdd_detail.Modello = modello
				hdd_detail.Tipo = "hdd"
				hdd_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), hdd)
				coll_detail.InsertOne(context.TODO(), hdd_detail)
			}
		}
	}

	n_send = 0
	content, err = ioutil.ReadFile("db/ssd.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w{1,}).(.{1,})\s(\d{3,4})\sGB(\d{3,4}\sGB\s|\s)(NVM|SATA).Protocol.(M.2|SATA).(FormatUSD.)?(\d{1,}.\d{1,}.)?(Format)?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	ssd := Componente{}
	ssd_detail := MemoriaDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit/2 {
				n_send++
				ssd.Categoria = "memoria"
				ssd.Marca = elem[1]
				ssd.Modello = modello
				ssd.Capienza, _ = strconv.Atoi(elem[3])
				if elem[8] != "" {
					ram.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
				} else {
					ram.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				ssd_detail.Modello = modello
				ssd_detail.Tipo = "ssd"
				ssd_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), ssd)
				coll_detail.InsertOne(context.TODO(), ssd_detail)
			}
		}
	}

	n_send = 0
	content, err = ioutil.ReadFile("db/cpucooler.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w{1,})\s(.{1,})For\ssocket\s(.{1,}),\s(\w{1,}\+?\-?(V3)?)\s(USD\s(\d{1,}.\d{1,}))?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	cpucooler := Componente{}
	cpucooler_detail := DissipatoreDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit {
				n_send++
				cpucooler.Categoria = "dissipatore"
				cpucooler.Marca = elem[1]
				cpucooler.Modello = modello
				if elem[7] != "" {
					cpucooler.Prezzo, _ = strconv.ParseFloat(elem[7], 64)
				} else {
					cpucooler.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				cpucooler_detail.Modello = modello
				listSocket := strings.Split(elem[3], ", ")
				listSocketL := make([]string, len(listSocket)+1)
				for i := 0; i < len(listSocketL); i++ {
					if i < len(listSocket) {
						listSocketL[i] = listSocket[i]
					} else {
						listSocketL[i] = elem[4]
					}
				}
				cpucooler_detail.CpuSocket = listSocketL
				cpucooler_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), cpucooler)
				coll_detail.InsertOne(context.TODO(), cpucooler_detail)
			}
		}
	}

	n_send = 0
	content, err = ioutil.ReadFile("db/motherboard.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w{1,})\s(.{1,}ATX).Socket.(\w{1,}(\+)?(\-\w{1,})?).Chipset.(\w{1,}).\d.Ramslots.(USD.)?(\d{1,}.\d{1,2})?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	mb := Componente{}
	mb_detail := SchedaMadreDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			if n_send < limit {
				n_send++
				mb.Categoria = "schedaMadre"
				mb.Marca = elem[1]
				mb.Modello = modello
				if elem[8] != "" {
					mb.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
				} else {
					mb.Prezzo = float64(rand.Intn((max_price - min_price)) + min_price)
				}
				mb_detail.Modello = modello
				mb_detail.CpuSocket = elem[3]
				mb_detail.Chipset = elem[6]
				ram_number := rand.Intn((max_ram - min_ram)) + min_ram
				mb_detail.Ram = "DDR" + strconv.Itoa(ram_number)
				mb_detail.Valutazione = rand.Intn((max_val - min_val)) + min_val
				coll_comp.InsertOne(context.TODO(), mb)
				coll_detail.InsertOne(context.TODO(), mb_detail)
			}
		}
	}
}

func controlloModello(modello string, coll *mongo.Collection) bool {
	filter := bson.D{{"modello", "" + modello + ""}}
	var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)
	return err != nil
}
