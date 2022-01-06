using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Text.Json;




using System.Net;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Net.Mail;
using System.Data.SqlClient;
using Microsoft.Azure.Documents;
using Client.Data.Componenti;
using Client.Data;
using Client.Connection;
using Client.Controlli;

namespace Client
{

    public partial class Form1 : Form
    {
        Protocol pt = new Protocol();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private async void Register_ClickAsync(object sender, EventArgs e)
        {
            string ris;
            CheckFields controlloR = new CheckFields();

            ris =controlloR.CheckRegister(textBoxNomeUtente.Text, textBoxEmailR.Text, textBoxIndirizzo.Text,
                textBoxInserisciPasswordR.Text, textBoxConfermaPasswordR.Text);

            switch (ris)
            {
                case "Apri Connessione":
                    SocketTCP sckt = new SocketTCP();
                    //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------
                    string Json = JsonSerializer.Serialize(
                        new
                        {
                            Email = textBoxEmailR.Text,
                            Indirizzo = textBoxIndirizzo.Text,
                            NomeUtente = textBoxNomeUtente.Text,
                            Password = textBoxConfermaPasswordR.Text
                        }
                        );
                    //conversione da Json a Byte
                    pt.SetProtocolID("register"); pt.Token = ""; pt.Data = Json;
                    string responce = await sckt.send(pt);
                    Console.WriteLine(responce);
                    string result = await sckt.receive();


                    if (result.Contains("Registrazione"))
                    {

                        textBoxNomeUtente.Text = string.Empty;
                        textBoxEmailR.Text = string.Empty;
                        textBoxIndirizzo.Text = string.Empty;
                        textBoxInserisciPasswordR.Text = string.Empty;
                        textBoxConfermaPasswordR.Text = string.Empty;

                    }
                    else
                    {
                        MessageBox.Show("Email o Codice Fiscale già usati in altri account",
                           "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    break;
                default:
                    MessageBox.Show(ris, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                

            }

        }


        private async void Login_Click(object sender, EventArgs e)
        {
            
            CheckFields controlloL = new CheckFields();
            string ris;

            ris = controlloL.CheckLogin(textBoxEmail.Text, textBoxPassword.Text);

            switch (ris)
            {
                case "Apri Connessione":
                    SocketTCP sckt = new SocketTCP();
                    //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------

                    string Json = JsonSerializer.Serialize(new
                    {
                        Email = textBoxEmail.Text,
                        Password = textBoxPassword.Text
                    }
                    );
                    pt.SetProtocolID("login"); pt.Token = ""; pt.Data = Json;
                    string responce = await sckt.send(pt);
                    Console.WriteLine(responce);
                    string responseData = await sckt.receive();
                    pt.Token = responseData;

                    if (responseData.Contains("errore: "))
                    {

                        Console.WriteLine("Login fallito," + responseData);
                        MessageBox.Show("Login fallito, Email o Password errate", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Console.WriteLine("Login effettuato");
                        Form2 f2 = new Form2(this, pt.Token); // Instantiate a Form2 object.
                        f2.Show(); // Show Form2 and
                        this.Visible = false; //invisible form1
                    }
                    //------------------------------------------------------------
                    textBoxEmail.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;
                    break;
                default:
                    MessageBox.Show(ris,"Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                
            }

            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Add this textbox to form
            this.Controls.Add(textBoxPassword);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBoxPassword.PasswordChar == default)
            {
                textBoxPassword.PasswordChar = '*';
            }
            else
            {
                textBoxPassword.PasswordChar = default;
            }




        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonMostraIP_Click(object sender, EventArgs e)
        {
            if (textBoxInserisciPasswordR.PasswordChar == default)
            {
                textBoxInserisciPasswordR.PasswordChar = '*';
            }
            else
            {
                textBoxInserisciPasswordR.PasswordChar = default;
            }
        }

        private void buttonCP_Click(object sender, EventArgs e)
        {
            if (textBoxConfermaPasswordR.PasswordChar == default)
            {
                textBoxConfermaPasswordR.PasswordChar = '*';
            }
            else
            {
                textBoxConfermaPasswordR.PasswordChar = default;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e1)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this, "bho"); // Instantiate a Form2 object.
            
            f2.Show(); // Show Form2 and
            this.Visible = false; //invisible form1
        }

        private void textBoxNomeUtente_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}