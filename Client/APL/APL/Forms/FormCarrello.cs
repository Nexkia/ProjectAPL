using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListView = System.Windows.Forms.ListView;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;
using System.Diagnostics;
using APL.Connections;
using APL.Data.Detail;
using Newtonsoft.Json;
using APL.Data;

namespace APL.Forms
{
    public partial class FormCarrello : Form
    {
        bool disableCloseEvent;
        public FormCarrello()
         {
             InitializeComponent();
            
            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
        }


        private string cpuSocket="";
        private string cpuSocketSchedaMadre="", ramSchedaMadre="";
        private string standardRam="";
        private string[] cpuSocketDissipatore;

        public void setCpuDetail(string value) { 
            cpuSocket = value; ControllaCompatibilita();}
        public void setSchedaMadreDetail(string cpu, string ram) { 
            cpuSocketSchedaMadre = cpu; ramSchedaMadre = ram; ControllaCompatibilita(); }
        public void setRamDetail(string value) { 
            standardRam = value; ControllaCompatibilita(); }
        public void setDissipatoreDetail(string[] value) {
            cpuSocketDissipatore = value; ControllaCompatibilita(); }

        public ListView getListViewC() { return listViewCarrello; }
        public ListView getListViewD() { return listViewCarrelloDetail; }
        public void EnableCloseEvent(){this.disableCloseEvent = false;}
        void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (disableCloseEvent == true)
            {
 
                //impedisce alla finestra di chiudersi
                e.Cancel = true;

                //rende la finestra invisibile
               this.Visible = false;

            }
            else  {e.Cancel = false; } //permette alla finestra di chiudersi
        }

 
        private void buttonRimuovi_Click(object sender, EventArgs e)
        {
            if (listViewCarrello.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewCarrello.SelectedItems[0];

                //rimuoviamo l'elemento selezionato dalla listViewNuovoCarrello
                listViewCarrello.Items.Remove(item);

              
                //in base alla categoria del componente rimosso, togliamo le corrispettive informazioni nella listViewDetail
                foreach (ListViewItem.ListViewSubItem SubItems in item.SubItems)
                { switch (SubItems.Text)
                    {
                        case "cpu":
                            cpuSocket = "";
                            eliminaElementoListViewDetail("cpu");
                            labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore (Build Solo):";
                            labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre (Build Solo):";
                            break;

                        case "schedaMadre":
                            cpuSocketSchedaMadre = "";ramSchedaMadre = "";
                            eliminaElementoListViewDetail("schedaMadre");
                            labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre (Build Solo):";
                            labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre (Build Solo):";
                            break;

                        case "dissipatore":
                            cpuSocketDissipatore=null;
                            eliminaElementoListViewDetail("dissipatore");
                            labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore (Build Solo):";
                            break;

                        case "ram":
                            standardRam = "";
                            eliminaElementoListViewDetail("ram");
                            labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre (Build Solo):";
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

        private void buttonConferma_Click(object sender, EventArgs e)
        {
            
            //Controlla che ci sia almeno un elemento nel carrello
            if (contaComponentiBuild("Build Guidata") > 0 || contaComponentiBuild("Build Solo") > 0 ||
                contaComponentiBuild("preassemblato") > 0) 
            {
                //caso in cui l'utente vuole prendere una Build Solo e una Build Guidata
                if(contaComponentiBuild("Build Guidata") > 0 && contaComponentiBuild("Build Guidata") ==8 &&
                   contaComponentiBuild("Build Solo") > 0 && contaComponentiBuild("Build Solo") == 8)
                {
                    
                    creaCheckOut();

                //caso in cui l'utente vuole prendere solo una Build Guidata
                }else if(contaComponentiBuild("Build Guidata") > 0 && contaComponentiBuild("Build Guidata") == 8)
                {
                    //la listView piene passata al CheckOut solo se non ci sono componenti di BuildSolo
                    if (contaComponentiBuild("Build Solo") == 0){ creaCheckOut(); }
                    else
                    {
                        MessageBox.Show("Bisogna finire di scegliere gli 8 componenti di Build Solo," +
                        " prima di procedere al CheckOut",
                       "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                } //caso in cui l'utente vuole prendere solo una Build Solo
                else if(contaComponentiBuild("Build Solo") > 0 && contaComponentiBuild("Build Solo") == 8)
                {
                    //la listView piene passata al CheckOut solo se non ci sono componenti di BuildGuidata
                    if (contaComponentiBuild("Build Guidata") == 0) { creaCheckOut(); }
                    else
                    {
                        MessageBox.Show("Bisogna finire di scegliere gli 8 componenti di Build Guidata," +
                       " prima di procedere al CheckOut",
                      "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                } //caso in cui l'utente vuole prendere solo preassemblati 
                else if (contaComponentiBuild("Build Guidata") == 0 && contaComponentiBuild("Build Solo") == 0 )
                {
                    creaCheckOut();
                }
                else
                {
                    MessageBox.Show("Bisogna finire di scegliere gli 8 componenti di Build Guidata o Build Solo,"+
                        " prima di procedere al CheckOut",
                       "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



            }



            else
            {
                MessageBox.Show("il carrello è vuoto " ,
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
                    if (subItem.Text==tipo) { i++; }
                }
                    
            }

            Debug.WriteLine("i "+tipo+" : " + i);
            if (i == 8)
            {
                Debug.WriteLine("Conferma carrello ok");
                return i;
            }
            else{
                
                return i;
            }
        }

        private void buttonSvuotaCarrello_Click(object sender, EventArgs e)
        {
            listViewCarrello.Items.Clear();
            listViewCarrelloDetail.Items.Clear();
            cpuSocketDissipatore = null;
            cpuSocket = ""; cpuSocketSchedaMadre = ""; ramSchedaMadre = ""; standardRam = "";
            labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore (Build Solo):";
            labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre (Build Solo):";
            labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre (Build Solo):";
        }

        private void creaCheckOut()
        {
            FormCheckOut checkout = new FormCheckOut();
            checkout.Show();

            foreach (ListViewItem item in listViewCarrello.Items)
            {
                checkout.getListView().Items.Add((ListViewItem)item.Clone());
            }

            checkout.calcolaTotale();
           
            
        }

        private void ControllaCompatibilita()
        { 
            if(ramSchedaMadre!="" && standardRam!="")
            {
                if (ramSchedaMadre== standardRam) 
                labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre (Build Solo): Presente";
                else
                labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre (Build Solo): Assente";
            }

            if (cpuSocketSchedaMadre != "" && cpuSocket != "")
            {
                if (cpuSocketSchedaMadre == cpuSocket)
                labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre (Build Solo): Presente";
                else
                labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre (Build Solo): Assente";
            }

            if(cpuSocketDissipatore!=null && cpuSocket!= "")
            {
                bool SocketCpuTrovata = false;
                foreach (string tipoSocket in cpuSocketDissipatore)
                {
                    if (tipoSocket == cpuSocket)
                        SocketCpuTrovata = true;
                }

                if(SocketCpuTrovata==true)
                labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore (Build Solo): Presente"; 
                else
                labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore (Build Solo): Assente";
            }
            

    }

        
    }
}
