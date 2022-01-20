package utils

import (
	"crypto/sha256"
	"encoding/base64"
	"log"
)

func Encoding(email string, password string) string {

	sha := sha256.New()
	/* il token è generato dall'unione dell'email
	e della password
	*/
	sha.Write([]byte(email + password))
	hashPsw := string(sha.Sum(nil))
	// converto la stringa in base 64
	token := base64.StdEncoding.EncodeToString([]byte(hashPsw))
	log.Println("token: " + token)
	return token
}
