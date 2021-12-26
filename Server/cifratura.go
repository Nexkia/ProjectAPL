package main

import (
	"crypto/sha256"
	"encoding/base64"
	"fmt"
)

func Encoding(email string, password string) string {

	sha := sha256.New()
	sha.Write([]byte(email + password))
	hashPsw := string(sha.Sum(nil))
	fmt.Printf("Secret: Data: \n", email, password, hashPsw)
	// converto la stringa in base 64
	token := base64.StdEncoding.EncodeToString([]byte(hashPsw))
	fmt.Println("token: " + token)
	return token
}
