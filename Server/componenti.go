package main

//func verificaCompatibilita(cp Cpu, sm SchedaMadre) bool {
//	compatibilita := false
//	for _, processore := range sm.CpuSocket {
//		if processore == cp.Socket {
//			compatibilita = true
//			break
//		}
//	}
//	return compatibilita
//}

type preAssemblato struct {
	Nome       string        `bson:"nome" json:"nome"`
	Prezzo     float64       `bson:"prezzoTot" json:"prezzoTot"`
	Componenti [8]Componente `bson:"componenti" json:"componenti"`
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
	Prezzo    float64 `bson:"prezzo" json:"prezzo"`
	Marca     string  `bson:"marca" json:"marca"`
	Capienza  int     `bson:"capienza" json:"capienza"`
	Img       string  `bson:"img" json:"img"`
	Modello   string  `bson:"modello" json:"modello"`
	Categoria string  `bson:"categoria" json:"categoria"`
}

type CpuDetail struct {
	Componente  `bson:"cpu" json:"cpu"`
	Valutazione int     `bson:"valutazione" json:"valutazione"`
	Tdp         int     `bson:"tdp" json:"tdp"`
	Frequenza   float64 `bson:"frequenza" json:"frequenza"`
	Socket      string  `bson:"socket" json:"socket"`
	Core        int     `bson:"core" json:"core"`
	Thread      int     `bson:"thread" json:"thread"`
}

type RamDetail struct {
	Componente  `bson:"ram" json:"ram"`
	Valutazione int     `bson:"valutazione" json:"valutazione"`
	Standard    string  `bson:"standard" json:"standard"`
	Frequenza   float64 `bson:"frequenza" json:"frequenza"`
}

type SchedaMadreDetail struct {
	Componente  `bson:"schdamadre" json:"schedamadre"`
	Valutazione int      `bson:"valutazione" json:"valutazione"`
	CpuSocket   []string `bson:"cpusocket" json:"cpusocket"`
	Ram         []string `bson:"ram" json:"ram"`
	SsdM2       bool     `bson:"ssd" json:"ssd"`
}

type SchedaVideoDetail struct {
	Componente  `bson:"schedavideo" json:"schedavideo"`
	Valutazione int     `bson:"valutazione" json:"valutazione"`
	Tdp         int     `bson:"tdp" json:"tdp"`
	Frequenza   float64 `bson:"frequenza" json:"frequenza"`
	Vram        int     `bson:"vram" json:"vram"`
}

type MemoriaDetail struct {
	Componente  `bson:"memoria" json:"memoria"`
	Valutazione int    `bson:"valutazione" json:"valutazione"`
	Tipo        string `bson:"tipo" json:"tipo"`
}

type CasePCDetail struct {
	Componente  `bson:"casepc" json:"casepc"`
	Valutazione int    `bson:"valutazione" json:"valutazione"`
	Taglia      string `bson:"taglia" json:"taglia"`
}

type DissipatoreDetail struct {
	Componente  `bson:"dissipatore" json:"dissipatore"`
	Valutazione int      `bson:"valutazione" json:"valutazione"`
	CpuSocket   []string `bson:"cpusocket" json:"cpusocket"`
}

type AlimentatoreDetail struct {
	Componente  `bson:"alimentatore" json:"alimentatore"`
	Valutazione int `bson:"valutazione" json:"valutazione"`
	Watt        int `bson:"watt" json:"watt"`
}
