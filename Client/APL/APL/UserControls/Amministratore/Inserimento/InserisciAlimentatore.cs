using APL.Connections;
using APL.Data.Detail;
using APL.Forms.Amministratore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciAlimentatore : UserControl
    {
        FormInserisciComponente inserisciComponente;
        
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
