using System.Windows.Forms;

namespace APL.UserControls
{
    public partial class Info : UserControl
    {
        public Info()
        {
            InitializeComponent();
        }

        public void Title(string m, float p) { label1info.Text = "Nome: " + m + " Prezzo: " + p; }
        public string Message { set { label2info.Text = value; } }
    }
}
