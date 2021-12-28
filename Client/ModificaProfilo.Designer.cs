
namespace Client
{
    partial class ModificaProfilo
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
            this.label6 = new System.Windows.Forms.Label();
            this.TextName = new System.Windows.Forms.TextBox();
            this.TextEmail = new System.Windows.Forms.TextBox();
            this.TextIndirizzo = new System.Windows.Forms.TextBox();
            this.TextOldPassword = new System.Windows.Forms.TextBox();
            this.TextNewPassword = new System.Windows.Forms.TextBox();
            this.TextRepeatPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(383, 266);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Ripeti Nuova Password";
            // 
            // TextName
            // 
            this.TextName.Location = new System.Drawing.Point(63, 77);
            this.TextName.Name = "TextName";
            this.TextName.Size = new System.Drawing.Size(217, 20);
            this.TextName.TabIndex = 0;
            // 
            // TextEmail
            // 
            this.TextEmail.Location = new System.Drawing.Point(63, 187);
            this.TextEmail.Name = "TextEmail";
            this.TextEmail.Size = new System.Drawing.Size(217, 20);
            this.TextEmail.TabIndex = 1;
            // 
            // TextIndirizzo
            // 
            this.TextIndirizzo.Location = new System.Drawing.Point(63, 294);
            this.TextIndirizzo.Name = "TextIndirizzo";
            this.TextIndirizzo.Size = new System.Drawing.Size(217, 20);
            this.TextIndirizzo.TabIndex = 3;
            // 
            // TextOldPassword
            // 
            this.TextOldPassword.Location = new System.Drawing.Point(380, 77);
            this.TextOldPassword.Name = "TextOldPassword";
            this.TextOldPassword.Size = new System.Drawing.Size(217, 20);
            this.TextOldPassword.TabIndex = 4;
            // 
            // TextNewPassword
            // 
            this.TextNewPassword.Location = new System.Drawing.Point(380, 187);
            this.TextNewPassword.Name = "TextNewPassword";
            this.TextNewPassword.Size = new System.Drawing.Size(217, 20);
            this.TextNewPassword.TabIndex = 5;
            // 
            // TextRepeatPassword
            // 
            this.TextRepeatPassword.Location = new System.Drawing.Point(380, 294);
            this.TextRepeatPassword.Name = "TextRepeatPassword";
            this.TextRepeatPassword.Size = new System.Drawing.Size(217, 20);
            this.TextRepeatPassword.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Indirizzo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Vecchia Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(383, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nuova Password";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(546, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.save_Click);
            // 
            // ModificaProfilo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextRepeatPassword);
            this.Controls.Add(this.TextNewPassword);
            this.Controls.Add(this.TextOldPassword);
            this.Controls.Add(this.TextIndirizzo);
            this.Controls.Add(this.TextEmail);
            this.Controls.Add(this.TextName);
            this.Name = "ModificaProfilo";
            this.Text = "ModificaProfilo";
            this.Load += new System.EventHandler(this.ModificaProfilo_LoadAsync);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextName;
        private System.Windows.Forms.TextBox TextEmail;
        private System.Windows.Forms.TextBox TextIndirizzo;
        private System.Windows.Forms.TextBox TextOldPassword;
        private System.Windows.Forms.TextBox TextNewPassword;
        private System.Windows.Forms.TextBox TextRepeatPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
    }
}