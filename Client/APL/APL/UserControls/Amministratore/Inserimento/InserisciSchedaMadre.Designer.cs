
namespace APL.UserControls.Amministratore.Inserimento
{
    partial class InserisciSchedaMadre
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
            this.textBoxChipset = new System.Windows.Forms.TextBox();
            this.labelChipset = new System.Windows.Forms.Label();
            this.textBoxRam = new System.Windows.Forms.TextBox();
            this.labelRam = new System.Windows.Forms.Label();
            this.textBoxCpuSocket = new System.Windows.Forms.TextBox();
            this.textBoxValutazione = new System.Windows.Forms.TextBox();
            this.labelCpuSocket = new System.Windows.Forms.Label();
            this.labelValutazione = new System.Windows.Forms.Label();
            this.buttonConferma = new System.Windows.Forms.Button();
            this.labelTitolo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxChipset);
            this.panel1.Controls.Add(this.labelChipset);
            this.panel1.Controls.Add(this.textBoxRam);
            this.panel1.Controls.Add(this.labelRam);
            this.panel1.Controls.Add(this.textBoxCpuSocket);
            this.panel1.Controls.Add(this.textBoxValutazione);
            this.panel1.Controls.Add(this.labelCpuSocket);
            this.panel1.Controls.Add(this.labelValutazione);
            this.panel1.Controls.Add(this.buttonConferma);
            this.panel1.Controls.Add(this.labelTitolo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 420);
            this.panel1.TabIndex = 0;
            // 
            // textBoxChipset
            // 
            this.textBoxChipset.Location = new System.Drawing.Point(121, 259);
            this.textBoxChipset.Name = "textBoxChipset";
            this.textBoxChipset.Size = new System.Drawing.Size(348, 27);
            this.textBoxChipset.TabIndex = 28;
            // 
            // labelChipset
            // 
            this.labelChipset.AutoSize = true;
            this.labelChipset.Location = new System.Drawing.Point(57, 262);
            this.labelChipset.Name = "labelChipset";
            this.labelChipset.Size = new System.Drawing.Size(58, 20);
            this.labelChipset.TabIndex = 27;
            this.labelChipset.Text = "Chipset";
            // 
            // textBoxRam
            // 
            this.textBoxRam.Location = new System.Drawing.Point(121, 195);
            this.textBoxRam.Name = "textBoxRam";
            this.textBoxRam.Size = new System.Drawing.Size(348, 27);
            this.textBoxRam.TabIndex = 26;
            // 
            // labelRam
            // 
            this.labelRam.AutoSize = true;
            this.labelRam.Location = new System.Drawing.Point(67, 198);
            this.labelRam.Name = "labelRam";
            this.labelRam.Size = new System.Drawing.Size(39, 20);
            this.labelRam.TabIndex = 25;
            this.labelRam.Text = "Ram";
            // 
            // textBoxCpuSocket
            // 
            this.textBoxCpuSocket.Location = new System.Drawing.Point(121, 134);
            this.textBoxCpuSocket.Name = "textBoxCpuSocket";
            this.textBoxCpuSocket.Size = new System.Drawing.Size(348, 27);
            this.textBoxCpuSocket.TabIndex = 24;
            // 
            // textBoxValutazione
            // 
            this.textBoxValutazione.Location = new System.Drawing.Point(121, 72);
            this.textBoxValutazione.Name = "textBoxValutazione";
            this.textBoxValutazione.Size = new System.Drawing.Size(348, 27);
            this.textBoxValutazione.TabIndex = 23;
            // 
            // labelCpuSocket
            // 
            this.labelCpuSocket.AutoSize = true;
            this.labelCpuSocket.Location = new System.Drawing.Point(32, 137);
            this.labelCpuSocket.Name = "labelCpuSocket";
            this.labelCpuSocket.Size = new System.Drawing.Size(83, 20);
            this.labelCpuSocket.TabIndex = 22;
            this.labelCpuSocket.Text = "Cpu Socket";
            // 
            // labelValutazione
            // 
            this.labelValutazione.AutoSize = true;
            this.labelValutazione.Location = new System.Drawing.Point(29, 75);
            this.labelValutazione.Name = "labelValutazione";
            this.labelValutazione.Size = new System.Drawing.Size(86, 20);
            this.labelValutazione.TabIndex = 21;
            this.labelValutazione.Text = "Valutazione";
            // 
            // buttonConferma
            // 
            this.buttonConferma.Location = new System.Drawing.Point(280, 6);
            this.buttonConferma.Name = "buttonConferma";
            this.buttonConferma.Size = new System.Drawing.Size(238, 41);
            this.buttonConferma.TabIndex = 20;
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
            this.labelTitolo.TabIndex = 19;
            this.labelTitolo.Text = "Scheda Madre";
            this.labelTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InserisciSchedaMadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InserisciSchedaMadre";
            this.Size = new System.Drawing.Size(526, 420);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxChipset;
        private System.Windows.Forms.Label labelChipset;
        private System.Windows.Forms.TextBox textBoxRam;
        private System.Windows.Forms.Label labelRam;
        private System.Windows.Forms.TextBox textBoxCpuSocket;
        private System.Windows.Forms.TextBox textBoxValutazione;
        private System.Windows.Forms.Label labelCpuSocket;
        private System.Windows.Forms.Label labelValutazione;
        private System.Windows.Forms.Button buttonConferma;
        private System.Windows.Forms.Label labelTitolo;
    }
}
