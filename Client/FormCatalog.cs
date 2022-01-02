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

            listView_record.Items.Clear();
            listViewCatalogo.Items.Clear();

            for (int i = 0; i < cp.Length; i++){
                
                ListViewItem lvitem = new ListViewItem("" + cp[i].Modello + "");
                lvitem.SubItems.Add("" + cp[i].Categoria + "");
                lvitem.SubItems.Add("" + cp[i].Marca+ "");
                lvitem.SubItems.Add("" + cp[i].Prezzo + "");
                
                listView_record.Items.Add(lvitem);
                
            }
            Console.WriteLine("fine del for");
           
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
                string[] modelli = new string[listViewCatalogo.Items.Count];
                string[] prezzi=new string[listViewCatalogo.Items.Count];

                string categoria="default";
                
                for(int i=0;i< listViewCatalogo.Items.Count; i++)
                {
                    ListViewItem item = listViewCatalogo.Items[i];
                    
                    modelli[i] = item.SubItems[0].Text.ToString();
                    categoria = item.SubItems[1].Text.ToString();
                    prezzi[i] = item.SubItems[3].Text.ToString();
                    Console.WriteLine(modelli[i] + " " + prezzi[i] + " " + categoria);
                }

                Confronto cf = new Confronto(modelli,prezzi,categoria);
                cf.Show();

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

        private void listView_record_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
