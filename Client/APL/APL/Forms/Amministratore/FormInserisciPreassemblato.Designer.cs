
namespace APL.Forms.Amministratore
{
    partial class FormInserisciPreassemblato
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

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelNome = new System.Windows.Forms.Label();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.labelPrezzo = new System.Windows.Forms.Label();
            this.textBoxPrezzo = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Conferma = new System.Windows.Forms.Button();
            this.listViewPreassemblato = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(521, 32);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(50, 20);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(577, 29);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(171, 27);
            this.textBoxNome.TabIndex = 1;
            // 
            // labelPrezzo
            // 
            this.labelPrezzo.AutoSize = true;
            this.labelPrezzo.Location = new System.Drawing.Point(786, 32);
            this.labelPrezzo.Name = "labelPrezzo";
            this.labelPrezzo.Size = new System.Drawing.Size(53, 20);
            this.labelPrezzo.TabIndex = 2;
            this.labelPrezzo.Text = "Prezzo";
            // 
            // textBoxPrezzo
            // 
            this.textBoxPrezzo.Location = new System.Drawing.Point(845, 29);
            this.textBoxPrezzo.Name = "textBoxPrezzo";
            this.textBoxPrezzo.Size = new System.Drawing.Size(186, 27);
            this.textBoxPrezzo.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.CadetBlue;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(510, 67);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 430);
            this.flowLayoutPanel1.TabIndex = 4;
            
            // 
            // Conferma
            // 
            this.Conferma.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Conferma.Location = new System.Drawing.Point(133, 9);
            this.Conferma.Name = "Conferma";
            this.Conferma.Size = new System.Drawing.Size(214, 61);
            this.Conferma.TabIndex = 5;
            this.Conferma.Text = "Conferma";
            this.Conferma.UseVisualStyleBackColor = true;
            this.Conferma.Click += new System.EventHandler(this.Conferma_Click);
            // 
            // listViewPreassemblato
            // 
            this.listViewPreassemblato.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewPreassemblato.HideSelection = false;
            this.listViewPreassemblato.Location = new System.Drawing.Point(17, 96);
            this.listViewPreassemblato.Name = "listViewPreassemblato";
            this.listViewPreassemblato.Size = new System.Drawing.Size(462, 400);
            this.listViewPreassemblato.TabIndex = 6;
            this.listViewPreassemblato.UseCompatibleStateImageBehavior = false;
            this.listViewPreassemblato.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Modello";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Marca";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Prezzo";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Capienza";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Categoria";
            this.columnHeader5.Width = 100;
            // 
            // FormInserisciPreassemblato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 511);
            this.Controls.Add(this.listViewPreassemblato);
            this.Controls.Add(this.Conferma);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.textBoxPrezzo);
            this.Controls.Add(this.labelPrezzo);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
            this.Name = "FormInserisciPreassemblato";
            this.Load += new System.EventHandler(this.FormInserisciPreassemblato_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.Label labelPrezzo;
        private System.Windows.Forms.TextBox textBoxPrezzo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button Conferma;
        private System.Windows.Forms.ListView listViewPreassemblato;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}
