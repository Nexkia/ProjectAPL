using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace APL.Connections
{
    public static class SocketTCP
    {
        private static readonly Mutex mut;
        const string host = "localhost";
        const Int32 port = 13000;
        const Int32 timeout = 5000;
        private static readonly TcpClient client;
        private static readonly NetworkStream stream;

        static SocketTCP()
        {
            mut = new Mutex();
            client = new TcpClient();
            try
            {
                client.Connect(host, port);
                stream = client.GetStream();
                stream.ReadTimeout = timeout;
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message + "Assicurarsi che il server remoto sia in ascolto");
                System.Environment.Exit(50);
            }
        }
        // Close everything.
        static public void CloseConnection()
        {
            stream.Close();
            client.Close();
            mut.Close();
        }

        static public void Wait()
        {
            mut.WaitOne();
        }

        static public void Release()
        {
            mut.ReleaseMutex();
        }
        static public void Send(string message)
        {
            /*
             I primi 16 byte inviati sono la lunghezza del messaggio
            con l'ultimo byte contente il ritorno a capo
             
             */
            Debug.WriteLine("Sended: {0}", message);
            byte[] outJson = Encoding.ASCII.GetBytes(message);
            var lenbytes = new byte[16];
            string lenmsg = Convert.ToString(outJson.Length);
            // effettuo il padding 
            byte[] len_ = Encoding.ASCII.GetBytes(lenmsg);
            var difference = lenbytes.Length - len_.Length;

            for (int i = 0; i < len_.Length; i++)
            {
                lenbytes[difference + i - 1] = len_[i];
            }
            lenbytes[lenbytes.Length - 1] = 10;

            if (client.Connected && stream.CanWrite)
            {
                try
                {
                    stream.Write(lenbytes, 0, lenbytes.Length);
                    stream.Flush();
                    stream.Write(outJson, 0, outJson.Length);
                    stream.Flush();
                    Debug.WriteLine(outJson.Length);
                }
                catch (IOException io)
                {
                    MessageBox.Show(io.Message + "Connessione col Server interrotta");
                    System.Environment.Exit(51);
                }
            }
        }


        static public string Receive()
        {
            /*
            I primi 16 byte ricevuti sono la lunghezza del messaggio
           con l'ultimo byte contente il ritorno a capo
            */
            var data = new Byte[16];
            String responseData = String.Empty;
            if (client.Connected && stream.CanRead)
            {
                try
                {
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    int inizio = 0;
                    for (int i = 0; i < 16; i++)
                    {   // Conversione da ASCII in decimal
                        if (data[i] > 47 && data[i] < 58)
                        {
                            inizio = i;
                            break;
                        }
                    }
                    int fine = data.Length - 1;
                    // effettuo uno slice in quanto l'ultimo elemento è un ritorno a capo
                    data = data[inizio..fine];
                    string lenData = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
                    int lenmsg = int.Parse(lenData);
                    var msg = new Byte[lenmsg];
                    Int32 bytesMsg = stream.Read(msg, 0, msg.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(msg, 0, bytesMsg);
                    Debug.WriteLine(data.Length);
                    Debug.WriteLine("Received: {0}", responseData);
                }
                catch (IOException io)
                {
                    MessageBox.Show(io.Message + "Connessione col Server interrotta");
                    System.Environment.Exit(51);
                }
            }
            return responseData;
        }
    }
}
