import pymongo

class connetion():
    def __init__(self):
        self.client=pymongo.MongoClient("mongodb://localhost:27017/")
        self.db=self.client["apl_database"]

    def getCollection(self,collection):
        return self.db[collection]