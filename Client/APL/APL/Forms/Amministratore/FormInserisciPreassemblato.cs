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
    }
}
