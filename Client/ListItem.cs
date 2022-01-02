using Client.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ListItem : UserControl
    {
        Form2 vecchioForm2;
        FlowLayoutPanel vecchioflowLayoutPanel1;
        FlowLayoutPanel vecchioflowLayoutPanel2;
        
        public ListItem(FlowLayoutPanel vfp2,Form2 f2,FlowLayoutPanel vfp1)
        {
            InitializeComponent();
            vecchioflowLayoutPanel1 = vfp1;
            vecchioflowLayoutPanel2 = vfp2;
            vecchioForm2 = f2;
            


        }

        
        public string Title{  set { lblTitle.Text = value; }}
        public Color IconBackground{  set {  panel1.BackColor = value; }}
        public string Message{set {  lblMessage.Text = value; }}
        public Image Icon{set { pictureBox1.Image = value; }}
        public Preassemblato pre { get; set; }
      
        private void lblMessage_MouseEnter(object sender, EventArgs e)
        {
                this.BackColor = Color.Silver;
        }

        private void lblMessage_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void lbl_MessageClick1(object sender, EventArgs e)
        {
            Console.WriteLine("hai cliccato");
            vecchioflowLayoutPanel2.Controls.Clear();

            vecchioForm2.allargaForm2();
            populateItemsInfo();
        }

        private  void populateItemsInfo()
        {
         
            Info info = new Info();
            info.Title = "Nome: " + pre.Nome+ " Prezzo:"+pre.Prezzo;

            string message = "";
            //8 come il numero dei componenti
            for (int j = 0; j < 8; j++)
            {
                
                    message += "• "+pre.Componenti[j].Categoria + "\n"
                              + pre.Componenti[j].Marca + " " + pre.Componenti[j].Modello+" "+ pre.Componenti[j].Prezzo+" €";
                
                if (int.Parse(pre.Componenti[j].Capienza) > 0)
                    {
                        message += " " + pre.Componenti[j].Capienza + " GB";
                    
                }
                

                    message += "\n";
                

            }
            info.Message = message;

            //resetto il colore degli altri user control
            foreach (Control control in vecchioflowLayoutPanel1.Controls)
            {
                
                control.ForeColor = Color.Black;
            }

           this.ForeColor = Color.Red;


            
            vecchioflowLayoutPanel2.Controls.Add(info);
            }

       
            
        }
}
