using APL.Connections;
using APL.Data;
using APL.UserControls.Amministratore.Inserimento;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        public string getModello() { return textBoxModello.Text; }
        private void buttonConfermaTipoComponente_Click(object sender, EventArgs e)
        {

            switch (comboBox1.Text)
            {
                case "cpu":
                    categoria = "cpu";
                    setReadOnly(false);
                    InserisciCpu detCpu = new InserisciCpu(this);
                    setFlowLayoutPanel(detCpu);
                    break;
                case "schedaVideo":
                    categoria = "schedaVideo";
                    setReadOnly(false);
                    InserisciSchedaVideo detScVid = new InserisciSchedaVideo(this);
                    setFlowLayoutPanel(detScVid);
                    break;
                case "schedaMadre":
                    categoria = "schedaMadre";
                    setReadOnly(false);
                    InserisciSchedaMadre detScMad = new InserisciSchedaMadre(this);
                    setFlowLayoutPanel(detScMad);
                    break;
                case "dissipatore":
                    categoria = "dissipatore";
                    setReadOnly(false);
                    InserisciDissipatore detDis = new InserisciDissipatore(this);
                    setFlowLayoutPanel(detDis);
                    break;
                case "alimentatore":
                    categoria = "alimentatore";
                    setReadOnly(false);
                    InserisciAlimentatore detAli = new InserisciAlimentatore(this);
                    setFlowLayoutPanel(detAli);
                        break;
                case "casepc":
                    categoria = "casepc";
                    setReadOnly(false);
                    InserisciCasePc detCase = new InserisciCasePc(this);
                    setFlowLayoutPanel(detCase);
                    break;
                case "ram":
                    categoria = "ram";
                    setReadOnly(false);
                    InserisciRam detRam = new InserisciRam(this);
                    setFlowLayoutPanel(detRam);
                    break;
                case "memoria":
                    categoria = "memoria";
                    setReadOnly(false);
                    InserisciMemoria detMem = new InserisciMemoria(this);
                    setFlowLayoutPanel(detMem);
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

        public Componente areFullAllTextBox()
        {

            if(textBoxModello.Text!=string.Empty && textBoxMarca.Text!=string.Empty
                && textBoxPrezzo.Text!=string.Empty && textBoxCapienza.Text != string.Empty && categoria !=string.Empty)
            {
                Componente comp = new Componente(textBoxModello.Text, textBoxMarca.Text, 
                    float.Parse(textBoxPrezzo.Text), int.Parse(textBoxCapienza.Text), categoria);
               
                return comp;
            }
            else {
               
                return null; }
            
        }
       
    }
}
