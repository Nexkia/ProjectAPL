using APL.Connections;
using APL.Controlli;
using APL.Data;
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
using System.Diagnostics;
namespace APL.Forms
{
    public partial class FormModificaProfilo : Form
    {
        Protocol pt;
        CheckFields controllo = new CheckFields();
        public FormModificaProfilo(Protocol pt)
        {
            InitializeComponent();
            this.pt = pt;   
        }

        private void FormModificaProfilo_Load(object sender, EventArgs e)
        {
            Utente utente;
            pt.SetProtocolID("getUtente");pt.Data = String.Empty;
            SocketTCP.Send(pt.ToString());
            string user = SocketTCP.Receive();
            utente = JsonConvert.DeserializeObject<Utente>(user);
            TextBoxNomeUtente.Text = utente.Nome;
            TextBoxEmail.Text = utente.Email;
            TextBoxEmail.ReadOnly = true;
            TextBoxIndirizzo.Text = utente.Indirizzo;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string result = controllo.CheckRegister(TextBoxNomeUtente.Text,
                TextBoxEmail.Text, TextBoxIndirizzo.Text,
                TextBoxNuovaPassword.Text, TextBoxRipetiPassword.Text);
            switch (result)
            {
                case "Email o Codice Fiscale già usati in altri account":
                    pt.SetProtocolID("modificaUtente");
                    pt.Data = TextBoxEmail.Text + "###" + TextBoxVecchiaPassword.Text;
                    SocketTCP.Send(pt.ToString());
                    string check = SocketTCP.Receive();
                    Debug.WriteLine(check);
                    if (!check.Contains("err"))
                    {
                        Utente mod = new Utente();
                        mod.Nome = TextBoxNomeUtente.Text;
                        mod.Email = TextBoxEmail.Text;
                        mod.Indirizzo = TextBoxIndirizzo.Text;
                        mod.Password = TextBoxNuovaPassword.Text;
                        string json_update = JsonConvert.SerializeObject(mod);
                        SocketTCP.Send(json_update);
                        //aggiorna il token, che cambia con la nuova password
                        Debug.WriteLine(json_update);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("la Vecchia Password è errata",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                default:
                    MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ButtonMostraRepeat_Click(object sender, EventArgs e)
        {
            if (TextBoxRipetiPassword.PasswordChar == default)
            {
                TextBoxRipetiPassword.PasswordChar = '*';
            }
            else
            {
                TextBoxRipetiPassword.PasswordChar = default;
            }
        }

        private void ButtonMostraNew_Click(object sender, EventArgs e)
        {
            if (TextBoxNuovaPassword.PasswordChar == default)
            {
                TextBoxNuovaPassword.PasswordChar = '*';
            }
            else
            {
                TextBoxNuovaPassword.PasswordChar = default;
            }
        }

        private void ButtonMostraOld_Click(object sender, EventArgs e)
        {
            if (TextBoxVecchiaPassword.PasswordChar == default)
            {
                TextBoxVecchiaPassword.PasswordChar = '*';
            }
            else
            {
                TextBoxVecchiaPassword.PasswordChar = default;
            }
        }
    }
}
