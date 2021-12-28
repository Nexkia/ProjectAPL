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
            // Set the start position of the form to the center of the screen.
            //Form.StartPosition = FormStartPosition.CenterScreen;

        }

        private async void Register_ClickAsync(object sender, EventArgs e)
        {
            SocketTCP sckt = new SocketTCP();

            String nomeUtente;
            String emailR;
            String indirizzo;
            String inserisciPasswordR;
            String confermaPasswordR;

            if (textBoxNomeUtente.Text != string.Empty &&
                textBoxEmailR.Text != string.Empty && textBoxIndirizzo.Text != string.Empty &&
                textBoxInserisciPasswordR.Text != string.Empty && textBoxConfermaPasswordR.Text != string.Empty)
            {
                nomeUtente = textBoxNomeUtente.Text;
                // codiceFiscale = textBoxCodiceFiscale.Text.ToUpper();// trasforma i caratteri in maiuscole
                emailR = textBoxEmailR.Text;
                indirizzo = textBoxIndirizzo.Text;
                inserisciPasswordR = textBoxInserisciPasswordR.Text;
                confermaPasswordR = textBoxConfermaPasswordR.Text;

                //controllo sul nome utente, che non deve avere spazi
                bool isValidNomeUtente = nomeUtente.Contains(" ");
                // bool isValidCodiceFiscale = codiceFiscale.Contains(" ");
                bool isValidEmailR = emailR.Contains(" ");
                bool isValidIndirizzo = indirizzo.Contains(" ");
                bool isValidinserisciPasswordR = inserisciPasswordR.Contains(" ");
                bool isValidconfermaPasswordR = confermaPasswordR.Contains(" ");
                if (isValidNomeUtente || isValidEmailR
                    || isValidinserisciPasswordR || isValidconfermaPasswordR || isValidIndirizzo)
                {
                    MessageBox.Show("Togliere gli spazi all'interno dei campi",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //controllo formato email
                    bool isValidEmailR1 = emailR.Contains("@");
                    bool isValidEmailR2 = emailR.Contains(".");
                    if (!isValidEmailR1 || !isValidEmailR2)
                    {
                        MessageBox.Show("Email non valida",
                        "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //controlla che le due password siano uguali
                        if (inserisciPasswordR != confermaPasswordR)
                        {
                            MessageBox.Show("Le due password inserite sono diverse",
                            "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------
                            string Json = JsonSerializer.Serialize(
                                new
                                {
                                    Email = emailR,
                                    Indirizzo = indirizzo,
                                    NomeUtente = nomeUtente,
                                    Password = confermaPasswordR
                                }
                                );
                            //conversione da Json a Byte
                            pt.ProtocolID = "0"; pt.Token = ""; pt.Data = Json;
                            string responce = await sckt.send(pt);
                            Console.WriteLine(responce);
                            string result = await sckt.receive(256);


                            if (result.Contains("Registrazione"))
                            {
                                textBoxNomeUtente.Text = string.Empty;
                                textBoxEmailR.Text = string.Empty; ;
                                textBoxIndirizzo.Text = string.Empty; ;
                                textBoxInserisciPasswordR.Text = string.Empty; ;
                                textBoxConfermaPasswordR.Text = string.Empty; ;

                            }
                            else
                            {
                                MessageBox.Show("Email o Codice Fiscale già usati in altri account",
                                   "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            else
            {

                MessageBox.Show("Riempire tutti i campi",
                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }


        private async void Login_Click(object sender, EventArgs e)
        {
            String email;
            String password;
            SocketTCP sckt = new SocketTCP();

            if (textBoxEmail.Text != string.Empty && textBoxPassword.Text != string.Empty)
            {

                email = textBoxEmail.Text;
                password = textBoxPassword.Text;
                bool isValidEmail1 = email.Contains("@");
                bool isValidEmail2 = email.Contains(".");
                if (!isValidEmail1 || !isValidEmail2)
                {
                    MessageBox.Show("Email non valida",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    //-----comunicazione con il server, che a sua volta comunica con il database--------------------------------------

                    string Json = JsonSerializer.Serialize(new
                    {
                        Email = email,
                        Password = password
                    }
                    );
                    pt.ProtocolID = "1"; pt.Token = ""; pt.Data = Json;
                    string responce = await sckt.send(pt);
                    Console.WriteLine(responce);
                    string responseData = await sckt.receive(256);
                    pt.Token = responseData;

                    if (responseData.Contains("errore: "))
                    {

                        Console.WriteLine("Login fallito," + responseData);
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
                }
            }
            else
            {
                MessageBox.Show("Riempire tutti i campi",
                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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