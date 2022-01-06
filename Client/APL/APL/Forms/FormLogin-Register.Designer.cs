namespace APL.Forms
{
    partial class FormLogin_Register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Login = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.Button();
            this.LabelNomeUtente = new System.Windows.Forms.Label();
            this.LabelEmail = new System.Windows.Forms.Label();
            this.LabelIndirizzo = new System.Windows.Forms.Label();
            this.LabelInserisciPassword = new System.Windows.Forms.Label();
            this.LabelConfermaPassword = new System.Windows.Forms.Label();
            this.LabelLoginEmail = new System.Windows.Forms.Label();
            this.LabelLoginPassword = new System.Windows.Forms.Label();
            this.TextBoxNomeUtente = new System.Windows.Forms.TextBox();
            this.TextBoxEmail = new System.Windows.Forms.TextBox();
            this.TextBoxIndirizzo = new System.Windows.Forms.TextBox();
            this.TextBoxInserisciPassword = new System.Windows.Forms.TextBox();
            this.TextBoxConfermaPassword = new System.Windows.Forms.TextBox();
            this.TextBoxLoginEmail = new System.Windows.Forms.TextBox();
            this.TextBoxLoginPassword = new System.Windows.Forms.TextBox();
            this.ButtonMostraCP = new System.Windows.Forms.Button();
            this.ButtonMostraIP = new System.Windows.Forms.Button();
            this.ButtonMostraLP = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Login.Location = new System.Drawing.Point(559, 208);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(184, 52);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Register
            // 
            this.Register.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Register.Location = new System.Drawing.Point(49, 502);
            this.Register.Margin = new System.Windows.Forms.Padding(2);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(182, 52);
            this.Register.TabIndex = 1;
            this.Register.Text = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // LabelNomeUtente
            // 
            this.LabelNomeUtente.AutoSize = true;
            this.LabelNomeUtente.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelNomeUtente.Location = new System.Drawing.Point(79, 20);
            this.LabelNomeUtente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelNomeUtente.Name = "LabelNomeUtente";
            this.LabelNomeUtente.Size = new System.Drawing.Size(132, 24);
            this.LabelNomeUtente.TabIndex = 2;
            this.LabelNomeUtente.Text = "Nome Utente";
            // 
            // LabelEmail
            // 
            this.LabelEmail.AutoSize = true;
            this.LabelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelEmail.Location = new System.Drawing.Point(102, 94);
            this.LabelEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelEmail.Name = "LabelEmail";
            this.LabelEmail.Size = new System.Drawing.Size(62, 24);
            this.LabelEmail.TabIndex = 3;
            this.LabelEmail.Text = "Email";
            // 
            // LabelIndirizzo
            // 
            this.LabelIndirizzo.AutoSize = true;
            this.LabelIndirizzo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelIndirizzo.Location = new System.Drawing.Point(94, 193);
            this.LabelIndirizzo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelIndirizzo.Name = "LabelIndirizzo";
            this.LabelIndirizzo.Size = new System.Drawing.Size(88, 24);
            this.LabelIndirizzo.TabIndex = 4;
            this.LabelIndirizzo.Text = "Indirizzo";
            // 
            // LabelInserisciPassword
            // 
            this.LabelInserisciPassword.AutoSize = true;
            this.LabelInserisciPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelInserisciPassword.Location = new System.Drawing.Point(53, 308);
            this.LabelInserisciPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelInserisciPassword.Name = "LabelInserisciPassword";
            this.LabelInserisciPassword.Size = new System.Drawing.Size(183, 24);
            this.LabelInserisciPassword.TabIndex = 5;
            this.LabelInserisciPassword.Text = "Inserisci Password";
            // 
            // LabelConfermaPassword
            // 
            this.LabelConfermaPassword.AutoSize = true;
            this.LabelConfermaPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelConfermaPassword.Location = new System.Drawing.Point(45, 403);
            this.LabelConfermaPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelConfermaPassword.Name = "LabelConfermaPassword";
            this.LabelConfermaPassword.Size = new System.Drawing.Size(196, 24);
            this.LabelConfermaPassword.TabIndex = 6;
            this.LabelConfermaPassword.Text = "Conferma Password";
            // 
            // LabelLoginEmail
            // 
            this.LabelLoginEmail.AutoSize = true;
            this.LabelLoginEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelLoginEmail.Location = new System.Drawing.Point(619, 29);
            this.LabelLoginEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLoginEmail.Name = "LabelLoginEmail";
            this.LabelLoginEmail.Size = new System.Drawing.Size(62, 24);
            this.LabelLoginEmail.TabIndex = 7;
            this.LabelLoginEmail.Text = "Email";
            // 
            // LabelLoginPassword
            // 
            this.LabelLoginPassword.AutoSize = true;
            this.LabelLoginPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LabelLoginPassword.Location = new System.Drawing.Point(555, 113);
            this.LabelLoginPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelLoginPassword.Name = "LabelLoginPassword";
            this.LabelLoginPassword.Size = new System.Drawing.Size(100, 24);
            this.LabelLoginPassword.TabIndex = 8;
            this.LabelLoginPassword.Text = "Password";
            // 
            // TextBoxNomeUtente
            // 
            this.TextBoxNomeUtente.Location = new System.Drawing.Point(36, 55);
            this.TextBoxNomeUtente.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxNomeUtente.Name = "TextBoxNomeUtente";
            this.TextBoxNomeUtente.Size = new System.Drawing.Size(203, 23);
            this.TextBoxNomeUtente.TabIndex = 9;
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Location = new System.Drawing.Point(36, 147);
            this.TextBoxEmail.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(203, 23);
            this.TextBoxEmail.TabIndex = 10;
            // 
            // TextBoxIndirizzo
            // 
            this.TextBoxIndirizzo.Location = new System.Drawing.Point(36, 242);
            this.TextBoxIndirizzo.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxIndirizzo.Name = "TextBoxIndirizzo";
            this.TextBoxIndirizzo.Size = new System.Drawing.Size(203, 23);
            this.TextBoxIndirizzo.TabIndex = 11;
            // 
            // TextBoxInserisciPassword
            // 
            this.TextBoxInserisciPassword.Location = new System.Drawing.Point(36, 347);
            this.TextBoxInserisciPassword.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxInserisciPassword.Name = "TextBoxInserisciPassword";
            this.TextBoxInserisciPassword.PasswordChar = '*';
            this.TextBoxInserisciPassword.Size = new System.Drawing.Size(203, 23);
            this.TextBoxInserisciPassword.TabIndex = 12;
            // 
            // TextBoxConfermaPassword
            // 
            this.TextBoxConfermaPassword.Location = new System.Drawing.Point(38, 448);
            this.TextBoxConfermaPassword.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxConfermaPassword.Name = "TextBoxConfermaPassword";
            this.TextBoxConfermaPassword.PasswordChar = '*';
            this.TextBoxConfermaPassword.Size = new System.Drawing.Size(203, 23);
            this.TextBoxConfermaPassword.TabIndex = 13;
            // 
            // TextBoxLoginEmail
            // 
            this.TextBoxLoginEmail.Location = new System.Drawing.Point(550, 55);
            this.TextBoxLoginEmail.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxLoginEmail.Name = "TextBoxLoginEmail";
            this.TextBoxLoginEmail.Size = new System.Drawing.Size(203, 23);
            this.TextBoxLoginEmail.TabIndex = 14;
            // 
            // TextBoxLoginPassword
            // 
            this.TextBoxLoginPassword.Location = new System.Drawing.Point(550, 147);
            this.TextBoxLoginPassword.Margin = new System.Windows.Forms.Padding(2);
            this.TextBoxLoginPassword.Name = "TextBoxLoginPassword";
            this.TextBoxLoginPassword.PasswordChar = '*';
            this.TextBoxLoginPassword.Size = new System.Drawing.Size(203, 23);
            this.TextBoxLoginPassword.TabIndex = 15;
            // 
            // ButtonMostraCP
            // 
            this.ButtonMostraCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonMostraCP.Location = new System.Drawing.Point(260, 448);
            this.ButtonMostraCP.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonMostraCP.Name = "ButtonMostraCP";
            this.ButtonMostraCP.Size = new System.Drawing.Size(82, 21);
            this.ButtonMostraCP.TabIndex = 17;
            this.ButtonMostraCP.Text = "Mostra";
            this.ButtonMostraCP.UseVisualStyleBackColor = true;
            this.ButtonMostraCP.Click += new System.EventHandler(this.ButtonMostraCP_Click);
            // 
            // ButtonMostraIP
            // 
            this.ButtonMostraIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonMostraIP.Location = new System.Drawing.Point(260, 347);
            this.ButtonMostraIP.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonMostraIP.Name = "ButtonMostraIP";
            this.ButtonMostraIP.Size = new System.Drawing.Size(82, 21);
            this.ButtonMostraIP.TabIndex = 16;
            this.ButtonMostraIP.Text = "Mostra";
            this.ButtonMostraIP.UseVisualStyleBackColor = true;
            this.ButtonMostraIP.Click += new System.EventHandler(this.ButtonMostraIP_Click);
            // 
            // ButtonMostraLP
            // 
            this.ButtonMostraLP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonMostraLP.Location = new System.Drawing.Point(669, 115);
            this.ButtonMostraLP.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonMostraLP.Name = "ButtonMostraLP";
            this.ButtonMostraLP.Size = new System.Drawing.Size(82, 21);
            this.ButtonMostraLP.TabIndex = 18;
            this.ButtonMostraLP.Text = "Mostra";
            this.ButtonMostraLP.UseVisualStyleBackColor = true;
            this.ButtonMostraLP.Click += new System.EventHandler(this.ButtonMostraLP_Click);
            // 
            // FormLogin_Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 658);
            this.Controls.Add(this.ButtonMostraLP);
            this.Controls.Add(this.ButtonMostraCP);
            this.Controls.Add(this.ButtonMostraIP);
            this.Controls.Add(this.TextBoxLoginPassword);
            this.Controls.Add(this.TextBoxLoginEmail);
            this.Controls.Add(this.TextBoxConfermaPassword);
            this.Controls.Add(this.TextBoxInserisciPassword);
            this.Controls.Add(this.TextBoxIndirizzo);
            this.Controls.Add(this.TextBoxEmail);
            this.Controls.Add(this.TextBoxNomeUtente);
            this.Controls.Add(this.LabelLoginPassword);
            this.Controls.Add(this.LabelLoginEmail);
            this.Controls.Add(this.LabelConfermaPassword);
            this.Controls.Add(this.LabelInserisciPassword);
            this.Controls.Add(this.LabelIndirizzo);
            this.Controls.Add(this.LabelEmail);
            this.Controls.Add(this.LabelNomeUtente);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.Login);
            this.Name = "FormLogin_Register";
            this.Text = "FormLogin_Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Button ButtonMostraIP;
        private System.Windows.Forms.Button ButtonMostraCP;
        private System.Windows.Forms.Button ButtonMostraLP;
        private System.Windows.Forms.Label LabelNomeUtente;
        private System.Windows.Forms.Label LabelEmail;
        private System.Windows.Forms.Label LabelIndirizzo;
        private System.Windows.Forms.Label LabelInserisciPassword;
        private System.Windows.Forms.Label LabelConfermaPassword;
        private System.Windows.Forms.Label LabelLoginEmail;
        private System.Windows.Forms.Label LabelLoginPassword;
        private System.Windows.Forms.TextBox TextBoxNomeUtente;
        private System.Windows.Forms.TextBox TextBoxEmail;
        private System.Windows.Forms.TextBox TextBoxIndirizzo;
        private System.Windows.Forms.TextBox TextBoxInserisciPassword;
        private System.Windows.Forms.TextBox TextBoxConfermaPassword;
        private System.Windows.Forms.TextBox TextBoxLoginEmail;
        private System.Windows.Forms.TextBox TextBoxLoginPassword;
    }
}