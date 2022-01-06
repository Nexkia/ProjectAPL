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

   
        public void Title(string m,float p) {label1info.Text = "Nome: " + m + " Prezzo: " + p;} 
        public string Message {set { label2info.Text = value; } }
        


    }
}
