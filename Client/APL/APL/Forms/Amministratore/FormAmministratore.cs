using APL.Connections;
using APL.Forms.Amministratore;
using System;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormAmministratore : Form
    {
        Protocol pt = new Protocol();
        bool disableCloseEvent;
        FormLogin_Register parent;
        FormInserisciPreassemblato formInserisciPreassemblato;
        FormInserisciComponente formInserisciComponente; 
        public FormAmministratore(FormLogin_Register f_start)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
            parent = f_start;
            formInserisciPreassemblato = new FormInserisciPreassemblato(this);
            formInserisciComponente = new FormInserisciComponente(this);
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
        private void buttonInserisciComponente_Click(object sender, EventArgs e)
        {
            
            formInserisciComponente.Show();
            this.Visible = false;
        }

        private void buttonEliminaComponente_Click(object sender, EventArgs e)
        {
            pt.SetProtocolID("cancellazione");pt.Data = TextBoxModello.Text;

            SocketTCP.GetMutex().WaitOne();
                SocketTCP.Send(pt.ToString());
                string response = SocketTCP.Receive();
            SocketTCP.GetMutex().ReleaseMutex();
        }

        private void buttonInserisciPreassemblato_Click(object sender, EventArgs e)
        {
            
            formInserisciPreassemblato.Show();
            this.Visible = false; //invisible amministratore
        }

        private  void buttonEliminaPreassemblato_Click(object sender, EventArgs e)
        {
            pt.SetProtocolID("cancellazione_pre"); pt.Data = textBoxNome.Text;
            SocketTCP.GetMutex().WaitOne();
                SocketTCP.Send(pt.ToString());
                string receve = SocketTCP.Receive();
            SocketTCP.GetMutex().ReleaseMutex();
        }

        private  void buttonStatistiche_Click(object sender, EventArgs e)
        {
            FormStatistiche statistiche = new FormStatistiche();

            pt.SetProtocolID("recupera_statistiche");
            SocketTCP.GetMutex().WaitOne();
                SocketTCP.Send(pt.ToString());
                for (int i = 0; i < 3; i++)
                {

                    string vet = SocketTCP.Receive();
                    statistiche.setVenditeComponenti(vet, i);
                }
            SocketTCP.GetMutex().ReleaseMutex();

            statistiche.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            parent.Visible = true;
            formInserisciPreassemblato.EnableCloseEvent();
            formInserisciPreassemblato.Close();
            base.OnClosed(e);
        }

    }
}
