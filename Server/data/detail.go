package data

type CpuDetail struct {
	Modello     string  `bson:"modello_cpu" json:"modello_cpu"`
	Valutazione int     `bson:"valutazione" json:"valutazione"`
	Frequenza   float64 `bson:"frequenza" json:"frequenza"`
	Socket      string  `bson:"socket" json:"socket"`
	Core        int     `bson:"core" json:"core"`
	Thread      int     `bson:"thread" json:"thread"`
}

type RamDetail struct {
	Modello     string `bson:"modello_ram" json:"modello_ram"`
	Valutazione int    `bson:"valutazione" json:"valutazione"`
	Standard    string `bson:"standard" json:"standard"`
	Frequenza   int    `bson:"frequenza" json:"frequenza"`
}

type SchedaMadreDetail struct {
	Modello     string `bson:"modello_schedaMadre" json:"modello_schedaMadre"`
	Valutazione int    `bson:"valutazione" json:"valutazione"`
	CpuSocket   string `bson:"cpusocket" json:"cpusocket"`
	Chipset     string `bson:"chipset" json:"chipset"`
	Ram         string `bson:"ram" json:"ram"`
}

type SchedaVideoDetail struct {
	Modello     string `bson:"modello_schedaVideo" json:"modello_schedaVideo"`
	Valutazione int    `bson:"valutazione" json:"valutazione"`
	Tdp         int    `bson:"tdp" json:"tdp"`
	Vram        int    `bson:"vram" json:"vram"`
}

type MemoriaDetail struct {
	Modello     string `bson:"modello_memoria" json:"modello_memoria"`
	Valutazione int    `bson:"valutazione" json:"valutazione"`
	Tipo        string `bson:"tipo" json:"tipo"`
}

type CasePCDetail struct {
	Modello     string `bson:"modello_casepc" json:"modello_casepc"`
	Valutazione int    `bson:"valutazione" json:"valutazione"`
	Taglia      string `bson:"taglia" json:"taglia"`
}

type DissipatoreDetail struct {
	Modello     string   `bson:"modello_dissipatore" json:"modello_dissipatore"`
	Valutazione int      `bson:"valutazione" json:"valutazione"`
	CpuSocket   []string `bson:"cpusocket" json:"cpusocket"`
}

type AlimentatoreDetail struct {
	Modello     string `bson:"modello_alimentatore" json:"modello_alimentatore"`
	Valutazione int    `bson:"valutazione" json:"valutazione"`
	Watt        int    `bson:"watt" json:"watt"`
}
