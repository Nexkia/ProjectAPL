package main

import "fmt"

func getDetailType(detailType string) (interface{}, error) {

	switch detailType {
	case "cpu":
		return &CpuDetail{}, nil
	case "schedaVideo":
		return &SchedaVideoDetail{}, nil
	case "schedaMadre":
		return &SchedaMadreDetail{}, nil
	case "memoria":
		return &MemoriaDetail{}, nil
	case "alimentatore":
		return &AlimentatoreDetail{}, nil
	case "dissipatore":
		return &DissipatoreDetail{}, nil
	case "ram":
		return &RamDetail{}, nil
	case "casepc":
		return &CasePCDetail{}, nil

	default:
		return nil, fmt.Errorf("error")
	}
}
