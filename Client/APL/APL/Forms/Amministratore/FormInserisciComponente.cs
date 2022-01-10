using APL.UserControls.Amministratore.Inserimento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.Forms.Amministratore
{
    public partial class FormInserisciComponente : Form
    {
        public FormInserisciComponente()
        {
            InitializeComponent();
        }

        private string categoria;

        private void buttonConfermaTipoComponente_Click(object sender, EventArgs e)
        {

            switch (comboBox1.Text)
            {
                case "cpu":
                    setReadOnly(false);
                    categoria = "cpu";
                    break;
                case "schedaVideo":
                    categoria = "schedaVideo";
                    setReadOnly(false);
                    break;
                case "schedaMadre":
                    categoria = "schedaMadre";
                    setReadOnly(false);
                    break;
                case "dissipatore":
                    categoria = "dissipatore";
                    setReadOnly(false);
                    break;
                case "alimentatore":
                    categoria = "alimentatore";
                    setReadOnly(false);
                    InserisciAlimentatore elem = new InserisciAlimentatore();
                    setFlowLayoutPanel(elem);
                    break;
                case "casepc":
                    categoria = "casepc";
                    setReadOnly(false);
                    break;
                case "ram":
                    categoria = "ram";
                    setReadOnly(false);
                    break;
                case "memoria":
                    categoria = "memoria";
                    setReadOnly(false);
                    break;
                default:
                    MessageBox.Show("Selezionare un Componente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

            }
        }

        public void setReadOnly(bool value)
        {
            textBoxModello.ReadOnly =
            textBoxMarca.ReadOnly =
            textBoxPrezzo.ReadOnly = value;

            if(categoria!="ram" && categoria != "memoria")
            {
                textBoxCapienza.ReadOnly = !value;
                textBoxCapienza.Text = "0";
            }
            else
            {
                textBoxCapienza.ReadOnly = value;
            }
            
           
        }

        public void setFlowLayoutPanel(Control value)
        {
            
            flowLayoutPanel1.Controls.Clear();
            //aggiunge al flow label
            if (flowLayoutPanel1.Controls.Count< 0)
                {

                    flowLayoutPanel1.Controls.Clear();
                }
                else
                    flowLayoutPanel1.Controls.Add(value);

        }
    }
}
