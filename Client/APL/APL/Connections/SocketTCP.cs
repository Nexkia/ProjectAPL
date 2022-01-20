using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace APL.Connections
{
    public static class SocketTCP
    {
        public static Mutex mut;
        const string host = "localhost";
        const Int32 port = 13000;
        static TcpClient client;
        static NetworkStream stream;
        // Close everything.

        static SocketTCP() {
            mut = new Mutex();
            client = new TcpClient(host, port);
            stream = client.GetStream();
        }

        static public void CloseConnection() {
            stream.Close();
            client.Close();
            mut.Close();
        }

        static public Mutex GetMutex() { 
            return mut;
        }
        static public void send(Protocol p)
        {
            string message = p.GetProtocolID() + p.Limit + p.Data+"\n";
            Debug.WriteLine("Sended: {0}", message);
            byte[] outJson = Encoding.ASCII.GetBytes(message);
            var lenbytes = new byte[16];
            string lenmsg = Convert.ToString(outJson.Length);
            byte[] len_ = Encoding.ASCII.GetBytes(lenmsg);
            var difference = lenbytes.Length - len_.Length;

            for (int i = 0; i < len_.Length; i++)
            {
                lenbytes[difference + i -1] = len_[i];
            }
            lenbytes[lenbytes.Length - 1] = 10;
            stream.Write(lenbytes, 0, lenbytes.Length);
            Debug.WriteLine(outJson.Length);
            stream.Write(outJson, 0, outJson.Length);
        }
        static public void sendClose(Protocol p)
        {
            string message = p.GetProtocolID() + p.Limit + p.Data;
            Debug.WriteLine("Sended: {0}", message);
            byte[] outJson = Encoding.ASCII.GetBytes(message);
            var lenbytes = new byte[16];
            string lenmsg = Convert.ToString(outJson.Length);
            byte[] len_ = Encoding.ASCII.GetBytes(lenmsg);
            var difference = lenbytes.Length - len_.Length;

            for (int i = 0; i < len_.Length; i++)
            {
                lenbytes[difference + i - 1] = len_[i];
            }
            lenbytes[lenbytes.Length - 1] = 10;
            stream.Write(lenbytes, 0, lenbytes.Length);
            Debug.WriteLine(outJson.Length);
            stream.Write(outJson, 0, outJson.Length);
        }
        static public void sendSingleMsg(string message)
        {
            Debug.WriteLine("Sended: {0}", message);
            byte[] outJson = Encoding.ASCII.GetBytes(message);
            var lenbytes = new byte[16];
            string lenmsg = Convert.ToString(outJson.Length);
            byte[] len_ = Encoding.ASCII.GetBytes(lenmsg);
            var difference = lenbytes.Length - len_.Length;

            for (int i = 0; i < len_.Length; i++)
            {
                lenbytes[difference + i - 1] = len_[i];
            }
            lenbytes[lenbytes.Length - 1] = 10;
            stream.Write(lenbytes, 0, lenbytes.Length);
            Debug.WriteLine(outJson.Length);
            stream.Write(outJson, 0, outJson.Length);
        }

        static public string receive()
        {
            var data = new Byte[16];
            // String to store the response ASCII representation.
            String lenData = String.Empty;
            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            int inizio = 0;
            for (int i = 0; i < 16; i++) {
                if (data[i] > 47 && data[i] < 58)
                {
                    inizio = i;
                    break;
                }
            }
            int fine = data.Length - 1;
            data = data[inizio..fine];
            lenData = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
            Debug.WriteLine(data.Length);
            int lenmsg = int.Parse(lenData);
            var msg = new Byte[lenmsg];
            String responseData = String.Empty;
            Int32 bytesMsg = stream.Read(msg, 0, msg.Length);
            responseData = System.Text.Encoding.ASCII.GetString(msg, 0, bytesMsg);
            Debug.WriteLine("Received: {0}", responseData);
            return responseData;
        }


        public static Byte[] receiveBytesBlock()
        {
            Byte[] data = new Byte[16];
            // String to store the response ASCII representation.
            String lenData = String.Empty;
            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            int inizio = 0;
            for (int i = 0; i < 16; i++)
            {
                if (data[i] > 47 && data[i] < 58)
                {
                    inizio = i;
                    break;
                }
            }
            int fine = data.Length - 1;
            data = data[inizio..fine];
            lenData = System.Text.Encoding.ASCII.GetString(data, 0, data.Length);
            Debug.WriteLine(data.Length);
            int lenmsg = int.Parse(lenData);
            Byte[] msg = new Byte[lenmsg];
            Int32 bytesMsg = stream.Read(msg, 0, msg.Length);
            return msg;
        }
    }
}
