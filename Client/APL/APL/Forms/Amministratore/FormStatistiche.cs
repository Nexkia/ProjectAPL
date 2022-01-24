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

        private byte[] venditePerData;
        private byte[] venditeComponenti;
        private byte[] venditePreassemblati;

        public void setVenditeComponenti(byte[] value,int i){ 
            
            if(i==0)         
                venditePreassemblati = value;

            if (i == 1)
                venditePerData = value;

            if (i == 2)
                venditeComponenti = value;
        }
        private void FormStatistiche_Load(object sender, EventArgs e)
        {
            ImgStatistiche img1 = new ImgStatistiche(byteArrayToImage(venditePreassemblati));
            //ImgStatistiche img2 = new ImgStatistiche(byteArrayToImage(venditePerData));
            //ImgStatistiche img3 = new ImgStatistiche(byteArrayToImage(venditeComponenti));
           
            if (flowLayoutPanel1.Controls.Count < 0)
            {

                flowLayoutPanel1.Controls.Clear();
            }
            else 
            { 
                flowLayoutPanel1.Controls.Add(img1);
               // flowLayoutPanel1.Controls.Add(img2);
              //  flowLayoutPanel1.Controls.Add(img3);
            }
        }


       
        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);

            //System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            //Image Image = (Image)converter.ConvertFrom(byteArrayIn);

            return returnImage;
        }



       



    }
}
