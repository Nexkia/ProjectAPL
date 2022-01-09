
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
            this.labelImmagine = new System.Windows.Forms.Label();
            this.textBoxModello = new System.Windows.Forms.TextBox();
            this.textBoxMarca = new System.Windows.Forms.TextBox();
            this.textBoxPrezzo = new System.Windows.Forms.TextBox();
            this.textBoxCapienza = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonConfermaTipoComponente = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonConferma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelModello
            // 
            this.labelModello.AutoSize = true;
            this.labelModello.Location = new System.Drawing.Point(12, 132);
            this.labelModello.Name = "labelModello";
            this.labelModello.Size = new System.Drawing.Size(65, 20);
            this.labelModello.TabIndex = 1;
            this.labelModello.Text = "Modello";
            // 
            // labelMarca
            // 
            this.labelMarca.AutoSize = true;
            this.labelMarca.Location = new System.Drawing.Point(14, 198);
            this.labelMarca.Name = "labelMarca";
            this.labelMarca.Size = new System.Drawing.Size(50, 20);
            this.labelMarca.TabIndex = 2;
            this.labelMarca.Text = "Marca";
            // 
            // labelCapienza
            // 
            this.labelCapienza.AutoSize = true;
            this.labelCapienza.Location = new System.Drawing.Point(9, 348);
            this.labelCapienza.Name = "labelCapienza";
            this.labelCapienza.Size = new System.Drawing.Size(70, 20);
            this.labelCapienza.TabIndex = 3;
            this.labelCapienza.Text = "Capienza";
            // 
            // labelPrezzo
            // 
            this.labelPrezzo.AutoSize = true;
            this.labelPrezzo.Location = new System.Drawing.Point(12, 269);
            this.labelPrezzo.Name = "labelPrezzo";
            this.labelPrezzo.Size = new System.Drawing.Size(53, 20);
            this.labelPrezzo.TabIndex = 4;
            this.labelPrezzo.Text = "Prezzo";
            // 
            // labelImmagine
            // 
            this.labelImmagine.AutoSize = true;
            this.labelImmagine.Location = new System.Drawing.Point(12, 420);
            this.labelImmagine.Name = "labelImmagine";
            this.labelImmagine.Size = new System.Drawing.Size(76, 20);
            this.labelImmagine.TabIndex = 6;
            this.labelImmagine.Text = "Immagine";
            // 
            // textBoxModello
            // 
            this.textBoxModello.Location = new System.Drawing.Point(12, 155);
            this.textBoxModello.Name = "textBoxModello";
            this.textBoxModello.ReadOnly = true;
            this.textBoxModello.Size = new System.Drawing.Size(316, 27);
            this.textBoxModello.TabIndex = 7;
            // 
            // textBoxMarca
            // 
            this.textBoxMarca.Location = new System.Drawing.Point(12, 221);
            this.textBoxMarca.Name = "textBoxMarca";
            this.textBoxMarca.ReadOnly = true;
            this.textBoxMarca.Size = new System.Drawing.Size(316, 27);
            this.textBoxMarca.TabIndex = 8;
            // 
            // textBoxPrezzo
            // 
            this.textBoxPrezzo.Location = new System.Drawing.Point(12, 292);
            this.textBoxPrezzo.Name = "textBoxPrezzo";
            this.textBoxPrezzo.ReadOnly = true;
            this.textBoxPrezzo.Size = new System.Drawing.Size(316, 27);
            this.textBoxPrezzo.TabIndex = 9;
            // 
            // textBoxCapienza
            // 
            this.textBoxCapienza.Location = new System.Drawing.Point(12, 371);
            this.textBoxCapienza.Name = "textBoxCapienza";
            this.textBoxCapienza.ReadOnly = true;
            this.textBoxCapienza.Size = new System.Drawing.Size(316, 27);
            this.textBoxCapienza.TabIndex = 10;
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
            this.comboBox1.Location = new System.Drawing.Point(366, 26);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(197, 28);
            this.comboBox1.TabIndex = 12;
            // 
            // buttonConfermaTipoComponente
            // 
            this.buttonConfermaTipoComponente.Location = new System.Drawing.Point(586, 26);
            this.buttonConfermaTipoComponente.Name = "buttonConfermaTipoComponente";
            this.buttonConfermaTipoComponente.Size = new System.Drawing.Size(189, 51);
            this.buttonConfermaTipoComponente.TabIndex = 13;
            this.buttonConfermaTipoComponente.Text = "Conferma Tipo Componente";
            this.buttonConfermaTipoComponente.UseVisualStyleBackColor = true;
            this.buttonConfermaTipoComponente.Click += new System.EventHandler(this.buttonConfermaTipoComponente_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(365, 158);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(526, 420);
            this.flowLayoutPanel1.TabIndex = 14;
            // 
            // buttonConferma
            // 
            this.buttonConferma.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonConferma.Location = new System.Drawing.Point(373, 602);
            this.buttonConferma.Name = "buttonConferma";
            this.buttonConferma.Size = new System.Drawing.Size(274, 77);
            this.buttonConferma.TabIndex = 15;
            this.buttonConferma.Text = "Conferma";
            this.buttonConferma.UseVisualStyleBackColor = true;
            // 
            // FormInserisciComponente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 681);
            this.Controls.Add(this.buttonConferma);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.buttonConfermaTipoComponente);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxCapienza);
            this.Controls.Add(this.textBoxPrezzo);
            this.Controls.Add(this.textBoxMarca);
            this.Controls.Add(this.textBoxModello);
            this.Controls.Add(this.labelImmagine);
            this.Controls.Add(this.labelPrezzo);
            this.Controls.Add(this.labelCapienza);
            this.Controls.Add(this.labelMarca);
            this.Controls.Add(this.labelModello);
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
        private System.Windows.Forms.Label labelImmagine;
        private System.Windows.Forms.TextBox textBoxModello;
        private System.Windows.Forms.TextBox textBoxMarca;
        private System.Windows.Forms.TextBox textBoxPrezzo;
        private System.Windows.Forms.TextBox textBoxCapienza;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonConfermaTipoComponente;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonConferma;
    }
}