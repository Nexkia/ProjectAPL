import base64
import socket

import Recommendation
import grafici
import time

HOST = 'localhost'
PORT = 13000
ADDR = (HOST, PORT)
HEADER = 16
CONNECTED = True


def send(message):
    """
    Calcolo la lunghezza del messaggio codificata in ascii
    concatenata ad un ritorno a capo ed effettuo il padding
    per avere una lunghezza fissa del messaggio di 16 byte
    """
    lenmsg = (str(len(message)) + "\n").encode(encoding="ascii")
    len_msg = bytearray(16)
    diff = len(len_msg) - len(lenmsg)
    for i in range(len(lenmsg)):
        len_msg[diff + i] = lenmsg[i]
    sckt.send(len_msg)
    sckt.send(message)


with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sckt:
    sckt.connect(ADDR)
    listaAcquistiLast = []
    numeroAcquistiUtenteLast = []
    listaPreAssemblatiLast = []
    listaDetLast = []
    listaCompLast = []
    # La funzione Recommendation ritorna le liste aggiornate direttamente dal database e un boolean check
    # questo boolean è il risultato di un confronto tra le liste dell'aggiornamento precedente e quelle correnti
    # per cui ogni volta che vi è un cambiamento all'interno del database vengono ricalcolati i consigliati e i grafici
    while CONNECTED:
        check, listaAcquistiLast, numeroAcquistiUtenteLast, listaPreAssemblatiLast, listaDetLast, listaCompLast = \
            Recommendation.checkList(listaAcquistiLast, numeroAcquistiUtenteLast, listaPreAssemblatiLast, listaDetLast,
                                     listaCompLast)
        if check:
            raccomandazione, raccomandazionePre = Recommendation.calcolaModelli(listaAcquistiLast,
                                                                                numeroAcquistiUtenteLast,
                                                                                listaPreAssemblatiLast, listaDetLast,
                                                                                listaCompLast)
            send("17 \n".encode(encoding="ascii"))
            # print(raccomandazione)
            for listComp in raccomandazione:
                for comp in listComp:
                    comp = comp + "\n"
                    comp_byte = comp.encode(encoding="ascii")
                    send(comp_byte)
            for name in raccomandazionePre:
                name = name + "\n"
                name_byte = name.encode(encoding="ascii")
                send(name_byte)
            time.sleep(3)
            send("18 \n".encode(encoding="ascii"))
            for img_path in grafici.listaImmagini(listaAcquistiLast, numeroAcquistiUtenteLast):
                with open(img_path, 'rb') as img:
                    img_byte = base64.b64encode(img.read())
                    send(img_byte)
        time.sleep(90)

