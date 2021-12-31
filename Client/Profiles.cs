﻿using Client.Connection;
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
            pt.SetProtocolID("profilo");pt.Token="";pt.Data = nameProfile;
            string ok = await skt.send(pt);

            Dictionary<string, int> order = new Dictionary<string, int>{
                { "schedaMadre",0 },{ "cpu",1 },{"ram",2},{"schedaVideo",3},
                {"alimentatore",4},{"casepc",5},{"memoria",6},{"dissipatore",7},
            };
            Componente[,] showElements = new Componente[8, 3];
            for (int i = 0; i < componentsTab.Length; i++) { 
                string okmsg = await skt.sendSingleMsg("ok");
                componentsTab[i] = new ComponentsTab();
                string response = "";
                do
                {
                    response += await skt.receive();
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

                    componentsTab[i].Icon1 = Resources.imageNotFound2;
                    componentsTab[i].Message1 = showElements[i, 0].Modello ;

                    componentsTab[i].Icon2 = Resources.imageNotFound2;
                    componentsTab[i].Message2 = showElements[i, 1].Modello;

                    componentsTab[i].Icon3 = Resources.imageNotFound2;
                    componentsTab[i].Message3 = showElements[i, 2].Modello;

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
