package main

func verificaCompatibilita(cp Cpu, sm SchedaMadre) bool {
	compatibilita := false
	for _, processore := range sm.CpuSocket {
		if processore == cp.Socket {
			compatibilita = true
			break
		}
	}
	return compatibilita
}

type preAssemblato struct {
	Nome       string        `bson:"nome" json:"nome"`
	Prezzo     float64       `bson:"prezzoTot" json:"prezzoTot"`
	Componenti [6]Componente `bson:"componenti" json:"componenti"`
	Ram        `bson:"ram" json:"ram"`
	Memoria    `bson:"memoria" json:"memoria"`
}

func (pc *PcAssemblato) prezzoTot() {
	for _, comp := range (*pc).Componenti {
		(*pc).Prezzo += comp.Prezzo
	}

}

type PcAssemblato struct {
	Prezzo     float64       `bson:"prezzoTot" json:"prezzoTot"`
	Componenti [8]Componente `bson:"componenti" json:"componenti"`
}

type Componente struct {
	Prezzo      float64 `bson:"prezzo" json:"prezzo"`
	Marca       string  `bson:"marca" json:"marca"`
	Img         string  `bson:"img" json:"img"`
	Valutazione int     `bson:"valutazione" json:"valutazione"`
	Modello     string  `bson:"modello" json:"modello"`
	Categoria   string  `bson:"categoria" json:"categoria"`
}

type Cpu struct {
	Componente `bson:"componente" json:"componente"`
	Tdp        int     `bson:"tdp" json:"tdp"`
	Frequenza  float64 `bson:"frequenza" json:"frequenza"`
	Socket     string  `bson:"socket" json:"socket"`
	Core       int     `bson:"core" json:"core"`
	Thread     int     `bson:"thread" json:"thread"`
}

type Ram struct {
	Componente `bson:"componente" json:"componente"`
	Frequenza  float64 `bson:"frequenza" json:"frequenza"`
	Capienza   int     `bson:"capienza" json:"capienza"`
	Standard   string  `bson:"standard" json:"standard"`
}

type SchedaMadre struct {
	Componente `bson:"componente" json:"componente"`
	CpuSocket  []string `bson:"cpusocket" json:"cpusocket"`
	Ram        []string `bson:"ram" json:"ram"`
	SsdM2      bool     `bson:"ssd" json:"ssd"`
}

type SchedaVideo struct {
	Componente `bson:"componente" json:"componente"`
	Tdp        int     `bson:"tdp" json:"tdp"`
	Frequenza  float64 `bson:"frequenza" json:"frequenza"`
	Vram       int     `bson:"vram" json:"vram"`
}

type Memoria struct {
	Componente `bson:"componente" json:"componente"`
	Dimensione int    `bson:"dimensione" json:"dimensione"`
	Tipo       string `bson:"tipo" json:"tipo"`
}

type Telaio struct {
	Componente `bson:"componente" json:"componente"`
	Taglia     string `bson:"taglia" json:"taglia"`
}

type Dissipatore struct {
	Componente `bson:"componente" json:"componente"`
	CpuSocket  []string `bson:"cpusocket" json:"cpusocket"`
}

type Alimentatore struct {
	Componente `bson:"componente" json:"componente"`
	Watt       int `bson:"watt" json:"watt"`
}
