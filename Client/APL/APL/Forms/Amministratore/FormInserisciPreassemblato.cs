using APL.Connections;
using APL.Data;
using APL.UserControls.Amministratore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace APL.Forms.Amministratore
{
    public partial class FormInserisciPreassemblato : Form
    {
        private Protocol pt;
        private bool disableCloseEvent;
        private FormAmministratore parent;
        private FormPleaseWait pleaseWait;
        public FormInserisciPreassemblato(FormAmministratore parent)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormAmministratore_FormClosing);
            disableCloseEvent = true;
            this.parent = parent;
            pt = new Protocol();
            pleaseWait = new FormPleaseWait();
            
        }

        private string cpuSocket = "";
        private string cpuSocketSchedaMadre = "", ramSchedaMadre = "";
        private string standardRam = "";
        private string[] cpuSocketDissipatore;

        private bool RamSchedaMadre=false;
        private bool CpuSchedaMadre=false;
        private bool CpuDissipatore=false;

        private Componente[] comp;

        #region setCpuSchedaMadreRamDissiptore----------------------------------------------
        public void setCpuDetail(string value)
        {
            cpuSocket = value; ControllaCompatibilita();
        }
        public void setSchedaMadreDetail(string cpu, string ram)
        {
            cpuSocketSchedaMadre = cpu; ramSchedaMadre = ram; ControllaCompatibilita();
        }
        public void setRamDetail(string value)
        {
            standardRam = value; ControllaCompatibilita();
        }
        public void setDissipatoreDetail(string[] value)
        {
            cpuSocketDissipatore = value; ControllaCompatibilita();
        }
        #endregion


        public ListView getListViewP() { return listViewPreassemblato; }
        public ListView getListViewD() { return listViewPreassemblatoDetail; }

        #region Chiusura-------------------------------------------------------------------------
        public void EnableCloseEvent() { this.disableCloseEvent = false;  }
        private void FormAmministratore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (disableCloseEvent == true)
            {
                //impedisce alla finestra di chiudersi
                e.Cancel = true;

                //rende la finestra invisibile
                this.Visible = false;
                parent.Visible = true;
            }
            else { e.Cancel = false; } //permette alla finestra di chiudersi
        }
        #endregion


        #region Caricamento dei Preassemblati------------------------------------------------------
        private void FormInserisciPreassemblato_Load(object sender, EventArgs e)
        {
            /*
             Creo una lista di liste componenti, per sapere quanti elementi
            sono presenti 
            */
            pt.SetProtocolID("buildSolo");
            List<List<Componente>> myList = new();
            /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());
            
            for (int i = 0; i < 8; i++)
            {
                string response =  SocketTCP.Receive();
                try
                {
                    Componente[]? elem = JsonConvert.DeserializeObject<Componente[]>(response);
                    if (elem != null)
                    {
                        List<Componente> singleComponent = elem.ToList();
                        pleaseWait.Show();
                        myList.Add(singleComponent);
                    }
                }
                catch (JsonException ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
            SocketTCP.Release();
            /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
            Debug.WriteLine(myList.Count());

            stampaComponentsPreassemblato(myList);
        }
        private void stampaComponentsPreassemblato(List<List<Componente>> myList)
        {
            ComponentsPreassemblato[] componentsPreassemblato;
            int index = 0;
            componentsPreassemblato = new ComponentsPreassemblato[myList.Count];

            //creo un componentsPreassemblato per ogni Lista (le liste sono in tutto 8 una per ogni categoria)
            foreach (List<Componente> subList in myList)
            {
                componentsPreassemblato[index] = new ComponentsPreassemblato(this);
                int i = 0;
               
                componentsPreassemblato[index].impostaCategoria(subList[0].Categoria);
                foreach (Componente item in subList)
                {
                    //inserisco una Lista dentro la listView dell'UserControl componentsPreassemblato
                    ListViewItem lvitem = new ListViewItem("" + item.Modello + "");
                    lvitem.SubItems.Add("" + item.Marca + "");
                    lvitem.SubItems.Add("" + item.Prezzo + "");
                    lvitem.SubItems.Add("" + item.Capienza + "");
                    lvitem.SubItems.Add("" + item.Categoria + "");

                    componentsPreassemblato[index].addListView(lvitem);
                    i++;
                }
                Debug.WriteLine("" + subList[0].Categoria + " numero: " + i);
                index++;

                //aggiunge al flowLayoutPnel l'UserControl componentsPreassemblato
                if (flowLayoutPanel1.Controls.Count < 0)
                    flowLayoutPanel1.Controls.Clear();
                else
                    flowLayoutPanel1.Controls.Add(componentsPreassemblato[index - 1]);
            }
        }
        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {//mostra il form con la scritta "Loading"
            if (flowLayoutPanel1.Controls.Count >= 8)
                pleaseWait.Close();
        }
        #endregion


        #region Conferma Preassemblato------------------------------------------------------------
        private void Conferma_Click(object sender, EventArgs e)
        {
            if (contaComponentiPreassemblati() && textBoxNome.Text != string.Empty && textBoxPrezzo.Text != string.Empty)
            {
                PcPreassemblato pre = new()
                {
                    Nome = textBoxNome.Text,
                    Prezzo = float.Parse(textBoxPrezzo.Text),
                    Componenti = comp
                };
                string jsonPreassemblato = JsonConvert.SerializeObject(pre);
                pt.SetProtocolID("inserimento_pre"); pt.Data = jsonPreassemblato;
                /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
                SocketTCP.Wait();
                SocketTCP.Send(pt.ToString());
                SocketTCP.Release();
                /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
                MessageBox.Show("Inserimento completato correttamente",
                  "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool contaComponentiPreassemblati()
        {
            int i = 0;
            foreach (ListViewItem item in listViewPreassemblato.Items)
            {
                //verifichiamo che ci siano 8 elementi (che devono essere di categorie diverse)
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text == "ram" || subItem.Text == "memoria" || subItem.Text == "cpu" ||
                        subItem.Text == "schedaVideo" || subItem.Text == "schedaMadre" || subItem.Text == "dissipatore" ||
                        subItem.Text == "alimentatore" || subItem.Text == "casepc") { i++; }
                }

            }

            Debug.WriteLine("categoria i: " + i);
            if (i == 8 && textBoxNome.Text != string.Empty && textBoxPrezzo.Text != string.Empty)
            {
                if (RamSchedaMadre == true && CpuSchedaMadre == true && CpuDissipatore == true)
                {
                    creaVettoreOrdinato();
                    Debug.WriteLine("Conferma carrello ok");
                    return true;
                }
                else
                {
                    MessageBox.Show("i componenti inseriti non sono compatibili",
                  "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            else
            {
                if (textBoxNome.Text == string.Empty || textBoxPrezzo.Text == string.Empty)
                {
                    MessageBox.Show("Selezionare 8 componenti prima di premere Conferma e riempire i campi 'Nome' e 'Prezzo'",
                        "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    MessageBox.Show("Selezionare 8 componenti prima di premere Conferma", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }


            }
        }
        private void ControllaCompatibilita()
        {
            RamSchedaMadre = false; CpuSchedaMadre = false;
            CpuDissipatore = false;
            if (ramSchedaMadre != "" && standardRam != "")
            {
                if (ramSchedaMadre == standardRam)
                    RamSchedaMadre = true;
            }

            if (cpuSocketSchedaMadre != "" && cpuSocket != "")
            {
                if (cpuSocketSchedaMadre == cpuSocket)
                    CpuSchedaMadre = true;
            }

            if (cpuSocketDissipatore != null && cpuSocket != "")
            {
                foreach (string tipoSocket in cpuSocketDissipatore)
                {
                    if (tipoSocket == cpuSocket)
                        CpuDissipatore = true;
                }
            }
        }
        private void creaVettoreOrdinato()
        {
            string modello, marca, prezzo, capienza, categoria;
            comp = new Componente[8];

            Dictionary<string, int> order = new Dictionary<string, int>{
                { "cpu",0 },{ "schedaMadre",1 },{"schedaVideo",2},{"casepc",3},
                {"dissipatore",4},{"alimentatore",5},{"memoria",6},{"ram",7},
            };

            //scorriamo la lista per ordinarla
            foreach (ListViewItem item in listViewPreassemblato.Items)
            {
                modello = item.SubItems[0].Text.ToString();
                marca = item.SubItems[1].Text.ToString();
                prezzo = item.SubItems[2].Text.ToString();
                capienza = item.SubItems[3].Text.ToString();
                categoria = item.SubItems[4].Text.ToString();
                if (capienza == "") { capienza = "0"; }

                comp[order[categoria]] = new Componente()
                {
                    Modello = modello,
                    Marca = marca,
                    Prezzo = float.Parse(prezzo),
                    Capienza = int.Parse(capienza),
                    Categoria = categoria
                };
            }
        }
        #endregion


        #region Buttons--------------------------------------------------------------------------
        private void buttonSvuotaLista_Click(object sender, EventArgs e)
        {
            listViewPreassemblato.Items.Clear();
            listViewPreassemblato.Items.Clear();
            cpuSocketDissipatore = null;
            cpuSocket = ""; cpuSocketSchedaMadre = ""; ramSchedaMadre = ""; standardRam = "";
        }
        private void buttonRimuoviElemento_Click(object sender, EventArgs e)
        {
            if (listViewPreassemblato.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewPreassemblato.SelectedItems[0];
                //rimuoviamo l'elemento selezionato dalla listViewPreassemblato
                listViewPreassemblato.Items.Remove(item);

                //in base alla categoria del componente rimosso, togliamo le corrispettive informazioni nella listViewDetail
                foreach (ListViewItem.ListViewSubItem SubItems in item.SubItems)
                {
                    switch (SubItems.Text)
                    {
                        case "cpu":
                            cpuSocket = "";
                            eliminaElementoListViewDetail("cpu");
                            break;

                        case "schedaMadre":
                            cpuSocketSchedaMadre = ""; ramSchedaMadre = "";
                            eliminaElementoListViewDetail("schedaMadre");
                            break;

                        case "dissipatore":
                            cpuSocketDissipatore = null;
                            eliminaElementoListViewDetail("dissipatore");
                            break;

                        case "ram":
                            standardRam = "";
                            eliminaElementoListViewDetail("ram");
                            break;
                    }
                }

            }
            else
            {
                MessageBox.Show("Nessun componente è stato selezionato",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void eliminaElementoListViewDetail(string categoria)
        {
            foreach (ListViewItem item in listViewPreassemblatoDetail.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text == categoria) 
                        item.Remove(); 
                }
            }
        }
        #endregion


        private void textBoxPrezzo_TextChanged(object sender, EventArgs e)
        {
            bool isInvalidPrezzo = textBoxPrezzo.Text.Contains(".");
            //permette di inserire solo dei Float nel prezzo
            if (!float.TryParse(textBoxPrezzo.Text, out float value))
                textBoxPrezzo.Text = "";
            if (isInvalidPrezzo)
                textBoxPrezzo.Text = "";
            if (textBoxPrezzo.Text == "0")
                textBoxPrezzo.Text = "1";
        }
    }
}
