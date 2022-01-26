using APL.Data;
using System;
using System.Windows.Forms;

namespace APL.UserControls
{
    public partial class ElementoCronologia : UserControl
    {
        public ElementoCronologia()
        {
            InitializeComponent();
        }

        public void setPrezzoData(string val1,DateTime val2) { labelPrezzo.Text ="Prezzo totale: "+ val1+"     Data: "+val2; }

      
        public void addComponenteListView(Componente comp)
        {
            string modello = comp.Modello.ToString();
            string marca = comp.Marca.ToString();
            string prezzo = comp.Prezzo.ToString();
            string capienza = comp.Capienza.ToString();
            string categoria = comp.Categoria.ToString();

            ListViewItem lvitem = new ListViewItem("" + modello + "");
            if (marca == "") 
            {
                lvitem.BackColor = System.Drawing.Color.Red;
                lvitem.ForeColor = System.Drawing.Color.White;
                lvitem.SubItems.Add("COMPONENTE");
                lvitem.SubItems.Add("ELIMINATO");
                lvitem.SubItems.Add("DAL DATABASE");
                lvitem.SubItems.Add("");
            }
            else 
            {
                lvitem.SubItems.Add("" + marca + "");
                lvitem.SubItems.Add("" + prezzo + "");

                if (categoria != "memoria" && categoria != "ram") { capienza = ""; }
                lvitem.SubItems.Add("" + capienza + "");
                lvitem.SubItems.Add("" + categoria + "");
            }
            listViewElementoC.Items.Add(lvitem);

        }

        public void addPreassemblatoListView(string nome,string prezzo)
        {
            ListViewItem lvitem = new ListViewItem(nome );
            if (prezzo != "0")
            {
                lvitem.SubItems.Add("");
                lvitem.SubItems.Add(prezzo);
            }
            else
            {
                lvitem.BackColor = System.Drawing.Color.Red;
                lvitem.ForeColor = System.Drawing.Color.White;
                lvitem.SubItems.Add("PREASSEMBLATO");
                lvitem.SubItems.Add("ELIMINATO");
                lvitem.SubItems.Add("DAL DATABASE");
                lvitem.SubItems.Add("");
            }
            
            listViewElementoC.Items.Add(lvitem);
        }


    }
}
