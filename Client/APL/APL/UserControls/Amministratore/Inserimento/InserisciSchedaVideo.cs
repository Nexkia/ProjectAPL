using APL.Data.Detail;
using APL.Forms.Amministratore;
using System;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciSchedaVideo : UserControl
    {
        FormInserisciComponente inserisciComponente;
        public InserisciSchedaVideo(FormInserisciComponente inserisciComponente)
        {
            InitializeComponent();
            this.inserisciComponente = inserisciComponente;
        }

        public SchedaVideo getInputDetail()
        {

            if (inserisciComponente.getModello() != string.Empty && textBoxValutazione.Text != string.Empty 
                && textBoxTdp.Text != string.Empty && textBoxVram.Text != string.Empty )
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
            if (this.getInputDetail() != null && inserisciComponente.areFullAllTextBox()!=null)
            {
                MessageBox.Show("Inserimento avvenuto",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                MessageBox.Show("Riempire i campi detail",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
