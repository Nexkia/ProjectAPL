using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class schedaConfronto : UserControl
    {
        public schedaConfronto()
        {
            InitializeComponent();
        }

        public void labelCategoriaName(string value) { labelCategoria.Text = value; }

       
        public void panelNascosto2VisibileOFF() { panelNascosto2.Visible = false; }
        public void panelNascosto3VisibileOFF() { panelNascosto3.Visible = false; }
        public void label5Invisible() { label5.Visible = false;  }
        public void label6Invisible() { label6.Visible = false; }
        public void panel6Invisible() { panel6.Visible = false; }
        public void label7Invisible() { label7.Visible = false; }
        public void panel7Invisible() { panel7.Visible = false; }
        public void label8Invisible() { label8.Visible = false; }
        public void panel8Invisible() { panel8.Visible = false; }
        public void labelMod1Det3Invisible() { labelMod1Det3.Visible = false;  }
        public void labelMod1Det4Invisible() { labelMod1Det4.Visible = false; }
        public void labelMod1Det5Invisible() { labelMod1Det5.Visible = false; }
        public void labelMod1Det6Invisible() { labelMod1Det6.Visible = false; }
        public void labelMod2Det3Invisible() { labelMod2Det3.Visible = false; }
        public void labelMod2Det4Invisible() { labelMod2Det4.Visible = false; }
        public void labelMod2Det5Invisible() { labelMod2Det5.Visible = false; }
        public void labelMod2Det6Invisible() { labelMod2Det6.Visible = false; }
        public void labelMod3Det3Invisible() { labelMod3Det3.Visible = false; }
        public void labelMod3Det4Invisible() { labelMod3Det4.Visible = false; }
        public void labelMod3Det5Invisible() { labelMod3Det5.Visible = false; }
        public void labelMod3Det6Invisible() { labelMod3Det6.Visible = false; }

        public void label3Name(string value) {label3.Text = value;  }
        public void label4Name(string value) { label4.Text = value; }
        public void label5Name(string value) { label5.Text = value; }
        public void label6Name(string value) { label6.Text = value; }
        public void label7Name(string value) { label7.Text = value; }
        public void label8Name(string value) { label8.Text = value; }

        public void labelModello1Name(string value) { labelModello1.Text = value; }
        public void labelModello2Name(string value) { labelModello2.Text = value; }
        public void labelModello3Name(string value) { labelModello3.Text = value; }

        public void labelValutazione1Name(string value) { labelValutazione1.Text = value; }
        public void labelValutazione2Name(string value) { labelValutazione2.Text = value; }
        public void labelValutazione3Name(string value) { labelValutazione3.Text = value; }

        public void labelValutazione1Color(Color value) { labelValutazione1.ForeColor = value; }
        public void labelValutazione2Color(Color value) { labelValutazione2.ForeColor = value; }
        public void labelValutazione3Color(Color value) { labelValutazione3.ForeColor = value; }

        public void labelMod1Det1Name(string value) { labelMod1Det1.Text = value; }
        public void labelMod1Det2Name(string value) { labelMod1Det2.Text = value; }
        public void labelMod1Det3Name(string value) { labelMod1Det3.Text = value; }
        public void labelMod1Det4Name(string value) { labelMod1Det4.Text = value; }
        public void labelMod1Det5Name(string value) { labelMod1Det5.Text = value; }
        public void labelMod1Det6Name(string value) { labelMod1Det6.Text = value; }

        public void labelMod2Det1Name(string value) { labelMod2Det1.Text = value; }
        public void labelMod2Det2Name(string value) { labelMod2Det2.Text = value; }
        public void labelMod2Det3Name(string value) { labelMod2Det3.Text = value; }
        public void labelMod2Det4Name(string value) { labelMod2Det4.Text = value; }
        public void labelMod2Det5Name(string value) { labelMod2Det5.Text = value; }
        public void labelMod2Det6Name(string value) { labelMod2Det6.Text = value; }

        public void labelMod3Det1Name(string value) { labelMod3Det1.Text = value; }
        public void labelMod3Det2Name(string value) { labelMod3Det2.Text = value; }
        public void labelMod3Det3Name(string value) { labelMod3Det3.Text = value; }
        public void labelMod3Det4Name(string value) { labelMod3Det4.Text = value; }
        public void labelMod3Det5Name(string value) { labelMod3Det5.Text = value; }
        public void labelMod3Det6Name(string value) { labelMod3Det6.Text = value; }

        public void labelMod1Det1Color(Color value) { labelMod1Det1.ForeColor = value; }
        public void labelMod1Det2Color(Color value) { labelMod1Det2.ForeColor = value; }
        public void labelMod1Det3Color(Color value) { labelMod1Det3.ForeColor = value; }
        public void labelMod1Det4Color(Color value) { labelMod1Det4.ForeColor = value; }
        public void labelMod1Det5Color(Color value) { labelMod1Det5.ForeColor = value; }
        public void labelMod1Det6Color(Color value) { labelMod1Det6.ForeColor = value; }

        public void labelMod2Det1Color(Color value) { labelMod2Det1.ForeColor = value; }
        public void labelMod2Det2Color(Color value) { labelMod2Det2.ForeColor = value; }
        public void labelMod2Det3Color(Color value) { labelMod2Det3.ForeColor = value; }
        public void labelMod2Det4Color(Color value) { labelMod2Det4.ForeColor = value; }
        public void labelMod2Det5Color(Color value) { labelMod2Det5.ForeColor = value; }
        public void labelMod2Det6Color(Color value) { labelMod2Det6.ForeColor = value; }

        public void labelMod3Det1Color(Color value) { labelMod3Det1.ForeColor = value; }
        public void labelMod3Det2Color(Color value) { labelMod3Det2.ForeColor = value; }
        public void labelMod3Det3Color(Color value) { labelMod3Det3.ForeColor = value; }
        public void labelMod3Det4Color(Color value) { labelMod3Det4.ForeColor = value; }
        public void labelMod3Det5Color(Color value) { labelMod3Det5.ForeColor = value; }
        public void labelMod3Det6Color(Color value) { labelMod3Det6.ForeColor = value; }



        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelModello1_Click(object sender, EventArgs e)
        {

        }

        private void panelNascondi2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxMod2Det2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
