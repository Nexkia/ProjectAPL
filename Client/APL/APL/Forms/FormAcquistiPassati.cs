using APL.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormAcquistiPassati : Form
    {
        public FormAcquistiPassati()
        {
            InitializeComponent();
        }

       
        public void aggiungiElementoCronologia(ElementoCronologia elem)
        {
            //aggiunge al flow label
            if (flowLayoutPanel1.Controls.Count < 0)
            {

                flowLayoutPanel1.Controls.Clear();
            }
            else
                flowLayoutPanel1.Controls.Add(elem);


        }

        private ElementoCronologia creaElementoCronologia(string[][] vet, string tot)
        {
            ElementoCronologia elem = new ElementoCronologia();

            elem.setPrezzo(tot);
            int i, j;

            for (i = 0; i < vet.Length; i++)
            {

                for (j = 0; j < vet[i].Length; j++)
                {

                    elem.addElementListView(vet[i][j]);

                }
            }

            return elem;
        }

        public void recuperaAcquisti()
        {
            //--------da cancellare---------------------------------
            string[][] lista1 = new string[3][];
            string[][] lista2 = new string[3][];
            string[][] lista3 = new string[3][];
            string prezzo1 = "100";
            string prezzo2 = "200";
            string prezzo3 = "300";
            int i;
            int j;
            for (i = 0; i < 3; i++)
            {
                if (i < 2)
                {
                    lista1[i] = new string[8];
                    lista2[i] = new string[8];
                    lista3[i] = new string[8];
                }
                else
                {
                    lista1[i] = new string[3];
                    lista2[i] = new string[3];
                    lista3[i] = new string[3];
                }

                for (j = 0; j < 8; j++)
                {
                    if (i < 2)
                    {

                        lista1[i][j] = "lista1comp" + j;
                        lista2[i][j] = "lista2comp" + j;
                        Debug.WriteLine("lista1: " + lista1[i][j] + "lista3: " + lista2[i][j]);

                    }
                    else
                    {
                        lista1[i][j] = "lista1prea" + j;
                        lista3[i][j] = "lista3prea" + j;

                        Debug.WriteLine("lista1: " + lista1[i][j] + "lista3: " + lista3[i][j]);

                        if (j == 2) { break; }
                    }
                }

            }
            //--------da cancellare---------------------------------

            ElementoCronologia e1 = creaElementoCronologia(lista1, prezzo1);
            ElementoCronologia e2 = creaElementoCronologia(lista2, prezzo2);
            ElementoCronologia e3 = creaElementoCronologia(lista3, prezzo3);

            this.aggiungiElementoCronologia(e1);
            this.aggiungiElementoCronologia(e2);
            this.aggiungiElementoCronologia(e3);
        }
    }
}
