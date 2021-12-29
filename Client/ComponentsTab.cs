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
    public partial class ComponentsTab : UserControl
    {
        public ComponentsTab()
        {
            InitializeComponent();
        }

        #region Properties

        private string _title;
        private string _message1;
        private string _message2;
        private string _message3;
        private Image _icon1;
        private Image _icon2;
        private Image _icon3;



        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; label1ComponentsTab.Text = value; }
        }
       

        [Category("Custom Props")]
        public string Message1
        {
            get { return _message1; }
            set { _message1 = value; label2ComponentsTab.Text = value; }
        }

        [Category("Custom Props")]
        public string Message2
        {
            get { return _message2; }
            set { _message2 = value; label3ComponentsTab.Text = value; }
        }

        [Category("Custom Props")]
        public string Message3
        {
            get { return _message3; }
            set { _message3 = value; label4ComponentsTab.Text = value; }
        }

        [Category("Custom Props")]
        public Image Icon1
        {
            get { return _icon1; }
            set { _icon1 = value; pictureBox1ComponentsTab.Image = value; }
        }

        [Category("Custom Props")]
        public Image Icon2
        {
            get { return _icon2; }
            set { _icon2 = value; pictureBox2ComponentsTab.Image = value; }
        }

        [Category("Custom Props")]
        public Image Icon3
        {
            get { return _icon3; }
            set { _icon3 = value; pictureBox3ComponentsTab.Image = value; }
        }

        #endregion


    }
}
