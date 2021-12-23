package main

import (
	"encoding/base64"
	"fmt"
	"log"

	"github.com/odysseus/vigenere"
)

const chiave = "mysecret"

func Encoding(data string) string {

	fmt.Printf("Secret: %s Data: %s\n", chiave, data)

	//cifrazione del testo, con il cifrario di Cipher
	testoCifrato := vigenere.Encipher(data, chiave)

	// converto la stringa in base 64
	token := base64.StdEncoding.EncodeToString([]byte(testoCifrato))

	fmt.Println("token: " + token)
	return token
}

func Decoding(data string) string {
	token, err := base64.StdEncoding.DecodeString(data)

	if err != nil {
		log.Fatal(err)
	}
	testoDecifrato := vigenere.Decipher(string(token), chiave)

	return testoDecifrato

}
