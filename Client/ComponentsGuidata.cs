﻿using Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ComponentsGuidata : UserControl
    {
        ListView vecchialistView;
        ListView vecchioCarrello;
        private Componente[] _componente;
        public ComponentsGuidata(ListView vlw,ListView carrello)
        {
            InitializeComponent();
           vecchialistView = vlw;
            vecchioCarrello = carrello;

            _componente = new Componente[3];
        }

        #region Properties

     


        [Category("Custom Props")]
        public string Title
        { set {  label1ComponentsTab.Text = value; }}
       

        [Category("Custom Props")]
        public string MostraModello1
        { set {  label2ComponentsTab.Text = value; }}

        [Category("Custom Props")]
        public string MostraModello2
        { set {  label3ComponentsTab.Text = value; }}

        [Category("Custom Props")]
        public string MostraModello3
        {set {  label4ComponentsTab.Text = value; }}

        [Category("Custom Props")]
        public Image Icon1
        {set { pictureBox1ComponentsTab.Image = value; }}

        [Category("Custom Props")]
        public Image Icon2
        {set {  pictureBox2ComponentsTab.Image = value; }}

        [Category("Custom Props")]
        public Image Icon3
        {set {  pictureBox3ComponentsTab.Image = value; }}

        [Category("Custom Props")]
        public Componente Componente1
        {
            get { return _componente[0]; }
            set { _componente[0] = value;  }
        }

        [Category("Custom Props")]
        public Componente Componente2
        {
            get { return _componente[1]; }
            set { _componente[1] = value; }
        }

        [Category("Custom Props")]
        public Componente Componente3
        {
            get { return _componente[2]; }
            set { _componente[2] = value; }
        }



        #endregion

      
        private void RiempiListView()
        {
            vecchialistView.Items.Clear();
            vecchialistView.Visible = true;

            if (checkBox1ComponentsTab.Checked==true ) {
                Console.WriteLine("checkbox1 spuntata");
                ListViewItem lvitem1 = new ListViewItem("" + _componente[0].Modello + "");
                lvitem1.SubItems.Add("" + _componente[0].Categoria + "");
                lvitem1.SubItems.Add("" + _componente[0].Marca + "");
                lvitem1.SubItems.Add("" + _componente[0].Prezzo + "");
                lvitem1.SubItems.Add("" + _componente[0].Capienza + "");

                vecchialistView.Items.Add(lvitem1);
            }

            if (checkBox2ComponentsTab.Checked == true)
            {
                Console.WriteLine("checkbox2 spuntata");
                ListViewItem lvitem2 = new ListViewItem("" + _componente[1].Modello + "");
                lvitem2.SubItems.Add("" + _componente[1].Categoria + "");
                lvitem2.SubItems.Add("" + _componente[1].Marca + "");
                lvitem2.SubItems.Add("" + _componente[1].Prezzo + "");
                lvitem2.SubItems.Add("" + _componente[1].Capienza + "");

                vecchialistView.Items.Add(lvitem2);
            }

            if (checkBox3ComponentsTab.Checked == true)
            {
                Console.WriteLine("checkbox3 spuntata");
                ListViewItem lvitem3 = new ListViewItem("" + _componente[2].Modello + "");
                lvitem3.SubItems.Add("" + _componente[2].Categoria + "");
                lvitem3.SubItems.Add("" + _componente[2].Marca + "");
                lvitem3.SubItems.Add("" + _componente[2].Prezzo + "");
                lvitem3.SubItems.Add("" + _componente[2].Capienza + "");

                vecchialistView.Items.Add(lvitem3);
            }


            
        }

        private void buttonConfronta_Click(object sender, EventArgs e)
        {
            RiempiListView();

            string[] modelli = new string[vecchialistView.Items.Count];
            string[] prezzi = new string[vecchialistView.Items.Count];
            string[] capienze = new string[vecchialistView.Items.Count];

            string categoria="default";

            for (int i = 0; i < vecchialistView.Items.Count; i++)
            {
                ListViewItem item = vecchialistView.Items[i];

                modelli[i] = item.SubItems[0].Text.ToString();
                categoria = item.SubItems[1].Text.ToString();
                prezzi[i] = item.SubItems[3].Text.ToString();
                capienze[i] = item.SubItems[4].Text.ToString();
                Console.WriteLine(modelli[i] + " " + prezzi[i] + " " + categoria+" capienza:"+capienze[i]);
            }
            if (modelli.Length > 0)
            {
                Confronto cf = new Confronto(modelli, prezzi,capienze, categoria);
                cf.Show();
            }
            else
            {
                MessageBox.Show("Prima di premere confronta, spuntare almeno un componente",
                            "Errore ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
               
            

        }

        private void buttonCarrello_Click(object sender, EventArgs e)
        {
         if((checkBox1ComponentsTab.Checked == true && checkBox2ComponentsTab.Checked == true) ||
            (checkBox1ComponentsTab.Checked == true && checkBox3ComponentsTab.Checked == true) ||
            (checkBox2ComponentsTab.Checked == true && checkBox3ComponentsTab.Checked == true) ||
            (checkBox1ComponentsTab.Checked == true && checkBox2ComponentsTab.Checked == true && checkBox3ComponentsTab.Checked == true ))
            {
                MessageBox.Show("Spuntare una sola CheckBox, per aggiungere il componente al carrello",
                         "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int i;
                if (checkBox1ComponentsTab.Checked == true)
                {
                    i = 0;
                    aggiungiAlCarrello(i);

                }else if (checkBox2ComponentsTab.Checked == true)
                {
                    i = 1;
                    aggiungiAlCarrello(i);

                }
                else {
                    i = 2;
                    aggiungiAlCarrello(i);

                }


              

            }



        }

        private void aggiungiAlCarrello(int i)
        {
            
            string modello = _componente[i].Modello;
            string marca = _componente[i].Marca;
            string prezzo = Convert.ToString(_componente[i].Prezzo);
            string capienza = _componente[i].Capienza;
            string categoria = _componente[i].Categoria;


            ListViewItem lvitem = new ListViewItem("" + modello + "");
            lvitem.SubItems.Add("" + marca + "");
            lvitem.SubItems.Add("" + prezzo + "");
            lvitem.SubItems.Add("" + capienza + "");
            lvitem.SubItems.Add("" + categoria + "");
            lvitem.SubItems.Add("Build Guidata");

            bool componentePresente = false;
            int j;

            foreach (ListViewItem elem in vecchioCarrello.Items)
            {
                j = 0;
                if (elem.Text == modello) { componentePresente = true; }

                foreach (ListViewItem.ListViewSubItem subItem in elem.SubItems)
                {

                    //evitiamo di mettere due componenti con la stessa categoria (associati a build solo)
                    if (subItem.Text == categoria) { j++; }

                    if (subItem.Text == "Build Guidata") { j++; }

                }
                
                
                if (j == 2) { componentePresente = true; }

            }

            if (componentePresente == false){ vecchioCarrello.Items.Add(lvitem);}
            else{
                MessageBox.Show("Modello o Categoria già presente nel carrello, ", "Errore",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           



        }
    }
}
