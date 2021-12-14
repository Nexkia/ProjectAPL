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



using System.Net;
using System.Net.Sockets;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Net.Mail;
using System.Data.SqlClient;
using Microsoft.Azure.Documents;

namespace Client
{
     
    public partial class Form1 : Form
    {
        Socket send;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the start position of the form to the center of the screen.
            //Form.StartPosition = FormStartPosition.CenterScreen;

        }

       


        private void button1_Click(object sender, EventArgs e)
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
                    
                    MongoClient client = new MongoClient();
                    var database = client.GetDatabase(nomeDatabase);
                    Utenti utente = new Utenti();
                    var events = database.GetCollection<Utenti>("utenti");

                    var risultato = events.Count(x => x.Email == email && x.Password==password);
                    

                    if (risultato == 0)
                    {
                        Console.WriteLine("Utente non trovato");
                    }
                    if (risultato == 1)
                    {
                        Console.WriteLine("Utente trovato");
                    }

                   //------------------------------------------------------------



                    textBoxEmail.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;
                }



                
                

            }
            else {
                

                MessageBox.Show("Riempire tutti i campi",
                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
            
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String nomeUtente;
            String codiceFiscale;
            String emailR;
            String indirizzo;
            String inserisciPasswordR;
            String confermaPasswordR;

            if (textBoxNomeUtente.Text != string.Empty && textBoxCodiceFiscale.Text != string.Empty &&
                textBoxEmailR.Text != string.Empty && textBoxIndirizzo.Text != string.Empty &&
                textBoxInserisciPasswordR.Text != string.Empty && textBoxConfermaPasswordR.Text != string.Empty)
            {

                nomeUtente = textBoxNomeUtente.Text;
                codiceFiscale = textBoxCodiceFiscale.Text.ToUpper();// trasforma i caratteri in maiuscole
                emailR = textBoxEmailR.Text;
                indirizzo = textBoxIndirizzo.Text;
                inserisciPasswordR = textBoxInserisciPasswordR.Text;
                confermaPasswordR = textBoxConfermaPasswordR.Text;

                //controllo sul nome utente, che non deve avere spazi
                bool isValidNomeUtente = nomeUtente.Contains(" ");
                bool isValidCodiceFiscale = codiceFiscale.Contains(" ");
                bool isValidEmailR = emailR.Contains(" ");
                bool isValidIndirizzo=indirizzo.Contains(" ");
                bool isValidinserisciPasswordR = inserisciPasswordR.Contains(" ");
                bool isValidconfermaPasswordR = confermaPasswordR.Contains(" ");
                if (isValidNomeUtente || isValidCodiceFiscale || isValidEmailR
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
                            //-verifica che l'utente non sia già presente all'interno del DATABASE

                            string nomeDatabase = "apl_database";
                            Utenti utente = new Utenti();

                            MongoClient client = new MongoClient();
                            var database = client.GetDatabase(nomeDatabase);
                            var events = database.GetCollection<Utenti>("utenti");

                            var risultato1 = events.Count(x=>x.Email==emailR || x.CodiceFiscale==codiceFiscale);

                            if (risultato1 >= 1 )
                            {
                                
                                MessageBox.Show("Email o Codice Fiscale già usati in altri account",
                                "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                            }
                            if (risultato1 == 0 )
                            {
                                //---Inserimento valori nel DATABASE-------------
 
                                Console.WriteLine("invio al database");

                                   Utenti document = new Utenti
                                       {    
                                            Id=Guid.NewGuid(),
                                            CodiceFiscale= codiceFiscale ,
                                            NomeUtente=nomeUtente ,
                                            Email= emailR  ,
                                            Password= confermaPasswordR ,
                                            Indirizzo= indirizzo ,
                                       };
                                           events.InsertOne(document);

                                //----------------------------------------------------------------

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
            Form2 f2 = new Form2(this); // Instantiate a Form2 object.
            f2.Show(); // Show Form2 and
           this.Visible = false; //invisible form1
            //this.Close(); // closes the Form2 instance.
        }

        private void button2_Click_1(object sender, EventArgs e1)
        {
            byte[] bytes = new byte[1024];

            try
            {
                // Connect to a Remote server
                // Get Host IP Address that is used to establish a connection
                // In this case, we get one IP address of localhost that is IP : 127.0.0.1
                // If a host has multiple addresses, you will get a list of addresses
                IPHostEntry host = Dns.GetHostEntry("localhost");
                IPAddress ipAddress = host.AddressList[0];
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP  socket.
                Socket sender1 = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    // Connect to Remote EndPoint
                    sender1.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                        sender1.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.ASCII.GetBytes("This is a test\n");

                    // Send the data through the socket.
                    int bytesSent = sender1.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = sender1.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.ASCII.GetString(bytes, 0, bytesRec));

                    // Release the socket.
                    sender1.Shutdown(SocketShutdown.Both);
                    sender1.Close();

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
