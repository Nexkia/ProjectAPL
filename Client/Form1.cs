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

                Console.WriteLine("EMAIL " + textBoxEmail.Text + " Password " + textBoxPassword.Text);


                bool isValidEmail1 = email.Contains("@");
                bool isValidEmail2 = email.Contains(".");
                if (!isValidEmail1 || !isValidEmail2)
                {
                    Console.WriteLine($"The email is invalid");
                    
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
    }
}
