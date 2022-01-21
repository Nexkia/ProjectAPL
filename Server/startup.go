package main

import (
	"Server/data"
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
)

const (
	min_price = 50
	max_price = 300
	min_val   = 1
	max_val   = 10
	min_ram   = 3
	max_ram   = 4
)

var flag_check bool

func invio(mongodb *mongo.Database) {

	coll_comp := mongodb.Collection("componenti")
	coll_detail := mongodb.Collection("detail")
	rand.Seed(time.Now().UnixNano())
	content, err := ioutil.ReadFile("database/case.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg := regexp.MustCompile(`(?m:(^\w*).(.*)\s(Midi-Tower|Micro-ATX|Big-Tower).-.*X.(0USD)?.(\d*.\d*)?)`)
	result := reg.FindAllStringSubmatch(string(content), -1)
	cspc := data.Componente{}
	cspc_detail := data.CasePCDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			cspc.Categoria = "casepc"
			cspc.Marca = strings.Title(strings.ToLower(elem[1]))
			cspc.Modello = modello
			if elem[5] != "" {
				cspc.Prezzo, _ = strconv.ParseFloat(elem[5], 64)
			} else {
				cspc.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			cspc_detail.Modello = modello
			cspc_detail.Taglia = elem[3]
			cspc_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), cspc)
			coll_detail.InsertOne(context.TODO(), cspc_detail)
		}
	}
	content, err = ioutil.ReadFile("database/cpu.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*).(.*).Socket.(\w*\+?).Clock.(\w?.\w?).\w{1,3}.(Turbo\s\w\.\w.\w*.)?(\d*).Cores.(\d*).Threads.USD.(\d*.\d{1,2}))`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	cpu := data.Componente{}
	cpu_detail := data.CpuDetail{}

	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			cpu.Categoria = "cpu"
			cpu.Marca = elem[1]
			cpu.Modello = modello
			if elem[8] != "" {
				cpu.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
			} else {
				cpu.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			cpu_detail.Modello = modello
			cpu_detail.Socket = elem[3]
			cpu_detail.Frequenza, _ = strconv.ParseFloat(elem[4], 64)
			cpu_detail.Core, _ = strconv.Atoi(elem[6])
			cpu_detail.Thread, _ = strconv.Atoi(elem[7])
			cpu_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), cpu)
			coll_detail.InsertOne(context.TODO(), cpu_detail)
		}
	}

	content, err = ioutil.ReadFile("database/gpu.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*).(.*)\s(GeForce |Radeon).*\s(\d*)(\sGB).(\d*)W.(USD.(\d*.\d*))?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	gpu := data.Componente{}
	gpu_detail := data.SchedaVideoDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			gpu.Categoria = "schedaVideo"
			gpu.Marca = elem[1]
			gpu.Modello = modello
			if elem[8] != "" {
				gpu.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
			} else {
				gpu.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			gpu_detail.Modello = modello
			gpu_detail.Vram, _ = strconv.Atoi(elem[4])
			gpu_detail.Tdp, _ = strconv.Atoi(elem[6])
			gpu_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), gpu)
			coll_detail.InsertOne(context.TODO(), gpu_detail)
		}
	}

	content, err = ioutil.ReadFile("database/psu.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*)\s(\w*\-?.*)\sATX.(\d*)W(.USD.)?(\d*.\d*)?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	psu := data.Componente{}
	psu_detail := data.AlimentatoreDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			psu.Categoria = "alimentatore"
			psu.Marca = elem[1]
			psu.Modello = modello
			if elem[5] != "" {
				psu.Prezzo, _ = strconv.ParseFloat(elem[5], 64)
			} else {
				psu.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			psu_detail.Modello = modello
			psu_detail.Watt, _ = strconv.Atoi(elem[3])
			psu_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), psu)
			coll_detail.InsertOne(context.TODO(), psu_detail)
		}
	}

	content, err = ioutil.ReadFile("database/ram.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*).(.*)\s(\d{1,2})\sGB.(DDR\d)-(\d*).*Kit.of.(1|2|4)(USD.)?(\d*.\d*)?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	ram := data.Componente{}
	ram_detail := data.RamDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			ram.Categoria = "ram"
			ram.Marca = elem[1]
			ram.Modello = modello
			ram.Capienza, _ = strconv.Atoi(elem[3])
			if elem[8] != "" {
				ram.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
			} else {
				ram.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			ram_detail.Modello = modello
			ram_detail.Standard = elem[4]
			ram_detail.Frequenza, _ = strconv.Atoi(elem[5])
			ram_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), ram)
			coll_detail.InsertOne(context.TODO(), ram_detail)
		}
	}

	content, err = ioutil.ReadFile("database/hdd.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*).(.*).(\d*).TB.\d{1,4}.*RPM(.*USD.)?(USD.)?(\d*.\d*)?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	hdd := data.Componente{}
	hdd_detail := data.MemoriaDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			hdd.Categoria = "memoria"
			hdd.Marca = elem[1]
			hdd.Modello = modello
			hdd.Capienza, _ = strconv.Atoi(elem[3])
			hdd.Capienza = hdd.Capienza * 1000
			if elem[6] != "" {
				hdd.Prezzo, _ = strconv.ParseFloat(elem[6], 64)
			} else {
				hdd.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			hdd_detail.Modello = modello
			hdd_detail.Tipo = "hdd"
			hdd_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), hdd)
			coll_detail.InsertOne(context.TODO(), hdd_detail)
		}
	}

	content, err = ioutil.ReadFile("database/ssd.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*).(.*)\s(\d{3,4})\sGB(\d{3,4}\sGB\s|\s)(NVM|SATA).Protocol.(M.2|SATA).(FormatUSD.)?(\d*.\d*.)?(Format)?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	ssd := data.Componente{}
	ssd_detail := data.MemoriaDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			ssd.Categoria = "memoria"
			ssd.Marca = elem[1]
			ssd.Modello = modello
			ssd.Capienza, _ = strconv.Atoi(elem[3])
			if elem[8] != "" {
				ssd.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
				if ssd.Prezzo == 0 {
					ssd.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
				}
			} else {
				ssd.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}

			ssd_detail.Modello = modello
			ssd_detail.Tipo = "ssd"
			ssd_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), ssd)
			coll_detail.InsertOne(context.TODO(), ssd_detail)
		}
	}

	content, err = ioutil.ReadFile("database/cpucooler.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*)\s(.*)For\ssocket\s(.*),\s(\w*\+?\-?(V3)?)\s(USD\s(\d*.\d*))?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	cpucooler := data.Componente{}
	cpucooler_detail := data.DissipatoreDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			cpucooler.Categoria = "dissipatore"
			cpucooler.Marca = elem[1]
			cpucooler.Modello = modello
			if elem[7] != "" {
				cpucooler.Prezzo, _ = strconv.ParseFloat(elem[7], 64)
			} else {
				cpucooler.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
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
			cpucooler_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), cpucooler)
			coll_detail.InsertOne(context.TODO(), cpucooler_detail)
		}
	}

	content, err = ioutil.ReadFile("database/motherboard.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*)\s(.*ATX).Socket.(\w*(\+)?(\-\w*)?).Chipset.(\w*).\d.Ramslots.(USD.)?(\d*.\d{1,2})?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	mb := data.Componente{}
	mb_detail := data.SchedaMadreDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = controlloModello(modello, coll_comp)
		if flag_check {
			mb.Categoria = "schedaMadre"
			mb.Marca = elem[1]
			mb.Modello = modello
			if elem[8] != "" {
				mb.Prezzo, _ = strconv.ParseFloat(elem[8], 64)
			} else {
				mb.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			mb_detail.Modello = modello
			mb_detail.CpuSocket = elem[3]
			mb_detail.Chipset = elem[6]
			ram_number := rand.Intn((max_ram-min_ram)+1) + min_ram
			mb_detail.Ram = "DDR" + strconv.Itoa(ram_number)
			mb_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			coll_comp.InsertOne(context.TODO(), mb)
			coll_detail.InsertOne(context.TODO(), mb_detail)
		}
	}

	/*
		Creazione PcPreassemblati

	*/
	//categorie := []string{"schedaMadre,cpu,ram,dissipatore,"}
	//filter := bson.D{{"$match", bson.D{{"categoria", "cpu"}}}, {"$sample", bson.D{{"size", 1}}}}

}

func controlloModello(modello string, coll *mongo.Collection) bool {
	filter := bson.D{{"modello", modello}}
	var result bson.D
	err := coll.FindOne(context.TODO(), filter).Decode(&result)
	return err != nil
}
