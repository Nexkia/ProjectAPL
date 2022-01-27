from pymongo import MongoClient

URL = "mongodb://localhost:27017/"
DATABASE = "apl_database"


class Connetion():
    def __init__(self):
        self.client = MongoClient(URL)
        self.db = self.client[DATABASE]

    def getCollection(self, collection):
        return self.db[collection]
