package utils

import (
	"context"

	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
)

func FindOne(filter primitive.D, name_coll string, mongodb *mongo.Database) *mongo.SingleResult {
	coll := mongodb.Collection(name_coll)
	result := coll.FindOne(context.TODO(), filter)
	return result
}

func InsertOne(name_coll string, mongodb *mongo.Database, newelement interface{}) error {
	coll := mongodb.Collection(name_coll)
	_, err := coll.InsertOne(context.TODO(), newelement)
	return err
}

func UpdateOne(name_coll string, mongodb *mongo.Database, filter primitive.D, update primitive.D) {
	coll := mongodb.Collection(name_coll)
	coll.UpdateOne(context.TODO(), filter, update)
}

func DeleteOne(name_coll string, mongodb *mongo.Database, filter primitive.D) {
	coll := mongodb.Collection(name_coll)
	coll.DeleteOne(context.TODO(), filter)
}
