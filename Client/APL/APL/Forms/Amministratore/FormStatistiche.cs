using APL;
using APL.Cache;
using APL.UserControls.Amministratore;
using Org.BouncyCastle.Utilities.Zlib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.Forms.Amministratore
{
    public partial class FormStatistiche : Form
    {
        public FormStatistiche()
        {
            InitializeComponent();
        }

        private string venditePerData;
        private string venditeComponenti;
        private string venditePreassemblati;

        public void setVenditeComponenti(string value,int i){ 
            
            if(i==0)         
                venditePreassemblati = value;

            if (i == 1)
                venditePerData = value;

            if (i == 2)
                venditeComponenti = value;
        }
        private void FormStatistiche_Load(object sender, EventArgs e)
        {
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
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }






    }
}
