using APL.Connections;
using APL.Data;
using APL.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
namespace APL.UserControls
{
    public partial class Profiles : UserControl
    {
        private FlowLayoutPanel vecchioFlowLayoutPanel1;
        private Protocol pt;
        private ListView vecchialistView;
        private ListView vecchioCarrello;

        public Profiles(FlowLayoutPanel vfp1,ListView vlw,ListView carrello)
        {
            InitializeComponent();
            vecchioFlowLayoutPanel1 = vfp1;
            vecchialistView = vlw;
            vecchioCarrello = carrello;
            pt = new Protocol();
        }

        private string _title;

        public string Title{
            get { return _title; }
            set { _title = value; label1Prototypes.Text = value; }}
        public string Price{set {  label2Prototypes.Text = value; }}
        public string Message{set { label3Prototypes.Text = value; }}
        private void lblMessage_MouseEnter(object sender, EventArgs e){this.BackColor = Color.Silver;}
        private void lblMessage_MouseLeave(object sender, EventArgs e){this.BackColor = Color.White;}

        private void lbl_MessageClick1(object sender, EventArgs e)
        {
            Debug.WriteLine(this.Title);
            vecchioFlowLayoutPanel1.Controls.Clear();
            populateItemsComponenti(this.Title);
        }

        private void populateItemsComponenti(string nameProfile)
        {
            Dictionary<string, string> nomeProfili = new Dictionary<string, string>{
                { "Basic","0" },{ "Advanced","1" },{"Gamer","2"},{"Pro","3"},
                {"Ultra","4"}
            };
            Dictionary<string, int> order = new Dictionary<string, int>{
                { "schedaMadre",0 },{ "cpu",1 },{"ram",2},{"schedaVideo",3},
                {"alimentatore",4},{"casepc",5},{"memoria",6},{"dissipatore",7},
            };
            ComponentsGuidata[] componentsTab = new ComponentsGuidata[8];
            Componente[,] showElements = new Componente[8, 3];

            pt.SetProtocolID("profilo");pt.Data = nomeProfili[nameProfile];
            SocketTCP.Wait();

            SocketTCP.Send(pt.ToString());
            for (int i = 0; i < componentsTab.Length; i++) {
                componentsTab[i] = new ComponentsGuidata(vecchialistView,vecchioCarrello);
                string response = SocketTCP.Receive();
                Componente[] elem = new Componente[3];
                elem = JsonConvert.DeserializeObject<Componente[]>(response);
                // Sono 3 elementi suggeriti con la stessa categoria per cui ottengo l'ordine 
                // con il primo elemento. L'ordine è dato dall'indice ottenuto dal dizionario
                int idx = order[elem[0].Categoria]; 
                for (int j = 0; j < 3; j++){
                    showElements[idx,j] = new Componente();
                    showElements[idx,j] = elem[j];
                }
            }
            SocketTCP.Release();
            //ci sono 8 iterazionei, una per ogni componente
            for (int i = 0; i < componentsTab.Length; i++){
                componentsTab[i].Title = showElements[i,0].Categoria;//"qui si mette il titolo";

            componentsTab[i].MostraModello1 = showElements[i, 0].Modello;
            componentsTab[i].Componente1= showElements[i, 0];

            componentsTab[i].MostraModello2 = showElements[i, 1].Modello;
            componentsTab[i].Componente2 = showElements[i, 1];

            componentsTab[i].MostraModello3 = showElements[i, 2].Modello;
            componentsTab[i].Componente3 = showElements[i, 2];

            addImg(componentsTab[i]);

            //aggiunge al flow label
            if (vecchioFlowLayoutPanel1.Controls.Count < 0)
                {
                    vecchioFlowLayoutPanel1.Controls.Clear();
                }
                else
                    vecchioFlowLayoutPanel1.Controls.Add(componentsTab[i]);
            }
        }

        private void addImg(ComponentsGuidata componentsTab)
        {
            string categoria = componentsTab.Title;

            switch (categoria)
            {
                case "schedaMadre":
                    componentsTab.Icon1 = Resources.schedaMadre;
                    componentsTab.Icon2 = Resources.schedaMadre;
                    componentsTab.Icon3 = Resources.schedaMadre;
                    break;
                case "schedaVideo":
                    componentsTab.Icon1 = Resources.schedaVideo;
                    componentsTab.Icon2 = Resources.schedaVideo;
                    componentsTab.Icon3 = Resources.schedaVideo;
                    break;
                case "cpu":
                    componentsTab.Icon1 = Resources.cpu;
                    componentsTab.Icon2 = Resources.cpu;
                    componentsTab.Icon3 = Resources.cpu;
                    break;
                case "ram":
                    componentsTab.Icon1 = Resources.ram;
                    componentsTab.Icon2 = Resources.ram;
                    componentsTab.Icon3 = Resources.ram;
                    break;
                case "alimentatore":
                    componentsTab.Icon1 = Resources.alimentatore;
                    componentsTab.Icon2 = Resources.alimentatore;
                    componentsTab.Icon3 = Resources.alimentatore;
                    break;
                case "dissipatore":
                    componentsTab.Icon1 = Resources.dissipatore;
                    componentsTab.Icon2 = Resources.dissipatore;
                    componentsTab.Icon3 = Resources.dissipatore;
                    break;
                case "casepc":
                    componentsTab.Icon1 = Resources.casepc;
                    componentsTab.Icon2 = Resources.casepc;
                    componentsTab.Icon3 = Resources.casepc;
                    break;
                case "memoria":
                    componentsTab.Icon1 = Resources.memoria;
                    componentsTab.Icon2 = Resources.memoria;
                    componentsTab.Icon3 = Resources.memoria;
                    break;
            }
            
        }

    }
}
