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
        Protocol pt;
        public FormCarrello()
         {
             InitializeComponent();
            
            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
            pt = new Protocol();
        }

        public ListView getListView() { return listViewCarrello; }
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

               
                    
            }
            else
            {
                MessageBox.Show("Nessun componente è stato selezionato",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void panelSfondo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCompatibilita_Click(object sender, EventArgs e)

        {   int BuildSolo = 0;
            foreach (ListViewItem item in listViewCarrello.Items)
            {
                //in base al tipo passato contiamo gli elementi di Build  Solo
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text == "Build Solo") { BuildSolo++; }
                }

            }

      

            if (BuildSolo == 8)
            {
                recuperaDetailCpuSchedaMadreRamDissipatore();
            
            }
            else
            {
                MessageBox.Show("Selezionare 8 componenti prima di controllare la compatibilità", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void recuperaDetailCpuSchedaMadreRamDissipatore()
        {
            string[] modelli = recuperaModelloCpuSchedaMadreRamDissipatore();
            string[] categorie = { "cpu", "schedaMadre", "ram", "dissipatore" };

            Details[] MyDetails = new Details[4];
            pt.Data = ""; pt.SetProtocolID("compatibilita");
            for (int i = 0; i < modelli.Length; i++)
            {
                pt.Data += modelli[i] + "#";
            }

            string cat = "";
            for (int i = 0; i < categorie.Length; i++)
            {
                cat += categorie[i] + "#";
            }

            SocketTCP.GetMutex().WaitOne();

            SocketTCP.send(pt.ToString());
            SocketTCP.send(cat);

            ConstructorDetail factory = new ConstructorDetail();

            for (int i = 0; i < 4; i++)
            {
                string detailMsg =  SocketTCP.receive();
                Details componenteF = factory.GetDetails(categorie[i]);
                Type categoria = componenteF.GetType();
                MyDetails[i] = (Details)JsonConvert.DeserializeObject(detailMsg, categoria);
                Debug.WriteLine(MyDetails[i].Modello);
            }
            SocketTCP.GetMutex().ReleaseMutex();

            labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore (Build Solo): Assente";
            labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre (Build Solo): Assente";
            labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre (Build Solo): Assente";
            string[] vet = MyDetails[0].getDetail();
            string cpuSocket = vet[1];

            vet = MyDetails[1].getDetail();
            string cpuSocketSchedaMadre = vet[0];
            string ramSchedaMadre = vet[1];

            vet = MyDetails[2].getDetail();
            string standardRam = vet[1];

            string[] cpuSocketDissipatore = MyDetails[3].getDetail();

            foreach (string tipoSocket in cpuSocketDissipatore)
            {
                if (tipoSocket == cpuSocket)
                {
                    labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore (Build Solo): Presente";
                }
            }

            if (cpuSocketSchedaMadre == cpuSocket)
            {
                labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre (Build Solo): Presente";
            }

            if (standardRam == ramSchedaMadre)
            {
                labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre (Build Solo): Presente";
            }


        }

        private string[] recuperaModelloCpuSchedaMadreRamDissipatore()
        {
            string[] modelli = new string[4];
            foreach (ListViewItem item in listViewCarrello.Items)
            {
                switch (item.SubItems[4].Text.ToString())
                {
                    case "cpu":
                        modelli[0] = item.SubItems[0].Text.ToString();
                        break;
                    case "schedaMadre":
                        modelli[1] = item.SubItems[0].Text.ToString();
                        break;
                    case "ram":
                        modelli[2] = item.SubItems[0].Text.ToString();
                        break;
                    case "dissipatore":
                        modelli[3] = item.SubItems[0].Text.ToString();
                        break;
                }
            }

            return modelli;
        }
    }
}
