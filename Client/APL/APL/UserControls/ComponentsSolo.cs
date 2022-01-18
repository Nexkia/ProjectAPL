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

namespace APL.UserControls
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
            if (listViewSolo.SelectedItems.Count > 0 )
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
                if (categoria != "memoria" && categoria != "ram") { capienza = ""; }
                lvitem.SubItems.Add("" + capienza + "");
                lvitem.SubItems.Add("" + categoria + "");
                lvitem.SubItems.Add("Build Solo");


                bool componentePresente = false;
                int i ;

                foreach (ListViewItem elem in vecchioCarrello.Items)
                {
                    i = 0;
                    if (elem.Text == modello) { componentePresente = true; }

                    foreach (ListViewItem.ListViewSubItem subItem in elem.SubItems)
                    {

                        //evitiamo di mettere due componenti con la stessa categoria (associati a build solo)
                        if (subItem.Text == categoria) { i++; }

                        if(subItem.Text =="Build Solo") { i++; }

                    }
                    
                    if (i == 2) { componentePresente = true; }

                }

                
                

                
                if (componentePresente == false)
                {
                    vecchioCarrello.Items.Add(lvitem);
                   
                    
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

        private void labelCategoria_Click(object sender, EventArgs e)
        {

        }
    }
}
