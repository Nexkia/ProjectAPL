
using System.Windows.Forms;

namespace APL.Forms.Amministratore
{
    partial class FormInserisciComponente
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
            this.labelModello = new System.Windows.Forms.Label();
            this.labelMarca = new System.Windows.Forms.Label();
            this.labelCapienza = new System.Windows.Forms.Label();
            this.labelPrezzo = new System.Windows.Forms.Label();
            this.textBoxModello = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBoxPrezzo = new System.Windows.Forms.TextBox();
            this.textBoxCapienza = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonConfermaTipoComponente = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // labelModello
            // 
            this.labelModello.AutoSize = true;
            this.labelModello.Location = new System.Drawing.Point(10, 99);
            this.labelModello.Name = "labelModello";
            this.labelModello.Size = new System.Drawing.Size(51, 15);
            this.labelModello.TabIndex = 1;
            this.labelModello.Text = "Modello";
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(12, 148);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(40, 15);
            this.labelMarca.TabIndex = 2;
            this.labelMarca.Text = "Marca";
            // 
            // labelCapienza
            // 
            this.labelCapienza.AutoSize = true;
            this.labelCapienza.Location = new System.Drawing.Point(8, 261);
            this.labelCapienza.Name = "labelCapienza";
            this.labelCapienza.Size = new System.Drawing.Size(55, 15);
            this.labelCapienza.TabIndex = 3;
            this.labelCapienza.Text = "Capienza";
            // 
            // labelPrezzo
            // 
            this.labelPrezzo.AutoSize = true;
            this.labelPrezzo.Location = new System.Drawing.Point(10, 202);
            this.labelPrezzo.Name = "labelPrezzo";
            this.labelPrezzo.Size = new System.Drawing.Size(41, 15);
            this.labelPrezzo.TabIndex = 4;
            this.labelPrezzo.Text = "Prezzo";
            // 
            // textBoxModello
            // 
            this.textBoxModello.Location = new System.Drawing.Point(10, 116);
            this.textBoxModello.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxModello.Name = "textBoxModello";
            this.textBoxModello.ReadOnly = true;
            this.textBoxModello.Size = new System.Drawing.Size(277, 23);
            this.textBoxModello.TabIndex = 7;
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(10, 166);
            this.textBoxMarca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.ReadOnly = true;
            this.textBoxMarca.Size = new System.Drawing.Size(277, 23);
            this.textBoxMarca.TabIndex = 8;
            // 
            // textBoxPrezzo
            // 
            this.textBoxPrezzo.Location = new System.Drawing.Point(10, 219);
            this.textBoxPrezzo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPrezzo.Name = "textBoxPrezzo";
            this.textBoxPrezzo.ReadOnly = true;
            this.textBoxPrezzo.Size = new System.Drawing.Size(277, 23);
            this.textBoxPrezzo.TabIndex = 9;
            this.textBoxPrezzo.TextChanged += new System.EventHandler(this.textBoxPrezzo_TextChanged);
            // 
            // textBoxCapienza
            // 
            this.textBoxCapienza.Location = new System.Drawing.Point(10, 278);
            this.textBoxCapienza.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCapienza.Name = "textBoxCapienza";
            this.textBoxCapienza.ReadOnly = true;
            this.textBoxCapienza.Size = new System.Drawing.Size(277, 23);
            this.textBoxCapienza.TabIndex = 10;
            this.textBoxCapienza.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCapienza_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "alimentatore",
            "casepc",
            "cpu",
            "dissipatore",
            "memoria",
            "ram",
            "schedaMadre",
            "schedaVideo"});
            this.comboBox1.Location = new System.Drawing.Point(12, 20);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 23);
            this.comboBox1.TabIndex = 12;
            // 
            // buttonConfermaTipoComponente
            // 
            this.buttonConfermaTipoComponente.Location = new System.Drawing.Point(206, 20);
            this.buttonConfermaTipoComponente.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConfermaTipoComponente.Name = "buttonConfermaTipoComponente";
            this.buttonConfermaTipoComponente.Size = new System.Drawing.Size(114, 38);
            this.buttonConfermaTipoComponente.TabIndex = 13;
            this.buttonConfermaTipoComponente.Text = "Conferma Tipo Componente";
            this.buttonConfermaTipoComponente.UseVisualStyleBackColor = true;
            this.buttonConfermaTipoComponente.Click += new System.EventHandler(this.buttonConfermaTipoComponente_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(319, 118);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(460, 315);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // FormInserisciComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 438);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonConfermaTipoComponente);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxCapienza);
            this.Controls.Add(this.textBoxPrezzo);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.textBoxModello);
            this.Controls.Add(this.labelPrezzo);
            this.Controls.Add(this.labelCapienza);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.labelModello);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormInserisciComponente";
            this.Text = "FormInserisciComponente";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelModello;
        private System.Windows.Forms.Label labelMarca;
        private System.Windows.Forms.Label labelCapienza;
        private System.Windows.Forms.Label labelPrezzo;
        private System.Windows.Forms.TextBox textBoxModello;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBoxPrezzo;
        private System.Windows.Forms.TextBox textBoxCapienza;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonConfermaTipoComponente;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}