using System.Drawing;
using System.Windows.Forms;

namespace APL.UserControls.Amministratore
{
    public partial class ImgStatistiche : UserControl
    {
        public ImgStatistiche(Image img)
        {
            InitializeComponent();
            pictureBox1.Image = img;
        }
    }
}
