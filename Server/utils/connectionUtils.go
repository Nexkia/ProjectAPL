package utils

import (
	"log"
	"math"
	"net"
	"strconv"
)

func Send(msg []byte, conn net.Conn) {
	bytemsg := []byte(msg)
	len_msg := strconv.Itoa(len(bytemsg))
	byteslen_msg := []byte(len_msg)
	byteslen := make([]byte, 16)
	diff := len(byteslen) - len(byteslen_msg)
	for i := 0; i < len(byteslen_msg); i++ {
		byteslen[diff+i-1] = byteslen_msg[i]
	}
	byteslen[len(byteslen)-1] = 10 //10 = ritorno a capo
	log.Println("Send: ", byteslen)
	if len(byteslen) < 100 {
		log.Println("SendMsg: ", string(msg))
	}
	conn.Write(byteslen)
	conn.Write(bytemsg)
}

func Receive(conn net.Conn) []byte {
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
	if len(bytesmsg) < 20000 {
		log.Println("Receive message: ", string(bytesmsg))
	}
	return bytesmsg
}
