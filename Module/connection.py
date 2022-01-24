from pymongo import MongoClient


class Connetion():
    def __init__(self):
        self.client = MongoClient("mongodb://localhost:27017/")
        self.db = self.client["apl_database"]

    def getCollection(self, collection):
        return self.db[collection]
