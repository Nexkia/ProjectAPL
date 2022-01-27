using APL.Data.Detail;
using APL.Forms.Amministratore;
using System;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciSchedaVideo : UserControl
    {
        private FormInserisciComponente inserisciComponente;
        public InserisciSchedaVideo(FormInserisciComponente inserisciComponente)
        {
            InitializeComponent();
            this.inserisciComponente = inserisciComponente;
        }

        public SchedaVideo getInputDetail()
        {

            if (inserisciComponente.getModello() != string.Empty && textBoxValutazione.Text != string.Empty
                && textBoxTdp.Text != string.Empty && textBoxVram.Text != string.Empty)
            {
                SchedaVideo elem = new SchedaVideo()
                {
                    Modello = inserisciComponente.getModello(),
                    Valutazione = int.Parse(textBoxValutazione.Text),
                    Tdp = int.Parse(textBoxTdp.Text),
                    Vram = int.Parse(textBoxVram.Text)
                };
                return elem;
            }
            else { return null; }


        }

        private void buttonConferma_Click(object sender, EventArgs e)
        {
            if (this.getInputDetail() != null && inserisciComponente.areFullAllTextBox() != null)
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

        private void textBoxValutazione_KeyPress(object sender, KeyPressEventArgs e)
        {
            //impedisce l'inserimento di un input non numerico
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void textBoxTdp_TextChanged(object sender, EventArgs e)
        {
            //impediamo di inserire un valore pari a 0
            if (textBoxTdp.Text != string.Empty)
            {
                if (int.Parse(textBoxTdp.Text) == 0)
                    textBoxTdp.Text = "1";
            }

            if (textBoxVram.Text != string.Empty)
            {
                if (int.Parse(textBoxVram.Text) == 0)
                    textBoxVram.Text = "1";
            }
        }
    }
}
