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
    public partial class Info : UserControl
    {
        public Info()
        {
            InitializeComponent();
        }

        private string _title;

        public string Title {set { label1info.Text = value; } }
        public string Message {set { label2info.Text = value; } }



        private void label1info_Click(object sender, EventArgs e)
        {

        }

        private void Info_Load(object sender, EventArgs e)
        {

        }
    }
}
