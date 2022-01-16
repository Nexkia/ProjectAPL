
from matplotlib import image as mpimg
import pymongo
from collections import Counter
import operator
import matplotlib.pyplot as plt
from matplotlib.pyplot import figure

def ConvertiInUnaLista(lista):
    listaFinale=[]
    # converto la lista di liste in un unica lista
    for t in lista:
        for a in list(t):
            listaFinale.append(''.join(a))
    return listaFinale

def histDataVendite():
    client = pymongo.MongoClient("mongodb://localhost:27017/")
    db = client["apl_database"]
    listaAcquisti = []

    col = db["Venduti"]

    print("\n////////////////////////////Vendite per data/////////////////////////////////")
    dim = 0
    for x in col.find():
        dim = dim + 1

    print("numero utente che hanno effettuato acquisti in venduti", dim)

    numeroAcquistiUtente = []
    # tutti gli acquisti di ogni utente, rappresentano un elemento della listaAcquisti
    for num in range(0, dim, 1):
        listaAcquisti.append(col.find().__getitem__(num))
        numeroAcquistiUtente.append(len(col.find().__getitem__(num)))
        print("lunghezza: ", len(col.find().__getitem__(num)), " utente n°: ", num)

    i = 0

    listeModelliPrezzo = []
    for y in listaAcquisti:
        for j in range(2, numeroAcquistiUtente[i], 1):
            listeModelliPrezzo.append(list(y.values())[j])
        i = i + 1

    print("listamodelliprezzo: ", listeModelliPrezzo)

    # questo for serve ad eliminare il prezzo, lasciando solo i modelli
    listaDate = []
    for z in listeModelliPrezzo:

        # caso in cui prima c'è la lista e dopo il prezzo
        if (isinstance(list(z.values())[1], str)):
            listaDate.append(list(z.values())[1])
        # caso in cui prima c'è il prezzo e dopo la lista
        if (isinstance(list(z.values())[2],str)):  # è un controllo su tipo, il prezzo è un int,quindi non essendo una list non passa
            listaDate.append(list(z.values())[2])

    print(" lista di Date: ", listaDate)

    listaYMD = []
    for s in listaDate:
        data, ora = s.split("T")
        listaYMD.append(data)

    resultYMD = dict(Counter(listaYMD))
    print("dizionario disordinato YMD: ", resultYMD)

    # creo un  dizionario  in ordine (discendente, ordiniamo i values)
    sorted_YMD = dict(sorted(resultYMD.items(), key=operator.itemgetter(0), reverse=True))
    print("dizionario ordinato YMD: ", sorted_YMD)

    key10 = list(sorted_YMD.keys())[:10]
    value10 = list(sorted_YMD.values())[:10]
    print("i primi 10 valori del dizionario ordinato YMD: ", key10)

    figure(figsize=(10, 10), dpi=70)  # dimensioni finestra
    plt.bar(key10, value10, color=(0.2, 0.4, 0.6, 0.6))
    plt.xticks(rotation=0)  # ,fontsize=8)
    plt.subplots_adjust(top=0.975,
                        bottom=0.06,
                        left=0.054,
                        right=0.985,
                        hspace=0.2,
                        wspace=0.2)

    plt.title("Vendite per data")
    plt.ylabel('Numero di vendite ultimi 10 giorni')
    plt.xlabel('Date')
    plt.savefig('histDataVendite.png')
    #plt.show()
    plt.close(figure)
    im = mpimg.imread('histDataVendite.png')

    return im

def histNumeroComponentiEPreassemblati():
    client = pymongo.MongoClient("mongodb://localhost:27017/")
    db = client["apl_database"]
    listaAcquisti = []

    col = db["Venduti"]
    print("\n////////////////////////////Componenti e Preassemblati/////////////////////////////////")

    dim = 0
    for x in col.find():
        dim = dim + 1

    print("numero acquisti in venduti", dim)

    numeroAcquistiUtente = []
    # tutti gli acquisti di ogni utente, rappresentano un elemento della listaAcquisti
    for num in range(0, dim, 1):
        listaAcquisti.append(col.find().__getitem__(num))
        numeroAcquistiUtente.append(len(col.find().__getitem__(num)))
        print("lunghezza: ", len(col.find().__getitem__(num)), " utente n°: ", num)

    i = 0

    listeModelliPrezzo = []
    for y in listaAcquisti:
        for j in range(2, numeroAcquistiUtente[i], 1):
            listeModelliPrezzo.append(list(y.values())[j])
        i = i + 1

    # questo for serve ad eliminare il prezzo, lasciando solo i modelli
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
    resultPreassemblati = dict(Counter(Preassemblati))
    print("dizionario disordinato Preassemblati: ", resultPreassemblati)

    resultComponenti = dict(Counter(Componenti))
    print("dizionario disordinato Componenti: ", resultComponenti)

    # creo un secondo dizionario che sta volta è in ordine (discendente, ordiniamo i values)
    sorted_Preassemblati = dict(sorted(resultPreassemblati.items(), key=operator.itemgetter(1), reverse=True))
    print("dizionario ordinato Preassemblati: ", sorted_Preassemblati)

    sorted_Componenti = dict(sorted(resultComponenti.items(), key=operator.itemgetter(1), reverse=True))
    print("dizionario ordinato Componenti: ", sorted_Componenti)

    Ckey15 = list(sorted_Componenti.keys())[:15]  # i primi n keys del dizionario, dentro una lista
    Cvalue15 = list(sorted_Componenti.values())[:15]

    ##I 15 COMPONENTI piu venduti
    figure(figsize=(10, 10), dpi=70)  # dimensioni finestra
    plt.bar(Ckey15, Cvalue15)
    plt.xticks(rotation='vertical')
    plt.subplots_adjust(top=0.975,
                        bottom=0.324,
                        left=0.067,
                        right=0.985,
                        hspace=0.2,
                        wspace=0.2)
    plt.title("Componenti più venduti")
    plt.ylabel('Unità vendute')
    plt.xlabel('Modelli Componenti')
    plt.savefig('histNumeroComponenti.png')
    #plt.show()
    plt.close(figure)

    Pkey15 = list(sorted_Preassemblati.keys())[:15]  # i primi n keys del dizionario, dentro una lista
    Pvalue15 = list(sorted_Preassemblati.values())[:15]

    ##I 15 pc piu venduti
    figure(figsize=(10, 10), dpi=70)  # dimensioni finestra
    plt.bar(Pkey15, Pvalue15)
    plt.xticks(rotation='vertical')
    plt.subplots_adjust(top=0.975,
                        bottom=0.164,
                        left=0.067,
                        right=0.985,
                        hspace=0.2,
                        wspace=0.2)
    plt.title("Preassemblati più venduti")
    plt.ylabel('Unità vendute')
    plt.xlabel('Preassemblati')
    plt.savefig('histNumeroPreassemblati.png')
    #plt.show()
    plt.close(figure)
    im1 = mpimg.imread('histNumeroComponenti.png')
    im2 = mpimg.imread('histNumeroPreassemblati.png')

    listIMG=[]
    listIMG.append(im1)
    listIMG.append(im2)

    return listIMG

def listaImmagini():
    listIMG = histNumeroComponentiEPreassemblati()
    listIMG.append(histDataVendite())
    return listIMG

