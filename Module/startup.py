import pymongo

client=pymongo.MongoClient("mongodb://localhost:27017/")
db=client["apl_database"]
listaDet=[]

col =db["detail"]

i=0
for x in col.find({"valutazione":9}):

   listaDet.append(x)
  # print(x)
   i =i+1


list1=["modello_casepc","modello_cpu","modello_schedaVideo",
      "modello_schedaMadre","modello_alimentatore","modello_ram"
      ,"modello_memoria","modello_dissipatore"]

col =db["componenti"]

listaComp=[]

chiaviMod=[]
for x in listaDet:
    for key in x.keys():
        if key.find("modello")!=-1:
            chiaviMod.append(key)
    print(chiaviMod)
    for y in col.find({"modello":x[chiaviMod.__getitem__(0)]}):
        listaComp.append(y)
        print(y)
    chiaviMod=[]

   ## col.find({"modello": x[[key for key in list]]})
    #print(x[[key for key in list(y)]])

