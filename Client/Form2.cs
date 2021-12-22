using Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Client
{
    public partial class Form2 : Form
    {
        Form1 vecchioForm;
        public Form2(Form1 f)
        {
            InitializeComponent();
             vecchioForm = f;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string host = "localhost";
            Int32 port = 13000;
            // var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (port));
            TcpClient client = new TcpClient(host, port);

            NetworkStream stream = client.GetStream();


            //conversione da Json a Byte
            byte[] outJson = Encoding.ASCII.GetBytes("2 a " + "\n");

            stream.Write(outJson, 0, outJson.Length);

            Console.WriteLine("Sent: {0}",  outJson);

            // Buffer to store the response bytes.
            var data = new Byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);

            preAssemblato c1=JsonSerializer.Deserialize<preAssemblato>(responseData);
            Console.WriteLine(c1.Prezzo);
            

            // Close everything.
            stream.Close();
            client.Close();
        }


        protected override void OnClosed(EventArgs e)
        {
            vecchioForm.Visible = true;
            base.OnClosed(e);
        }

        



        private void button1_Click(object sender, EventArgs e)
        {
            vecchioForm.Visible = true;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void prova1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
