using Client.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
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
        string token;
        public Form2(Form1 f,string token)
        {
            InitializeComponent();
             vecchioForm = f;
            this.token = token;
            
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            string host = "localhost";
            Int32 port = 13000;
            // var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (port));
            TcpClient client = new TcpClient(host, port);

            NetworkStream stream = client.GetStream();


            //conversione da Json a Byte
            byte[] outJson = Encoding.ASCII.GetBytes("2 "+token+" " + "\n");

            stream.Write(outJson, 0, outJson.Length);

            Console.WriteLine("Sent: {0}",  outJson);

            //--------------ricezione grandezza messaggio in byte----------------------
            var data1 = new Byte[256];
            // String to store the response ASCII representation.
            String responseData1 = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes1 = stream.Read(data1, 0, data1.Length);
            responseData1 = System.Text.Encoding.ASCII.GetString(data1, 0, bytes1);
            Console.WriteLine("Received: {0}", responseData1);

            //--------------ricezione dei dati e split----------------------
            // Buffer to store the response bytes.
            var data = new Byte[int.Parse(responseData1)];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Received: {0}", responseData);


            JArray c1= JsonConvert.DeserializeObject<JArray>(responseData);
          
            var returnType = c1.GetType();
            Console.WriteLine("Tipo c1: {0}", returnType);

            preAssemblato[] a= new preAssemblato[10];

            int index = 0;
            foreach (var pc in c1)
            {
                a[index] = JsonConvert.DeserializeObject< preAssemblato>(pc.ToString());
                Console.WriteLine("Tipo a:"+ a[index].Nome);
                index++;

            }
            


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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
            
        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
