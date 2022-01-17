import threading
import socket
import startup
import grafici
import time

from array import array
HOST = 'localhost'  # Standard loopback interface address (localhost)
PORT = 13000  # Port to listen on (non-privileged ports are > 1023)
# Define the port on which you want to connect
ADDR = (HOST, PORT)
# connect to the server on local computer
CONNECTED = True
# Create a socket object

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
            sckt.send(b"17 \n")
            print(sckt.recv(256).decode())
            print(raccomandazione)
            for listComp in raccomandazione:
                for comp in listComp:
                    comp = comp + "\n"
                    sckt.send(comp.encode())
                    print(sckt.recv(256).decode())
            for name in raccomandazionePre:
                name = name + "\n"
                sckt.send(name.encode())
                print(sckt.recv(256).decode())
            time.sleep(60)
            sckt.send(b"18 \n")
            print(sckt.recv(256).decode())
            for img in grafici.listaImmagini(listaAcquistiLast, numeroAcquistiUtenteLast):
                b = bytearray(img)
                sckt.send(b)
                print(sckt.recv(256).decode())
        time.sleep(120)
# receive data from the server and decoding to get the string.
#
#          #sckt.send(b"9 \n")
