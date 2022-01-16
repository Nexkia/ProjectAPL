using APL.UserControls.Amministratore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
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

        public void setVenditeComponenti(byte[] value){ venditeComponenti = value; }
        private void FormStatistiche_Load(object sender, EventArgs e)
        {
            ImgStatistiche img1 = new ImgStatistiche(byteArrayToImage(venditeComponenti));
            ImgStatistiche img2 = new ImgStatistiche(Image.FromFile("C:\\Users\\dario\\Source\\Repos\\ProjectAPL\\Client\\APL\\APL\\Img\\statistiche\\histDataVendite.png"));
            if (flowLayoutPanel1.Controls.Count < 0)
            {

                flowLayoutPanel1.Controls.Clear();
            }
            else 
            { 
                flowLayoutPanel1.Controls.Add(img1);
                flowLayoutPanel1.Controls.Add(img2);
            }
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
