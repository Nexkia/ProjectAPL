package main

import (
	"fmt"
	"net"
	"sync"
)

func getProfiles(conn net.Conn, wait *sync.WaitGroup) {

	fmt.Println("ciao")
	conn.Write([]byte("ok"))
	response := make([]byte, 8000)
	conn.Read(response)
	fmt.Println(string(response))
	wait.Done()
}

func getImages(conn net.Conn, wait *sync.WaitGroup, img [3]Img) {
	conn.Write([]byte("ok"))
	rWlock.Lock()
	for i := 0; i < 3; i++ {
		byte_img := make([]byte, 7840000)
		conn.Read(byte_img)
		img[i].Img = byte_img
		conn.Write([]byte("ok"))
		print(i)
	}
	rWlock.Unlock()
	wait.Done()
}
