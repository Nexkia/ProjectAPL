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
    public partial class ListItem : UserControl
    {

         
        public ListItem()
        {
            InitializeComponent();
           
            
        }


        #region Properties

        private string _title;
        private Color _iconBack;
        private string _message;
        private Image _icon;
        
        

        [Category ("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value;lblTitle.Text = value; }
        }
        [Category("Custom Props")]
        public Color IconBackground
        {
            get { return _iconBack; }
            set { _iconBack = value; panel1.BackColor = value; }
        }

        [Category("Custom Props")]
        public string Message
        {
            get { return _message; }
            set { _message = value; lblMessage.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get { return _icon; }
            set { _icon = value; pictureBox1.Image = value; }
        }

        
        #endregion





        private void lblMessage_MouseEnter(object sender, EventArgs e)
        {
           
                this.BackColor = Color.Silver;
           

           
        }

        private void lblMessage_MouseLeave(object sender, EventArgs e)
        {

            this.BackColor = Color.White;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void ListItem_Load(object sender, EventArgs e)
        {

        }

        private void lbl_MessageClick1(object sender, EventArgs e)
        {
            Console.WriteLine("hai cliccato");
            
        }
    }
}
