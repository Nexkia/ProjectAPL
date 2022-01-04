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
using System.Windows.Controls;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Client
{
    public partial class Form2 : Form
    {

        Protocol pt = new Protocol();
        Form1 vecchioForm;



         Preassemblato[] ricevuto;
         int dimRicevuto;
        public Form2(Form1 f, string token)
        {
            InitializeComponent();
            vecchioForm = f;
            this.pt.Token = token;
            comboBox1.Text = "Build Guidata";


        }

        private async void Form2_Load(object sender, EventArgs e)
        {

            SocketTCP sckt = new SocketTCP();
            // Richiede due messaggi 
            pt.SetProtocolID("home"); pt.Data = "";
            string response = await sckt.send(pt);
            string responseData = "";
            do
            {
                responseData += await sckt.receive();
            } while (!responseData.Contains("\n"));

            int dim = 3;
            Preassemblato[] a = new Preassemblato[dim];
            a = JsonConvert.DeserializeObject<Preassemblato[]>(responseData);
            populateItems(a, dim);

            ricevuto = a;
            dimRicevuto = dim;


        }


        protected override void OnClosed(EventArgs e)
        {
            vecchioForm.Visible = true;
            base.OnClosed(e);
        }





        private void Home(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            listView.Items.Clear();
            listView.Visible=false ;

            this.restringiForm2();
            populateItems(ricevuto, dimRicevuto);

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



        private void populateItems(Preassemblato[] pre, int index)
        {
            //  Console.WriteLine(pre.Stampa());
            ListItem[] listItems = new ListItem[index];

            string[] vet = { "cpu", "schedaVideo", "memoria", "ram" };



            for (int i = 0; i < listItems.Length; i++) {

                // Console.Write("flowLayoutPanel1.Controls.Count: " + flowLayoutPanel1.Controls.Count);
                listItems[i] = new ListItem(flowLayoutPanel2, this,flowLayoutPanel1);

                listItems[i].pre = pre[i];
                listItems[i].Icon = Resources.imageNotFound1;
                listItems[i].IconBackground = Color.SteelBlue;
                listItems[i].Title = "Nome: " + pre[i].Nome + " Prezzo: " + pre[i].Prezzo;//"qui si mette il titolo";


                string message = "";
                //8 come il numero dei componenti
                for (int j = 0; j < 8; j++)
                {
                    if (Array.Exists(vet, x => x == pre[i].Componenti[j].Categoria))
                    {
                        message += pre[i].Componenti[j].Categoria + ": " + pre[i].Componenti[j].Marca + " " + pre[i].Componenti[j].Modello;

                        if (int.Parse(pre[i].Componenti[j].Capienza) > 0) {
                            message += " " + pre[i].Componenti[j].Capienza + " GB";
                        }

                        message += "\n";
                    }

                }
                listItems[i].Message = message;

                //aggiunge al flow label
                if (flowLayoutPanel1.Controls.Count < 0) {

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

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModificaProfilo mdp = new ModificaProfilo(pt);
            mdp.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vecchioForm.Visible = true;
            this.Close();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void populateItemsBuildG()
        {
            //  Console.WriteLine(pre.Stampa());
            Profiles[] profiles = new Profiles[4];

            for (int i = 0; i < profiles.Length; i++)

            {//passo il flowLayoutPanel1 per poter chiamare la Clear() all'interno del Profiles
                profiles[i] = new Profiles(flowLayoutPanel1,listView);

                switch (i)
                {
                    case 0:


                        profiles[i].Title = "Basic";
                        profiles[i].Price = "a partire da 300€";
                        profiles[i].Message = "\n" + "► Socket AM4 with B450 chipset" + "\n" +
                                             "► Scheda grafica integrata" + "\n" +
                                             "► RAM 8GB DDR4 2133 MHz" + "\n" +
                                             "► SSD 250GB SATA" + "\n" +
                                             "► Bassi consumi " + "\n" +
                                             "► Ideale per navigare in Internet, guardare film e ascoltare musica";
                        break;

                    case 1:

                        profiles[i].Title = "Advanced";
                        profiles[i].Price = "a partire da 600€";
                        profiles[i].Message = "\n" + "► CPU Intel Core i3 Quad Core" + "\n" +
                                             "► Scheda grafica di fascia media" + "\n" +
                                             "► RAM 8GB DDR4 2400 MHz" + "\n" +
                                             "► SSD 500GB SATA" + "\n" +
                                             "► Consumi medi " + "\n" +
                                             "► Consigliato per il lavoro d'ufficio e per giocare ai videogiochi casualmente";
                        break;

                    case 2:

                        profiles[i].Title = "Gamer";
                        profiles[i].Price = "a partire da 1100€";
                        profiles[i].Message = "\n" + "► CPU Intel Core i5 11th gen 6 - Core" + "\n" +
                                             "► GPU NVidia RTX 3060 Ti or AMD RX 6700 XT" + "\n" +
                                             "► RAM 16GB DDR4 3000 MHz" + "\n" +
                                             "► SSD 1TB M.2 NVME" + "\n" +
                                             "► Consumi Alti " + "\n" +
                                             "► Consigliato per appassionati di videogiochi";
                        break;

                    case 3:
                        profiles[i].Title = "Pro";
                        profiles[i].Price = "a partire da 1800€";
                        profiles[i].Message = "\n" + "► CPU Intel Core i7/ i9 11th gen" + "\n" +
                                             "► GPU NVidia RTX 3070 / RTX 3080 Ti" + "\n" +
                                             "► RAM 16GB DDR4 3200 MHz" + "\n" +
                                             "► SSD 1TB M.2 NVME" + "\n" +
                                             "► Consumi Alti " + "\n" +
                                             "► Consigliato per lavori di modellazione 3d";
                        break;

                }




                //aggiunge al flow label
                if (flowLayoutPanel1.Controls.Count < 0)
                {

                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(profiles[i]);


            }
        }

        private async void populateItemsBuilSolo()
        {

            ComponentsSolo[] componentsSolo; 

            SocketTCP skt = new SocketTCP();
            pt.SetProtocolID("buildSolo"); pt.Token = ""; pt.Data = "";
            string ok = await skt.send(pt);

            Dictionary<string, int> order = new Dictionary<string, int>{
                { "schedaMadre",0 },{ "cpu",1 },{"ram",2},{"schedaVideo",3},
                {"alimentatore",4},{"casepc",5},{"memoria",6},{"dissipatore",7},
            };


            List<List<Componente>> myList = new List<List<Componente>>();
            for (int i = 0; i < 8; i++)
            {
                string okmsg = await skt.sendSingleMsg("ok");
                string nElements = await skt.receive();
                int n = int.Parse(nElements);
                okmsg = await skt.sendSingleMsg("ok");
                string response = "";
                do
                {
                    response += await skt.receive();
                } while (!response.Contains("\n"));

                Componente[] pezzo = new Componente[n];
                pezzo = JsonConvert.DeserializeObject<Componente[]>(response);
                List<Componente> singleComponent = pezzo.ToList();
                myList.Add(singleComponent);

                int index = 0;

                componentsSolo = new ComponentsSolo[myList.Count];

                foreach (List<Componente> subList in myList)
                {
                    componentsSolo[index] = new ComponentsSolo(listViewCarrello);

                    Console.WriteLine("Lista superiore://////////////////////////////////////");

                    componentsSolo[index].impostaCategoria(subList[0].Categoria);
                    foreach (Componente item in subList)
                    {


                        ListViewItem lvitem = new ListViewItem("" + item.Modello + "");
                        lvitem.SubItems.Add("" + item.Marca + "");
                        lvitem.SubItems.Add("" + item.Prezzo + "");
                        lvitem.SubItems.Add("" + item.Capienza + "");
                        lvitem.SubItems.Add("" + item.Categoria + "");

                        componentsSolo[index].addListView(lvitem);
                        Console.WriteLine("Modello: "+item.Modello+" Marca: "+item.Marca+" Prezzo: "+item.Prezzo);
                    }

                   
                    
                    index++;

                    //aggiunge al flow label
                    if (flowLayoutPanel1.Controls.Count < 0)
                    {

                        flowLayoutPanel1.Controls.Clear();
                    }
                    else
                        flowLayoutPanel1.Controls.Add(componentsSolo[i]);

                }
                
            }

        }

        private void buttonMyBuild_Click(object sender, EventArgs e)
        {
            //pulisco le tendine

            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();

            listView.Items.Clear();
            listView.Visible = false;

            this.restringiForm2();

            if (comboBox1.Text == "Build Guidata") {
                Console.WriteLine("valore combobox: " + comboBox1.Text);
                populateItemsBuildG();

            }
            else
            {
                populateItemsBuilSolo();
                Console.WriteLine("valore combobox: " + comboBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCatalog fcg = new FormCatalog();
            fcg.Show();
        }

        public void allargaForm2()
        { if (this.ClientSize.Width != 1293 && this.ClientSize.Height != 778)
            {
                this.ClientSize = new System.Drawing.Size(933, 632);
                flowLayoutPanel2.Visible = true;
            }
        }

        public void restringiForm2()
        { if (this.ClientSize.Width != 821 && this.ClientSize.Height != 778)
            {
                this.ClientSize = new System.Drawing.Size(616, 632);
                flowLayoutPanel2.Visible = false;
                
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
