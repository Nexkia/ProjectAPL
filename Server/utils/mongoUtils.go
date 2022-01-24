package utils

import (
	"context"

	"go.mongodb.org/mongo-driver/bson"
	"go.mongodb.org/mongo-driver/bson/primitive"
	"go.mongodb.org/mongo-driver/mongo"
)

var ctx = context.Background()

func FindOne(filter primitive.D, name_coll string, mongodb *mongo.Database) *mongo.SingleResult {
	coll := mongodb.Collection(name_coll)
	result := coll.FindOne(ctx, filter)
	return result
}

func InsertOne(name_coll string, mongodb *mongo.Database, newelement interface{}) error {
	coll := mongodb.Collection(name_coll)
	_, err := coll.InsertOne(ctx, newelement)
	return err
}

func UpdateOne(name_coll string, mongodb *mongo.Database, filter primitive.D, update primitive.D) {
	coll := mongodb.Collection(name_coll)
	coll.UpdateOne(ctx, filter, update)
}

func DeleteOne(name_coll string, mongodb *mongo.Database, filter primitive.D) {
	coll := mongodb.Collection(name_coll)
	coll.DeleteOne(ctx, filter)
}

func Aggregate(name_coll string, mongodb *mongo.Database, pipe mongo.Pipeline) []bson.M {
	var res []bson.M
	coll := mongodb.Collection(name_coll)
	cursor, err := coll.Aggregate(ctx, pipe)
	if err != nil {
		panic(err)
	}
	defer cursor.Close(ctx)

	if err = cursor.All(ctx, &res); err != nil {
		panic(err)
	}
	return res
}

func Find(name_coll string, mongodb *mongo.Database, filter primitive.D, res interface{}) {
	coll := mongodb.Collection(name_coll)
	cursor, err := coll.Find(ctx, filter)
	if err != nil {
		panic(err)
	}
	defer cursor.Close(ctx)
	if err = cursor.All(ctx, res); err != nil {
		panic(err)
	}
}
