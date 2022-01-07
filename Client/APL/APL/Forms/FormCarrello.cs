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
                string modello = item.SubItems[0].Text.ToString();

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
            if (listViewCarrello.FindItemWithText("Build Guidata") != null) {
                contaComponentiBuild("Build Guidata");
            }

            if (listViewCarrello.FindItemWithText("Build Solo") != null)
            {
                contaComponentiBuild("Build Solo");
            }
        }

        private void contaComponentiBuild(string tipo)
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
            }
            else{
                MessageBox.Show("Selezionare 8 elementi appartenenti a "+tipo,
                         "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
