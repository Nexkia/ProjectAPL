from connection import connetion
import pandas as pd
from DataFrameStd import DataFrame
from DataFrameFiltering import DataFrameFilter
from collections import Counter


def nElem(dic):
    list = []
    for i in (0, 5, 1):
        list.append(dic)
    return list


def ConvertiInUnaLista(lista):
    listaFinale = []
    # converto la lista di liste in un unica lista
    for t in lista:
        for a in list(t):
            listaFinale.append(''.join(a))
    return listaFinale


connect = connetion()


def checkList(listaAcquistiLast, numeroAcquistiUtenteLast, listaPreAssemblatiLast, listaDetLast, listaCompLast):
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
    listaPreAssemblati = []
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
    check = False
    if listaAcquisti != listaAcquistiLast or numeroAcquistiUtente != numeroAcquistiUtenteLast:
        check = True
    if listaPreAssemblati != listaPreAssemblatiLast or listaDet != listaDetLast or listaComp == listaCompLast:
        check = True
    return check, listaAcquisti, numeroAcquistiUtente, listaPreAssemblati, listaDet, listaComp


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


def calcolaModelli(listaAcquisti, numeroAcquistiUtente, listaPreAssemblati, listaDet, listaComp):
    # Creazione lista vendite componenti e creazione lista vendite preassemblati
    i = 0
    listeModelliPrezzo = []
    for y in listaAcquisti:
        for j in range(2, numeroAcquistiUtente[i], 1):
            listeModelliPrezzo.append(list(y.values())[j])
        i = i + 1

    # questo for serve a eliminare il prezzo, lasciando solo i modelli
    listeModelli = []
    for z in listeModelliPrezzo:
        # print( isinstance(list(z.values())[1], list),"wow",list(z.values())[1])

        # caso in cui prima c'è la lista e dopo il prezzo
        if (isinstance(list(z.values())[0], list)):
            listeModelli.append(list(z.values())[0])
        # caso in cui prima c'è il prezzo e dopo la lista
        if (isinstance(list(z.values())[1],
                       list)):  # è un controllo su tipo, il prezzo è un int,quindi non essendo una list non passa
            listeModelli.append(list(z.values())[1])

    # separo i componenti dai preassemblati
    listeM = []
    listeP = []
    for s in listeModelli:
        for g in s:
            if (len(g)) == 8:  # componenti
                listeM.append(g)
            else:  # preassemblati
                listeP.append(g)

    # trasformo le liste di liste in singole liste di string
    Preassemblati = ConvertiInUnaLista(listeP)
    Componenti = ConvertiInUnaLista(listeM)

    # converto la lista in un dizionario, i nomi sono le key e il numero di copie di ogni elemento è il value
    venditePreassemblati = dict(Counter(Preassemblati))
    print("dizionario disordinato Preassemblati: ", venditePreassemblati)

    venditeComponenti = dict(Counter(Componenti))
    print("dizionario disordinato Componenti: ", venditeComponenti)

    '''  
        Inizio Raccomandazione
    
    
    '''

    listElementiPre = [elem for pre in listaPreAssemblati for x in pre for elem in x if isinstance(elem, str)]
    listaNomiPre = []
    # Estraggo solamente i nomi dai vari elementi dei preassemblati
    for i in range(len(listElementiPre)):
        if listElementiPre[i] in "nome":
            # copio una posizione in avanti perché composto da
            # nome : valore
            listaNomiPre.append(listElementiPre[i + 1])

    print(listaNomiPre)

    modelli = ["modello_casepc", "modello_cpu", "modello_schedaVideo",
               "modello_schedaMadre", "modello_alimentatore", "modello_ram"
        , "modello_memoria", "modello_dissipatore"]
    categorie = ["casepc", "cpu", "schedaVideo",
                 "schedaMadre", "alimentatore", "ram", "memoria", "dissipatore"]
    exclude = ["modello_ram", "modello_memoria"]

    listaDettagli = []
    for modello in modelli:
        # il primo elemento è il modello
        list_modello = [elem for elem in listaDet if elem[0] in modello]
        listaDettagli.append(list_modello)

    listaComponenti = []
    for categoria in categorie:
        # L'ultimo elemento è la categoria
        list_categoria = [elem for elem in listaComp if elem[-1] in categoria]
        listaComponenti.append(list_categoria)

    listaChiaveValori = []
    for dettaglio, componente in zip(listaDettagli, listaComponenti):
        for x, y in zip(dettaglio, componente):
            '''
            Unisco i dettagli ai componenti
            Prendo solamente le informazioni utili 
            Nel caso particolare di ram il campo in più è la capienza 
            '''
            if x[0] in exclude:
                tmp = x + y[:-4]
            else:
                tmp = x + y[:-6]
            listaChiaveValori.append(tmp)

    listaOrganizzata = []
    for modello in modelli:
        list_modello = [elem for elem in listaChiaveValori if elem[0] in modello]
        listaOrganizzata.append(list_modello)

    rows_tot = []
    columns_tot = []
    for x in listaOrganizzata:
        rows = []
        columns = []
        for x_elem in x:
            # Caso indice dispari rappresenta un valore
            row_elm = [x_elem[i] for i in range(len(x_elem)) if i % 2 == 1]
            # Caso indice pari rappresenta una chiave
            columns = [x_elem[i] for i in range(len(x_elem)) if i % 2 == 0]
            rows.append(row_elm)
        columns_tot.append(columns)
        rows_tot.append(rows)

    pt = DataFrame(rows_tot, columns_tot, venditeComponenti)
    listdf = pt.standardize()

    pd.set_option('max_column', None)
    pd.set_option('max_row', None)

    filterDT = DataFrameFilter(listdf)

    raccomandazione = []
    listdf2 = filterDT.fiter(listdf, 70, "AM4", "DDR3", 80, 6, 600, 1000, "hdd", "Midi-Tower", 8)
    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][modelli[i]][:3].values))
    listdf2 = filterDT.fiter(listdf, 150, "AM4", "DDR4", 120, 8, 750, 1000, "ssd", "Midi-Tower", 16)
    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][modelli[i]][:3].values))

    listdf2 = filterDT.fiter(listdf, 200, "1200", "DDR4", 160, 8, 750, 1250, "ssd", "Midi-Tower", 16)
    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][modelli[i]][:3].values))

    listdf2 = filterDT.fiter(listdf, 400, "TR4", "DDR4", 300, 12, 1000, 2000, "ssd", "Big-Tower", 32)

    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][modelli[i]][:3].values))

    listdf2 = filterDT.fiter(listdf, prezzo=600, socket="2066", tipo_ram="DDR4", tdp_gpu=300, vram=16,
                             watt=1250, mem_capienza=2000, tipo_mem="ssd", size_case="Big-Tower", ram_capienza=64)

    for i in range(len(listdf2)):
        raccomandazione.append(list(listdf2[i][modelli[i]][:3].values))

    DFpre = pd.DataFrame(data=listaNomiPre, columns=["nome"])
    DFpre["venduti"] = 0
    for key, value in venditePreassemblati.items():
        for i, row in DFpre["nome"].items():
            if row == key:
                DFpre.at[i, "venduti"] = value
    DFpre.sort_values("venduti", inplace=True, ascending=False)

    raccomandazionePre = list(DFpre["nome"][:2].values)
    random_pre = list(DFpre["nome"][2:].sample().values)
    raccomandazionePre.append(random_pre[0])


    return raccomandazione, raccomandazionePre
