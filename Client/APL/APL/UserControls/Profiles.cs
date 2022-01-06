﻿using APL.Connections;
using APL.Data;
using APL.Properties;
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
namespace APL.UserControls
{
    public partial class Profiles : UserControl
    {
        FlowLayoutPanel vecchioFlowLayoutPanel1;
        Protocol pt = new Protocol();
        ListView vecchialistView;
        SocketTCP sckt;
        ListView vecchioCarrello;

        public Profiles(FlowLayoutPanel vfp1,ListView vlw,ListView carrello, string Token,SocketTCP sckt)
        {
            InitializeComponent();
            vecchioFlowLayoutPanel1 = vfp1;
            vecchialistView = vlw;
            pt.Token = Token;  
            this.sckt = sckt;
            vecchioCarrello = carrello;
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
            ComponentsGuidata[] componentsTab = new ComponentsGuidata[8];
            pt.SetProtocolID("profilo");pt.Data = nameProfile;
            sckt.send(pt);

            Dictionary<string, int> order = new Dictionary<string, int>{
                { "schedaMadre",0 },{ "cpu",1 },{"ram",2},{"schedaVideo",3},
                {"alimentatore",4},{"casepc",5},{"memoria",6},{"dissipatore",7},
            };
            Componente[,] showElements = new Componente[8, 3];
            for (int i = 0; i < componentsTab.Length; i++) { 
                sckt.sendSingleMsg("ok");
                componentsTab[i] = new ComponentsGuidata(vecchialistView,vecchioCarrello,pt.Token,sckt);
                string response = "";
                do
                {
                    response += await sckt.receive();
                } while (!response.Contains("\n"));

                Componente[] pezzo = new Componente[3];
                pezzo = JsonConvert.DeserializeObject<Componente[]>(response);
                int idx = order[pezzo[0].Categoria]; 
                for (int j = 0; j < 3; j++){
                    showElements[idx,j] = new Componente();
                    showElements[idx, j] = pezzo[j];
                }

            }
                //ci sono 8 iterazionei, una per ogni componente
                for (int i = 0; i < componentsTab.Length; i++){
                    componentsTab[i].Title = showElements[i,0].Categoria;//"qui si mette il titolo";

                    componentsTab[i].Icon1 = Resources.ImageNotFound2;
                    componentsTab[i].MostraModello1 = showElements[i, 0].Modello ;
                    componentsTab[i].Componente1= showElements[i, 0];

                    componentsTab[i].Icon2 = Resources.ImageNotFound2;
                    componentsTab[i].MostraModello2 = showElements[i, 1].Modello;
                    componentsTab[i].Componente2 = showElements[i, 1];

                    componentsTab[i].Icon3 = Resources.ImageNotFound2;
                    componentsTab[i].MostraModello3 = showElements[i, 2].Modello;
                    componentsTab[i].Componente3 = showElements[i, 2];

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
