from connection import connetion
import json
import pandas as pd
import numpy as np
import time
from DataFrameStd import DataFrame
from DataFrameFiltering import DataFrameFilter
from collections import Counter
import operator
import time
def nElem(dic):
    list=[]
    for i in (0,5,1):
        list.append(dic)
    return list

def ConvertiInUnaLista(lista):
    listaFinale=[]
    # converto la lista di liste in un unica lista
    for t in lista:
        for a in list(t):
            listaFinale.append(''.join(a))
    return listaFinale

connect = connetion()





def loop(sckt):
    listaAcquistiLast = []
    numeroAcquistiUtenteLast =[]
    listaPreAssemblatiLast = []
    listaDetLast = []
    listaCompLast = []
    while True:
        check, listaAcquistiLast, numeroAcquistiUtenteLast, listaPreAssemblatiLast, listaDetLast, listaCompLast =  \
            checkList(listaAcquistiLast,numeroAcquistiUtenteLast,listaPreAssemblatiLast,listaDetLast,listaCompLast)
        if check:
            raccomandazione = calcolaModelli(listaAcquistiLast,numeroAcquistiUtenteLast,listaPreAssemblatiLast,listaDetLast,listaCompLast)
            sckt.send(b"17 \n")
            print(sckt.recv(256).decode())
            print(raccomandazione)
            jsonStr = json.dumps(raccomandazione)
            sckt.send(jsonStr.encode())
        time.sleep(120)

def checkList(listaAcquistiLast,numeroAcquistiUtenteLast,listaPreAssemblatiLast,listaDetLast,listaCompLast):
    listaAcquisti = []
    coll = connect.getCollection("Venduti")

    dim = 0
    for x in coll.find():
        dim = dim + 1
    print("numero acquisti in venduti", dim)
    numeroAcquistiUtente = []
    # tutti gli acquisti di ogni utente, rappresentano un elemento della listaAcquisti
    for num in range(0, dim, 1):
        listaAcquisti.append(coll.find().__getitem__(num))
        numeroAcquistiUtente.append(len(coll.find().__getitem__(num)))
        print("lunghezza: ", len(coll.find().__getitem__(num)), " utente n°: ", num)
    coll = connect.getCollection("preAssemblati")
    listaPreAssemblati =[]
    for x in coll.find():
        listaPreAssemblati.append([list(elm) for elm in x.items()])
    coll = connect.getCollection("detail")
    listaDet = []
    for x in coll.find():
        listaDet.append([list(elm) for elm in x.items()])
    listaDet = getFixedList(listaDet)
    coll = connect.getCollection("componenti")
    listaComp = []
    for x in coll.find():
        listaComp.append([list(elm) for elm in x.items()])
    listaComp = getFixedList(listaComp)
    check = True
    if listaPreAssemblati == listaPreAssemblatiLast:
        check = False
    if listaDet == listaDetLast:
        check = False
    if listaComp == listaCompLast:
        check = False
    return check,listaAcquisti,numeroAcquistiUtente,listaPreAssemblati,listaDet,listaComp


def getFixedList(lista):
    # remove id
    lista = [elem[1:] for elem in lista]
    external = []
    for elem in lista:
        internal = []
        for info in elem:
            for singleInfo in info:
                internal.append(singleInfo)
        external.append(internal)
    return external


def calcolaModelli(listaAcquisti,numeroAcquistiUtente,listaPreAssemblati,listaDet,listaComp):
    i=0

    listeModelliPrezzo=[]
    for y in listaAcquisti:
        for j in range(2,numeroAcquistiUtente[i],1):
            listeModelliPrezzo.append(list(y.values())[j])
        i=i+1


    #questo for serve ad eliminare il prezzo, lasciando solo i modelli
    listeModelli=[]
    for z in listeModelliPrezzo:
    #print( isinstance(list(z.values())[1], list),"wow",list(z.values())[1])

        # caso in cui prima c'è la lista e dopo il prezzo
        if (isinstance(list(z.values())[0], list)):
            listeModelli.append(list(z.values())[0])
         #caso in cui prima c'è il prezzo e dopo la lista
        if(isinstance(list(z.values())[1], list)):#è un controllo su tipo, il prezzo è un int,quindi non essendo una list non passa
            listeModelli.append(list(z.values())[1])

    #separo i componenti dai preassemblati
    listeM=[]
    listeP=[]
    for s in listeModelli:
        for g in s:
            if (len(g))==8:#componenti
                listeM.append(g)
            else:#preassemblati
                listeP.append(g)

    # trasformo le liste di liste in singole liste di string
    Preassemblati=ConvertiInUnaLista(listeP)
    Componenti=ConvertiInUnaLista(listeM)




    #converto la lista in un dizionario, i nomi sono le key e il numero di copie di ogni elemento è il value
    resultPreassemblati= dict(Counter(Preassemblati))
    print("dizionario disordinato Preassemblati: ",resultPreassemblati)

    resultComponenti= dict(Counter(Componenti))
    print("dizionario disordinato Componenti: ",resultComponenti)






    #print([nome for elem in listaPreAssemblati for x in elem for nome in x if isinstance(nome, str) and nome in "" ])
    listtmp = [nome for elem in listaPreAssemblati for x in elem for nome in x if isinstance(nome, str)]
    listaNomiPre = []
    for i in range(len(listtmp)):
        if listtmp[i] in "nome":
            listaNomiPre.append(listtmp[i+1])

    print(listaNomiPre)


    list1 = ["modello_casepc", "modello_cpu", "modello_schedaVideo",
             "modello_schedaMadre", "modello_alimentatore", "modello_ram"
        , "modello_memoria", "modello_dissipatore"]
    list2 = ["casepc", "cpu", "schedaVideo",
             "schedaMadre", "alimentatore", "ram"
        , "memoria", "dissipatore"]
    excluse = ["modello_ram", "modello_memoria"]
    start_time = time.time()


    end_time = time.time()
    print(end_time - start_time)
    start_time = time.time()


    end_time = time.time()
    print(end_time - start_time)

    start_time = time.time()

    listaDettagli = []
    for modello in list1:
        list_modello = [elem for elem in listaDet if elem[0] in modello]
        listaDettagli.append(list_modello)

    listaCatalogo = []
    for categoria in list2:
        list_categoria = [elem for elem in listaComp if elem[-1] in categoria]
        listaCatalogo.append(list_categoria)

    listaCompleta = []
    for modello, categoria in zip(listaDettagli, listaCatalogo):
        for x, y in zip(modello, categoria):
            # -4 se manca l'img
            if x[0] in excluse:
                tmp = x + y[:-4]
            else:
                tmp = x + y[:-6]
            listaCompleta.append(tmp)

    listaCompleta2 = []
    for modello in list1:
        list_modello = [elem for elem in listaCompleta if elem[0] in modello]
        listaCompleta2.append(list_modello)

    # print(listaCompleta2[6][1])

    rows = []
    rows_tot = []
    row_elm = []
    columns_tot = []
    columns = []
    for x in listaCompleta2:
        rows = []
        columns = []
        for x_elem in x:
            row_elm = [x_elem[i] for i in range(len(x_elem)) if i % 2 == 1]
            columns = [x_elem[i] for i in range(len(x_elem)) if i % 2 == 0]
            rows.append(row_elm)
        columns_tot.append(columns)
        rows_tot.append(rows)

    pt = DataFrame(rows_tot, columns_tot,resultComponenti)
    listdf = pt.standardize()

    pd.set_option('max_column', None)
    pd.set_option('max_row', None)

    filterDT = DataFrameFilter(listdf)



    listaRaccomndazione =[]
    listdf2 = filterDT.fiter(listdf, 70, "AM4", "DDR3", 80, 6, 600, 1000, "hdd", "Midi-Tower", 8)
    raccomandazione = []
    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][list1[i]][:3].values))
    listaRaccomndazione.append(raccomandazione)
    listdf2 = filterDT.fiter(listdf, 150, "AM4", "DDR4", 120, 8, 750, 1000, "ssd", "Midi-Tower", 16)
    raccomandazione = []
    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][list1[i]][:3].values))
    listaRaccomndazione.append(raccomandazione)

    listdf2 = filterDT.fiter(listdf, 200, "1200", "DDR4", 160, 8, 750, 1250, "ssd", "Midi-Tower", 16)
    raccomandazione = []
    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][list1[i]][:3].values))

    listaRaccomndazione.append(raccomandazione)

    listdf2 = filterDT.fiter(listdf, 400, "TR4", "DDR4", 300, 12, 1000, 2000, "ssd", "Big-Tower", 32)

    raccomandazione = []
    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][list1[i]][:3].values))

    listaRaccomndazione.append(raccomandazione)
    listdf2 = filterDT.fiter(listdf, prezzo=600, socket="2066", tipo_ram="DDR4", tdp_gpu=300, vram=16,
                             watt=1250, mem_capienza=2000, tipo_mem="ssd", size_case="Big-Tower", ram_capienza=64)

    raccomandazione = []
    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][list1[i]][:3].values))

    listaRaccomndazione.append(raccomandazione)


    DFpre = pd.DataFrame(data=listaNomiPre,columns=["nome"])
    DFpre["venduti"] = 0
    for key, value in resultPreassemblati.items():
        for i, row in DFpre["nome"].items():
            if row == key:
                DFpre.at[i, "venduti"] = value
    DFpre.sort_values("venduti", inplace=True, ascending=False)
    raccomandazionePre = list(DFpre["nome"][:2].values)
    random_pre = list(DFpre["nome"][2:].sample().values)
    raccomandazionePre.append(random_pre[0])
    listaRaccomndazione.append(raccomandazionePre)
    # print(listdf)
    # print(listdf2)
    # print(dfmotherboard.filter(items=['prezzo','ram','modello_schedaMadre','cpusocket']))


    end_time = time.time()
    print(end_time - start_time)

    return  listaRaccomndazione
