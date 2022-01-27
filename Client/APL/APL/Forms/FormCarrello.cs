using System;
using ListView = System.Windows.Forms.ListView;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;
using System.Diagnostics;
using APL.Connections;


namespace APL.Forms
{
    public partial class FormCarrello : Form
    {
        private bool disableCloseEvent;
        private Protocol pt;
        private FormCheckOut checkoutForm;
        public FormCarrello(FormCheckOut checkoutForm)
        {
            InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
            pt = new Protocol();
            this.checkoutForm=checkoutForm;
        }


        private string cpuSocket = "";
        private string cpuSocketSchedaMadre = "", ramSchedaMadre = "";
        private string standardRam = "";
        private string[] cpuSocketDissipatore;
        private bool RamSchedaMadre = false; 
        private bool CpuSchedaMadre = false;
        private bool CpuDissipatore = false;

        #region setCpuSchedaMadreRamDissipatore------------------------------------------------
        public void setCpuDetail(string value)
        {
            cpuSocket = value;
        }
        public void setSchedaMadreDetail(string cpu, string ram)
        {
            cpuSocketSchedaMadre = cpu; ramSchedaMadre = ram;
        }
        public void setRamDetail(string value)
        {
            standardRam = value;
        }
        public void setDissipatoreDetail(string[] value)
        {
            cpuSocketDissipatore = value;
        }
        #endregion


        public ListView getListViewC() { return listViewCarrello; }
        public ListView getListViewD() { return listViewCarrelloDetail; }


        #region Chiusura---------------------------------------------------------
        public void EnableCloseEvent() { this.disableCloseEvent = false; }
        void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (disableCloseEvent == true)
            {
                //impedisce alla finestra di chiudersi
                e.Cancel = true;

                //rende la finestra invisibile
                this.Visible = false;
            }
            else { e.Cancel = false; } //permette alla finestra di chiudersi
        }
        #endregion


        #region Creazione CheckOut con Componenti Compatibili--------------------------------------
        private void buttonConferma_Click(object sender, EventArgs e)
        {

            //Controlla che ci sia almeno un elemento nel carrello
            if (contaComponentiBuild("Build Guidata") > 0 || contaComponentiBuild("Build Solo") > 0 ||
                contaComponentiBuild("preassemblato") > 0)
            {
                //caso in cui l'utente vuole prendere una Build Solo e una Build Guidata
                if (contaComponentiBuild("Build Guidata") > 0 && contaComponentiBuild("Build Guidata") == 8 &&
                   contaComponentiBuild("Build Solo") > 0 && contaComponentiBuild("Build Solo") == 8)
                {
                    //verifichiamo che i componenti della buildsolo siano compatibili
                    ControllaCompatibilita();
                    if (RamSchedaMadre == true && CpuSchedaMadre == true && CpuDissipatore == true)
                        creaCheckOut();
                    else
                        MessageBox.Show("Componenti Build Solo non compatibili,", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                    //caso in cui l'utente vuole prendere solo una Build Guidata
                }
                else if (contaComponentiBuild("Build Guidata") > 0 && contaComponentiBuild("Build Guidata") == 8)
                {
                    //la listView piene passata al CheckOut solo se non ci sono componenti di BuildSolo
                    if (contaComponentiBuild("Build Solo") == 0) { creaCheckOut(); }
                    else
                    {
                        MessageBox.Show("Bisogna finire di scegliere gli 8 componenti di Build Solo," +
                        " prima di procedere al CheckOut",
                       "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                } //caso in cui l'utente vuole prendere solo una Build Solo
                else if (contaComponentiBuild("Build Solo") > 0 && contaComponentiBuild("Build Solo") == 8)
                {
                    //la listView piene passata al CheckOut solo se non ci sono componenti di BuildGuidata
                    if (contaComponentiBuild("Build Guidata") == 0)
                    {

                        //verifichiamo che i componenti della buildsolo siano compatibili
                        ControllaCompatibilita();
                        if (RamSchedaMadre == true && CpuSchedaMadre == true && CpuDissipatore == true)
                            creaCheckOut();
                        else
                            MessageBox.Show("Componenti Build Solo non compatibili,", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Bisogna finire di scegliere gli 8 componenti di Build Guidata," +
                       " prima di procedere al CheckOut",
                      "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                } //caso in cui l'utente vuole prendere solo preassemblati 
                else if (contaComponentiBuild("Build Guidata") == 0 && contaComponentiBuild("Build Solo") == 0)
                {
                    creaCheckOut();
                }
                else
                {
                    MessageBox.Show("Bisogna finire di scegliere gli 8 componenti di Build Guidata o Build Solo," +
                        " prima di procedere al CheckOut",
                       "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



            }
            else
            {
                MessageBox.Show("il carrello è vuoto ",
                "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }
        private int contaComponentiBuild(string tipo)
        {
            int i = 0;
            foreach (ListViewItem item in listViewCarrello.Items)
            {
                //in base al tipo passato contiamo gli elementi di Build Guidata o Solo
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text == tipo) { i++; }
                }
            }

            Debug.WriteLine("i " + tipo + " : " + i);
            if (i == 8)
            {
                Debug.WriteLine("Conferma carrello ok");
                return i;
            }
            else
            {
                return i;
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
        private void creaCheckOut()
        {
            foreach (ListViewItem item in listViewCarrello.Items)
            {
                checkoutForm.getListView().Items.Add((ListViewItem)item.Clone());
            }
            checkoutForm.calcolaTotale();
            checkoutForm.Show();
        }
        #endregion


        #region Rimuovi elementi dal carrello--------------------------------------------------------
        private void buttonRimuovi_Click(object sender, EventArgs e)
        {
            if (listViewCarrello.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewCarrello.SelectedItems[0];
                //rimuoviamo l'elemento selezionato dalla listViewNuovoCarrello
                listViewCarrello.Items.Remove(item);

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
            foreach (ListViewItem item in listViewCarrelloDetail.Items)
            {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text == categoria) { item.Remove(); }
                }
            }
        }

        private void buttonSvuotaCarrello_Click(object sender, EventArgs e){svuotaCarrello();}
        public void svuotaCarrello()
        {
            listViewCarrello.Items.Clear();
            listViewCarrelloDetail.Items.Clear();
            cpuSocketDissipatore = null;
            cpuSocket = ""; cpuSocketSchedaMadre = ""; ramSchedaMadre = ""; standardRam = "";
        }
        #endregion

    }
}