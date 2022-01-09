using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.UserControls
{
    public partial class ElementoCronologia : UserControl
    {
        public ElementoCronologia()
        {
            InitializeComponent();
        }

        public void setPrezzo(string value) { labelPrezzo.Text ="Prezzo totale: "+ value; }

      
        public void addElementListView(string modello)
        {
            //---prendere dal server-------
            string marca = "marca";
            string prezzo = "prezzo";
            string capienza = "capienza";
            string categoria = "categoria";


            ListViewItem lvitem = new ListViewItem("" + modello + "");
            lvitem.SubItems.Add("" + marca + "");
            lvitem.SubItems.Add("" + prezzo + "");

            if (categoria!="memoria" && categoria !="ram") { capienza = ""; }
            lvitem.SubItems.Add("" + capienza + "");
            lvitem.SubItems.Add("" + categoria + "");

            listViewElementoC.Items.Add(lvitem);
            
        }


    }
}
