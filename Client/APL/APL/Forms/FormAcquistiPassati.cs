using APL.UserControls;
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
    public partial class FormAcquistiPassati : Form
    {
        public FormAcquistiPassati()
        {
            InitializeComponent();
        }

        public void aggiungiElementoCronologia(ElementoCronologia elem)
        {
            //aggiunge al flow label
            if (flowLayoutPanel1.Controls.Count < 0)
            {

                flowLayoutPanel1.Controls.Clear();
            }
            else
                flowLayoutPanel1.Controls.Add(elem);


        }
    
    }
}
