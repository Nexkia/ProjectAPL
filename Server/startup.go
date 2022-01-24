package main

import (
	"Server/data"
	"Server/utils"
	"fmt"
	"io/ioutil"
	"math/rand"
	"regexp"
	"strconv"
	"strings"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

const (
	// PREZZO
	min_price = 50
	max_price = 300
	// VALUTAZIONE
	min_val = 1
	max_val = 10
	// DDR3-DDR4
	min_ram = 3
	max_ram = 4
)

var flag_check bool

func invio(mongodb *mongo.Database) {
	//rand.Seed(time.Now().UnixNano())
	rand.Seed(800)
	// GENERAZIONE CASEPC
	content, err := ioutil.ReadFile("database/case.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg := regexp.MustCompile(`(?m:(^\w*).(.*)\s(Midi-Tower|Micro-ATX|Big-Tower).-.*X.(0USD)?\s?(\d*.\d*)?)`)
	result := reg.FindAllStringSubmatch(string(content), -1)
	cspc := data.Componente{}
	cspc_detail := data.CasePCDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			cspc.Categoria = "casepc"
			cspc.Marca = strings.Title(strings.ToLower(elem[1]))
			cspc.Modello = modello
			if elem[5] != "0 " {
				cspc.Prezzo, _ = strconv.ParseFloat(elem[5], 64)
			} else {
				cspc.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			cspc_detail.Modello = modello
			cspc_detail.Taglia = elem[3]
			cspc_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			utils.InsertOne("componenti", mongodb, cspc)
			utils.InsertOne("detail", mongodb, cspc_detail)
		}
	}
	// GENERAZIONE CPU
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
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			cpu.Categoria = "cpu"
			cpu.Marca = strings.Title(strings.ToLower(elem[1]))
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
			utils.InsertOne("componenti", mongodb, cpu)
			utils.InsertOne("detail", mongodb, cpu_detail)
		}
	}
	// GENERAZIONE GPU
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
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			gpu.Categoria = "schedaVideo"
			gpu.Marca = strings.Title(strings.ToLower(elem[1]))
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
			utils.InsertOne("componenti", mongodb, gpu)
			utils.InsertOne("detail", mongodb, gpu_detail)
		}
	}
	// GENERAZIONE PSU
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
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			psu.Categoria = "alimentatore"
			psu.Marca = strings.Title(strings.ToLower(elem[1]))
			psu.Modello = modello
			if elem[5] != " " {
				psu.Prezzo, _ = strconv.ParseFloat(elem[5], 64)
			} else {
				psu.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			psu_detail.Modello = modello
			psu_detail.Watt, _ = strconv.Atoi(elem[3])
			psu_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			utils.InsertOne("componenti", mongodb, psu)
			utils.InsertOne("detail", mongodb, psu_detail)
		}
	}
	// GENERAZIONE RAM
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
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			ram.Categoria = "ram"
			ram.Marca = strings.Title(strings.ToLower(elem[1]))
			ram.Modello = modello
			ram.Capienza, _ = strconv.Atoi(elem[3])
			elem_price, _ := strconv.ParseFloat(elem[8], 64)
			if elem_price > 0 {
				ram.Prezzo = elem_price
			} else {
				ram.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			ram_detail.Modello = modello
			ram_detail.Standard = elem[4]
			ram_detail.Frequenza, _ = strconv.Atoi(elem[5])
			ram_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			utils.InsertOne("componenti", mongodb, ram)
			utils.InsertOne("detail", mongodb, ram_detail)
		}
	}
	// GENERAZIONE HDD
	content, err = ioutil.ReadFile("database/hdd.txt")
	if err != nil {
		fmt.Println("err")
	}
	reg = regexp.MustCompile(`(?m:(^\w*).(.*).(\d).TB.\d{1,4}.*RPM(.*USD.)?(USD.)?(\d*.\d*)?)`)
	result = reg.FindAllStringSubmatch(string(content), -1)
	hdd := data.Componente{}
	hdd_detail := data.MemoriaDetail{}
	for _, elem := range result {
		modello := strings.TrimSuffix(elem[2], " ")
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			hdd.Categoria = "memoria"
			hdd.Marca = strings.Title(strings.ToLower(elem[1]))
			hdd.Modello = modello
			hdd.Capienza, _ = strconv.Atoi(elem[3])
			hdd.Capienza = hdd.Capienza * 1000
			if elem[6] != " " {
				hdd.Prezzo, _ = strconv.ParseFloat(elem[6], 64)
			} else {
				hdd.Prezzo = float64(rand.Intn((max_price-min_price)+1) + min_price)
			}
			hdd_detail.Modello = modello
			hdd_detail.Tipo = "hdd"
			hdd_detail.Valutazione = rand.Intn((max_val-min_val)+1) + min_val
			utils.InsertOne("componenti", mongodb, hdd)
			utils.InsertOne("detail", mongodb, hdd_detail)
		}
	}
	// GENERAZIONE SSD
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
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			ssd.Categoria = "memoria"
			ssd.Marca = strings.Title(strings.ToLower(elem[1]))
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
			utils.InsertOne("componenti", mongodb, ssd)
			utils.InsertOne("detail", mongodb, ssd_detail)
		}
	}
	// GENERAZIONE COOLER
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
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			cpucooler.Categoria = "dissipatore"
			cpucooler.Marca = strings.Title(strings.ToLower(elem[1]))
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
			utils.InsertOne("componenti", mongodb, cpucooler)
			utils.InsertOne("detail", mongodb, cpucooler_detail)
		}
	}
	// GENERAZIONE MOTHERBOARD
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
		flag_check = ControlloModello(modello, mongodb)
		if flag_check {
			mb.Categoria = "schedaMadre"
			mb.Marca = strings.Title(strings.ToLower(elem[1]))
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
			utils.InsertOne("componenti", mongodb, mb)
			utils.InsertOne("detail", mongodb, mb_detail)
		}
	}
	/*
		Generazione dei pc Preassemblati, 4 categorie richiedono la compatibilità mentre altre 4

	*/
	categorie := []string{"schedaVideo", "casepc", "alimentatore", "memoria"}
	n_pre := 30
	min_price_pre := 1000
	max_price_pre := 5000
	for i := 0; i < n_pre; i++ {
		pre := data.PcpreAssemblato{}
		comp := data.Componente{}
		filter_comp := bson.D{{Key: "$match", Value: bson.D{{Key: "categoria", Value: "schedaMadre"}}}}
		filter_sample := bson.D{{Key: "$sample", Value: bson.D{{Key: "size", Value: 1}}}}
		pipe := mongo.Pipeline{filter_comp, filter_sample}
		res := utils.Aggregate("componenti", mongodb, pipe)
		BsonUnmarshaling(res[0], &comp)
		pre.Componenti[1] = comp
		/* Dai detail della schedaMadre ottengo tutte le caratterische per
		i successivi componenti compatibili
		*/
		mb_ := data.SchedaMadreDetail{}
		filter := bson.D{{Key: "modello_" + "schedaMadre", Value: comp.Modello}}
		utils.FindOne(filter, "detail", mongodb).Decode(&mb_)
		/// CPU
		filter_comp = bson.D{{Key: "$match", Value: bson.D{{Key: "socket", Value: mb_.CpuSocket}}}}
		pipe = mongo.Pipeline{filter_comp, filter_sample}
		cpu_ := data.CpuDetail{}
		res = utils.Aggregate("detail", mongodb, pipe)
		BsonUnmarshaling(res[0], &cpu_)
		filter = bson.D{{Key: "modello", Value: cpu_.Modello}}
		comp = data.Componente{}
		utils.FindOne(filter, "componenti", mongodb).Decode(&comp)
		pre.Componenti[0] = comp
		// RAM
		filter_comp = bson.D{{Key: "$match", Value: bson.D{{Key: "standard", Value: mb_.Ram}}}}
		pipe = mongo.Pipeline{filter_comp, filter_sample}
		ram_ := data.RamDetail{}
		res = utils.Aggregate("detail", mongodb, pipe)
		BsonUnmarshaling(res[0], &ram_)
		filter = bson.D{{Key: "modello", Value: ram_.Modello}}
		comp = data.Componente{}
		utils.FindOne(filter, "componenti", mongodb).Decode(&comp)
		pre.Componenti[7] = comp
		// DISSIPATORE
		filter_comp = bson.D{{Key: "$match", Value: bson.D{{Key: "cpusocket", Value: mb_.CpuSocket}}}}
		filter_cooler := bson.D{{Key: "$group", Value: bson.D{{Key: "_id",
			Value: "$modello_dissipatore"}, {Key: "cpusocket", Value: bson.D{{Key: "$first", Value: "$cpusocket"}}}}}}
		pipe = mongo.Pipeline{filter_cooler, filter_comp, filter_sample}
		res = utils.Aggregate("detail", mongodb, pipe)
		filter = bson.D{{Key: "modello", Value: res[0]["_id"]}}
		comp = data.Componente{}
		utils.FindOne(filter, "componenti", mongodb).Decode(&comp)
		pre.Componenti[4] = comp
		/// Componenti che non richiedono compatibilità
		for _, categoria := range categorie {
			comp = data.Componente{}
			filter_comp = bson.D{{Key: "$match", Value: bson.D{{Key: "categoria", Value: categoria}}}}
			pipe = mongo.Pipeline{filter_comp, filter_sample}
			res = utils.Aggregate("componenti", mongodb, pipe)
			BsonUnmarshaling(res[0], &comp)
			switch categoria {
			case "schedaVideo":
				pre.Componenti[2] = comp
			case "casepc":
				pre.Componenti[3] = comp
			case "alimentatore":
				pre.Componenti[5] = comp
			case "memoria":
				pre.Componenti[6] = comp
			}
		}
		pre.Nome = "pre_" + strconv.Itoa(i)
		pre.Prezzo = float64(rand.Intn((max_price_pre-min_price_pre)+1) + min_price_pre)
		flag_check = ControlloNome(pre.Nome, mongodb)
		if flag_check {
			utils.InsertOne("preAssemblati", mongodb, pre)
		}
	}
}

func ControlloModello(modello string, mongodb *mongo.Database) bool {
	filter := bson.D{{Key: "modello", Value: modello}}
	var result bson.D
	err := utils.FindOne(filter, "componenti", mongodb).Decode(&result)
	return err != nil
}

func BsonUnmarshaling(in interface{}, out interface{}) interface{} {
	in_byte, _ := bson.Marshal(in)
	bson.Unmarshal(in_byte, out)
	return out
}

func ControlloNome(nome string, mongodb *mongo.Database) bool {
	filter := bson.D{{Key: "nome", Value: nome}}
	var result bson.D
	err := utils.FindOne(filter, "preAssemblati", mongodb).Decode(&result)
	return err != nil
}
