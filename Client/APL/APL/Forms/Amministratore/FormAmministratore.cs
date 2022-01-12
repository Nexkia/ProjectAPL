using APL.Connections;
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
    }
}
