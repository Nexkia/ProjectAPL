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
                lvitem1.SubItems.Add("" + _componente1.Capienza + "");

                vecchialistView.Items.Add(lvitem1);
            }

            if (checkBox2ComponentsTab.Checked == true)
            {
                Console.WriteLine("checkbox2 spuntata");
                ListViewItem lvitem2 = new ListViewItem("" + _componente2.Modello + "");
                lvitem2.SubItems.Add("" + _componente2.Categoria + "");
                lvitem2.SubItems.Add("" + _componente2.Marca + "");
                lvitem2.SubItems.Add("" + _componente2.Prezzo + "");
                lvitem2.SubItems.Add("" + _componente2.Capienza + "");

                vecchialistView.Items.Add(lvitem2);
            }

            if (checkBox3ComponentsTab.Checked == true)
            {
                Console.WriteLine("checkbox3 spuntata");
                ListViewItem lvitem3 = new ListViewItem("" + _componente3.Modello + "");
                lvitem3.SubItems.Add("" + _componente3.Categoria + "");
                lvitem3.SubItems.Add("" + _componente3.Marca + "");
                lvitem3.SubItems.Add("" + _componente3.Prezzo + "");
                lvitem3.SubItems.Add("" + _componente3.Capienza + "");

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

       
    }
}
