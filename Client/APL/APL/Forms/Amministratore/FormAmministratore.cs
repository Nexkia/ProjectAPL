﻿using APL.Connections;
using APL.Forms.Amministratore;
using System;
using System.Diagnostics;
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
        
        public FormAmministratore(FormLogin_Register f_start)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
            parent = f_start;
            formInserisciPreassemblato = new FormInserisciPreassemblato(this);
            formInserisciComponente = new FormInserisciComponente(this);
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

                SocketTCP.Wait();
                /*  Invio modello del componente da cancellare
                    Ne verrà cancellato anche il rispettivo detail 
                */
                SocketTCP.Send(pt.ToString());
                string response = SocketTCP.Receive();
                SocketTCP.Release();

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
                SocketTCP.Wait();
                SocketTCP.Send(pt.ToString());
                string receve = SocketTCP.Receive();
                SocketTCP.Release();
  
                if (receve == "NotFound")
                {
                    MessageBox.Show("Eliminazione fallita",
                   "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (receve == "Done")
                {
                    MessageBox.Show("Eliminazione avvenuta correttamente",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBoxNome.Text = "";
                }
            }
        }
        private  void buttonStatistiche_Click(object sender, EventArgs e)
        {
            FormStatistiche statistiche = new FormStatistiche();

            pt.SetProtocolID("recupera_statistiche");
            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());
            for (int i = 0; i < 3; i++)
            {
                string Img =  SocketTCP.Receive();
                statistiche.setVenditeComponenti(Img, i);
            }
            SocketTCP.Release();
            statistiche.Show();
        }
        #endregion

    }
}
