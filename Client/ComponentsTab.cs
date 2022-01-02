using Client.Data;
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
    public partial class ComponentsTab : UserControl
    {
        ListView vecchialistView;
        public ComponentsTab(ListView vlw)
        {
            InitializeComponent();
           vecchialistView = vlw;
        }

        #region Properties

        private Componente _componente1;
        private Componente _componente2;
        private Componente _componente3;



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
            get { return _componente1; }
            set { _componente1 = value;  }
        }

        [Category("Custom Props")]
        public Componente Componente2
        {
            get { return _componente2; }
            set { _componente2 = value; }
        }

        [Category("Custom Props")]
        public Componente Componente3
        {
            get { return _componente3; }
            set { _componente3 = value; }
        }



        #endregion

        private void checkBox1ComponentsTab_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine(checkBox1ComponentsTab.CheckState);
        }

        private void checkBox2ComponentsTab_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine(checkBox2ComponentsTab.CheckState);
        }

        private void checkBox3ComponentsTab_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine(checkBox3ComponentsTab.CheckState);
        }

        private void RiempiListView()
        {
            vecchialistView.Items.Clear();
            vecchialistView.Visible = true;

            if (checkBox1ComponentsTab.Checked==true ) {
                Console.WriteLine("checkbox1 spuntata");
                ListViewItem lvitem1 = new ListViewItem("" + _componente1.Modello + "");
                lvitem1.SubItems.Add("" + _componente1.Categoria + "");
                lvitem1.SubItems.Add("" + _componente1.Marca + "");
                lvitem1.SubItems.Add("" + _componente1.Prezzo + "");

                vecchialistView.Items.Add(lvitem1);
            }

            if (checkBox2ComponentsTab.Checked == true)
            {
                Console.WriteLine("checkbox2 spuntata");
                ListViewItem lvitem2 = new ListViewItem("" + _componente2.Modello + "");
                lvitem2.SubItems.Add("" + _componente2.Categoria + "");
                lvitem2.SubItems.Add("" + _componente2.Marca + "");
                lvitem2.SubItems.Add("" + _componente2.Prezzo + "");

                vecchialistView.Items.Add(lvitem2);
            }

            if (checkBox3ComponentsTab.Checked == true)
            {
                Console.WriteLine("checkbox3 spuntata");
                ListViewItem lvitem3 = new ListViewItem("" + _componente3.Modello + "");
                lvitem3.SubItems.Add("" + _componente3.Categoria + "");
                lvitem3.SubItems.Add("" + _componente3.Marca + "");
                lvitem3.SubItems.Add("" + _componente3.Prezzo + "");

                vecchialistView.Items.Add(lvitem3);
            }


            
        }

        private void buttonConfronta_Click(object sender, EventArgs e)
        {
            RiempiListView();


            string categoria0,modello0, marca0, prezzo0,
                    categoria1, modello1, marca1, prezzo1,
                    categoria2, modello2, marca2, prezzo2;

            categoria0 = modello0 = marca0 = prezzo0 =
            categoria1 = modello1 = marca1 = prezzo1 =
            categoria2 = modello2 = marca2 = prezzo2 = "default";


            if (vecchialistView.Items.Count >= 1)
            {
                ListViewItem item0 = vecchialistView.Items[0];
                

                 modello0 = item0.SubItems[0].Text.ToString();
                 categoria0 = item0.SubItems[1].Text.ToString();
                marca0 = item0.SubItems[2].Text.ToString();
                 prezzo0 = item0.SubItems[3].Text.ToString();


                if (vecchialistView.Items.Count >= 2)
                {
                    ListViewItem item1 = vecchialistView.Items[1];
                     modello1 = item1.SubItems[0].Text.ToString();
                     categoria1 = item1.SubItems[1].Text.ToString();
                    marca1 = item1.SubItems[2].Text.ToString();
                     prezzo1 = item1.SubItems[3].Text.ToString();


                    if (vecchialistView.Items.Count == 3)
                    {
                        ListViewItem item2 = vecchialistView.Items[2];
                        modello2 = item2.SubItems[0].Text.ToString();
                        categoria2 = item2.SubItems[1].Text.ToString();
                        marca2 = item2.SubItems[2].Text.ToString();
                        prezzo2 = item2.SubItems[3].Text.ToString();

                    }
                }
            }

            if (categoria2 == "default" && categoria1 == "default" && categoria0 == "default")  //ci sono 0 componenti
            {
                MessageBox.Show("Prima di premere confronta, spuntare almeno un componente",
                         "Errore ", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (categoria2 == "default" && categoria1 == "default")  //c'è un solo componente
            {
                Console.WriteLine("C'è un solo componente");
                Console.WriteLine("modello0: " + modello0 + " modello1: " + modello1 + " modello2: " + modello2);
                Console.WriteLine("marca0: " + marca0 + " marca1: " + marca1 + " marca2: " + marca2);
                Console.WriteLine("prezzo0: " + prezzo0 + " prezzo1: " + prezzo1 + " prezzo2: " + prezzo2);

            }
            else if (categoria2 == "default")//ci sono 2 componenti
            {
                Console.WriteLine("Ci sono 2 componenti");
                Console.WriteLine("modello0: " + modello0 + " modello1: " + modello1 + " modello2: " + modello2);
                Console.WriteLine("marca0: " + marca0 + " marca1: " + marca1 + " marca2: " + marca2);
                Console.WriteLine("prezzo0: " + prezzo0 + " prezzo1: " + prezzo1 + " prezzo2: " + prezzo2);

            }
            else //ci sono 3 componenti
            {
                Console.WriteLine("Ci sono 3 componenti");
                Console.WriteLine("modello0: " + modello0 + " modello1: " + modello1 + " modello2: " + modello2);
                Console.WriteLine("marca0: " + marca0 + " marca1: " + marca1 + " marca2: " + marca2);
                Console.WriteLine("prezzo0: " + prezzo0 + " prezzo1: " + prezzo1 + " prezzo2: " + prezzo2);
            }
        }

       
    }
}
