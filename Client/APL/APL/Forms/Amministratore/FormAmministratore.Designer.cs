
namespace APL.Forms
{
    partial class FormAmministratore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAmministratore));
            this.buttonInserisciComponente = new System.Windows.Forms.Button();
            this.buttonEliminaComponente = new System.Windows.Forms.Button();
            this.TextBoxModello = new System.Windows.Forms.TextBox();
            this.buttonInserisciPreassemblato = new System.Windows.Forms.Button();
            this.buttonEliminaPreassemblato = new System.Windows.Forms.Button();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonInserisciComponente
            // 
            this.buttonInserisciComponente.Location = new System.Drawing.Point(34, 52);
            this.buttonInserisciComponente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInserisciComponente.Name = "buttonInserisciComponente";
            this.buttonInserisciComponente.Size = new System.Drawing.Size(197, 50);
            this.buttonInserisciComponente.TabIndex = 1;
            this.buttonInserisciComponente.Text = "Inserisci Componente";
            this.buttonInserisciComponente.UseVisualStyleBackColor = true;
            this.buttonInserisciComponente.Click += new System.EventHandler(this.buttonInserisciComponente_Click);
            // 
            // buttonEliminaComponente
            // 
            this.buttonEliminaComponente.Location = new System.Drawing.Point(291, 52);
            this.buttonEliminaComponente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEliminaComponente.Name = "buttonEliminaComponente";
            this.buttonEliminaComponente.Size = new System.Drawing.Size(197, 50);
            this.buttonEliminaComponente.TabIndex = 2;
            this.buttonEliminaComponente.Text = "Elimina Componente";
            this.buttonEliminaComponente.UseVisualStyleBackColor = true;
            this.buttonEliminaComponente.Click += new System.EventHandler(this.buttonEliminaComponente_Click);
            // 
            // TextBoxModello
            // 
            this.TextBoxModello.Location = new System.Drawing.Point(291, 143);
            this.TextBoxModello.Name = "TextBoxModello";
            this.TextBoxModello.Size = new System.Drawing.Size(197, 23);
            this.TextBoxModello.TabIndex = 3;
            // 
            // buttonInserisciPreassemblato
            // 
            this.buttonInserisciPreassemblato.Location = new System.Drawing.Point(34, 236);
            this.buttonInserisciPreassemblato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonInserisciPreassemblato.Name = "buttonInserisciPreassemblato";
            this.buttonInserisciPreassemblato.Size = new System.Drawing.Size(197, 50);
            this.buttonInserisciPreassemblato.TabIndex = 4;
            this.buttonInserisciPreassemblato.Text = "Inserisci Preassemblato";
            this.buttonInserisciPreassemblato.UseVisualStyleBackColor = true;
            this.buttonInserisciPreassemblato.Click += new System.EventHandler(this.buttonInserisciPreassemblato_Click);
            // 
            // buttonEliminaPreassemblato
            // 
            this.buttonEliminaPreassemblato.Location = new System.Drawing.Point(291, 236);
            this.buttonEliminaPreassemblato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonEliminaPreassemblato.Name = "buttonEliminaPreassemblato";
            this.buttonEliminaPreassemblato.Size = new System.Drawing.Size(197, 50);
            this.buttonEliminaPreassemblato.TabIndex = 5;
            this.buttonEliminaPreassemblato.Text = "Elimina Preassemblato";
            this.buttonEliminaPreassemblato.UseVisualStyleBackColor = true;
            this.buttonEliminaPreassemblato.Click += new System.EventHandler(this.buttonEliminaPreassemblato_Click);
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(291, 324);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(197, 23);
            this.textBoxNome.TabIndex = 6;
            // 
            // FormAmministratore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 409);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.buttonEliminaPreassemblato);
            this.Controls.Add(this.buttonInserisciPreassemblato);
            this.Controls.Add(this.TextBoxModello);
            this.Controls.Add(this.buttonEliminaComponente);
            this.Controls.Add(this.buttonInserisciComponente);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormAmministratore";
            this.Text = "FormAmministratore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonInserisciComponente;
        private System.Windows.Forms.Button buttonEliminaComponente;
        private System.Windows.Forms.TextBox TextBoxModello;
        private System.Windows.Forms.Button buttonInserisciPreassemblato;
        private System.Windows.Forms.Button buttonEliminaPreassemblato;
        private System.Windows.Forms.TextBox textBoxNome;
    }
}