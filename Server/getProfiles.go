package main

import (
	"fmt"
	"net"
	"sync"
)

func getProfiles(conn net.Conn, wait *sync.WaitGroup) {

	fmt.Println("ciao")
	conn.Write([]byte("ok"))
	response := make([]byte, 1024)
	conn.Read(response)
	fmt.Println(string(response))
	wait.Done()
}
