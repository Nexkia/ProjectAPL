using APL.UserControls.Amministratore;
using System;
using System.Drawing;
using System.IO;
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
            ImgStatistiche img1 = new ImgStatistiche(byteArrayToImage(venditePreassemblati));
            ImgStatistiche img2 = new ImgStatistiche(byteArrayToImage(venditePerData));
            ImgStatistiche img3 = new ImgStatistiche(byteArrayToImage(venditeComponenti));
           
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


       
        public Image byteArrayToImage(string image64Bit)
        {
            Image returnImage=ConvertBase64StringToImage(image64Bit);
            return returnImage;
        }


        public Image ConvertBase64StringToImage(string image64Bit)
        {
            byte[] imageBytes = Convert.FromBase64String(image64Bit);
            return new Bitmap(new MemoryStream(imageBytes));
        }




    }
}
