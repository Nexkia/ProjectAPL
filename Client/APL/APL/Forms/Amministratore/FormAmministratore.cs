using APL.Connections;
using APL.Forms.Amministratore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APL.Forms
{
    public partial class FormAmministratore : Form
    {
        Protocol pt = new Protocol();
        bool disableCloseEvent;
        FormLogin_Register parent;
        FormInserisciPreassemblato formInserisciPreassemblato;
        FormInserisciComponente formInserisciComponente; 
        public FormAmministratore(FormLogin_Register f_start)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(FormHome_FormClosing);
            disableCloseEvent = true;
            parent = f_start;
            formInserisciPreassemblato = new FormInserisciPreassemblato(this);
            formInserisciComponente = new FormInserisciComponente(this);
        }

        public void EnableCloseEvent() { this.disableCloseEvent = false; }
        void FormHome_FormClosing(object sender, FormClosingEventArgs e)
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
        private void buttonInserisciComponente_Click(object sender, EventArgs e)
        {
            
            formInserisciComponente.Show();
            this.Visible = false;
        }

        private void buttonEliminaComponente_Click(object sender, EventArgs e)
        {
            pt.SetProtocolID("cancellazione");pt.Data = TextBoxModello.Text;
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            SocketTCP.GetMutex().ReleaseMutex();
        }

        private void buttonInserisciPreassemblato_Click(object sender, EventArgs e)
        {
            
            formInserisciPreassemblato.Show();
            this.Visible = false; //invisible amministratore
        }

        private  void buttonEliminaPreassemblato_Click(object sender, EventArgs e)
        {
            pt.SetProtocolID("cancellazione_pre"); pt.Data = textBoxNome.Text;
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            SocketTCP.GetMutex().ReleaseMutex();
        }

        private  void buttonStatistiche_Click(object sender, EventArgs e)
        {
            FormStatistiche statistiche = new FormStatistiche();

            pt.SetProtocolID("recupera_statistiche");
            SocketTCP.GetMutex().WaitOne();
            SocketTCP.send(pt);
            for (int i = 0; i < 3; i++)
            {

                byte[] vet =  SocketTCP.receiveBytesBlock();
                File.WriteAllBytes("image"+Convert.ToString(i)+".txt", vet);
                //byte[] decompressed = ZLibDotnetDecompress(vet, vet.Length);
                //File.WriteAllBytes("image_compressed" + Convert.ToString(i) + ".txt.txt", decompressed);
                //statistiche.setVenditeComponenti(decompressed, i);
            }

            SocketTCP.GetMutex().ReleaseMutex();
            statistiche.Show();
        }

        /*
        public static byte[] ZLibDotnetDecompress(byte[] data, int size)
        {
            
            MemoryStream compressed = new MemoryStream(data);
            zlib.ZInputStream inputStream = new zlib.ZInputStream(compressed);
            Byte[] result = new byte[size]; // Since ZinputStream is inherited is binaryReader instead of stream, you can only prepare the output buffer in advance and then use the READ to get the fixed length data.
            inputStream.read(result, 0, result.Length); // Note that the read letter here is lowercase
            return result;
        }
        */

        protected override void OnClosed(EventArgs e)
        {
            parent.Visible = true;
            formInserisciPreassemblato.EnableCloseEvent();
            formInserisciPreassemblato.Close();
            base.OnClosed(e);
        }

    }
}
