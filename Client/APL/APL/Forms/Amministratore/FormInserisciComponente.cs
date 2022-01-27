using APL.Data;
using APL.UserControls.Amministratore.Inserimento;
using System;
using System.Windows.Forms;

namespace APL.Forms.Amministratore
{
    public partial class FormInserisciComponente : Form
    {
        private bool disableCloseEvent;
        private FormAmministratore parent;
        public FormInserisciComponente(FormAmministratore parent)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormAmministratore_FormClosing);
            disableCloseEvent = true;
            this.parent = parent;

        }

        private string categoria;
        public string getModello() { return textBoxModello.Text; }


        #region Chiusura-----------------------------------------------------------------
        public void EnableCloseEvent() { this.disableCloseEvent = false; }
        void FormAmministratore_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (disableCloseEvent == true)
            {

                //impedisce alla finestra di chiudersi
                e.Cancel = true;

                //rende la finestra invisibile
                this.Visible = false;
                parent.Visible = true;

            }
            else { e.Cancel = false; } //permette alla finestra di chiudersi
        }
        #endregion


        #region Scelta Componente---------------------------------------------------------
        private void buttonConfermaTipoComponente_Click(object sender, EventArgs e)
        {/*
          L'utente seleziona il componente dalla ComboBox, in base alla scelta vengono
            abilitati gli appositi campi del Form e viene caricato un diverso User Control
          */
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
                    textBoxCapienza.Text = "1";
                    break;
                case "memoria":
                    categoria = "memoria";
                    setReadOnly(false);
                    InserisciMemoria detMem = new InserisciMemoria(this);
                    setFlowLayoutPanel(detMem);
                    textBoxCapienza.Text = "1";
                    break;
                default:
                    MessageBox.Show("Selezionare un Componente", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }
        public void setReadOnly(bool value)
        {
            // se non si sceglie ram o memoria la capacità viene settata a 0 di default
            textBoxModello.ReadOnly =
            textBoxMarca.ReadOnly =
            textBoxPrezzo.ReadOnly = value;

            if (categoria != "ram" && categoria != "memoria")
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
            //aggiunge al flow label l'user control scelto 
            if (flowLayoutPanel1.Controls.Count < 0)
                flowLayoutPanel1.Controls.Clear();
            else
                flowLayoutPanel1.Controls.Add(value);
        }
        #endregion


        public Componente areFullAllTextBox()
        {
            /* Se i campi vengono riempiti correttamente ritorna il componente */
            if (textBoxModello.Text != string.Empty && textBoxMarca.Text != string.Empty
                && textBoxPrezzo.Text != string.Empty && textBoxCapienza.Text != string.Empty && categoria != string.Empty)
            {
                Componente comp = new Componente()
                {
                    Modello = textBoxModello.Text,
                    Marca = textBoxMarca.Text,
                    Prezzo = float.Parse(textBoxPrezzo.Text),
                    Capienza = int.Parse(textBoxCapienza.Text),
                    Categoria = categoria
                };

                return comp;
            }
            else
                return null;
        }


        #region Controlli TextBox------------------------------------------------------------
        private void textBoxCapienza_KeyPress(object sender, KeyPressEventArgs e)
        {
            //impedisce l'inserimento di un input non numerico
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }
        private void textBoxPrezzo_TextChanged(object sender, EventArgs e)
        {
            bool isInvalidPrezzo = textBoxPrezzo.Text.Contains(".");
            //permette di inserire solo dei Float nel prezzo
            if (!float.TryParse(textBoxPrezzo.Text, out float value))
                textBoxPrezzo.Text = "";
            if (isInvalidPrezzo)
                textBoxPrezzo.Text = "";
            if (textBoxPrezzo.Text == "0")
                textBoxPrezzo.Text = "1";
        }
        #endregion



    }
}
