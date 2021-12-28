using Client.Properties;
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
    public partial class Profiles : UserControl
    {
        FlowLayoutPanel vecchioFlowLayoutPanel;
        public Profiles(FlowLayoutPanel vfp)
        {
            InitializeComponent();
            vecchioFlowLayoutPanel = vfp;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void prototypes_Load(object sender, EventArgs e)
        {

        }


        #region Properties

        private string _title;
        private string _price;
        private string _message;


        [Category("Custom Props")]
        public string Title
        {
            get { return _title; }
            set { _title = value; label1Prototypes.Text = value; }
        }

        [Category("Custom Props")]
        public string Price
        {
            get { return _price; }
            set { _price = value; label2Prototypes.Text = value; }
        }

        [Category("Custom Props")]
        public string Message
        {
            get { return _message; }
            set { _message = value; label3Prototypes.Text = value; }
        }

        

        #endregion





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
            vecchioFlowLayoutPanel.Controls.Clear();
            populateItemsComponenti();
        }

        private void populateItemsComponenti()
        {
           
            ComponentsTab[] componentsTab = new ComponentsTab[8];
            string[] vet = { "cpu", "schedaMadre","schedaVideo","casepc","dissipatore","alimentatore", "memoria", "ram" };

            //ci sono 8 iterazionei, una per ogni componente
            for (int i = 0; i < componentsTab.Length; i++)

            {
                componentsTab[i] = new ComponentsTab();

                    if (Array.Exists(vet, x => x =="cpu" /*pre[i].Componenti[j].Categoria*/))
                    {
                        componentsTab[i].Title = "categoria"+i;//"qui si mette il titolo";

                        componentsTab[i].Icon1 = Resources.imageNotFound2;
                        componentsTab[i].Message1 ="modello1" ;

                        componentsTab[i].Icon2 = Resources.imageNotFound2;
                        componentsTab[i].Message2 = "modello2";

                        componentsTab[i].Icon3 = Resources.imageNotFound2;
                        componentsTab[i].Message3 = "modello3";

                    }

                 //aggiunge al flow label
                if (vecchioFlowLayoutPanel.Controls.Count < 0)
                {

                    vecchioFlowLayoutPanel.Controls.Clear();
                }
                else
                    vecchioFlowLayoutPanel.Controls.Add(componentsTab[i]);


            }
        }

    }
}
