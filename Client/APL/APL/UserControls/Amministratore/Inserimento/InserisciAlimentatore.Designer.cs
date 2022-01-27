
namespace APL.UserControls.Amministratore.Inserimento
{
    partial class InserisciAlimentatore
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonConferma = new System.Windows.Forms.Button();
            this.textBoxWatt = new System.Windows.Forms.TextBox();
            this.textBoxValutazione = new System.Windows.Forms.TextBox();
            this.labelWatt = new System.Windows.Forms.Label();
            this.labelValutazione = new System.Windows.Forms.Label();
            this.labelTitolo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonConferma);
            this.panel1.Controls.Add(this.textBoxWatt);
            this.panel1.Controls.Add(this.textBoxValutazione);
            this.panel1.Controls.Add(this.labelWatt);
            this.panel1.Controls.Add(this.labelValutazione);
            this.panel1.Controls.Add(this.labelTitolo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 420);
            this.panel1.TabIndex = 0;
            // 
            // buttonConferma
            // 
            this.buttonConferma.Location = new System.Drawing.Point(280, 3);
            this.buttonConferma.Name = "buttonConferma";
            this.buttonConferma.Size = new System.Drawing.Size(238, 41);
            this.buttonConferma.TabIndex = 9;
            this.buttonConferma.Text = "Conferma";
            this.buttonConferma.UseVisualStyleBackColor = true;
            this.buttonConferma.Click += new System.EventHandler(this.buttonConferma_Click);
            // 
            // textBoxWatt
            // 
            this.textBoxWatt.Location = new System.Drawing.Point(107, 139);
            this.textBoxWatt.Name = "textBoxWatt";
            this.textBoxWatt.Size = new System.Drawing.Size(348, 27);
            this.textBoxWatt.TabIndex = 8;
            this.textBoxWatt.TextChanged += new System.EventHandler(this.textBoxWatt_TextChanged);
            this.textBoxWatt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWatt_KeyPress);
            // 
            // textBoxValutazione
            // 
            this.textBoxValutazione.Location = new System.Drawing.Point(107, 77);
            this.textBoxValutazione.MaxLength = 2;
            this.textBoxValutazione.Name = "textBoxValutazione";
            this.textBoxValutazione.Size = new System.Drawing.Size(348, 27);
            this.textBoxValutazione.TabIndex = 7;
            this.textBoxValutazione.TextChanged += new System.EventHandler(this.textBoxValutazione_TextChanged);
            this.textBoxValutazione.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxWatt_KeyPress);
            // 
            // labelWatt
            // 
            this.labelWatt.AutoSize = true;
            this.labelWatt.Location = new System.Drawing.Point(40, 146);
            this.labelWatt.Name = "labelWatt";
            this.labelWatt.Size = new System.Drawing.Size(40, 20);
            this.labelWatt.TabIndex = 5;
            this.labelWatt.Text = "Watt";
            // 
            // labelValutazione
            // 
            this.labelValutazione.AutoSize = true;
            this.labelValutazione.Location = new System.Drawing.Point(15, 80);
            this.labelValutazione.Name = "labelValutazione";
            this.labelValutazione.Size = new System.Drawing.Size(86, 20);
            this.labelValutazione.TabIndex = 4;
            this.labelValutazione.Text = "Valutazione";
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoEllipsis = true;
            this.labelTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitolo.Location = new System.Drawing.Point(3, 0);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(271, 47);
            this.labelTitolo.TabIndex = 2;
            this.labelTitolo.Text = "Alimentatore";
            this.labelTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InserisciAlimentatore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InserisciAlimentatore";
            this.Size = new System.Drawing.Size(526, 420);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitolo;
        private System.Windows.Forms.Label labelValutazione;
        private System.Windows.Forms.Label labelWatt;
        private System.Windows.Forms.TextBox textBoxWatt;
        private System.Windows.Forms.TextBox textBoxValutazione;
        private System.Windows.Forms.Button buttonConferma;
    }
}
