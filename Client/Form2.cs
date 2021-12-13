using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Client
{
    public partial class Form2 : Form
    {
        Form1 vecchioForm;
        public Form2(Form1 f)
        {
            InitializeComponent();
             vecchioForm = f;
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.AbortRetryIgnore;
        }

        




        private void button1_Click(object sender, EventArgs e)
        {
            vecchioForm.Visible = true;
            this.Close();
        }
    }
}
