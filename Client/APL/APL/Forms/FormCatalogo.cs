﻿using APL.Connections;
using APL.Data;
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
using System.Diagnostics;
using APL.Controlli;

namespace APL.Forms
{
    public partial class FormCatalogo : Form
    {
        Protocol pt = new Protocol();
        public FormCatalogo(String token)
        {
            InitializeComponent();
            pt.SetProtocolID("catalogo"); 
            pt.Token = token;

            comboBoxPrezzo.Text = "Ascendente";
        }

        private List<Componente> listaComponenti;

        private  void cpu_Click(object sender, EventArgs e)
        {
            pt.Data =  cpuButton.Text;
             GetElements( pt);
        }


        private  void schedaMadre_Click(object sender, EventArgs e)
        {
            pt.Data = schedaMadreButton.Text;
            GetElements(pt);
        }

        private  void ram_Click(object sender, EventArgs e)
        {
            pt.Data = ramButton.Text;
            GetElements(pt);
        }

        private  void memoria_Click(object sender, EventArgs e)
        {
            pt.Data = memoriaButton.Text;
            GetElements(pt);
        }

        private  void alimentatore_Click(object sender, EventArgs e)
        {
            pt.Data = alimentatoreButton.Text;
            GetElements(pt);

        }

        private  void schedaVideo_Click(object sender, EventArgs e)
        {
            pt.Data = schedaVideoButton.Text;
            GetElements(pt);
        }

        private  void casepc_Click(object sender, EventArgs e)
        {
            pt.Data = casepcButton.Text;
            GetElements(pt);
        }

        private  void dissipatore_Click(object sender, EventArgs e)
        {
            pt.Data = dissipatoreButton.Text;
            GetElements(pt);
        }

        private void buttonAggiungi_Click(object sender, EventArgs e)
        {
            if (listViewCatalogo.Items.Count < 3)
            {
                if (listView_record.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView_record.SelectedItems[0];
                   
                    string modello = item.SubItems[0].Text.ToString();
                    string marca = item.SubItems[1].Text.ToString();
                    string prezzo = item.SubItems[2].Text.ToString();
                    string capienza = item.SubItems[3].Text.ToString();
                    string categoria = item.SubItems[4].Text.ToString();

                    //rimuoviamo l'elemento selezionato dalla listView_record
                    listView_record.Items.Remove(listView_record.SelectedItems[0]);
                    ListViewItem lvitem = new ListViewItem("" + modello + "");
                    lvitem.SubItems.Add("" + marca + "");
                    lvitem.SubItems.Add("" + prezzo + "");
                    lvitem.SubItems.Add("" + capienza + "");
                    lvitem.SubItems.Add("" + categoria + "");
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
                string marca = item.SubItems[1].Text.ToString();
                string prezzo = item.SubItems[2].Text.ToString();
                string capienza = item.SubItems[3].Text.ToString();
                string categoria = item.SubItems[4].Text.ToString();

                //rimuoviamo l'elemento selezionato dalla listViewCatalogo
                listViewCatalogo.Items.Remove(listViewCatalogo.SelectedItems[0]);
                ListViewItem lvitem = new ListViewItem("" + modello + "");
                lvitem.SubItems.Add("" + marca + "");
                lvitem.SubItems.Add("" + prezzo + "");
                lvitem.SubItems.Add("" + capienza + "");
                lvitem.SubItems.Add("" + categoria + "");
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
                string[] capienze = new string[listViewCatalogo.Items.Count];
                string categoria="default";
                
                for(int i=0;i< listViewCatalogo.Items.Count; i++)
                {
                    ListViewItem item = listViewCatalogo.Items[i];
                    modelli[i] = item.SubItems[0].Text.ToString();
                    prezzi[i] = item.SubItems[2].Text.ToString();
                    capienze[i] = item.SubItems[3].Text.ToString();
                    categoria = item.SubItems[4].Text.ToString();
                    Debug.WriteLine(modelli[i] + " " + prezzi[i] + " " + categoria+ " capienza:"+capienze[i]);
                }
                FormConfronto cf = new FormConfronto(modelli,prezzi, capienze,categoria,pt.Token);
                cf.Show();
            }
            else
            {
                MessageBox.Show("Per avviare il confronto bisogna scegliere almeno un componente",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private async void GetElements(Protocol pt) {
            listaComponenti = new List<Componente>();

            string response = String.Empty;
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            // n elem
            string nelem = await SocketTCP.receive();
            Componente[] cp = new Componente[int.Parse(nelem)];
            SocketTCP.sendSingleMsg("ok");
            do
            {
                response += await SocketTCP.receive();
            } while (!response.Contains("\n"));
            SocketTCP.GetMutex().ReleaseMutex() ;

            cp = JsonConvert.DeserializeObject<Componente[]>(response);
            Debug.WriteLine(response);

            listView_record.Items.Clear();
            listViewCatalogo.Items.Clear();

            for (int i = 0; i < cp.Length; i++)
            {
                ListViewItem lvitem = new ListViewItem("" + cp[i].Modello + "");
                lvitem.SubItems.Add("" + cp[i].Marca + "");
                lvitem.SubItems.Add("" + cp[i].Prezzo + "");

                if(cp[i].Categoria!="ram" && cp[i].Categoria != "memoria")
                {lvitem.SubItems.Add("");}
                else{lvitem.SubItems.Add("" + cp[i].Capienza + "");}
                
                lvitem.SubItems.Add("" + cp[i].Categoria + "");
                listView_record.Items.Add(lvitem);

                //salvo tutti i componenti appena ricevuti in una lista
                listaComponenti.Add(new Componente(cp[i].Modello, cp[i].Marca, cp[i].Prezzo, cp[i].Capienza, cp[i].Categoria));
            }
            Debug.WriteLine("fine del for");
        }

        private void buttonOrdinaPerPrezzo_Click(object sender, EventArgs e)
        {
            if (listaComponenti != null)
            {
                if (comboBoxPrezzo.Text == "Ascendente")
                {
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderBy(x => x.Prezzo);
                    cambiaOrdineListView(listaComponentiOrdinata);
                }
                else
                {
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderByDescending(x => x.Prezzo);
                    cambiaOrdineListView(listaComponentiOrdinata);
                }
            }
            
        }


        private void buttonOrdinaPerMarca_Click(object sender, EventArgs e)
        {
            if (listaComponenti != null)
            {
                if (comboBoxPrezzo.Text == "Ascendente")
                {
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderBy(x => x.Marca);
                    cambiaOrdineListView(listaComponentiOrdinata);
                }
                else
                {
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderByDescending(x => x.Marca);
                    cambiaOrdineListView(listaComponentiOrdinata);
                }
            }
        }

        private void buttonOrdinaPerCapienza_Click(object sender, EventArgs e)
        {
            if (listaComponenti != null)
            {
                if (comboBoxPrezzo.Text == "Ascendente" && (listaComponenti[0].Categoria=="ram" || listaComponenti[0].Categoria == "memoria"))
                {
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderBy(x => x.Capienza);
                    cambiaOrdineListView(listaComponentiOrdinata);
                }
                else if (listaComponenti[0].Categoria == "ram" || listaComponenti[0].Categoria == "memoria")
                {
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderByDescending(x => x.Capienza);
                    cambiaOrdineListView(listaComponentiOrdinata);
                }
            }
        }

        private void buttonOrdinaPerModello_Click(object sender, EventArgs e)
        {
            if (listaComponenti != null)
            {
                if (comboBoxPrezzo.Text == "Ascendente")
                {
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderBy(x => x.Modello);
                    cambiaOrdineListView(listaComponentiOrdinata);
                }
                else
                {
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderByDescending(x => x.Modello);
                    cambiaOrdineListView(listaComponentiOrdinata);
                }
            }
        }

        private void cambiaOrdineListView(IOrderedEnumerable<Componente> listaComponentiOrdinata)
        {
            listView_record.Items.Clear();

            foreach (Componente item in listaComponentiOrdinata)
            {
                ListViewItem lvitem = new ListViewItem("" + item.Modello + "");
                lvitem.SubItems.Add("" + item.Marca + "");
                lvitem.SubItems.Add("" + item.Prezzo + "");

                if (item.Categoria != "ram" && item.Categoria != "memoria")
                { lvitem.SubItems.Add(""); }
                else { lvitem.SubItems.Add("" + item.Capienza + ""); }

                lvitem.SubItems.Add("" + item.Categoria + "");
                listView_record.Items.Add(lvitem);

            }


        }

   
    }
}
