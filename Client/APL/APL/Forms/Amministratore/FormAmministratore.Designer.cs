
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonInserisciComponente = new System.Windows.Forms.Button();
            this.buttonEliminaComponente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(333, 168);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(225, 28);
            this.comboBox1.TabIndex = 0;
            // 
            // buttonInserisciComponente
            // 
            this.buttonInserisciComponente.Location = new System.Drawing.Point(39, 69);
            this.buttonInserisciComponente.Name = "buttonInserisciComponente";
            this.buttonInserisciComponente.Size = new System.Drawing.Size(225, 66);
            this.buttonInserisciComponente.TabIndex = 1;
            this.buttonInserisciComponente.Text = "Inserisci Componente";
            this.buttonInserisciComponente.UseVisualStyleBackColor = true;
            this.buttonInserisciComponente.Click += new System.EventHandler(this.buttonInserisciComponente_Click);
            // 
            // buttonEliminaComponente
            // 
            this.buttonEliminaComponente.Location = new System.Drawing.Point(333, 69);
            this.buttonEliminaComponente.Name = "buttonEliminaComponente";
            this.buttonEliminaComponente.Size = new System.Drawing.Size(225, 66);
            this.buttonEliminaComponente.TabIndex = 2;
            this.buttonEliminaComponente.Text = "Elimina Componente";
            this.buttonEliminaComponente.UseVisualStyleBackColor = true;
            // 
            // FormAmministratore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 545);
            this.Controls.Add(this.buttonEliminaComponente);
            this.Controls.Add(this.buttonInserisciComponente);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAmministratore";
            this.Text = "FormAmministratore";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonInserisciComponente;
        private System.Windows.Forms.Button buttonEliminaComponente;
    }
}