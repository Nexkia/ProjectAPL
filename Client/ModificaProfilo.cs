using Client.Connection;
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
using Client.Data;
namespace Client
{
    public partial class ModificaProfilo : Form
    {
        Protocol pt ;
        
        public ModificaProfilo(Protocol pt)
        {
            InitializeComponent();
            this.pt = pt;
            //pt.Token = token;
        }

        private async void save_Click(object sender, EventArgs e)
        {
            SocketTCP skt = new SocketTCP();
            pt.SetProtocolID("modificaUtente");
            pt.Data =TextEmail.Text+"-"+TextOldPassword.Text;
            string ok = await skt.send(pt);
            string check = await skt.receive();
            Console.WriteLine(check);
            if (!check.Contains("err"))
            {
                Console.WriteLine("sono dentro");
                Utente mod = new Utente();
                mod.Nome = TextName.Text;
                mod.Email = TextEmail.Text;
                mod.Indirizzo = TextIndirizzo.Text;
                mod.Password = TextNewPassword.Text;
                string json_update = JsonConvert.SerializeObject(mod);
                string update = await skt.sendSingleMsg(json_update+pt.end);

                //aggiorna il token, che cambia con la nuova password
                pt.Token = await skt.receive();
                Console.WriteLine(json_update);

                this.Close();
            }
            else
            {
                MessageBox.Show("Password errata",
                        "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void ModificaProfilo_LoadAsync(object sender, EventArgs e)
        {
            SocketTCP skt = new SocketTCP();
            Utente u;
            pt.SetProtocolID("getUtente"); pt.Data = "";
            Console.WriteLine("token: " + pt.Token);
            string ok = await skt.send(pt);
            string user = await skt.receive();
            u = JsonConvert.DeserializeObject<Utente>(user);
            TextName.Text = u.Nome;
            TextEmail.Text = u.Email;
            TextEmail.ReadOnly = true;
            TextIndirizzo.Text = u.Indirizzo;
        }


    }
}
