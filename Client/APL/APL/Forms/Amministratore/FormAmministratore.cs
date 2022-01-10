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
        public FormAmministratore()
        {
            InitializeComponent();
        }

        private void buttonInserisciComponente_Click(object sender, EventArgs e)
        {
            FormInserisciComponente insert = new FormInserisciComponente();
            insert.Show();
        }
    }
}
