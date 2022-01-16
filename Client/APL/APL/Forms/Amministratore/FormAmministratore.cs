using APL.Connections;
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
        public FormAmministratore()
        {
            InitializeComponent();
           
        }

        private void buttonInserisciComponente_Click(object sender, EventArgs e)
        {
            FormInserisciComponente insert = new FormInserisciComponente();
            insert.Show();
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
            FormInserisciPreassemblato pre = new FormInserisciPreassemblato();
            pre.Show();
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

       
        
    }
}
