using APL.Connections;
using APL.Data;
using APL.Data.Detail;
using APL.Forms;
using Newtonsoft.Json;
using System;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace APL.UserControls
{
    
    public partial class ComponentsSolo : UserControl
    {
        private FormCarrello vecchioCarrello;
        private Protocol pt;
        public ComponentsSolo(FormCarrello formCarrello)
        {
            InitializeComponent();
            vecchioCarrello = formCarrello;
            pt = new Protocol();
        }

        private string categoria;
        private string modello;

        public void impostaCategoria(string value) { labelCategoria.Text = value; }

        public void addListView(ListViewItem value){ listViewSolo.Items.Add(value); }

        private void buttonCarrello_Click(object sender, EventArgs e)
        {
            if (listViewSolo.SelectedItems.Count > 0 )
            {
                ListViewItem item = listViewSolo.SelectedItems[0];

                modello = item.SubItems[0].Text.ToString();
                string marca = item.SubItems[1].Text.ToString();
                string prezzo = item.SubItems[2].Text.ToString();
                string capienza = item.SubItems[3].Text.ToString();
                categoria= item.SubItems[4].Text.ToString();

                ListViewItem lvitem = new ListViewItem("" + modello + "");
                lvitem.SubItems.Add("" + marca + "");
                lvitem.SubItems.Add("" + prezzo + "");
                if (categoria != "memoria" && categoria != "ram") { capienza = ""; }
                lvitem.SubItems.Add("" + capienza + "");
                lvitem.SubItems.Add("" + categoria + "");
                lvitem.SubItems.Add("Build Solo");

                bool componentePresente = false;
                int i ;

                foreach (ListViewItem elem in vecchioCarrello.getListViewC().Items)
                {
                    i = 0;

                    if (elem.Text == modello)
                        componentePresente = true; 

                    foreach (ListViewItem.ListViewSubItem subItem in elem.SubItems)
                    {
                        //evitiamo di mettere due componenti con la stessa categoria (associati a build solo)
                        if (subItem.Text == categoria) 
                            i++; 

                        if(subItem.Text =="Build Solo") 
                            i++; 

                    }
                    
                    if (i == 2)
                        componentePresente = true;

                }

                if (componentePresente == false)
                {
                    vecchioCarrello.getListViewC().Items.Add(lvitem);

                    if ((categoria == "cpu") || (categoria == "schedaMadre")|| (categoria=="dissipatore")|| (categoria=="ram"))
                        recuperaDetailCpuSchedaMadreRamDissipatore();
                }
                else
                {
                    MessageBox.Show("Modello o Categoria componente già presente","Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nessun componente è stato selezionato",
                          "Errore Aggiungi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void recuperaDetailCpuSchedaMadreRamDissipatore()
        {
            ConstructorDetail factoryDetail = new ConstructorDetail();
            Details MyDetails = factoryDetail.GetDetails(categoria);
            Type categ = MyDetails.GetType();
            pt.Data = modello; pt.SetProtocolID("compatibilita");

            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());
            SocketTCP.Send(categoria+"\n");
            string detailMsg = SocketTCP.Receive();
            SocketTCP.Release();
            MyDetails = (Details)JsonConvert.DeserializeObject(detailMsg, categ);

            string[] vet;
            ListViewItem lvitem = new ListViewItem("" + categoria + "");

            switch (categoria)
            {
                case "cpu":
                     vet = MyDetails.getDetail();
                    string cpuSocket = vet[1];
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("" + cpuSocket + "");
                    vecchioCarrello.setCpuDetail(cpuSocket);
                    
                    break;
                case "schedaMadre":
                    vet = MyDetails.getDetail();
                    string cpuSocketSchedaMadre = vet[0];
                    string ramSchedaMadre = vet[1];
                    lvitem.SubItems.Add(""+ ramSchedaMadre + "");
                    lvitem.SubItems.Add("" + cpuSocketSchedaMadre + "");
                    vecchioCarrello.setSchedaMadreDetail(cpuSocketSchedaMadre, ramSchedaMadre);

                    break;
                case "dissipatore":
                    string[] cpuSocketDissipatore = MyDetails.getDetail();
                    string msg_dissipatore = "";
                    foreach (string tipoSocket in cpuSocketDissipatore)
                    {
                        msg_dissipatore += tipoSocket + " ";
                    }
                    
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("" + msg_dissipatore+"");
                    vecchioCarrello.setDissipatoreDetail(cpuSocketDissipatore);

                        break;
                case "ram":
                    vet = MyDetails.getDetail();
                    string standardRam = vet[1];
                    lvitem.SubItems.Add(""+ standardRam + "");
                    lvitem.SubItems.Add("");
                    vecchioCarrello.setRamDetail(standardRam);

                    break;
            }

            vecchioCarrello.getListViewD().Items.Add(lvitem);
            //ridimensiona la 3° colonna in base agli elementi al suo interno
            vecchioCarrello.getListViewD().Columns[2].Width = -2;


        }
    }
}
