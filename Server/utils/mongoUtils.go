package utils

import (
	"context"

	"go.mongodb.org/mongo-driver/bson"
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

func Aggregate(name_coll string, mongodb *mongo.Database, filter1 primitive.D, filter2 primitive.D) []bson.D {
	var res []bson.D
	coll := mongodb.Collection(name_coll)
	pipe := mongo.Pipeline{filter1, filter2}
	cursor, err := coll.Aggregate(context.TODO(), pipe)
	if err != nil {
		panic(err)
	}
	defer cursor.Close(context.TODO())

	if err = cursor.All(context.TODO(), &res); err != nil {
		panic(err)
	}
	return res
}

func Find(name_coll string, mongodb *mongo.Database, filter primitive.D, res interface{}) {
	coll := mongodb.Collection(name_coll)
	cursor, err := coll.Find(context.TODO(), filter)
	if err != nil {
		panic(err)
	}
	defer cursor.Close(context.TODO())
	if err = cursor.All(context.TODO(), res); err != nil {
		panic(err)
	}
}
