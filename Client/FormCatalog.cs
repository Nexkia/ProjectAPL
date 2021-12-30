using Client.Connection;
using Client.Data;
using Newtonsoft.Json;
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
    public partial class FormCatalog : Form
    {
        Protocol pt = new Protocol();
        public FormCatalog()
        {
            InitializeComponent();
            pt.SetProtocolID("catalogo"); pt.Token = "";
        }

        private async void cpu_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data= cpuButton.Text;
            string response = String.Empty;
            string ok = await sckt.send(pt);
            // n elem
            string nelem = await sckt.receive();
            Componente[] cp = new Componente[int.Parse(nelem)];
            ok = await sckt.sendSingleMsg("ok");
            do
            {
                response += await sckt.receive();
            } while (!response.Contains("\n"));

            cp = JsonConvert.DeserializeObject<Componente[]>(response);
            Console.WriteLine(response);
            for (int i = 0; i < cp.Length; i++){
                string elem = cp[i].Marca + " " + cp[i].Modello + " " + cp[i].Prezzo;
                checkedListBox1.Items.Add(elem);

            }
            Confronto cf = new Confronto(cp[0],cp[1]);
            cf.Show();
        }


        private async void schedaMadre_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = schedaMadreButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);
        }

        private async void ram_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = ramButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);
        }

        private async void memoria_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = memoriaButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);
        }

        private async void alimentatore_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = alimentatoreButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);
        }

        private async void schedaVideo_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = schedaVideoButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);

        }

        private async void casepc_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = casepcButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);

        }

        private async void dissipatore_Click(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();
            pt.Data = dissipatoreButton.Text;
            string ok = await sckt.send(pt);
            string responce = await sckt.receive();
            Console.WriteLine(responce);

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormCatalog_Load(object sender, EventArgs e)
        {

        }
    }
}
