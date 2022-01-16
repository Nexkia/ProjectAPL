import threading
import socket
import grafici
import time
HOST = 'localhost'  # Standard loopback interface address (localhost)
PORT = 13000  # Port to listen on (non-privileged ports are > 1023)
# Define the port on which you want to connect
ADDR = (HOST, PORT)
# connect to the server on local computer
CONNECTED = True
# Create a socket object
lock = threading.Lock()
import  startup

with socket.socket(socket.AF_INET, socket.SOCK_STREAM) as sckt:
    sckt.connect(ADDR)
    #thread = threading.Thread(target=startup.loop,args=(sckt,))
    #thread.start()
    while CONNECTED:
# receive data from the server and decoding to get the string.
        sckt.send(b"18 \n")
        print(sckt.recv(256).decode())
        for img in grafici.listaImmagini():
            b = bytearray(img)
            sckt.send(b)
            print(sckt.recv(256).decode())
         #sckt.send(b"9 \n")
        time.sleep(120)
def sendfunction(sock, data):
    with lock:
        sock.send(data)
