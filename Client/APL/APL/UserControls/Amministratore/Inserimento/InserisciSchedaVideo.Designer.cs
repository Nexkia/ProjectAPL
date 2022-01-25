
namespace APL.UserControls.Amministratore.Inserimento
{
    partial class InserisciSchedaVideo
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
            this.textBoxVram = new System.Windows.Forms.TextBox();
            this.labelVram = new System.Windows.Forms.Label();
            this.textBoxTdp = new System.Windows.Forms.TextBox();
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
            this.panel1.Controls.Add(this.textBoxVram);
            this.panel1.Controls.Add(this.labelVram);
            this.panel1.Controls.Add(this.textBoxTdp);
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
            // textBoxVram
            // 
            this.textBoxVram.Location = new System.Drawing.Point(121, 195);
            this.textBoxVram.Name = "textBoxVram";
            this.textBoxVram.Size = new System.Drawing.Size(348, 27);
            this.textBoxVram.TabIndex = 24;
            this.textBoxVram.TextChanged += new System.EventHandler(this.textBoxTdp_TextChanged);
            this.textBoxVram.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValutazione_KeyPress);
            // 
            // labelVram
            // 
            this.labelVram.AutoSize = true;
            this.labelVram.Location = new System.Drawing.Point(62, 198);
            this.labelVram.Name = "labelVram";
            this.labelVram.Size = new System.Drawing.Size(43, 20);
            this.labelVram.TabIndex = 23;
            this.labelVram.Text = "Vram";
            // 
            // textBoxTdp
            // 
            this.textBoxTdp.Location = new System.Drawing.Point(121, 134);
            this.textBoxTdp.Name = "textBoxTdp";
            this.textBoxTdp.Size = new System.Drawing.Size(348, 27);
            this.textBoxTdp.TabIndex = 22;
            this.textBoxTdp.TextChanged += new System.EventHandler(this.textBoxTdp_TextChanged);
            this.textBoxTdp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValutazione_KeyPress);
            // 
            // textBoxValutazione
            // 
            this.textBoxValutazione.Location = new System.Drawing.Point(121, 72);
            this.textBoxValutazione.MaxLength = 2;
            this.textBoxValutazione.Name = "textBoxValutazione";
            this.textBoxValutazione.Size = new System.Drawing.Size(348, 27);
            this.textBoxValutazione.TabIndex = 21;
            this.textBoxValutazione.TextChanged += new System.EventHandler(this.textBoxValutazione_TextChanged);
            this.textBoxValutazione.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValutazione_KeyPress);
            // 
            // labelFrequenza
            // 
            this.labelFrequenza.AutoSize = true;
            this.labelFrequenza.Location = new System.Drawing.Point(62, 134);
            this.labelFrequenza.Name = "labelFrequenza";
            this.labelFrequenza.Size = new System.Drawing.Size(34, 20);
            this.labelFrequenza.TabIndex = 20;
            this.labelFrequenza.Text = "Tdp";
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
            this.labelTitolo.Text = "Scheda Video";
            this.labelTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InserisciSchedaVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InserisciSchedaVideo";
            this.Size = new System.Drawing.Size(526, 420);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxVram;
        private System.Windows.Forms.Label labelVram;
        private System.Windows.Forms.TextBox textBoxTdp;
        private System.Windows.Forms.TextBox textBoxValutazione;
        private System.Windows.Forms.Label labelFrequenza;
        private System.Windows.Forms.Label labelValutazione;
        private System.Windows.Forms.Button buttonConferma;
        private System.Windows.Forms.Label labelTitolo;
    }
}
