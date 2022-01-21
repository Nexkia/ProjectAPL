package data

func GetDetailType(detailType string) interface{} {

	switch detailType {
	case "cpu":
		return &CpuDetail{}
	case "schedaVideo":
		return &SchedaVideoDetail{}
	case "schedaMadre":
		return &SchedaMadreDetail{}
	case "memoria":
		return &MemoriaDetail{}
	case "alimentatore":
		return &AlimentatoreDetail{}
	case "dissipatore":
		return &DissipatoreDetail{}
	case "ram":
		return &RamDetail{}
	case "casepc":
		return &CasePCDetail{}

	default:
		return nil
	}
}
