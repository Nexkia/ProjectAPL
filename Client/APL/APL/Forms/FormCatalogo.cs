using APL.Cache;
using APL.Connections;
using APL.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormCatalogo : Form
    {
        private Protocol pt;
        private bool disableCloseEvent;
        public FormCatalogo()
        {
            InitializeComponent();
            pt = new Protocol();
            pt.SetProtocolID("catalogo");
            comboBoxPrezzo.Text = "Ascendente";

            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
        }

        #region Chiusura-----------------------------------------------------------
        public void EnableCloseEvent() { this.disableCloseEvent = false; }
        void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (disableCloseEvent == true)
            {
                //impedisce alla finestra di chiudersi
                e.Cancel = true;

                //rende la finestra invisibile
                this.Visible = false;
            }
            else { e.Cancel = false; } //permette alla finestra di chiudersi
        }
        #endregion



        #region Scarica Componenti------------------------------------------------------
        private void cpu_Click(object sender, EventArgs e)
        {
            if (recuperaListaDallaCache(cpuButton.Text) == false)
            {
                pt.Data = cpuButton.Text;
                GetElements(pt);
            }
            else
            {
                Debug.WriteLine("lista recuperata dalla cache///////////////////////");
            }


        }
        private void schedaMadre_Click(object sender, EventArgs e)
        {
            if (recuperaListaDallaCache(schedaMadreButton.Text) == false)
            {
                pt.Data = schedaMadreButton.Text;
                GetElements(pt);
            }
            else
            {
                Debug.WriteLine("lista recuperata dalla cache///////////////////////");
            }
        }
        private void ram_Click(object sender, EventArgs e)
        {
            if (recuperaListaDallaCache(ramButton.Text) == false)
            {
                pt.Data = ramButton.Text;
                GetElements(pt);
            }
            else
            {
                Debug.WriteLine("lista recuperata dalla cache///////////////////////");
            }
        }
        private void memoria_Click(object sender, EventArgs e)
        {
            if (recuperaListaDallaCache(memoriaButton.Text) == false)
            {
                pt.Data = memoriaButton.Text;
                GetElements(pt);
            }
            else
            {
                Debug.WriteLine("lista recuperata dalla cache///////////////////////");
            }
        }
        private void alimentatore_Click(object sender, EventArgs e)
        {
            if (recuperaListaDallaCache(alimentatoreButton.Text) == false)
            {
                pt.Data = alimentatoreButton.Text;
                GetElements(pt);
            }
            else
            {
                Debug.WriteLine("lista recuperata dalla cache///////////////////////");
            }
        }
        private void schedaVideo_Click(object sender, EventArgs e)
        {
            if (recuperaListaDallaCache(schedaVideoButton.Text) == false)
            {
                pt.Data = schedaVideoButton.Text;
                GetElements(pt);
            }
            else
            {
                Debug.WriteLine("lista recuperata dalla cache///////////////////////");
            }
        }
        private void casepc_Click(object sender, EventArgs e)
        {
            if (recuperaListaDallaCache(casepcButton.Text) == false)
            {
                pt.Data = casepcButton.Text;
                GetElements(pt);
            }
            else
            {
                Debug.WriteLine("lista recuperata dalla cache///////////////////////");
            }
        }
        private void dissipatore_Click(object sender, EventArgs e)
        {
            if (recuperaListaDallaCache(dissipatoreButton.Text) == false)
            {
                pt.Data = dissipatoreButton.Text;
                GetElements(pt);
            }
            else
            {
                Debug.WriteLine("lista recuperata dalla cache///////////////////////");
            }
        }

        private void GetElements(Protocol pt)
        {
            /*Esegue la richiesta al Server per recuperare la lista di componenti
            */
            List<Componente> listaComponenti = new();
            Componente[]? componenti;
            /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
            
            SocketTCP.Send(pt.ToString());
            string response = SocketTCP.Receive();
            
            /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
            try
            {
                componenti = JsonConvert.DeserializeObject<Componente[]>(response);
                Debug.WriteLine(response);

                listView_record.Items.Clear();
                listViewCatalogo.Items.Clear();
                if (componenti != null)
                {
                    for (int i = 0; i < componenti.Length; i++)
                    {
                        ListViewItem lvitem = new ListViewItem("" + componenti[i].Modello + "");
                        lvitem.SubItems.Add("" + componenti[i].Marca + "");
                        lvitem.SubItems.Add("" + componenti[i].Prezzo + "");

                        if (componenti[i].Categoria != "ram" && componenti[i].Categoria != "memoria")
                        { lvitem.SubItems.Add(""); }
                        else { lvitem.SubItems.Add("" + componenti[i].Capienza + ""); }

                        lvitem.SubItems.Add("" + componenti[i].Categoria + "");
                        listView_record.Items.Add(lvitem);

                        //salvo tutti i componenti appena ricevuti in una lista
                        listaComponenti.Add(new Componente()
                        {
                            Modello = componenti[i].Modello,
                            Marca = componenti[i].Marca,
                            Prezzo = componenti[i].Prezzo,
                            Capienza = componenti[i].Capienza,
                            Categoria = componenti[i].Categoria
                        });
                    }
                }
                //salvo la lista nella cache
                aggiungiListaInCache(listaComponenti);
            }
            catch (JsonException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion


        #region Buttons Confronto--------------------------------------------------
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
            if (listViewCatalogo.Items.Count > 0 && listViewCatalogo.Items.Count < 4)
            {
                string[] modelli = new string[listViewCatalogo.Items.Count];
                string[] prezzi = new string[listViewCatalogo.Items.Count];
                string[] capienze = new string[listViewCatalogo.Items.Count];
                string categoria = "default";

                for (int i = 0; i < listViewCatalogo.Items.Count; i++)
                {
                    ListViewItem item = listViewCatalogo.Items[i];
                    modelli[i] = item.SubItems[0].Text.ToString();
                    prezzi[i] = item.SubItems[2].Text.ToString();
                    capienze[i] = item.SubItems[3].Text.ToString();
                    categoria = item.SubItems[4].Text.ToString();
                    Debug.WriteLine(modelli[i] + " " + prezzi[i] + " " + categoria + " capienza:" + capienze[i]);
                }
                FormConfronto cf = new FormConfronto(modelli, prezzi, capienze, categoria);
                cf.Show();
            }
            else
            {
                MessageBox.Show("Per avviare il confronto bisogna scegliere almeno un componente",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion


        #region Ordina--------------------------------------------------------------
        private void buttonOrdinaPerPrezzo_Click(object sender, EventArgs e)
        {//recuperiamo dalla listVew la lista dei componenti
            List<Componente> listaComponenti = recuperaListaDallaListView();
            if (listaComponenti != null)
            {
                if (comboBoxPrezzo.Text == "Ascendente")
                {   //riordiniamo la lista
                    IOrderedEnumerable<Componente> listaComponentiOrdinata = listaComponenti.OrderBy(x => x.Prezzo);
                    cambiaOrdineListView(listaComponentiOrdinata);//rimettiamo i componenti nella listView
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
            List<Componente> listaComponenti = recuperaListaDallaListView();
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
            List<Componente> listaComponenti = recuperaListaDallaListView();
            if (listView_record.Items.Count > 0)
            {   //la lista viene ordinata solo se si ha ram o memoria come categoria
                if (comboBoxPrezzo.Text == "Ascendente" && (listaComponenti[0].Categoria == "ram" || listaComponenti[0].Categoria == "memoria"))
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
            List<Componente> listaComponenti = recuperaListaDallaListView();
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
        private List<Componente> recuperaListaDallaListView()
        {//recuperiamo i componenti dalla listView e li mettiamo dentro una lista
            List<Componente> lista = new List<Componente>();
            string modello, marca, categoria;
            float prezzo;
            int capienza;

            foreach (ListViewItem item in listView_record.Items)
            {
                modello = item.SubItems[0].Text.ToString();
                marca = item.SubItems[1].Text.ToString();
                prezzo = float.Parse(item.SubItems[2].Text.ToString());

                categoria = item.SubItems[4].Text.ToString();
                if (categoria != "ram" && categoria != "memoria")
                { capienza = 0; }
                else
                {
                    capienza = int.Parse(item.SubItems[3].Text.ToString());
                }

                lista.Add(new Componente()
                {
                    Modello = modello,
                    Marca = marca,
                    Prezzo = prezzo,
                    Capienza = capienza,
                    Categoria = categoria
                });
            }

            return lista;
        }
        private void cambiaOrdineListView(IOrderedEnumerable<Componente> listaComponentiOrdinata)
        {
            //inseriamo la lista ordinata all'interno della listView
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
        #endregion


        #region Cache----------------------------------------------------------------
        private void aggiungiListaInCache(List<Componente> lista)
        {
            CachingProviderBase.Instance.AddItem(lista[0].Categoria+ "BuildSolo", lista);
            Debug.WriteLine("lista inserita in cache: " + DateTime.Now + " ///////////////");
        }
        private bool recuperaListaDallaCache(string categoria)
        {
            List<Componente> message = CachingProviderBase.Instance.GetItem(categoria+ "BuildSolo");

            if (message == null) { return false; }

            listView_record.Items.Clear();
            foreach (Componente item in message)
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
            return true;
        }
        #endregion
    }

}
