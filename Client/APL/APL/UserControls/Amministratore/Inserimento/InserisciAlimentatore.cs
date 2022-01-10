using APL.Data.Detail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore.Inserimento
{
    public partial class InserisciAlimentatore : UserControl
    {
        public InserisciAlimentatore()
        {
            InitializeComponent();
        }


        public Alimentatore getInput()
        {
            Alimentatore elem = new Alimentatore();

            elem.Modello = "error";
            if (textBoxModello.Text != string.Empty && textBoxValutazione.Text != string.Empty && textBoxWatt.Text != string.Empty)
            {
                elem.Modello = textBoxModello.Text;
                elem.Valutazione = int.Parse(textBoxValutazione.Text);
            }

            return elem;
        }
    }
}
