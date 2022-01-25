package utils

import (
	"log"
	"math"
	"net"
	"strconv"
)

func Send(msg []byte, conn net.Conn) {
	/*
		Quando viene mandato un messaggio i primi 16 byte
		contengono la dimensione del messaggio
	*/
	bytemsg := []byte(msg)
	len_msg := strconv.Itoa(len(bytemsg))
	byteslen_msg := []byte(len_msg)
	byteslen := make([]byte, 16)
	diff := len(byteslen) - len(byteslen_msg)
	for i := 0; i < len(byteslen_msg); i++ {
		byteslen[diff+i-1] = byteslen_msg[i]
	}
	// L'ultimo byte contiene un ritorno a capo
	byteslen[len(byteslen)-1] = 10 //10 = ritorno a capo
	log.Println("Send: ", byteslen)
	conn.Write(byteslen)
	conn.Write(bytemsg)
}

func Receive(conn net.Conn) []byte {
	/*
		In ricezione prima arriva la lunghezza del messaggio
		16 byte di cui l'ultimo carattere è un ritorno a capo
	*/
	byteslen := make([]byte, 16)
	conn.Read(byteslen)
	var len_msg int
	log.Println(byteslen)
	for i := 0; i < len(byteslen); i++ {
		exp := len(byteslen) - i - 2
		if byteslen[i] > 47 && byteslen[i] < 58 {
			value := int(byteslen[i]) - 48
			len_msg += value * int(math.Pow(10, float64(exp)))
		}
	}
	bytesmsg := make([]byte, len_msg)
	conn.Read(bytesmsg)
	if len(bytesmsg) < 512 {
		log.Println("Receive message: ", string(bytesmsg))
	}
	return bytesmsg
}
