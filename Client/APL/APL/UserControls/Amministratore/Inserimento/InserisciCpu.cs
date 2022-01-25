using APL.Data.Detail;
using APL.Forms.Amministratore;
using System;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciCpu : UserControl
    {
        FormInserisciComponente inserisciComponente;
        public InserisciCpu(FormInserisciComponente inserisciComponente)
        {
            InitializeComponent();
            this.inserisciComponente = inserisciComponente;
        }

        public Cpu getInputDetail()
        {

            if (inserisciComponente.getModello() != string.Empty && textBoxValutazione.Text != string.Empty && textBoxFrequenza.Text != string.Empty
                 &&  textBoxSocket.Text != string.Empty && textBoxCore.Text != string.Empty && textBoxThread.Text != string.Empty)
            {
                Cpu elem = new Cpu()
                {
                    Modello = inserisciComponente.getModello(), 
                    Valutazione = int.Parse(textBoxValutazione.Text), 
                    Frequenza = float.Parse(textBoxFrequenza.Text), 
                    Socket = textBoxSocket.Text, 
                    Core = int.Parse(textBoxCore.Text),
                    Thread = int.Parse(textBoxThread.Text)
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

        private void textBoxCore_TextChanged(object sender, EventArgs e)
        {
            //impediamo di inserire un valore pari a 0
            if (textBoxCore.Text != string.Empty)
            {
                if (int.Parse(textBoxCore.Text) == 0)
                    textBoxCore.Text = "1";
            }

            if (textBoxThread.Text != string.Empty)
            {
                if (int.Parse(textBoxThread.Text) == 0)
                    textBoxThread.Text = "1";
            }
        }
    }
}
