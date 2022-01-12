using APL.Connections;
using APL.Data;
using APL.UserControls.Amministratore;
using Newtonsoft.Json;
using System;
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
        public FormInserisciPreassemblato()
        {
            InitializeComponent();
        }

        private Componente[] comp;

        private async void FormInserisciPreassemblato_Load(object sender, EventArgs e)
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
            
            string modello;
            string marca;
            string prezzo;
            string capienza;
            string categoria;
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
               Debug.WriteLine("pre: "+pre.Nome);
            }
        }
    }
}
