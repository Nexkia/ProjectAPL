using Client.Connection;
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

        Protocol pt = new Protocol();
        Form1 vecchioForm;
        string token;
        public Form2(Form1 f,string token)
        {
            InitializeComponent();
             vecchioForm = f;
            this.pt.Token = token;

        }
        
        private async void Form2_Load(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            // Richiede due messaggi 
            pt.ProtocolID = "2"; pt.Data = "";
            string responce = await sckt.send(pt);
            int datalen = int.Parse(await sckt.receive(256));
            responce = await sckt.send(pt);
            string responseData = await sckt.receive(datalen);

            JArray c1= JsonConvert.DeserializeObject<JArray>(responseData);
          
            var returnType = c1.GetType();
            Console.WriteLine("Tipo c1: {0}", returnType);

            int dim = 10;
            Preassemblato[] a= new Preassemblato[dim];

                 int index = 0;
            foreach (JObject pc in c1)
            {
               
                a[index] = JsonConvert.DeserializeObject<Preassemblato>(pc.ToString());
               // a[index].Inserimento();

                Console.WriteLine("prezzo pc: " + a[index].Prezzo );
                
                //b[index].toStringComponenti();
               // populateItems(index,a[index],dim);
                index++;
                
            }

            populateItems(a,index);

           
            
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

       

        private void populateItems(Preassemblato[] pre,int index)
        {
          //  Console.WriteLine(pre.Stampa());
            ListItem[] listItems= new ListItem[index];

            string[] vet = { "cpu", "schedaVideo", "memoria", "ram" };
            


           for(int i = 0; i < listItems.Length; i++){
            
               // Console.Write("flowLayoutPanel1.Controls.Count: " + flowLayoutPanel1.Controls.Count);
                listItems[i] = new ListItem();

                listItems[i].Icon = Resources.imageNotFound1;
                listItems[i].IconBackground = Color.SteelBlue;
               listItems[i].Title = "Nome: "+pre[i].Nome+" Prezzo: "+pre[i].Prezzo;//"qui si mette il titolo";

                string message="";
                //8 come il numero dei componenti
                for (int j = 0; j < 8; j++)
                {
                    if(Array.Exists(vet, x => x == pre[i].Componenti[j].Categoria))
                    {
                        message += pre[i].Componenti[j].Categoria + ": " + pre[i].Componenti[j].Marca + " " + pre[i].Componenti[j].Modello; 

                        if (int.Parse(pre[i].Componenti[j].Capienza) > 0) {
                            message += " "+pre[i].Componenti[j].Capienza + " GB";
                        }

                        message+= "\n";
                    }

                }
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
