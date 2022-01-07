﻿using APL.Connections;
using APL.Controlli;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

namespace APL.Forms
{
    public partial class FormLogin_Register : Form
    {
        Protocol pt = new Protocol();
        CheckFields controllo = new CheckFields();
        SocketTCP sckt = new SocketTCP();
        public FormLogin_Register()
        {
            InitializeComponent();
        }
        protected override void OnClosed(EventArgs e)
        {
            pt.Token = String.Empty;
            pt.SetProtocolID("close");
            sckt.GetMutex().WaitOne();
            sckt.send(pt);
            sckt.CloseConnection();
            sckt.GetMutex().ReleaseMutex();
            base.OnClosed(e);
        }
        private async void Register_Click(object sender, EventArgs e)
        {
            string result = controllo.CheckRegister(TextBoxNomeUtente.Text,
                TextBoxEmail.Text, TextBoxIndirizzo.Text,
                TextBoxInserisciPassword.Text, TextBoxConfermaPassword.Text);
            switch (result) {
                case "Email o Codice Fiscale già usati in altri account":
                    //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------
                    string Json = JsonSerializer.Serialize(
                        new
                        {
                            Email = TextBoxEmail.Text,
                            Indirizzo = TextBoxIndirizzo.Text,
                            NomeUtente = TextBoxNomeUtente.Text,
                            Password = TextBoxConfermaPassword.Text
                        }
                        );
                    //conversione da Json a Byte
                    pt.SetProtocolID("register"); pt.Token = ""; pt.Data = Json;
                    sckt.GetMutex().WaitOne();
                    sckt.send(pt);
                    string response = await sckt.receive();
                    sckt.GetMutex().ReleaseMutex();
                    if (result.Contains("Registrazione"))
                    {
                        TextBoxNomeUtente.Text = string.Empty;
                        TextBoxEmail.Text = string.Empty;
                        TextBoxIndirizzo.Text = string.Empty;
                        TextBoxInserisciPassword.Text = string.Empty;
                        TextBoxConfermaPassword.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show(result,
                           "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                default:
                    MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            string result = controllo.CheckLogin(TextBoxLoginEmail.Text, TextBoxLoginPassword.Text);
            switch (result)
            {
                case "Login fallito, Email o Password errate":
                    //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------
                    string Json = JsonSerializer.Serialize(new
                    {
                        Email = TextBoxLoginEmail.Text,
                        Password = TextBoxLoginPassword.Text
                    }
                    );
                    pt.SetProtocolID("login"); pt.Token = ""; pt.Data = Json;
                    sckt.GetMutex().WaitOne();
                    sckt.send(pt);
                    string responseData = await sckt.receive();
                    sckt.GetMutex().ReleaseMutex();
                    pt.Token = responseData;
                    if (responseData.Contains("errore: "))
                    {
                        Console.WriteLine("Login fallito," + responseData);
                        MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Console.WriteLine("Login effettuato");
                        FormHome home = new FormHome(this, pt.Token, sckt); // Instantiate a Form2 object.
                        home.Show(); // Show Form2 and
                        this.Visible = false; //invisible form1
                    }
                    //------------------------------------------------------------
                    TextBoxLoginEmail.Text = string.Empty;
                    TextBoxLoginPassword.Text = string.Empty;
                    break;
                default:
                    MessageBox.Show(result, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
            }
        }

        private void ButtonMostraIP_Click(object sender, EventArgs e)
        {
            if (TextBoxInserisciPassword.PasswordChar == default)
            {
                TextBoxInserisciPassword.PasswordChar = '*';
            }
            else
            {
                TextBoxInserisciPassword.PasswordChar = default;
            }
        }

        private void ButtonMostraCP_Click(object sender, EventArgs e)
        {
            if (TextBoxConfermaPassword.PasswordChar == default)
            {
                TextBoxConfermaPassword.PasswordChar = '*';
            }
            else
            {
                TextBoxConfermaPassword.PasswordChar = default;
            }
        }

        private void ButtonMostraLP_Click(object sender, EventArgs e)
        {
            if (TextBoxLoginPassword.PasswordChar == default)
            {
                TextBoxLoginPassword.PasswordChar = '*';
            }
            else
            {
                TextBoxLoginPassword.PasswordChar = default;
            }
        }
    }

}
