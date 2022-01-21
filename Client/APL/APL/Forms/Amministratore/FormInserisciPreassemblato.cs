using APL.Connections;
using APL.Data;
using APL.Data.Detail;
using APL.UserControls.Amministratore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.Forms.Amministratore
{
    public partial class FormInserisciPreassemblato : Form
    {
        Protocol pt = new Protocol();
        bool disableCloseEvent;
        FormAmministratore parent;
        FormPleaseWait pleaseWait;
        public FormInserisciPreassemblato(FormAmministratore parent)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormAmministratore_FormClosing);
            disableCloseEvent = true;
            this.parent = parent;

            pleaseWait = new FormPleaseWait();
            
        }

        private Componente[] comp;
        private string modelloCpu, modelloSchedaMadre, modelloRam, modelloDissipatore;

        public void EnableCloseEvent() { this.disableCloseEvent = false;  }
        void FormAmministratore_FormClosing(object sender, FormClosingEventArgs e)
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
        private void FormInserisciPreassemblato_Load(object sender, EventArgs e)
        {
            

            pt.SetProtocolID("buildSolo");

            Dictionary<string, int> order = new Dictionary<string, int>{
                { "schedaMadre",0 },{ "cpu",1 },{"ram",2},{"schedaVideo",3},
                {"alimentatore",4},{"casepc",5},{"memoria",6},{"dissipatore",7},
            };
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.Send(pt.ToString());
            List<List<Componente>> myList = new List<List<Componente>>();
            
            for (int i = 0; i < 8; i++)
            {
                string nElements =  SocketTCP.Receive();
                int n = int.Parse(nElements);
                string response = String.Empty;
                response = SocketTCP.Receive();
                Componente[] pezzo = new Componente[n];
                pezzo = JsonConvert.DeserializeObject<Componente[]>(response);
                List<Componente> singleComponent = pezzo.ToList();
                pleaseWait.Show();
                myList.Add(singleComponent);
                
            }
            SocketTCP.GetMutex().ReleaseMutex();
            Debug.WriteLine(myList.Count());

            
            stampaComponentsPreassemblato(myList);
        }

        private void stampaComponentsPreassemblato(List<List<Componente>> myList)
        {
            ComponentsPreassemblato[] componentsPreassemblato;
            //---------------------------------------------------------------
            int index = 0;

            componentsPreassemblato = new ComponentsPreassemblato[myList.Count];

            foreach (List<Componente> subList in myList)
            {
                componentsPreassemblato[index] = new ComponentsPreassemblato(listViewPreassemblato);

                int i = 0;

                componentsPreassemblato[index].impostaCategoria(subList[0].Categoria);
                foreach (Componente item in subList)
                {
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

                //aggiunge al flow label
                if (flowLayoutPanel1.Controls.Count < 0)
                {

                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(componentsPreassemblato[index - 1]);

            }
        }

        private bool contaComponentiPreassemblati()
        {

            int i = 0;
            foreach (ListViewItem item in listViewPreassemblato.Items)
            {
                //verifichiamo che ci siano 8 elementi (che saranno di categorie diverse)
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text == "ram" || subItem.Text =="memoria" || subItem.Text == "cpu"||
                        subItem.Text == "schedaVideo" || subItem.Text == "schedaMadre" || subItem.Text == "dissipatore" ||
                        subItem.Text == "alimentatore" || subItem.Text == "casepc" ) { i++; }
                }

            }

            Debug.WriteLine("categoria i: "+ i);
            if (i == 8)
            {
                creaVettoreOrdinato();
                Debug.WriteLine("Conferma carrello ok");
                return true;
            }
            else
            {
                MessageBox.Show("Selezionare 8 componenti prima di premere Conferma", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        
        private void creaVettoreOrdinato()
        {
            string modello,marca,prezzo,capienza,categoria;
            comp = new Componente[8];

            Dictionary<string, int> order = new Dictionary<string, int>{
                { "cpu",0 },{ "schedaMadre",1 },{"schedaVideo",2},{"casepc",3},
                {"dissipatore",4},{"alimentatore",5},{"memoria",6},{"ram",7},
            };

            //scorriamo la lista
            foreach (ListViewItem item in listViewPreassemblato.Items)
            {
                modello = item.SubItems[0].Text.ToString();
                marca = item.SubItems[1].Text.ToString();
                prezzo = item.SubItems[2].Text.ToString();
                capienza = item.SubItems[3].Text.ToString();
                categoria = item.SubItems[4].Text.ToString();
                if (capienza == ""){capienza = "0";}

                comp[order[categoria]] = new Componente(modello,marca,float.Parse(prezzo),int.Parse(capienza),categoria);

            }
        }
        private void Conferma_Click(object sender, EventArgs e)
        {
            if(contaComponentiPreassemblati() && textBoxNome.Text!=string.Empty && textBoxPrezzo.Text != string.Empty )
            {
                PcPreassemblato pre = new PcPreassemblato(textBoxNome.Text,float.Parse( textBoxPrezzo.Text),comp);
                string jsonPreassemblato = JsonConvert.SerializeObject(pre);
                pt.SetProtocolID("inserimento_pre"); pt.Data = jsonPreassemblato;
                SocketTCP.GetMutex().WaitOne();
                SocketTCP.Send(pt.ToString());
                SocketTCP.GetMutex().ReleaseMutex();
            }
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            if (flowLayoutPanel1.Controls.Count >= 8)
            {
                pleaseWait.Close();
            }
        }

        private void buttonSvuotaLista_Click(object sender, EventArgs e)
        {
            listViewPreassemblato.Items.Clear();
        }

        private void buttonRimuoviElemento_Click(object sender, EventArgs e)
        {
                if (listViewPreassemblato.SelectedItems.Count > 0)
                {
                    ListViewItem item = listViewPreassemblato.SelectedItems[0];
                   

                    //rimuoviamo l'elemento selezionato dalla listViewPreassemblato
                    listViewPreassemblato.Items.Remove(item);

                }
                else
                {
                    MessageBox.Show("Nessun componente è stato selezionato",
                              "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void buttonControllaCompatibilita_Click(object sender, EventArgs e)
        {
            
            if (listViewPreassemblato.Items.Count == 8)
            {
                recuperaDetailCpuSchedaMadreRamDissipatore();
                labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore: Assente";
                labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre: Assente";
                labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre: Assente";
            }
            else
            {
                MessageBox.Show("Selezionare 8 componenti prima di controllare la compatibilità", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string[] recuperaModelloCpuSchedaMadreRamDissipatore()
        {
            string[] modelli=new string[4];
            foreach (ListViewItem item in listViewPreassemblato.Items)
            {
                switch (item.SubItems[4].Text.ToString())
                {
                    case "cpu":
                        modelli[0] = item.SubItems[0].Text.ToString();
                        break;
                    case "schedaMadre":
                        modelli[1] = item.SubItems[0].Text.ToString();
                        break;
                    case "ram":
                        modelli[2] = item.SubItems[0].Text.ToString();
                        break;
                    case "dissipatore":
                        modelli[3] = item.SubItems[0].Text.ToString();
                        break;
                }
            }

            return modelli;
        }

        private async void recuperaDetailCpuSchedaMadreRamDissipatore()
        {
            string[] modelli=recuperaModelloCpuSchedaMadreRamDissipatore();
            string[] categorie = { "cpu", "schedaMadre", "ram", "dissipatore" };

            Details[] MyDetails = new Details[4];
            pt.Data = "";pt.SetProtocolID("compatibilita");
            for (int i = 0; i < modelli.Length; i++)
            {
                pt.Data += modelli[i] + "#";
            }

            string cat="";
            for (int i = 0; i < categorie.Length; i++)
            {
                cat += categorie[i] + "#";
            }

            cat += "\n";
            SocketTCP.GetMutex().WaitOne();

            SocketTCP.Send(pt.ToString());
            SocketTCP.Send(cat);

            ConstructorDetail factory = new ConstructorDetail();
           
            for (int i = 0; i < 4; i++)
            {
                string detailMsg=SocketTCP.Receive();
                Details componenteF = factory.GetDetails(categorie[i]);
                Type categoria = componenteF.GetType();
                MyDetails[i] = (Details)JsonConvert.DeserializeObject(detailMsg, categoria);
                Debug.WriteLine(MyDetails[i].Modello);
            }
            SocketTCP.GetMutex().ReleaseMutex();

            string[] vet = MyDetails[0].getDetail();
            string cpuSocket = vet[1];

            vet = MyDetails[1].getDetail();
            string cpuSocketSchedaMadre = vet[0];
            string ramSchedaMadre = vet[1];

            vet = MyDetails[2].getDetail();
            string standardRam = vet[1];

            string[] cpuSocketDissipatore = MyDetails[3].getDetail();

            foreach (string tipoSocket in cpuSocketDissipatore)
            {
                if(tipoSocket== cpuSocket)
                {
                    labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore: Presente";
                }
            }

            if(cpuSocketSchedaMadre== cpuSocket)
            {
                labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre: Presente";
            }

            if(standardRam== ramSchedaMadre)
            {
                labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre: Presente";
            }
            

        }
    }
}
