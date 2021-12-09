using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;




namespace Client
{
     
    public partial class Form1 : Form
    {
        Socket send;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
             send = Connection.StartClient();
            Console.WriteLine("load caricata correttamente");
            
            Console.WriteLine("Socket connected to {0}",
                    send.RemoteEndPoint.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("prova1");

            byte[] bytes = new byte[1024];

            // Encode the data string into a byte array.
            byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

            // Send the data through the socket.
            int bytesSent = send.Send(msg);

            // Receive the response from the remote device.
            int bytesRec = send.Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                Encoding.ASCII.GetString(bytes, 0, bytesRec));




            send.Shutdown(SocketShutdown.Both);
            send.Close();

        }
    }
}
