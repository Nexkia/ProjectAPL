package data

type Utente struct {
	Email      string `bson:"email" json:"email"`
	Indirizzo  string `bson:"indirizzo" json:"indirizzo"`
	NomeUtente string `bson:"nome" json:"nomeutente"`
	Password   string `bson:"password" json:"password"`
}

type CreditCard struct {
	Number int `bson:"number" json:"number"`
	Month  int `bson:"month" json:"month"`
	Year   int `bson:"year" json:"year"`
	Cvv    int `bson:"cvv" json:"cvv"`
}
type InfoPayment struct {
	Email                 string     `bson:"email" json:"email"`
	IndirizzoFatturazione string     `bson:"indirizzoFatturazione" json:"indirizzoFatturazione"`
	CreditCard            CreditCard `bson:"creditCard" json:"creditCard"`
}

type Vendita struct {
	Email    string      `bson:"email" json:"email"`
	Acquisto interface{} `bson:"acquisto" json:"acquisto"`
}
