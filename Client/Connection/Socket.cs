using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Connection
{
    class SocketTCP
    {
        const string host = "localhost";
        const Int32 port = 13000;
        TcpClient client;
        NetworkStream stream;
        public SocketTCP() {
            client = new TcpClient(host, port);
            stream = client.GetStream();
        }
        // Close everything.

        ~SocketTCP()
        {
            stream.Close();
            client.Close();
            Console.WriteLine("ho chiamato il distruttore");
        }
        
        public async Task<string> send(Protocol p) {
            await Task.Run(() =>
            {
            string message = p.ProtocolID + p.limit + p.Token + p.limit + p.Data + p.end;
            Console.WriteLine("Sended: {0}", message);
            byte[] outJson = Encoding.ASCII.GetBytes(message);
            stream.Write(outJson, 0, outJson.Length);            
            });

            return "done";
        }

        public async Task<string> sendSingleMsg(string single)
        {
            await Task.Run(() =>
            {
                string message = single;
                Console.WriteLine("Sended: {0}", message);
                byte[] outJson = Encoding.ASCII.GetBytes(message);
                stream.Write(outJson, 0, outJson.Length);
            });

            return "done";
        }

        public async Task<string> receive(int dim) {
            string result = await Task.Run(() =>
            {
                var data = new Byte[dim];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);
                return responseData;
            });

            return result;

        }
    }
 }
