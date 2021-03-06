using APL.Data;
using APL.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
namespace APL.UserControls
{
    public partial class ListItem : UserControl
    {
        private FormHome vecchioForm2;
        private FlowLayoutPanel vecchioflowLayoutPanel1;
        private FlowLayoutPanel vecchioflowLayoutPanel2;
        private ListView vecchioCarrello;
        public ListItem(FlowLayoutPanel vfp2, FormHome f2, FlowLayoutPanel vfp1, ListView carrello)
        {
            InitializeComponent();
            vecchioflowLayoutPanel1 = vfp1;
            vecchioflowLayoutPanel2 = vfp2;
            vecchioForm2 = f2;

            vecchioCarrello = carrello;
        }

        private string modello;
        private float prezzo;

        public string NomeModello { set { modello = value; } }
        public float Prezzo { set { prezzo = value; } }
        public void setTitle() { lblTitle.Text = "Nome: " + modello + " Prezzo: " + prezzo; }
        public Color IconBackground { set { panel1.BackColor = value; } }
        public string Message { set { lblMessage.Text = value; } }
        public Image Icon { set { pictureBox1.Image = value; } }
        public PcPreassemblato pre { get; set; }

        private void lblMessage_MouseEnter(object sender, EventArgs e) { this.BackColor = Color.Silver; }

        private void lblMessage_MouseLeave(object sender, EventArgs e) { this.BackColor = Color.White; }

        private void lbl_MessageClick1(object sender, EventArgs e)
        {
            vecchioflowLayoutPanel2.Controls.Clear();
            vecchioForm2.allargaForm2();
            populateItemsInfo();
        }

        private void populateItemsInfo()
        {
            Info info = new Info();
            info.Title(pre.Nome, pre.Prezzo);

            string message = "";
            //8 come il numero dei componenti
            for (int j = 0; j < 8; j++)
            {
                message += "• " + pre.Componenti[j].Categoria + "\n"
                            + pre.Componenti[j].Marca + " " + pre.Componenti[j].Modello + " " + pre.Componenti[j].Prezzo + " €";

                if (pre.Componenti[j].Capienza > 0)
                    message += " " + pre.Componenti[j].Capienza + " GB";

                message += "\n";
            }
            info.Message = message;

            //resetto il colore degli altri user control
            foreach (Control control in vecchioflowLayoutPanel1.Controls) { control.ForeColor = Color.Black; }
            //coloro di rosso questo l'elemento selezionato
            this.ForeColor = Color.Red;
            //aggiungo l'elemento
            vecchioflowLayoutPanel2.Controls.Add(info);
            //rendo il flowLayoutPanel visibile
            vecchioflowLayoutPanel2.Visible = true;
        }

        private void buttonCarrello_Click(object sender, EventArgs e)
        {
            ListViewItem lvitem = new ListViewItem("" + modello + "");
            lvitem.SubItems.Add("");
            lvitem.SubItems.Add("" + prezzo + "");
            lvitem.SubItems.Add("");
            lvitem.SubItems.Add("");
            lvitem.SubItems.Add("preassemblato");

            ListViewItem risultato = vecchioCarrello.FindItemWithText(modello);

            //impediamo che si possa mettere lo stesso modello 2 volte dentro la listView
            if (risultato == null)
                vecchioCarrello.Items.Add(lvitem);
            else
            {
                MessageBox.Show("Preassemblato già presente nel carrello, ", "Errore",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

    }
}
