﻿using APL.Connections;
using APL.Forms.Amministratore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private async void buttonEliminaComponente_Click(object sender, EventArgs e)
        {
            pt.SetProtocolID("cancellazione");pt.Data = TextBoxModello.Text;
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            string okmsg = await SocketTCP.receive();
            SocketTCP.GetMutex().ReleaseMutex();
        }

        private void buttonInserisciPreassemblato_Click(object sender, EventArgs e)
        {
            
            formInserisciPreassemblato.Show();
            this.Visible = false; //invisible amministratore
        }

        private  async void buttonEliminaPreassemblato_Click(object sender, EventArgs e)
        {
            pt.SetProtocolID("cancellazione_pre"); pt.Data = textBoxNome.Text;
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            string okmsg = await SocketTCP.receive();
            SocketTCP.GetMutex().ReleaseMutex();
        }

        private  void buttonStatistiche_Click(object sender, EventArgs e)
        {
            FormStatistiche statistiche = new FormStatistiche();

            pt.SetProtocolID("recupera_statistiche");
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            for (int i = 0; i < 3; i++)
            {

                byte[] vet =  SocketTCP.receiveBytesBlock();
                SocketTCP.sendSingleMsg("ok");
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
