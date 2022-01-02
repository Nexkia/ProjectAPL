using Client.Connection;
using Client.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class FormCatalog : Form
    {
        Protocol pt = new Protocol();
        public FormCatalog()
        {
            InitializeComponent();
            pt.SetProtocolID("catalogo"); pt.Token = "";
        }

        private async void cpu_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data= cpuButton.Text;
            string response = String.Empty;
            string ok = await sckt.send(pt);
            // n elem
            string nelem = await sckt.receive();
            Componente[] cp = new Componente[int.Parse(nelem)];
            ok = await sckt.sendSingleMsg("ok");
            do
            {
                response += await sckt.receive();
            } while (!response.Contains("\n"));

            cp = JsonConvert.DeserializeObject<Componente[]>(response);
            Console.WriteLine(response);


            


            for (int i = 0; i < cp.Length; i++){
                
                ListViewItem lvitem = new ListViewItem("" + cp[i].Modello + "");
                lvitem.SubItems.Add("" + cp[i].Categoria + "");
                lvitem.SubItems.Add("" + cp[i].Marca+ "");
                lvitem.SubItems.Add("" + cp[i].Prezzo + "");
                
                listView_record.Items.Add(lvitem);
                
            }
            Console.WriteLine("fine del for");
           // Confronto cf = new Confronto(cp[0],cp[1]);
           // cf.Show();
        }


        private async void schedaMadre_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = schedaMadreButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);
        }

        private async void ram_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = ramButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);
        }

        private async void memoria_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = memoriaButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);
        }

        private async void alimentatore_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = alimentatoreButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);
        }

        private async void schedaVideo_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = schedaVideoButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);

        }

        private async void casepc_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = casepcButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);

        }

        private async void dissipatore_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = dissipatoreButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void FormCatalog_Load(object sender, EventArgs e)
        {

        }

        private void buttonAggiungi_Click(object sender, EventArgs e)
        {
            if (listViewCatalogo.Items.Count < 3)
            {
                if (listView_record.SelectedItems.Count > 0)
                {


                    ListViewItem item = listView_record.SelectedItems[0];


                    string modello = item.SubItems[0].Text.ToString();
                    string categoria = item.SubItems[1].Text.ToString();
                    string marca = item.SubItems[2].Text.ToString();
                    string prezzo = item.SubItems[3].Text.ToString();

                    //rimuoviamo l'elemento selezionato dalla listView_record
                    listView_record.Items.Remove(listView_record.SelectedItems[0]);


                    ListViewItem lvitem = new ListViewItem("" + modello + "");
                    lvitem.SubItems.Add("" + categoria + "");
                    lvitem.SubItems.Add("" + marca + "");
                    lvitem.SubItems.Add("" + prezzo + "");
                    

                    listViewCatalogo.Items.Add(lvitem);

                }
                else
                {
                    MessageBox.Show("Nessun componente è stato selezionato",
                              "Errore Aggiungi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("E' stato raggiunto il numero massimo di componenti",
                              "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void buttonRimuovi_Click(object sender, EventArgs e)
        {
            if (listViewCatalogo.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewCatalogo.SelectedItems[0];


                string modello = item.SubItems[0].Text.ToString();
                string categoria = item.SubItems[1].Text.ToString();
                string marca = item.SubItems[2].Text.ToString();
                string prezzo = item.SubItems[3].Text.ToString();
                

                //rimuoviamo l'elemento selezionato dalla listViewCatalogo
                listViewCatalogo.Items.Remove(listViewCatalogo.SelectedItems[0]);


                ListViewItem lvitem = new ListViewItem("" + modello + "");
                lvitem.SubItems.Add("" + categoria + "");
                lvitem.SubItems.Add("" + marca + "");
                lvitem.SubItems.Add("" + prezzo + "");
                listView_record.Items.Add(lvitem);

            }
            else
            {
                MessageBox.Show("Nessun componente è stato selezionato",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonConfronta_Click(object sender, EventArgs e)
        {
            if (listViewCatalogo.Items.Count >0  && listViewCatalogo.Items.Count <4 )
            {
                ListViewItem item0 = listViewCatalogo.Items[0];

                string categoria1, modello1, marca1, prezzo1,
                       categoria2, modello2, marca2, prezzo2;

                categoria1 = modello1 = marca1 = prezzo1 =
                categoria2 = modello2 = marca2 = prezzo2 = "default";

                string modello0 = item0.SubItems[0].Text.ToString();
                string categoria0 = item0.SubItems[1].Text.ToString();
                string marca0 = item0.SubItems[2].Text.ToString();
                string prezzo0 = item0.SubItems[3].Text.ToString();

                if (listViewCatalogo.Items.Count >=2)
                {   ListViewItem item1 = listViewCatalogo.Items[1];
                     modello1 = item1.SubItems[0].Text.ToString();
                    categoria1 = item1.SubItems[1].Text.ToString();
                    marca1 = item1.SubItems[2].Text.ToString();
                     prezzo1 = item1.SubItems[3].Text.ToString();

                    if (listViewCatalogo.Items.Count == 3){
                        ListViewItem item2 = listViewCatalogo.Items[2];
                        modello2 = item2.SubItems[0].Text.ToString();
                        categoria2 = item2.SubItems[1].Text.ToString();
                         marca2 = item2.SubItems[2].Text.ToString();
                        prezzo2 = item2.SubItems[3].Text.ToString();}
                }

               

               
                if (categoria2 == "default" && categoria1 == "default")  //c'è un solo componente
                {
                    Console.WriteLine("C'è un solo componente");
                    Console.WriteLine("modello0: " + modello0 + " modello1: " + modello1 + " modello2: " + modello2);
                    Console.WriteLine("marca0: " + marca0 + " marca1: " + marca1 + " marca2: " + marca2);
                    Console.WriteLine("prezzo0: " + prezzo0 + " prezzo1: " + prezzo1 + " prezzo2: " + prezzo2);

                }
                else if (categoria2 == "default")//ci sono 2 componenti
                {
                    Console.WriteLine("Ci sono 2 componenti");

                    if (categoria1 == categoria0)
                    {
                        Console.WriteLine("modello0: " + modello0 + " modello1: " + modello1 + " modello2: " + modello2);
                        Console.WriteLine("marca0: " + marca0 + " marca1: " + marca1 + " marca2: " + marca2);
                        Console.WriteLine("prezzo0: " + prezzo0 + " prezzo1: " + prezzo1 + " prezzo2: " + prezzo2);
                    }
                    else
                    {
                        MessageBox.Show("I 2 componenti selezionati devono appartenere alla stessa categoria",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                else //ci sono 3 componenti
                {
                    Console.WriteLine("Ci sono 3 componenti");
                    if (categoria1 == categoria0 && categoria0==categoria2)
                    {
                        Console.WriteLine("modello0: " + modello0 + " modello1: " + modello1 + " modello2: " + modello2);
                        Console.WriteLine("marca0: " + marca0 + " marca1: " + marca1 + " marca2: " + marca2);
                        Console.WriteLine("prezzo0: " + prezzo0 + " prezzo1: " + prezzo1 + " prezzo2: " + prezzo2);
                    }
                    else
                    {
                        MessageBox.Show("I 3 componenti selezionati devono appartenere alla stessa categoria",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
            else
            {
                MessageBox.Show("Per avviare il confronto bisogna scegliere almeno un componente",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listViewCatalogo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
