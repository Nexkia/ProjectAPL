
namespace APL.UserControls.Amministratore.Inserimento
{
    partial class InserisciRam
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
            this.textBoxStandard = new System.Windows.Forms.TextBox();
            this.labelStandard = new System.Windows.Forms.Label();
            this.textBoxFrequenza = new System.Windows.Forms.TextBox();
            this.textBoxValutazione = new System.Windows.Forms.TextBox();
            this.labelFrequenza = new System.Windows.Forms.Label();
            this.labelValutazione = new System.Windows.Forms.Label();
            this.buttonConferma = new System.Windows.Forms.Button();
            this.labelTitolo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxStandard);
            this.panel1.Controls.Add(this.labelStandard);
            this.panel1.Controls.Add(this.textBoxFrequenza);
            this.panel1.Controls.Add(this.textBoxValutazione);
            this.panel1.Controls.Add(this.labelFrequenza);
            this.panel1.Controls.Add(this.labelValutazione);
            this.panel1.Controls.Add(this.buttonConferma);
            this.panel1.Controls.Add(this.labelTitolo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 420);
            this.panel1.TabIndex = 0;
            // 
            // textBoxStandard
            // 
            this.textBoxStandard.Location = new System.Drawing.Point(121, 195);
            this.textBoxStandard.Name = "textBoxStandard";
            this.textBoxStandard.Size = new System.Drawing.Size(348, 27);
            this.textBoxStandard.TabIndex = 24;
            // 
            // labelStandard
            // 
            this.labelStandard.AutoSize = true;
            this.labelStandard.Location = new System.Drawing.Point(46, 198);
            this.labelStandard.Name = "labelStandard";
            this.labelStandard.Size = new System.Drawing.Size(69, 20);
            this.labelStandard.TabIndex = 23;
            this.labelStandard.Text = "Standard";
            // 
            // textBoxFrequenza
            // 
            this.textBoxFrequenza.Location = new System.Drawing.Point(121, 134);
            this.textBoxFrequenza.Name = "textBoxFrequenza";
            this.textBoxFrequenza.Size = new System.Drawing.Size(348, 27);
            this.textBoxFrequenza.TabIndex = 22;
            // 
            // textBoxValutazione
            // 
            this.textBoxValutazione.Location = new System.Drawing.Point(121, 72);
            this.textBoxValutazione.Name = "textBoxValutazione";
            this.textBoxValutazione.Size = new System.Drawing.Size(348, 27);
            this.textBoxValutazione.TabIndex = 21;
            // 
            // labelFrequenza
            // 
            this.labelFrequenza.AutoSize = true;
            this.labelFrequenza.Location = new System.Drawing.Point(38, 137);
            this.labelFrequenza.Name = "labelFrequenza";
            this.labelFrequenza.Size = new System.Drawing.Size(77, 20);
            this.labelFrequenza.TabIndex = 20;
            this.labelFrequenza.Text = "Frequenza";
            // 
            // labelValutazione
            // 
            this.labelValutazione.AutoSize = true;
            this.labelValutazione.Location = new System.Drawing.Point(29, 75);
            this.labelValutazione.Name = "labelValutazione";
            this.labelValutazione.Size = new System.Drawing.Size(86, 20);
            this.labelValutazione.TabIndex = 19;
            this.labelValutazione.Text = "Valutazione";
            // 
            // buttonConferma
            // 
            this.buttonConferma.Location = new System.Drawing.Point(280, 6);
            this.buttonConferma.Name = "buttonConferma";
            this.buttonConferma.Size = new System.Drawing.Size(238, 41);
            this.buttonConferma.TabIndex = 18;
            this.buttonConferma.Text = "Conferma";
            this.buttonConferma.UseVisualStyleBackColor = true;
            this.buttonConferma.Click += new System.EventHandler(this.buttonConferma_Click);
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoEllipsis = true;
            this.labelTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitolo.Location = new System.Drawing.Point(3, 0);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(271, 47);
            this.labelTitolo.TabIndex = 17;
            this.labelTitolo.Text = "Ram";
            this.labelTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InserisciRam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InserisciRam";
            this.Size = new System.Drawing.Size(526, 420);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxStandard;
        private System.Windows.Forms.Label labelStandard;
        private System.Windows.Forms.TextBox textBoxFrequenza;
        private System.Windows.Forms.TextBox textBoxValutazione;
        private System.Windows.Forms.Label labelFrequenza;
        private System.Windows.Forms.Label labelValutazione;
        private System.Windows.Forms.Button buttonConferma;
        private System.Windows.Forms.Label labelTitolo;
    }
}
