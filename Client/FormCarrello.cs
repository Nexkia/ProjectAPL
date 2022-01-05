using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListViewItem = System.Windows.Forms.ListViewItem;
using System.Windows.Forms;
using System.Windows.Controls;
using ListView = System.Windows.Forms.ListView;

namespace Client
{
    public partial class FormCarrello : Form
    {
        ListView listViewVecchioCarrello;
        public FormCarrello(ListView vc)
        {
            InitializeComponent();

            listViewVecchioCarrello = vc;
            recuperaCarrello(vc);
           


           
        }


        public void recuperaCarrello(ListView vecchioCarrello)
        {
            
            foreach (ListViewItem item in vecchioCarrello.Items)
            {
                listViewNuovoCarrello.Items.Add((ListViewItem)item.Clone());
            }
        }


        private void buttonRimuovi_Click(object sender, EventArgs e)
        {
            if (listViewNuovoCarrello.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewNuovoCarrello.SelectedItems[0];
                string modello = item.SubItems[0].Text.ToString();

                //rimuoviamo l'elemento selezionato dalla listViewNuovoCarrello
                listViewNuovoCarrello.Items.Remove(item);

                //rimuoviamo l'elemento selezionato dalla listViewVecchioCarrello
                //listViewVecchioCarrello.FindItemWithText(modello).Remove();

            }
            else
            {
                MessageBox.Show("Nessun componente è stato selezionato",
                          "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonConferma_Click(object sender, EventArgs e)
        {
            if (listViewNuovoCarrello.Items.Count == 8) {

                Console.WriteLine("Conferma carrello ok");
            }
            else
            {
                MessageBox.Show("Selezionare 8 elementi",
                         "Errore Rimuovi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listViewNuovoCarrello.Items.Clear();
            recuperaCarrello(listViewVecchioCarrello);
        }
    }
}
