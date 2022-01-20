using APL.Data.Detail;
using APL.Forms.Amministratore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciCasePc : UserControl
    {
        FormInserisciComponente inserisciComponente;
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
