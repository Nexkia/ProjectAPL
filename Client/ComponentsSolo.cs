using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ListViewItem = System.Windows.Forms.ListViewItem;

namespace Client
{
    
    public partial class ComponentsSolo : UserControl
    {
        ListView vecchioCarrello;
        public ComponentsSolo(ListView vc)
        {
            InitializeComponent();
            vecchioCarrello=vc;

        }


        public void impostaCategoria(string value) { labelCategoria.Text = value; }

        public void addListView(ListViewItem value){ listViewSolo.Items.Add(value); }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonCarrello_Click(object sender, EventArgs e)
        {
            if (listViewSolo.SelectedItems.Count > 0)
            {


                ListViewItem item = listViewSolo.SelectedItems[0];


                string modello = item.SubItems[0].Text.ToString();
                string marca = item.SubItems[1].Text.ToString();

                string prezzo = item.SubItems[2].Text.ToString();

                string capienza = item.SubItems[3].Text.ToString();
                string categoria = item.SubItems[4].Text.ToString();

                


                ListViewItem lvitem = new ListViewItem("" + modello + "");
                lvitem.SubItems.Add("" + marca + "");
                lvitem.SubItems.Add("" + prezzo + "");
                lvitem.SubItems.Add("" + capienza + "");
                lvitem.SubItems.Add("" + categoria + "");

                int a = 0;
                // if (vecchioCarrello.Items. == false)
                foreach (ListViewItem value in vecchioCarrello.Items)
                {
                    if (value.SubItems == lvitem.SubItems)
                    {
                        a = 1;
                    }
                }

                if(a==0)
                vecchioCarrello.Items.Add(lvitem);


            }
            else
            {
                MessageBox.Show("Nessun componente è stato selezionato",
                          "Errore Aggiungi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
