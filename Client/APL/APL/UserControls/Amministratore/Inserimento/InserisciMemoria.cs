﻿using APL.Data.Detail;
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
    public partial class InserisciMemoria : UserControl
    {
        FormInserisciComponente inserisciComponente;
        public InserisciMemoria(FormInserisciComponente inserisciComponente)
        {
            InitializeComponent();
            this.inserisciComponente = inserisciComponente;
        }

        public Memoria getInputDetail()
        {

            if (inserisciComponente.getModello() != string.Empty && textBoxValutazione.Text != string.Empty && comboBoxTipo.Text != string.Empty)
            {
                Memoria elem = new Memoria(inserisciComponente.getModello(),
                    int.Parse(textBoxValutazione.Text), comboBoxTipo.Text);
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