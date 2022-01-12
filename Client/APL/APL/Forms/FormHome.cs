using APL.Connections;
using APL.Data;
using APL.Properties;
using APL.UserControls;
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
using System.Diagnostics;
using ListViewItem = System.Windows.Forms.ListViewItem;

using MessageBox = System.Windows.Forms.MessageBox;

namespace APL.Forms
{
    public partial class FormHome : Form
    {

        Protocol pt = new Protocol();
        FormLogin_Register parent;
        PcPreassemblato[] ricevuto;
        int dimRicevuto;
        FormCarrello carrelloForm;

        public FormHome(FormLogin_Register f_start, string token)
        {
            InitializeComponent();
            parent = f_start;
            this.pt.Token = token;
            comboBox1.Text = "Build Guidata";
            carrelloForm = new FormCarrello(pt.Token);
        }

        private async void FormHome_Load(object sender, EventArgs e)
        {
            // Richiede due messaggi 
            pt.SetProtocolID("home"); pt.Data = String.Empty;
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            string responseData = String.Empty;
            do
            {
                responseData += await SocketTCP.receive();
            } while (!responseData.Contains("\n"));
            SocketTCP.GetMutex().ReleaseMutex();
            int dim = 3;
            PcPreassemblato[] a = new PcPreassemblato[dim];
            a = JsonConvert.DeserializeObject<PcPreassemblato[]>(responseData);
            populateItems(a, dim);
            ricevuto = a;
            dimRicevuto = dim;
        }


        protected override void OnClosed(EventArgs e)
        {
            parent.Visible = true;
            carrelloForm.EnableCloseEvent();
            carrelloForm.Close();
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

       

        private void populateItems(PcPreassemblato[] pre, int index)
        {
            //  Console.WriteLine(pre.Stampa());
            ListItem[] listItems = new ListItem[index];

            string[] vet = { "cpu", "schedaVideo", "memoria", "ram" };



            for (int i = 0; i < listItems.Length; i++) {

               Debug.Write("pre:" +pre[i]);
                listItems[i] = new ListItem(flowLayoutPanel2, this, flowLayoutPanel1, carrelloForm.getListView());
                listItems[i].pre = pre[i];
                listItems[i].Icon = Resources.preassemblato;
                listItems[i].IconBackground = Color.SteelBlue;
                listItems[i].NomeModello = pre[i].Nome;
                listItems[i].Prezzo = pre[i].Prezzo;

                string message = "";
                //8 come il numero dei componenti
                for (int j = 0; j < 8; j++)
                {
                    if (Array.Exists(vet, x => x == pre[i].Componenti[j].Categoria))
                    {
                        message += pre[i].Componenti[j].Categoria + ": " + pre[i].Componenti[j].Marca + " " + pre[i].Componenti[j].Modello;

                        if (pre[i].Componenti[j].Capienza > 0) {
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

        private void buttonCarrello_Click(object sender, EventArgs e)
        {
            carrelloForm.Show();

           

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormModificaProfilo mdp = new FormModificaProfilo(pt);
            mdp.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pt.Token = String.Empty;
            parent.Visible = true;
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
                profiles[i] = new Profiles(flowLayoutPanel1,listView, carrelloForm.getListView(),pt.Token);

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
            pt.SetProtocolID("buildSolo");

            Dictionary<string, int> order = new Dictionary<string, int>{
                { "schedaMadre",0 },{ "cpu",1 },{"ram",2},{"schedaVideo",3},
                {"alimentatore",4},{"casepc",5},{"memoria",6},{"dissipatore",7},
            };
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            List<List<Componente>> myList = new List<List<Componente>>();
            for (int i = 0; i < 8; i++)
            {
                SocketTCP.sendSingleMsg("ok");
                string nElements = await SocketTCP.receive();
                int n = int.Parse(nElements);
                SocketTCP.sendSingleMsg("ok");
                string response = String.Empty;
                do
                {
                    response += await SocketTCP.receive();
                } while (!response.Contains("\n"));
                Componente[] pezzo = new Componente[n];
                pezzo = JsonConvert.DeserializeObject<Componente[]>(response);
                List<Componente> singleComponent = pezzo.ToList();
                myList.Add(singleComponent);  
            }
            SocketTCP.GetMutex().ReleaseMutex();
            Debug.WriteLine(myList.Count());

            stampaComponentsSolo(myList);
        }


        private void stampaComponentsSolo(List<List<Componente>> myList)
        {
            ComponentsSolo[] componentsSolo;
            //---------------------------------------------------------------
            int index = 0;
            
            componentsSolo = new ComponentsSolo[myList.Count];

            foreach (List<Componente> subList in myList)
            {
                componentsSolo[index] = new ComponentsSolo(carrelloForm.getListView());

                int i = 0;

                componentsSolo[index].impostaCategoria(subList[0].Categoria);
                foreach (Componente item in subList)
                {
                    ListViewItem lvitem = new ListViewItem("" + item.Modello + "");
                    lvitem.SubItems.Add("" + item.Marca + "");
                    lvitem.SubItems.Add("" + item.Prezzo + "");
                    lvitem.SubItems.Add("" + item.Capienza + "");
                    lvitem.SubItems.Add("" + item.Categoria + "");

                    componentsSolo[index].addListView(lvitem);
                    i++;
                }
                Debug.WriteLine("" + subList[0].Categoria + " numero: " + i);
                index++;

                //aggiunge al flow label
                if (flowLayoutPanel1.Controls.Count < 0)
                {

                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(componentsSolo[index-1]);

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
                Debug.WriteLine("valore combobox: " + comboBox1.Text);
                populateItemsBuildG();

            }
            else
            {
                populateItemsBuilSolo();
                Debug.WriteLine("valore combobox: " + comboBox1.Text);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormCatalogo fcg = new FormCatalogo(pt.Token);
            fcg.Show();
        }

        public void allargaForm2()
        { if (this.ClientSize.Width != 1293 && this.ClientSize.Height != 778)
            {
                //this.ClientSize = new System.Drawing.Size(933, 632);
                this.ClientSize = new System.Drawing.Size(1238, 972);
                flowLayoutPanel2.Visible = true;
            }
        }

        public void restringiForm2()
        { if (this.ClientSize.Width != 821 && this.ClientSize.Height != 778)
            {
                //this.ClientSize = new System.Drawing.Size(616, 632);
                this.ClientSize = new System.Drawing.Size(819, 972);
                flowLayoutPanel2.Visible = false;
                
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cronologiaOrdiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            FormAcquistiPassati acquistiPassati = new FormAcquistiPassati(pt.Token);
            acquistiPassati.Show();

        }

       
    }
}
