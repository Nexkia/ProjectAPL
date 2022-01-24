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
            lvitem.SubItems.Add("" + marca + "");
            lvitem.SubItems.Add("" + prezzo + "");

            if (categoria!="memoria" && categoria !="ram") { capienza = ""; }
            lvitem.SubItems.Add("" + capienza + "");
            lvitem.SubItems.Add("" + categoria + "");

            listViewElementoC.Items.Add(lvitem);
        }

        public void addPreassemblatoListView(string nome)
        {
            ListViewItem lvitem = new ListViewItem("" + nome + "");
            listViewElementoC.Items.Add(lvitem);
        }


    }
}
