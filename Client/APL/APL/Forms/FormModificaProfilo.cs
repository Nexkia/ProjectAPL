using APL.Connections;
using APL.Controlli;
using APL.Data;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Windows.Forms;
namespace APL.Forms
{
    public partial class FormModificaProfilo : Form
    {
        private Protocol pt;
        private CheckFields controllo = new CheckFields();
        public FormModificaProfilo(Protocol pt)
        {
            InitializeComponent();
            this.pt = pt;
        }

        private void FormModificaProfilo_Load(object sender, EventArgs e)
        {
            Utente? utente;
            pt.SetProtocolID("getUtente"); pt.Data = String.Empty;
            /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());
            string jsonUser = SocketTCP.Receive();
            SocketTCP.Release();
            /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
            try
            {
                utente = JsonConvert.DeserializeObject<Utente>(jsonUser);
                if (utente != null)
                {
                    TextBoxNomeUtente.Text = utente.Nome;
                    TextBoxEmail.Text = utente.Email;
                    TextBoxEmail.ReadOnly = true;
                    TextBoxIndirizzo.Text = utente.Indirizzo;
                }
            }
            catch (JsonException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            string result = controllo.CheckRegister(TextBoxNomeUtente.Text,
                TextBoxEmail.Text, TextBoxIndirizzo.Text,
                TextBoxNuovaPassword.Text, TextBoxRipetiPassword.Text);
            switch (result)
            {
                case "Registrazione avvenuta correttamente":
                    pt.SetProtocolID("modificaUtente");
                    pt.Data = TextBoxEmail.Text + "###" + TextBoxVecchiaPassword.Text;
                    /// INIZIO SCAMBIO DI MESSAGGI CON IL SERVER
                    SocketTCP.Wait();
                    SocketTCP.Send(pt.ToString());
                    string check = SocketTCP.Receive();
                    Debug.WriteLine(check);
                    if (!check.Contains("err"))
                    {
                        Utente mod = new()
                        {
                            Nome = TextBoxNomeUtente.Text,
                            Email = TextBoxEmail.Text,
                            Indirizzo = TextBoxIndirizzo.Text,
                            Password = TextBoxNuovaPassword.Text
                        };
                        string json_update = JsonConvert.SerializeObject(mod);
                        SocketTCP.Send(json_update);
                        Debug.WriteLine(json_update);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("la Vecchia Password è errata",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    SocketTCP.Release();
                    /// FINE SCAMBIO DI MESSAGGI CON IL SERVER
                    break;
                default:
                    MessageBox.Show("Le nuove password non sono uguali", "Errore",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ButtonMostraRepeat_Click(object sender, EventArgs e)
        {
            if (TextBoxRipetiPassword.PasswordChar == default)
                TextBoxRipetiPassword.PasswordChar = '*';
            else
                TextBoxRipetiPassword.PasswordChar = default;
        }

        private void ButtonMostraNew_Click(object sender, EventArgs e)
        {
            if (TextBoxNuovaPassword.PasswordChar == default)
                TextBoxNuovaPassword.PasswordChar = '*';
            else
                TextBoxNuovaPassword.PasswordChar = default;
        }

        private void ButtonMostraOld_Click(object sender, EventArgs e)
        {
            if (TextBoxVecchiaPassword.PasswordChar == default)
                TextBoxVecchiaPassword.PasswordChar = '*';
            else
                TextBoxVecchiaPassword.PasswordChar = default;
        }
    }
}
