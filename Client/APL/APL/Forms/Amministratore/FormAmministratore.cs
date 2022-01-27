using APL.Connections;
using APL.Forms.Amministratore;
using System;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormAmministratore : Form
    {
        private Protocol pt;
        private bool disableCloseEvent;
        private FormLogin_Register parent;
        private FormInserisciPreassemblato formInserisciPreassemblato;
        private FormInserisciComponente formInserisciComponente;
        private FormStatistiche formStatistiche;
        
        public FormAmministratore(FormLogin_Register f_start)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
            parent = f_start;
            formInserisciPreassemblato = new FormInserisciPreassemblato(this);
            formInserisciComponente = new FormInserisciComponente(this);
            formStatistiche = new FormStatistiche(this);
            pt = new Protocol();
        }

        #region Chiusura------------------------------------------------------------------
        protected override void OnClosed(EventArgs e)
        {
            parent.Visible = true;
            //quando l'amministratore si chiude chiude tutti gli altri form
            formInserisciPreassemblato.EnableCloseEvent();
            formInserisciComponente.EnableCloseEvent();
            formInserisciPreassemblato.Close();
            formInserisciComponente.Close();
            base.OnClosed(e);
        }
        public void EnableCloseEvent() { this.disableCloseEvent = false; }
        void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (disableCloseEvent == true)
            {
                //impedisce alla finestra di chiudersi
                e.Cancel = true;

                //rende la finestra invisibile
                this.Visible = false;
                parent.Visible = true;
            }
            else { e.Cancel = false; } //permette alla finestra di chiudersi
        }
        #endregion


        #region Button-----------------------------------------------------------------------
        private void buttonInserisciComponente_Click(object sender, EventArgs e)
        {
            formInserisciComponente.Show();
            this.Visible = false;
        }
        private void buttonInserisciPreassemblato_Click(object sender, EventArgs e)
        {
            formInserisciPreassemblato.Show();
            this.Visible = false; //invisible amministratore
        }
        private void buttonEliminaComponente_Click(object sender, EventArgs e)
        {
            if (TextBoxModello.Text != string.Empty)
            {
                pt.SetProtocolID("cancellazione"); pt.Data = TextBoxModello.Text;
                /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
                SocketTCP.Wait();
                /*  Invio modello del componente da cancellare
                    Ne verrà cancellato anche il rispettivo detail 
                */
                SocketTCP.Send(pt.ToString());
                string response = SocketTCP.Receive();
                SocketTCP.Release();
                /// FINE SCAMBIO DI MESSAGGI CON IL SERVER

                if (response == "Done")
                {
                    MessageBox.Show("Eliminazione avvenuta correttamente",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TextBoxModello.Text = "";
                }
                if (response == "NotFound")
                {
                    MessageBox.Show("Eliminazione fallita",
                   "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private  void buttonEliminaPreassemblato_Click(object sender, EventArgs e)
        {
            if (textBoxNome.Text != string.Empty) 
            {
                pt.SetProtocolID("cancellazione_pre"); pt.Data = textBoxNome.Text;
                /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
                SocketTCP.Wait();
                SocketTCP.Send(pt.ToString());
                string response = SocketTCP.Receive();
                SocketTCP.Release();
                /// FINE SCAMBIO DI MESSAGGI CON IL SERVER

                if (response == "NotFound")
                {
                    MessageBox.Show("Eliminazione fallita",
                   "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (response == "Done")
                {
                    MessageBox.Show("Eliminazione avvenuta correttamente",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNome.Text = "";
                }
            }
        }
        private  void buttonStatistiche_Click(object sender, EventArgs e)
        {
            pt.SetProtocolID("recupera_statistiche");
            /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER    
            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());
            for (int i = 0; i < 3; i++)
            {
                string Img =  SocketTCP.Receive();
                formStatistiche.setVenditeComponenti(Img, i);
            }
            SocketTCP.Release();
            /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
            formStatistiche.Show();
        }
        #endregion

    }
}
