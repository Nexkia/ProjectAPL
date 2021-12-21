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
            
        }


        protected override void OnClosed(EventArgs e)
        {
            vecchioForm.Visible = true;
            base.OnClosed(e);
        }

        



        private void button1_Click(object sender, EventArgs e)
        {
            vecchioForm.Visible = true;
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void prova1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
