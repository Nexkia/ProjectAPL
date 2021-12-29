using Client.Connection;
using Client.Data;
using Client.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    public partial class Profiles : UserControl
    {
        FlowLayoutPanel vecchioFlowLayoutPanel1;
        Protocol pt = new Protocol();
        public Profiles(FlowLayoutPanel vfp1)
        {
            InitializeComponent();
            vecchioFlowLayoutPanel1 = vfp1;
        }

        private string _title;

        public string Title{
            get { return _title; }
            set { _title = value; label1Prototypes.Text = value; }}
        public string Price{set {  label2Prototypes.Text = value; }}
        public string Message{set { label3Prototypes.Text = value; }}

        private void lblMessage_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void lblMessage_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void lbl_MessageClick1(object sender, EventArgs e)
        {
            Console.WriteLine(this.Title);
            vecchioFlowLayoutPanel1.Controls.Clear();
            populateItemsComponenti(this.Title);
        }

        private async void populateItemsComponenti(string nameProfile)
        {
            SocketTCP skt = new SocketTCP();
            ComponentsTab[] componentsTab = new ComponentsTab[8];
           // string[] vet = { "cpu", "schedaMadre","schedaVideo","casepc","dissipatore","alimentatore", "memoria", "ram" };
            pt.SetProtocolID("profilo");pt.Token="";pt.Data = nameProfile;
            string ok = await skt.send(pt);


            //ci sono 8 iterazionei, una per ogni componente
            for (int i = 0; i < componentsTab.Length; i++)

            {
                string okmsg = await skt.sendSingleMsg("ok"); 
                componentsTab[i] = new ComponentsTab();
                string responce = "";
                do
                {
                    responce += await skt.receive();
                } while (!responce.Contains("\n"));

                Componente[] pezzo = new Componente[3];
                pezzo = JsonConvert.DeserializeObject<Componente[]>(responce);
                
                        componentsTab[i].Title = pezzo[0].Categoria;//"qui si mette il titolo";

                        componentsTab[i].Icon1 = Resources.imageNotFound2;
                        componentsTab[i].Message1 =pezzo[0].Modello ;

                        componentsTab[i].Icon2 = Resources.imageNotFound2;
                        componentsTab[i].Message2 = pezzo[1].Modello;

                        componentsTab[i].Icon3 = Resources.imageNotFound2;
                        componentsTab[i].Message3 = pezzo[2].Modello;

                   

                 //aggiunge al flow label
                if (vecchioFlowLayoutPanel1.Controls.Count < 0)
                {

                    vecchioFlowLayoutPanel1.Controls.Clear();
                }
                else
                    vecchioFlowLayoutPanel1.Controls.Add(componentsTab[i]);


            }
        }

    }
}
