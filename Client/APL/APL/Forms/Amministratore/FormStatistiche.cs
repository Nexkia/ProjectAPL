using APL.UserControls.Amministratore;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace APL.Forms.Amministratore
{
    public partial class FormStatistiche : Form
    {
        private FormAmministratore parent;
        private bool disableCloseEvent;
        public FormStatistiche(FormAmministratore parent)
        {
            InitializeComponent();
            disableCloseEvent = true;
            this.FormClosing += new FormClosingEventHandler(FormAmministratore_FormClosing);
            this.parent = parent;
            
    }

        private string venditePerData;
        private string venditeComponenti;
        private string venditePreassemblati;

        #region Chiusura-------------------------------------------------------------------------
        public void EnableCloseEvent() { this.disableCloseEvent = false; }
        private void FormAmministratore_FormClosing(object sender, FormClosingEventArgs e)
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


        public void setVenditeComponenti(string value, int i)
        {
            //salviamo le 3 immagini delle statistiche
            if (i == 0)
                venditePreassemblati = value;
            if (i == 1)
                venditePerData = value;
            if (i == 2)
                venditeComponenti = value;
        }
        private void FormStatistiche_Load(object sender, EventArgs e)
        {
            mostraStatistiche();
        }
        private void FormStatistiche_VisibleChanged(object sender, EventArgs e)
        {
            mostraStatistiche();
        }
        private void mostraStatistiche()
        {
            flowLayoutPanel1.Controls.Clear();

            //mostriamo le immagini
            ImgStatistiche img1 = new ImgStatistiche(Base64ToImage(venditePreassemblati));
            ImgStatistiche img2 = new ImgStatistiche(Base64ToImage(venditePerData));
            ImgStatistiche img3 = new ImgStatistiche(Base64ToImage(venditeComponenti));

            if (flowLayoutPanel1.Controls.Count < 0)
            {
                flowLayoutPanel1.Controls.Clear();
            }
            else
            {
                flowLayoutPanel1.Controls.Add(img1);
                flowLayoutPanel1.Controls.Add(img2);
                flowLayoutPanel1.Controls.Add(img3);
            }
        }
        public Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to MmemoryStream
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            //Convert MemoryStream to Image
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
