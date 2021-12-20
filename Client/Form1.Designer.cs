
namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Login = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonMostra = new System.Windows.Forms.Button();
            this.textBoxConfermaPasswordR = new System.Windows.Forms.TextBox();
            this.labelConfermaPasswordR = new System.Windows.Forms.Label();
            this.textBoxInserisciPasswordR = new System.Windows.Forms.TextBox();
            this.labelInserisciPasswordR = new System.Windows.Forms.Label();
            this.textBoxEmailR = new System.Windows.Forms.TextBox();
            this.labelEmailR = new System.Windows.Forms.Label();
            this.textBoxNomeUtente = new System.Windows.Forms.TextBox();
            this.labelNomeUtente = new System.Windows.Forms.Label();
            this.textBoxIndirizzo = new System.Windows.Forms.TextBox();
            this.labelIndirizzo = new System.Windows.Forms.Label();
            this.buttonMostraIP = new System.Windows.Forms.Button();
            this.buttonCP = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Login
            // 
            resources.ApplyResources(this.Login, "Login");
            this.Login.Name = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.button1_Click);
            // 
            // Register
            // 
            resources.ApplyResources(this.Register, "Register");
            this.Register.Name = "Register";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Password
            // 
            resources.ApplyResources(this.Password, "Password");
            this.Password.BackColor = System.Drawing.SystemColors.Control;
            this.Password.Name = "Password";
            this.Password.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxEmail
            // 
            resources.ApplyResources(this.textBoxEmail, "textBoxEmail");
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxPassword
            // 
            resources.ApplyResources(this.textBoxPassword, "textBoxPassword");
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // buttonMostra
            // 
            resources.ApplyResources(this.buttonMostra, "buttonMostra");
            this.buttonMostra.Name = "buttonMostra";
            this.buttonMostra.UseVisualStyleBackColor = true;
            this.buttonMostra.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBoxConfermaPasswordR
            // 
            resources.ApplyResources(this.textBoxConfermaPasswordR, "textBoxConfermaPasswordR");
            this.textBoxConfermaPasswordR.Name = "textBoxConfermaPasswordR";
            // 
            // labelConfermaPasswordR
            // 
            resources.ApplyResources(this.labelConfermaPasswordR, "labelConfermaPasswordR");
            this.labelConfermaPasswordR.BackColor = System.Drawing.SystemColors.Control;
            this.labelConfermaPasswordR.Name = "labelConfermaPasswordR";
            this.labelConfermaPasswordR.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // textBoxInserisciPasswordR
            // 
            resources.ApplyResources(this.textBoxInserisciPasswordR, "textBoxInserisciPasswordR");
            this.textBoxInserisciPasswordR.Name = "textBoxInserisciPasswordR";
            // 
            // labelInserisciPasswordR
            // 
            resources.ApplyResources(this.labelInserisciPasswordR, "labelInserisciPasswordR");
            this.labelInserisciPasswordR.BackColor = System.Drawing.SystemColors.Control;
            this.labelInserisciPasswordR.Name = "labelInserisciPasswordR";
            this.labelInserisciPasswordR.Click += new System.EventHandler(this.label3_Click_2);
            // 
            // textBoxEmailR
            // 
            resources.ApplyResources(this.textBoxEmailR, "textBoxEmailR");
            this.textBoxEmailR.Name = "textBoxEmailR";
            // 
            // labelEmailR
            // 
            resources.ApplyResources(this.labelEmailR, "labelEmailR");
            this.labelEmailR.BackColor = System.Drawing.SystemColors.Control;
            this.labelEmailR.Name = "labelEmailR";
            // 
            // textBoxNomeUtente
            // 
            resources.ApplyResources(this.textBoxNomeUtente, "textBoxNomeUtente");
            this.textBoxNomeUtente.Name = "textBoxNomeUtente";
            // 
            // labelNomeUtente
            // 
            resources.ApplyResources(this.labelNomeUtente, "labelNomeUtente");
            this.labelNomeUtente.BackColor = System.Drawing.SystemColors.Control;
            this.labelNomeUtente.Name = "labelNomeUtente";
            // 
            // textBoxIndirizzo
            // 
            resources.ApplyResources(this.textBoxIndirizzo, "textBoxIndirizzo");
            this.textBoxIndirizzo.Name = "textBoxIndirizzo";
            // 
            // labelIndirizzo
            // 
            resources.ApplyResources(this.labelIndirizzo, "labelIndirizzo");
            this.labelIndirizzo.BackColor = System.Drawing.SystemColors.Control;
            this.labelIndirizzo.Name = "labelIndirizzo";
            // 
            // buttonMostraIP
            // 
            resources.ApplyResources(this.buttonMostraIP, "buttonMostraIP");
            this.buttonMostraIP.Name = "buttonMostraIP";
            this.buttonMostraIP.UseVisualStyleBackColor = true;
            this.buttonMostraIP.Click += new System.EventHandler(this.buttonMostraIP_Click);
            // 
            // buttonCP
            // 
            resources.ApplyResources(this.buttonCP, "buttonCP");
            this.buttonCP.Name = "buttonCP";
            this.buttonCP.UseVisualStyleBackColor = true;
            this.buttonCP.Click += new System.EventHandler(this.buttonCP_Click);
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // buttonConnect
            // 
            resources.ApplyResources(this.buttonConnect, "buttonConnect");
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCP);
            this.Controls.Add(this.buttonMostraIP);
            this.Controls.Add(this.labelIndirizzo);
            this.Controls.Add(this.textBoxIndirizzo);
            this.Controls.Add(this.labelNomeUtente);
            this.Controls.Add(this.textBoxNomeUtente);
            this.Controls.Add(this.labelEmailR);
            this.Controls.Add(this.textBoxEmailR);
            this.Controls.Add(this.labelInserisciPasswordR);
            this.Controls.Add(this.textBoxInserisciPasswordR);
            this.Controls.Add(this.labelConfermaPasswordR);
            this.Controls.Add(this.textBoxConfermaPasswordR);
            this.Controls.Add(this.buttonMostra);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Register);
            this.Controls.Add(this.Login);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonMostra;
        private System.Windows.Forms.TextBox textBoxConfermaPasswordR;
        private System.Windows.Forms.Label labelConfermaPasswordR;
        private System.Windows.Forms.TextBox textBoxInserisciPasswordR;
        private System.Windows.Forms.Label labelInserisciPasswordR;
        private System.Windows.Forms.TextBox textBoxEmailR;
        private System.Windows.Forms.Label labelEmailR;
        private System.Windows.Forms.TextBox textBoxNomeUtente;
        private System.Windows.Forms.Label labelNomeUtente;
        private System.Windows.Forms.TextBox textBoxIndirizzo;
        private System.Windows.Forms.Label labelIndirizzo;
        private System.Windows.Forms.Button buttonMostraIP;
        private System.Windows.Forms.Button buttonCP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonConnect;
    }
}

