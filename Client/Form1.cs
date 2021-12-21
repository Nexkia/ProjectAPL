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
using System.Net.Sockets;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Net.Mail;
using System.Data.SqlClient;
using Microsoft.Azure.Documents;
using Client.Data.Componenti;
using Client.Data;

namespace Client
{
     
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the start position of the form to the center of the screen.
            //Form.StartPosition = FormStartPosition.CenterScreen;

        }

        private void Register_Click(object sender, EventArgs e)
        {

            
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
                bool isValidIndirizzo=indirizzo.Contains(" ");
                bool isValidinserisciPasswordR = inserisciPasswordR.Contains(" ");
                bool isValidconfermaPasswordR = confermaPasswordR.Contains(" ");
                if (isValidNomeUtente  || isValidEmailR
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
                        if (inserisciPasswordR!= confermaPasswordR)
                        {
                            
                            MessageBox.Show("Le due password inserite sono diverse",
                            "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else {
                            //------------database---------------------------------------------


                            string nomeDatabase = "apl_database";
                           

                            string host = "localhost";
                            Int32 port = 13000;
                            // var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (port));
                            TcpClient client = new TcpClient(host, port);

                            NetworkStream stream = client.GetStream();

                            

                            string Json = JsonSerializer.Serialize(
                                new
                                {
                                    Email = emailR,
                                    Indirizzo=indirizzo,
                                    NomeUtente=nomeUtente,
                                    Password = confermaPasswordR
                                }
                                );

                            //conversione da Json a Byte
                            byte[] outJson = Encoding.ASCII.GetBytes("0 ok " + Json + "\n");

                            stream.Write(outJson, 0, outJson.Length);

                            Console.WriteLine("Sent: {0}\n bytes: {1}", Json, outJson);

                            // Buffer to store the response bytes.
                            var data = new Byte[256];

                            // String to store the response ASCII representation.
                            String responseData = String.Empty;

                            // Read the first batch of the TcpServer response bytes.
                            Int32 bytes = stream.Read(data, 0, data.Length);
                            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                            Console.WriteLine("Received: {0}", responseData);

                            // Close everything.
                            stream.Close();
                            client.Close();

                            if (responseData.Contains("Registrazione"))
                            {
                                textBoxNomeUtente.Text=string.Empty;
                                textBoxEmailR.Text = string.Empty; ;
                                textBoxIndirizzo.Text = string.Empty; ;
                                textBoxInserisciPasswordR.Text = string.Empty; ;
                                textBoxConfermaPasswordR.Text = string.Empty; ;

                            }
                            else {
                                MessageBox.Show("Email o Codice Fiscale già usati in altri account",
                                   "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }


                            //----------------------------------------------------------------

                        }
                    }


                }
            }else {
                   
                    MessageBox.Show("Riempire tutti i campi",
                    "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

     
        private void Login_Click(object sender, EventArgs e)
        {
            String email;
            String password;

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

                    //------------database---------------------------------------------


                    string nomeDatabase = "apl_database";
                    Detail a = new Detail();
                    Cpu b = new Cpu();
                  
                    


                    string host = "localhost";
                    Int32 port = 13000;
                    // var endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), (port));
                    TcpClient client = new TcpClient(host, port);

                    NetworkStream stream = client.GetStream();


                    string Json = JsonSerializer.Serialize(
                        new
                        {
                            Email = email,
                            Password = password
                        }
                        );

                    //conversione da Json a Byte
                    byte[] outJson = Encoding.ASCII.GetBytes("1 ok " + Json + "\n");

                    stream.Write(outJson, 0, outJson.Length);

                    Console.WriteLine("Sent: {0}\n bytes: {1}", Json, outJson);

                    // Buffer to store the response bytes.
                    var data = new Byte[256];

                    // String to store the response ASCII representation.
                    String responseData = String.Empty;

                    // Read the first batch of the TcpServer response bytes.
                    Int32 bytes = stream.Read(data, 0, data.Length);
                    responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                    Console.WriteLine("Received: {0}", responseData);



                    // Close everything.
                    stream.Close();
                    client.Close();




                    if (responseData.Contains("errore: "))
                    {

                        Console.WriteLine("Login fallito," + responseData);
                    }
                    else
                    {
                        Form2 f2 = new Form2(this); // Instantiate a Form2 object.
                        f2.Show(); // Show Form2 and
                        this.Visible = false; //invisible form1

                        Console.WriteLine("Login effettuato");
                        string token = responseData;
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

            if (textBoxPassword.PasswordChar == default) { 
            textBoxPassword.PasswordChar = '*'; }
            else { 
                textBoxPassword.PasswordChar = default; }

            


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
    }
}
