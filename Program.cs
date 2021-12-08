// See https://aka.ms/new-console-template for more information

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using static APL_software.connection;

public class StartUp
{
    public static void Main()
    {
        //connection prova= new connection();

        Socket sender= APL_software.connection.StartClient();
        //Console.WriteLine("Hello, World!");
/*
// Encode the data string into a byte array.
            byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

            // Send the data through the socket.
            int bytesSent = sender.Send(msg);

            // Receive the response from the remote device.
            int bytesRec = sender.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));

            // Release the socket.
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
*/

    }

}







