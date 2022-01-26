using APL.Data.Detail;
using APL.Forms.Amministratore;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciAlimentatore : UserControl
    {
        private FormInserisciComponente inserisciComponente;
        
        public InserisciAlimentatore(FormInserisciComponente inserisciComponente)
        {
            InitializeComponent();
            this.inserisciComponente = inserisciComponente;
        }

        
        public Alimentatore getInputDetail()
        {
            
            if (inserisciComponente.getModello()!= string.Empty && textBoxValutazione.Text != string.Empty && textBoxWatt.Text != string.Empty)
            {
                Alimentatore elem = new Alimentatore() { 
                    Modello = inserisciComponente.getModello(), 
                    Valutazione = int.Parse(textBoxValutazione.Text), 
                    Watt = int.Parse(textBoxWatt.Text) 
                };
                return elem;
            }
            else { return null; }

            
        }

        private void buttonConferma_Click(object sender, EventArgs e)
        {
            if (this.getInputDetail() != null  && inserisciComponente.areFullAllTextBox()!=null)
            {
                InserimentoElemento.InserisciElemento(getInputDetail(), inserisciComponente.areFullAllTextBox());
                MessageBox.Show("Inserimento avvenuto",
                    "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Riempire i campi detail",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBoxWatt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBoxWatt_TextChanged(object sender, EventArgs e)
        {
            //impediamo di inserire un valore pari a 0
            if (textBoxWatt.Text != string.Empty)
            {
                if (int.Parse(textBoxWatt.Text) == 0)
                    textBoxWatt.Text = "1";
            }

        }
    }
}
