
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
            this.buttonSvuotaLista = new System.Windows.Forms.Button();
            this.buttonRimuoviElemento = new System.Windows.Forms.Button();
            this.listViewPreassemblatoDetail = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(12, 78);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(40, 15);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(61, 78);
            this.textBoxNome.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(150, 23);
            this.textBoxNome.TabIndex = 1;
            // 
            // labelPrezzo
            // 
            this.labelPrezzo.AutoSize = true;
            this.labelPrezzo.Location = new System.Drawing.Point(216, 78);
            this.labelPrezzo.Name = "labelPrezzo";
            this.labelPrezzo.Size = new System.Drawing.Size(41, 15);
            this.labelPrezzo.TabIndex = 2;
            this.labelPrezzo.Text = "Prezzo";
            // 
            // textBoxPrezzo
            // 
            this.textBoxPrezzo.Location = new System.Drawing.Point(268, 78);
            this.textBoxPrezzo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPrezzo.Name = "textBoxPrezzo";
            this.textBoxPrezzo.Size = new System.Drawing.Size(151, 23);
            this.textBoxPrezzo.TabIndex = 3;
            this.textBoxPrezzo.TextChanged += new System.EventHandler(this.textBoxPrezzo_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.CadetBlue;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(446, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(695, 642);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanel1_ControlAdded);
            // 
            // Conferma
            // 
            this.Conferma.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Conferma.Location = new System.Drawing.Point(12, 4);
            this.Conferma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Conferma.Name = "Conferma";
            this.Conferma.Size = new System.Drawing.Size(187, 66);
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
            this.listViewPreassemblato.Location = new System.Drawing.Point(10, 111);
            this.listViewPreassemblato.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewPreassemblato.Name = "listViewPreassemblato";
            this.listViewPreassemblato.Size = new System.Drawing.Size(405, 301);
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
            // buttonSvuotaLista
            // 
            this.buttonSvuotaLista.Location = new System.Drawing.Point(268, 4);
            this.buttonSvuotaLista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSvuotaLista.Name = "buttonSvuotaLista";
            this.buttonSvuotaLista.Size = new System.Drawing.Size(150, 32);
            this.buttonSvuotaLista.TabIndex = 11;
            this.buttonSvuotaLista.Text = "Svuota lista";
            this.buttonSvuotaLista.UseVisualStyleBackColor = true;
            this.buttonSvuotaLista.Click += new System.EventHandler(this.buttonSvuotaLista_Click);
            // 
            // buttonRimuoviElemento
            // 
            this.buttonRimuoviElemento.Location = new System.Drawing.Point(268, 41);
            this.buttonRimuoviElemento.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRimuoviElemento.Name = "buttonRimuoviElemento";
            this.buttonRimuoviElemento.Size = new System.Drawing.Size(150, 32);
            this.buttonRimuoviElemento.TabIndex = 12;
            this.buttonRimuoviElemento.Text = "Rimuovi Elemento";
            this.buttonRimuoviElemento.UseVisualStyleBackColor = true;
            this.buttonRimuoviElemento.Click += new System.EventHandler(this.buttonRimuoviElemento_Click);
            // 
            // listViewPreassemblatoDetail
            // 
            this.listViewPreassemblatoDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewPreassemblatoDetail.HideSelection = false;
            this.listViewPreassemblatoDetail.Location = new System.Drawing.Point(12, 430);
            this.listViewPreassemblatoDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listViewPreassemblatoDetail.Name = "listViewPreassemblatoDetail";
            this.listViewPreassemblatoDetail.Size = new System.Drawing.Size(403, 218);
            this.listViewPreassemblatoDetail.TabIndex = 13;
            this.listViewPreassemblatoDetail.UseCompatibleStateImageBehavior = false;
            this.listViewPreassemblatoDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Categoria";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Standard";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Socket";
            this.columnHeader8.Width = 150;
            // 
            // FormInserisciPreassemblato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 656);
            this.Controls.Add(this.listViewPreassemblatoDetail);
            this.Controls.Add(this.buttonRimuoviElemento);
            this.Controls.Add(this.buttonSvuotaLista);
            this.Controls.Add(this.listViewPreassemblato);
            this.Controls.Add(this.Conferma);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.textBoxPrezzo);
            this.Controls.Add(this.labelPrezzo);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormInserisciPreassemblato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button buttonSvuotaLista;
        private System.Windows.Forms.Button buttonRimuoviElemento;
        private System.Windows.Forms.ListView listViewPreassemblatoDetail;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}
