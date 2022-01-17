package main

import (
	"bufio"
	"context"
	"fmt"
	"net"
	"strings"
	"sync"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/mongo"
)

func getProfiles(conn net.Conn, wait *sync.WaitGroup, mongodb *mongo.Database, profiles *[5][8][3]Componente, name *[3]string) {

	fmt.Println("ciao")
	conn.Write([]byte("ok"))
	coll := mongodb.Collection("componenti")
	for i := 0; i < 5; i++ {
		for j := 0; j < 8; j++ {
			for k := 0; k < 3; k++ {
				response, _ := bufio.NewReader(conn).ReadString('\n')
				conn.Write([]byte("ok"))
				modello := strings.Trim(string(response), "\n")
				filter := bson.D{{"modello", modello}}
				coll.FindOne(context.TODO(), filter).Decode(&profiles[i][j][k])
			}
		}
	}
	for i := 0; i < 3; i++ {
		conn.Write([]byte("ok"))
		name_pc, _ := bufio.NewReader(conn).ReadString('\n')
		name_pc = strings.Trim(name_pc, "\n")
		name[i] = name_pc
		print(name[i])
	}
	//fmt.Println(profiles)
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
