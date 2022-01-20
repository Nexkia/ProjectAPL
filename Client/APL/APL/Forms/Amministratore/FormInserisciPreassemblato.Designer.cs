
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
            this.buttonControllaCompatibilita = new System.Windows.Forms.Button();
            this.labelCpuDissipatore = new System.Windows.Forms.Label();
            this.labelRamSchedaMadre = new System.Windows.Forms.Label();
            this.labelCpuSchedaMadre = new System.Windows.Forms.Label();
            this.buttonSvuotaLista = new System.Windows.Forms.Button();
            this.buttonRimuoviElemento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNome
            // 
            this.labelNome.AutoSize = true;
            this.labelNome.Location = new System.Drawing.Point(1, 104);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(50, 20);
            this.labelNome.TabIndex = 0;
            this.labelNome.Text = "Nome";
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(57, 104);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(171, 27);
            this.textBoxNome.TabIndex = 1;
            // 
            // labelPrezzo
            // 
            this.labelPrezzo.AutoSize = true;
            this.labelPrezzo.Location = new System.Drawing.Point(234, 104);
            this.labelPrezzo.Name = "labelPrezzo";
            this.labelPrezzo.Size = new System.Drawing.Size(53, 20);
            this.labelPrezzo.TabIndex = 2;
            this.labelPrezzo.Text = "Prezzo";
            // 
            // textBoxPrezzo
            // 
            this.textBoxPrezzo.Location = new System.Drawing.Point(292, 104);
            this.textBoxPrezzo.Name = "textBoxPrezzo";
            this.textBoxPrezzo.Size = new System.Drawing.Size(186, 27);
            this.textBoxPrezzo.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.CadetBlue;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(510, 118);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(794, 430);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanel1_ControlAdded);
            // 
            // Conferma
            // 
            this.Conferma.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Conferma.Location = new System.Drawing.Point(14, 12);
            this.Conferma.Name = "Conferma";
            this.Conferma.Size = new System.Drawing.Size(214, 74);
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
            this.listViewPreassemblato.Location = new System.Drawing.Point(12, 148);
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
            // buttonControllaCompatibilita
            // 
            this.buttonControllaCompatibilita.Location = new System.Drawing.Point(292, 3);
            this.buttonControllaCompatibilita.Name = "buttonControllaCompatibilita";
            this.buttonControllaCompatibilita.Size = new System.Drawing.Size(186, 28);
            this.buttonControllaCompatibilita.TabIndex = 7;
            this.buttonControllaCompatibilita.Text = "Controlla Compatibilità";
            this.buttonControllaCompatibilita.UseVisualStyleBackColor = true;
            this.buttonControllaCompatibilita.Click += new System.EventHandler(this.buttonControllaCompatibilita_Click);
            // 
            // labelCpuDissipatore
            // 
            this.labelCpuDissipatore.AutoSize = true;
            this.labelCpuDissipatore.Location = new System.Drawing.Point(510, 20);
            this.labelCpuDissipatore.Name = "labelCpuDissipatore";
            this.labelCpuDissipatore.Size = new System.Drawing.Size(214, 20);
            this.labelCpuDissipatore.TabIndex = 8;
            this.labelCpuDissipatore.Text = "Compatibilità Cpu-Dissipatore:";
            // 
            // labelRamSchedaMadre
            // 
            this.labelRamSchedaMadre.AutoSize = true;
            this.labelRamSchedaMadre.Location = new System.Drawing.Point(510, 66);
            this.labelRamSchedaMadre.Name = "labelRamSchedaMadre";
            this.labelRamSchedaMadre.Size = new System.Drawing.Size(238, 20);
            this.labelRamSchedaMadre.TabIndex = 9;
            this.labelRamSchedaMadre.Text = "Compatibilità Ram-Scheda Madre:";
            // 
            // labelCpuSchedaMadre
            // 
            this.labelCpuSchedaMadre.AutoSize = true;
            this.labelCpuSchedaMadre.Location = new System.Drawing.Point(938, 20);
            this.labelCpuSchedaMadre.Name = "labelCpuSchedaMadre";
            this.labelCpuSchedaMadre.Size = new System.Drawing.Size(234, 20);
            this.labelCpuSchedaMadre.TabIndex = 10;
            this.labelCpuSchedaMadre.Text = "Compatibilità Cpu-Scheda Madre:";
            // 
            // buttonSvuotaLista
            // 
            this.buttonSvuotaLista.Location = new System.Drawing.Point(292, 37);
            this.buttonSvuotaLista.Name = "buttonSvuotaLista";
            this.buttonSvuotaLista.Size = new System.Drawing.Size(186, 26);
            this.buttonSvuotaLista.TabIndex = 11;
            this.buttonSvuotaLista.Text = "Svuota lista";
            this.buttonSvuotaLista.UseVisualStyleBackColor = true;
            this.buttonSvuotaLista.Click += new System.EventHandler(this.buttonSvuotaLista_Click);
            // 
            // buttonRimuoviElemento
            // 
            this.buttonRimuoviElemento.Location = new System.Drawing.Point(292, 69);
            this.buttonRimuoviElemento.Name = "buttonRimuoviElemento";
            this.buttonRimuoviElemento.Size = new System.Drawing.Size(188, 29);
            this.buttonRimuoviElemento.TabIndex = 12;
            this.buttonRimuoviElemento.Text = "Rimuovi Elemento";
            this.buttonRimuoviElemento.UseVisualStyleBackColor = true;
            this.buttonRimuoviElemento.Click += new System.EventHandler(this.buttonRimuoviElemento_Click);
            // 
            // FormInserisciPreassemblato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 560);
            this.Controls.Add(this.buttonRimuoviElemento);
            this.Controls.Add(this.buttonSvuotaLista);
            this.Controls.Add(this.labelCpuSchedaMadre);
            this.Controls.Add(this.labelRamSchedaMadre);
            this.Controls.Add(this.labelCpuDissipatore);
            this.Controls.Add(this.buttonControllaCompatibilita);
            this.Controls.Add(this.listViewPreassemblato);
            this.Controls.Add(this.Conferma);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.textBoxPrezzo);
            this.Controls.Add(this.labelPrezzo);
            this.Controls.Add(this.textBoxNome);
            this.Controls.Add(this.labelNome);
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
        private System.Windows.Forms.Button buttonControllaCompatibilita;
        private System.Windows.Forms.Label labelCpuDissipatore;
        private System.Windows.Forms.Label labelRamSchedaMadre;
        private System.Windows.Forms.Label labelCpuSchedaMadre;
        private System.Windows.Forms.Button buttonSvuotaLista;
        private System.Windows.Forms.Button buttonRimuoviElemento;
    }
}
