﻿using APL.Connections;
using APL.Data;
using APL.Data.Detail;
using APL.Forms.Amministratore;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore
{
    public partial class ComponentsPreassemblato : UserControl
    {
        private Protocol pt=new Protocol();
        private FormInserisciPreassemblato vecchioInserisciPreassemblato;
        public ComponentsPreassemblato(FormInserisciPreassemblato pre)
        {
            InitializeComponent();
            vecchioInserisciPreassemblato= pre;
        }

        private string categoria;
        private string modello;

        public void impostaCategoria(string value) { labelCategoria.Text = value; }

        public void addListView(ListViewItem value) { listViewComponentsPreassemblato.Items.Add(value); }

        private void buttonAggiungi_Click_1(object sender, EventArgs e)
        {
            if (listViewComponentsPreassemblato.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewComponentsPreassemblato.SelectedItems[0];

                modello = item.SubItems[0].Text.ToString();
                string marca = item.SubItems[1].Text.ToString();
                string prezzo = item.SubItems[2].Text.ToString();
                string capienza = item.SubItems[3].Text.ToString();
                categoria = item.SubItems[4].Text.ToString();

                ListViewItem lvitem = new ListViewItem("" + modello + "");
                lvitem.SubItems.Add("" + marca + "");
                lvitem.SubItems.Add("" + prezzo + "");
                if (categoria != "memoria" && categoria != "ram") { capienza = ""; }
                lvitem.SubItems.Add("" + capienza + "");
                lvitem.SubItems.Add("" + categoria + "");

                bool componentePresente = false;
                int i;

                foreach (ListViewItem elem in vecchioInserisciPreassemblato.getListViewP().Items)
                {
                    i = 0;
                    if (elem.Text == modello) { componentePresente = true; }

                    foreach (ListViewItem.ListViewSubItem subItem in elem.SubItems)
                    {
                        //evitiamo di mettere due componenti con la stessa categoria 
                        if (subItem.Text == categoria) { i++; }
                    }

                    if (i == 1)
                        componentePresente = true;
                }

                if (componentePresente == false)
                {
                    vecchioInserisciPreassemblato.getListViewP().Items.Add(lvitem);
                    if ((categoria == "cpu") || (categoria == "schedaMadre")|| (categoria == "dissipatore") || (categoria == "ram"))
                        recuperaDetailCpuSchedaMadreRamDissipatore();
                }
                else
                {
                    MessageBox.Show("Modello o Categoria componente già presente", "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Nessun componente è stato selezionato",
                          "Errore Aggiungi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private  void recuperaDetailCpuSchedaMadreRamDissipatore()
        {
            Details MyDetails;
            pt.Data = modello; pt.SetProtocolID("compatibilita");

            SocketTCP.Wait();
                SocketTCP.Send(pt.ToString());
                SocketTCP.Send(categoria + "\n");
                ConstructorDetail factory = new ConstructorDetail();

                string detailMsg = SocketTCP.Receive();
                Details componenteF = factory.GetDetails(categoria);
                Type categ = componenteF.GetType();
                MyDetails = (Details)JsonConvert.DeserializeObject(detailMsg, categ);
            SocketTCP.Release();

            string[] vet;
            ListViewItem lvitem = new ListViewItem("" + categoria + "");

            switch (categoria)
            {
                case "cpu":
                    vet = MyDetails.getDetail();
                    string cpuSocket = vet[1];
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("" + cpuSocket + "");
                    vecchioInserisciPreassemblato.setCpuDetail(cpuSocket);

                    break;
                case "schedaMadre":
                    vet = MyDetails.getDetail();
                    string cpuSocketSchedaMadre = vet[0];
                    string ramSchedaMadre = vet[1];
                    lvitem.SubItems.Add("" + ramSchedaMadre + "");
                    lvitem.SubItems.Add("" + cpuSocketSchedaMadre + "");
                    vecchioInserisciPreassemblato.setSchedaMadreDetail(cpuSocketSchedaMadre, ramSchedaMadre);

                    break;
                case "dissipatore":
                    string[] cpuSocketDissipatore = MyDetails.getDetail();
                    string msg_dissipatore = "";
                    foreach (string tipoSocket in cpuSocketDissipatore)
                    {
                        msg_dissipatore += tipoSocket + " ";
                    }

                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("" + msg_dissipatore + "");
                    vecchioInserisciPreassemblato.setDissipatoreDetail(cpuSocketDissipatore);

                    break;
                case "ram":
                    vet = MyDetails.getDetail();
                    string standardRam = vet[1];
                    lvitem.SubItems.Add("" + standardRam + "");
                    lvitem.SubItems.Add("");
                    vecchioInserisciPreassemblato.setRamDetail(standardRam);

                    break;
            }

            vecchioInserisciPreassemblato.getListViewD().Items.Add(lvitem);
            //ridimensiona la 3° colonna in base agli elementi al suo interno
            vecchioInserisciPreassemblato.getListViewD().Columns[2].Width = -2;


        }
    }
}
