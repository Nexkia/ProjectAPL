using APL.Data.Detail;
using APL.Forms.Amministratore;
using System;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciRam : UserControl
    {
        private FormInserisciComponente inserisciComponente;
        public InserisciRam(FormInserisciComponente inserisciComponente)
        {
            InitializeComponent();
            this.inserisciComponente = inserisciComponente;
        }

        public Ram getInputDetail()
        {

            if (inserisciComponente.getModello() != string.Empty && textBoxValutazione.Text != string.Empty && textBoxFrequenza.Text != string.Empty
                 && textBoxStandard.Text != string.Empty )
            {
                Ram elem = new Ram()
                {
                    Modello = inserisciComponente.getModello(),
                    Valutazione = int.Parse(textBoxValutazione.Text),
                    Frequenza = float.Parse(textBoxFrequenza.Text),
                    Standard = textBoxStandard.Text
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

        private void textBoxFrequenza_TextChanged(object sender, EventArgs e)
        {
            bool isInvalidPrezzo = textBoxFrequenza.Text.Contains(".");
            //permette di inserire solo dei Float nella frequenza
            if (!float.TryParse(textBoxFrequenza.Text, out float value))
                textBoxFrequenza.Text = "";
            if (isInvalidPrezzo)
                textBoxFrequenza.Text = "";
            if (textBoxFrequenza.Text == "0")
                textBoxFrequenza.Text = "1";
        }
    }
}
