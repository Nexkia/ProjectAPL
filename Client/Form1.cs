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



using System.Net;
using System.Net.Sockets;
using System.Windows;
using MessageBox = System.Windows.Forms.MessageBox;
using System.Net.Mail;
using System.Data.SqlClient;

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
                    
                    
                    MessageBox.Show("Email non valida", "Errore");
                }
                else
                {
                    Console.WriteLine($"The email is valid");

                    //------------database---------------------------------------------
                    string server = "localhost";
                    string database = "apl_database";
                    string uid = "Dario";
                    string passworddatabase = "ciaociao99";
                    string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + passworddatabase + ";";

                    MySqlConnection con = new MySqlConnection(connectionString);

                    con.Open();

                    var stm = "SELECT COUNT(*) FROM apl_database.utenti WHERE Email='" + email+ "' AND Password='"+password+"'";
                    var cmd = new MySqlCommand(stm, con);
                    int risultato = int.Parse(cmd.ExecuteScalar().ToString());
                    if (risultato == 0) {
                        Console.WriteLine("Utente non trovato");
                    }
                    if (risultato == 1)
                    {
                        Console.WriteLine("Utente trovato");
                    }
                    
                    //Console.WriteLine("cmd: "+ cmd.ExecuteScalar().ToString());
                    //----------------------------------------------------------------



                    textBoxEmail.Text = string.Empty;
                    textBoxPassword.Text = string.Empty;
                }



                
                

            }
            else {
                

                // disattiva la X in alto a destra
                // MessageBoxButtons buttons = MessageBoxButtons.AbortRetryIgnore;
                MessageBox.Show("Riempire tutti i campi", "Errore");


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
                    MessageBox.Show("Togliere gli spazi all'interno dei campi", "Errore");
                }
                else
                {
                    //controllo formato email
                    bool isValidEmailR1 = emailR.Contains("@");
                    bool isValidEmailR2 = emailR.Contains(".");
                    if (!isValidEmailR1 || !isValidEmailR2)
                    {
                        MessageBox.Show("Email non valida", "Errore");
                    }
                    else
                    {
                        //controlla che le due password siano uguali
                        if (inserisciPasswordR!= confermaPasswordR)
                        {
                            MessageBox.Show("Le due password inserite sono diverse", "Errore");
                        }
                        else {
                            //-verifica che l'utente non sia già presente all'interno del DATABASE
                            string server = "localhost";
                            string database = "apl_database";
                            string uid = "Dario";
                            string passworddatabase = "ciaociao99";
                            string connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + passworddatabase + ";";

                            MySqlConnection con = new MySqlConnection(connectionString);

                            con.Open();

                            var stm = "SELECT COUNT(*) FROM apl_database.utenti WHERE Email='" + emailR + "' OR CodiceFiscale='" + codiceFiscale + "'";
                           
                            var cmd = new MySqlCommand(stm, con);
                            int risultato = int.Parse(cmd.ExecuteScalar().ToString());
                            con.Close();

                            if (risultato == 1)
                            {
                                MessageBox.Show("Email o Codice Fiscale già usati in altri account"); 
                                
                                
                            }
                            if (risultato == 0)
                            {
                                //---Inserimento valori nel DATABASE-------------

                                

                                MySqlConnection con1= new MySqlConnection(connectionString);

                                con1.Open();

                                var stm1 = "INSERT INTO apl_database.utenti (CodiceFiscale, NomeUtente, Email, Password, Indirizzo) VALUES('" + codiceFiscale + "', '" + nomeUtente + "', '" + emailR + "', '" + confermaPasswordR + "', '" + indirizzo + "')";

                                var cmd1 = new MySqlCommand(stm1, con1);
                                int risultato1= int.Parse(cmd.ExecuteScalar().ToString());

                                con1.Close();

                                Console.WriteLine("invio al database");

                              


                                //----------------------------------------------------------------

                            }


                            //----------------------------------------------------------------

                        }
                    }


                }
            }else {
                    MessageBox.Show("Riempire tutti i campi", "Errore");
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
    }
}
