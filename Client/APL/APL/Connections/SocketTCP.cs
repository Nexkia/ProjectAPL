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
        public static Mutex mut = new Mutex();
        const string host = "localhost";
        const Int32 port = 13000;
        static TcpClient client =  new TcpClient(host, port);
        static NetworkStream stream = client.GetStream();
        // Close everything.


        static public void CloseConnection() {
            stream.Close();
            client.Close();
            mut.Close();
        }

        static public Mutex GetMutex() { 
            return mut;
        }
        static public async void send(Protocol p)
        {
            await Task.Run(() =>
            {
                string message = p.GetProtocolID() + p.Limit + p.Token + p.Limit + p.Data + p.End;
                Debug.WriteLine("Sended: {0}", message);
                byte[] outJson = Encoding.ASCII.GetBytes(message);
                stream.Write(outJson, 0, outJson.Length);
            });
            return;
        }
        static public void sendClose(Protocol p)
        {
            string message = p.GetProtocolID() + p.Limit + p.Token + p.Limit + p.Data + p.End;
            Debug.WriteLine("Sended: {0}", message);
            byte[] outJson = Encoding.ASCII.GetBytes(message);
            stream.Write(outJson, 0, outJson.Length);
            return;
        }
        static public async void sendSingleMsg(string single)
        {
            await Task.Run(() =>
            {
                string message = single;
                Debug.WriteLine("Sended: {0}", message);
                byte[] outJson = Encoding.ASCII.GetBytes(message);
                stream.Write(outJson, 0, outJson.Length);
            });
            return;
        }

        static public async Task<string> receive()
        {
            string result = await Task.Run(() =>
            {
                var data = new Byte[256];
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Debug.WriteLine("Received: {0}", responseData);
                return responseData;
            });
            return result;
        }

        public async Task<Byte[]> receiveBytes()
        {
            var result = await Task.Run(() =>
            {
                var data = new Byte[256];
                // String to store the response ASCII representation.
                String responseData = String.Empty;
                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                return data;
            });
            return result;
        }
    }
}
