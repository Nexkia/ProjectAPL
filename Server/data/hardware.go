package data

import "math"

type Componente struct {
	Prezzo    float64 `bson:"prezzo" json:"prezzo"`
	Marca     string  `bson:"marca" json:"marca"`
	Capienza  int     `bson:"capienza" json:"capienza"`
	Modello   string  `bson:"modello" json:"modello"`
	Categoria string  `bson:"categoria" json:"categoria"`
}

type PcAssemblato struct {
	Prezzo     float64       `bson:"prezzoTot" json:"prezzoTot"`
	Componenti [8]Componente `bson:"componenti" json:"componenti"`
}

type PcpreAssemblato struct {
	Nome       string        `bson:"nome" json:"nome"`
	Prezzo     float64       `bson:"prezzoTot" json:"prezzoTot"`
	Componenti [8]Componente `bson:"componenti" json:"componenti"`
}

func Round(num float64) int {
	return int(num + math.Copysign(0.5, num))
}

func (pc *PcAssemblato) PrezzoTot() {
	for _, comp := range (*pc).Componenti {
		(*pc).Prezzo += comp.Prezzo
	}
	output := math.Pow(10, float64(2))
	(*pc).Prezzo = float64(Round((*pc).Prezzo*output)) / output
}
