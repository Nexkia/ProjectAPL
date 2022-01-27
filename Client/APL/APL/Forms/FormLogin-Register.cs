using APL.Connections;
using APL.Controlli;
using System;
using System.Text.Json;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Diagnostics;
using APL.Forms.Amministratore;

namespace APL.Forms
{
    public partial class FormLogin_Register : Form
    {
        private Protocol pt;
        private CheckFields controllo;
        private FormAmministratore amministratoreForm;
        public FormLogin_Register()
        {
            InitializeComponent();
            pt = new Protocol();
            controllo = new CheckFields();
            amministratoreForm = new FormAmministratore(this);
        }

        protected override void OnClosed(EventArgs e)
        {
            pt.SetProtocolID("close");
            pt.Data = String.Empty;
            SocketTCP.Wait();
            SocketTCP.Send(pt.ToString());
            SocketTCP.Release();
            SocketTCP.CloseConnection();
           
            base.OnClosed(e);
        }


        private void Register_Click(object sender, EventArgs e)
        {
            string result = controllo.CheckRegister(TextBoxNomeUtente.Text,TextBoxEmail.Text, 
                TextBoxIndirizzo.Text,TextBoxInserisciPassword.Text, TextBoxConfermaPassword.Text);

            switch (result) {
                case "Email o Codice Fiscale già usati in altri account":
                    //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------
                    string UserJson = JsonSerializer.Serialize(
                        new
                        {
                            Email = TextBoxEmail.Text,
                            Indirizzo = TextBoxIndirizzo.Text,
                            NomeUtente = TextBoxNomeUtente.Text,
                            Password = TextBoxConfermaPassword.Text
                        }
                        );
                    //conversione da Json a Byte
                    pt.SetProtocolID("register"); pt.Data = UserJson;
                    SocketTCP.Wait();
                    SocketTCP.Send(pt.ToString());
                    string response = SocketTCP.Receive();
                    SocketTCP.Release();
                    
                    if (response.Contains("Registrazione"))
                    {
                        TextBoxNomeUtente.Text = string.Empty;
                        TextBoxEmail.Text = string.Empty;
                        TextBoxIndirizzo.Text = string.Empty;
                        TextBoxInserisciPassword.Text = string.Empty;
                        TextBoxConfermaPassword.Text = string.Empty;

                        MessageBox.Show(result,"Conferma",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Email o Codice Fiscale già usati in altri account",
                           "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                default:
                    MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }


        private  void Login_Click(object sender, EventArgs e)
        {
            string result = controllo.CheckLogin(TextBoxLoginEmail.Text, TextBoxLoginPassword.Text);
            switch (result)
            {
                case "Login effettuato correttamente":
                    //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------
                    string UserJson = JsonSerializer.Serialize(new
                    {
                        Email = TextBoxLoginEmail.Text,
                        Password = TextBoxLoginPassword.Text
                    }
                    );
                    pt.SetProtocolID("login");  pt.Data = UserJson;
                    SocketTCP.Wait();
                    SocketTCP.Send(pt.ToString());
                    string responseData = SocketTCP.Receive();
                    SocketTCP.Release();
                    if (responseData.Contains("Errore"))
                    {
                        Debug.WriteLine("Login fallito," + responseData);
                        MessageBox.Show("Login fallito, Email o Password errate", "Errore", 
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (responseData.Contains("true"))
                    {   
                        //apriamo il pannello dell'amministratore
                        amministratoreForm.Show();
                        this.Visible = false; //invisible form1
                        TextBoxLoginEmail.Text = string.Empty;
                        TextBoxLoginPassword.Text = string.Empty;
                    }
                    else
                    {
                        //apriamo il formHome
                        Debug.WriteLine("Login effettuato");
                        FormHome home = new FormHome(this); 
                        home.Show(); 
                        this.Visible = false; //invisible form1
                        TextBoxLoginEmail.Text = string.Empty;
                        TextBoxLoginPassword.Text = string.Empty;
                    }
                    
                    
                    break;

                default:
                    MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        
        private void ButtonMostraIP_Click(object sender, EventArgs e)
        {//register
            if (TextBoxInserisciPassword.PasswordChar == default)
                TextBoxInserisciPassword.PasswordChar = '*';
            else
                TextBoxInserisciPassword.PasswordChar = default;
        }
        private void ButtonMostraCP_Click(object sender, EventArgs e)
        {//register
            if (TextBoxConfermaPassword.PasswordChar == default)
                TextBoxConfermaPassword.PasswordChar = '*';
            else
                TextBoxConfermaPassword.PasswordChar = default;
        }

        private void ButtonMostraLP_Click(object sender, EventArgs e)
        {//login
            if (TextBoxLoginPassword.PasswordChar == default)
                TextBoxLoginPassword.PasswordChar = '*';
            else
                TextBoxLoginPassword.PasswordChar = default;
        }

        private void FormLogin_Register_VisibleChanged(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            
            foreach (Form frm in fc)
            {
                //iterate through
                if (frm.Name == "FormStatistiche")
                {
                    frm.Close();
                }
            }
        }

    }

}
