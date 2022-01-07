using System;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormCheckOut : Form
    {
        public FormCheckOut()
        {
            InitializeComponent();

            
        }

        private float totale;
        private string cvv;
        private string numeroCarta;
        private string meseScadenza;
        private string annoScadenza;
        private string indirizzoFatturazione;
        private string nome;
        private string cognome;
        public ListView getListView() { return listViewCheckOut; }

        public void calcolaTotale()
        {
           
            string prezzo;
            string tipo;

            float totPreassemblato=0;
            float totBuildSolo=0;
            float totBuildGuidata=0;
            

            foreach (ListViewItem item in listViewCheckOut.Items)
            {
                 prezzo = item.SubItems[2].Text.ToString();
                 tipo = item.SubItems[5].Text.ToString();

                if (tipo == "preassemblato")
                {
                    totPreassemblato += float.Parse(prezzo);
                }

                if(tipo == "Build Guidata")
                {
                    totBuildGuidata += float.Parse(prezzo);
                }

                if (tipo == "Build Solo")
                {
                    totBuildSolo += float.Parse(prezzo);
                }
            }

            float tot =  (totPreassemblato + totBuildGuidata + totBuildSolo);

            // oltre le due cifre decimali, tronca il valore del totale
            totale = (float)(Math.Truncate((double)tot * 100.0) / 100.0); 
            

            labelTotale.Text = "Costi dei Preassemblati: " + totPreassemblato + "\n" +
                        "Costi Build Solo: " + totBuildSolo + "\n" +
                        "Costi Build Guidata: " + totBuildGuidata + "\n" +
                        "Totale: "+totale;
        }

        private void buttonConfermaCheckout_Click(object sender, EventArgs e)
        {
            Console.WriteLine("sei dentro conferma");
            MessageBox.Show("Sei dentro conferma",
                           "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            indirizzoFatturazione = textBoxIndirizzoFatturazione.Text;

            meseScadenza = textBoxMese.Text;
            annoScadenza = textBoxAnno.Text;

            cvv = textBoxCVV.Text;

            numeroCarta = textBoxNumeroCarta.Text;

            nome = textBoxNome.Text;
            cognome = textBoxCognome.Text;

            if (indirizzoFatturazione != string.Empty && meseScadenza != string.Empty && annoScadenza != string.Empty
                && cvv != string.Empty && numeroCarta != string.Empty && nome != string.Empty && cognome != string.Empty)
            {

            }
            else
            {
                Console.WriteLine("Riempire tutti i campi");
            }
        }

        
    } 
}
