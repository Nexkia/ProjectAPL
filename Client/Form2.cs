using Client.Data;
using Client.Properties;
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

            int dim = 10;
            PreAssemblato[] a= new PreAssemblato[dim];

                 int index = 0;
            foreach (JObject pc in c1)
            {
               
                a[index] = JsonConvert.DeserializeObject<PreAssemblato>(pc.ToString());
               // a[index].Inserimento();

                Console.WriteLine("prezzo pc: " + a[index].Prezzo );
                
                //b[index].toStringComponenti();
               // populateItems(index,a[index],dim);
                index++;
                
            }

            populateItems(a,index);

            

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

        private void listItem1_Load(object sender, EventArgs e)
        {

        }

       

        private void populateItems(PreAssemblato[] pre,int index)
        {
          //  Console.WriteLine(pre.Stampa());
            ListItem[] listItems= new ListItem[index];

           for(int i = 0; i < listItems.Length; i++){
            
               // Console.Write("flowLayoutPanel1.Controls.Count: " + flowLayoutPanel1.Controls.Count);
                listItems[i] = new ListItem();

                listItems[i].Icon = Resources.imageNotFound1;
                listItems[i].IconBackground = Color.SteelBlue;
               listItems[i].Title = "Nome: "+pre[i].Nome+" Prezzo: "+pre[i].Prezzo;//"qui si mette il titolo";
                string message = pre[i].Componenti[0].Marca + " " + pre[i].Componenti[0].Modello + "\n" +
                                 pre[i].Ram.Componente.Categoria+" "+pre[i].Ram.Capienza + " GB"  + "\n" +
                                 pre[i].Memoria.Tipo +" " + pre[i].Memoria.Dimensione + " GB" + "\n"+
                                 pre[i].Componenti[2].Marca + " " + pre[i].Componenti[2].Modello + "\n";
                listItems[i].Message = message;

                //aggiunge al flow label

            if (flowLayoutPanel1.Controls.Count<0){

           flowLayoutPanel1.Controls.Clear();
           }
           else
                flowLayoutPanel1.Controls.Add(listItems[i]);


            }
        }

        private void flowLayoutPanel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void buttonMyBuild_Click(object sender, EventArgs e)
        {
            //pulisco la tendina
            flowLayoutPanel1.Controls.Clear();

            if (comboBox1.Text=="Build Guidata") {
                Console.WriteLine("valore combobox: " + comboBox1.Text);
                
            }
            else
            {
                Console.WriteLine("valore combobox: " + comboBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }
    }
}
