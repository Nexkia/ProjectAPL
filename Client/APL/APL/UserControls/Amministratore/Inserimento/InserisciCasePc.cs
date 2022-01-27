using APL.Data.Detail;
using APL.Forms.Amministratore;
using System;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciCasePc : UserControl
    {
        private FormInserisciComponente inserisciComponente;
        public InserisciCasePc(FormInserisciComponente inserisciComponente)
        {
            InitializeComponent();
            this.inserisciComponente=inserisciComponente;
        }

        public CasePC getInputDetail()
        {

            if (inserisciComponente.getModello() != string.Empty && textBoxValutazione.Text != string.Empty && comboBoxTaglia.Text != string.Empty)
            {
                CasePC elem = new CasePC() 
                { 
                    Modello = inserisciComponente.getModello(), Valutazione=
                    int.Parse(textBoxValutazione.Text), Taglia  = comboBoxTaglia.Text 
                };
                return elem;
            }
            else { return null; }


        }

        private void buttonConferma_Click(object sender, EventArgs e)
        {
            if (this.getInputDetail() != null && inserisciComponente.areFullAllTextBox()!=null)
            {
                MessageBox.Show("Inserimento avvenuto",
                    "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                MessageBox.Show("Riempire i campi detail",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxValutazione_KeyPress(object sender, KeyPressEventArgs e)
        {
            //impedisce l'inserimento di un input non numerico
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

        }

        private void textBoxValutazione_TextChanged(object sender, EventArgs e)
        {
            //impediamo di inserire una valutazione non valida
            if (textBoxValutazione.Text != string.Empty)
            {
                if (int.Parse(textBoxValutazione.Text) > 10)
                    textBoxValutazione.Text = "10";
                if (int.Parse(textBoxValutazione.Text) == 0)
                    textBoxValutazione.Text = "1";
            }
        }
    }
}
