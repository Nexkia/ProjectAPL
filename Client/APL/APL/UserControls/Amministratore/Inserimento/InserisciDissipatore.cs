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
    public partial class InserisciDissipatore : UserControl
    {
        FormInserisciComponente inserisciComponente;
        public InserisciDissipatore(FormInserisciComponente inserisciComponente)
        {
            InitializeComponent();
            this.inserisciComponente=inserisciComponente;
            CpuSocket = new List<string>();
        }

        private List<string> CpuSocket;
        
        public Dissipatore getInputDetail()
        {
            string[] vet = creaArrayCpuSocket();
            Debug.WriteLine("getInputDetail");
            if (inserisciComponente.getModello() != string.Empty && textBoxValutazione.Text != string.Empty && vet.Length>0 )
            {
                Dissipatore elem = new Dissipatore() 
                { 
                    Modello = inserisciComponente.getModello(), 
                    Valutazione = int.Parse(textBoxValutazione.Text), 
                    CpuSocket=vet 
                };
                Debug.WriteLine("getInputDetail true");
                return elem;
            }
            else { Debug.WriteLine("getInputDetail false"); return null; }
        }

            
        

        private string[] creaArrayCpuSocket()
        {
            if (CpuSocket.Count > 0)
            {
                string[] vet = new string[CpuSocket.Count];

                for(int i=0;i< CpuSocket.Count; i++)
                {
                    vet[i] = CpuSocket[i];
                }

                return vet;
            }
            else
            {
                MessageBox.Show("Inserire almeno una Cpu Socket", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

           
        }

        private bool cpuSocketGiaPresente(string value)
        {
            foreach (string item in CpuSocket)
            {
                if (value == item)
                {
                    return true;
                }
               
            }

            return false;
        }

        private void buttonAggiungiCpuSocket_Click(object sender, EventArgs e)
        {
            //se l'elemento non è già presente
            if (cpuSocketGiaPresente(textBoxAggiungiCpuSocket.Text) == false && textBoxAggiungiCpuSocket.Text!="")
            {
                //aggiungo l'elemento della textbox alla nostra lista
                CpuSocket.Add(textBoxAggiungiCpuSocket.Text);

                string message = "";
                foreach (string item in CpuSocket)
                {

                    message += item.ToString() + ",\n";
                }

                //aggiorno la texbox che fa vedere tutti i CpuSocket inseriti fino ad adesso
                textBoxCpuSocket.Text = message.Replace("\n", Environment.NewLine); 
                
            }
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

        private void buttonRimuoviCpuSocket_Click(object sender, EventArgs e)
        {
            
                //controlliamo che l'elemento da rimuovere sia effettivamente presente
                if (cpuSocketGiaPresente(textBoxAggiungiCpuSocket.Text) == true && textBoxAggiungiCpuSocket.Text != "")
                {
                    //rimuovo l'elemento della textbox dalla nostra lista
                    CpuSocket.Remove(textBoxAggiungiCpuSocket.Text);

                    string message = "";
                    foreach (string item in CpuSocket)
                    {

                        message += item.ToString() + ",\n";
                    }

                    //aggiorno la textbox di CpuSocket 
                    textBoxCpuSocket.Text = message.Replace("\n", Environment.NewLine);

            }
        }


    }
}
