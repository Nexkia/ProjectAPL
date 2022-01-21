import socket
import zlib

import startup
import grafici
import time

HOST = 'localhost'  # Standard loopback interface address (localhost)
PORT = 13000  # Port to listen on (non-privileged ports are > 1023)
# Define the port on which you want to connect
ADDR = (HOST, PORT)
HEADER = 16
# connect to the server on local computer
CONNECTED = True
# Create a socket object
def send(message):
    lenmsg = (str(len(message))+"\n").encode(encoding="ascii")
    len_msg = bytearray(16)
    diff = len(len_msg)-len(lenmsg)
    for i in range(len(lenmsg)):
        len_msg[diff+i] = lenmsg[i]
    sckt.send(len_msg)
    sckt.send(message)


with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sckt:
    sckt.connect(ADDR)
    listaAcquistiLast = []
    numeroAcquistiUtenteLast =[]
    listaPreAssemblatiLast = []
    listaDetLast = []
    listaCompLast = []
    while CONNECTED:
        check, listaAcquistiLast, numeroAcquistiUtenteLast, listaPreAssemblatiLast, listaDetLast, listaCompLast = \
            startup.checkList(listaAcquistiLast, numeroAcquistiUtenteLast, listaPreAssemblatiLast, listaDetLast, listaCompLast)
        if check:
            raccomandazione, raccomandazionePre = startup.calcolaModelli(listaAcquistiLast, numeroAcquistiUtenteLast,
            listaPreAssemblatiLast, listaDetLast, listaCompLast)
            send("17 \n".encode(encoding="ascii"))
            #print(raccomandazione)
            for listComp in raccomandazione:
                for comp in listComp:
                    comp = comp + "\n"
                    comp_byte = comp.encode(encoding="ascii")
                    send(comp_byte)
            for name in raccomandazionePre:
                name = name + "\n"
                name_byte = name.encode(encoding="ascii")
                send(name_byte)
            time.sleep(5)
            send("18 \n".encode(encoding="ascii"))
            for img in grafici.listaImmagini(listaAcquistiLast, numeroAcquistiUtenteLast):
                img_byte = zlib.compress(img)
                send(img_byte)
        time.sleep(120)



# receive data from the server and decoding to get the string.
#
#          #sckt.send(b"9 \n")
