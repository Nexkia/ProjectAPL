
namespace APL.UserControls.Amministratore.Inserimento
{
    partial class InserisciCpu
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
            this.textBoxThread = new System.Windows.Forms.TextBox();
            this.labelThread = new System.Windows.Forms.Label();
            this.textBoxCore = new System.Windows.Forms.TextBox();
            this.labelCore = new System.Windows.Forms.Label();
            this.textBoxSocket = new System.Windows.Forms.TextBox();
            this.labelSocket = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.textBoxThread);
            this.panel1.Controls.Add(this.labelThread);
            this.panel1.Controls.Add(this.textBoxCore);
            this.panel1.Controls.Add(this.labelCore);
            this.panel1.Controls.Add(this.textBoxSocket);
            this.panel1.Controls.Add(this.labelSocket);
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
            // textBoxThread
            // 
            this.textBoxThread.Location = new System.Drawing.Point(121, 335);
            this.textBoxThread.Name = "textBoxThread";
            this.textBoxThread.Size = new System.Drawing.Size(348, 27);
            this.textBoxThread.TabIndex = 20;
            this.textBoxThread.TextChanged += new System.EventHandler(this.textBoxCore_TextChanged);
            this.textBoxThread.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValutazione_KeyPress);
            // 
            // labelThread
            // 
            this.labelThread.AutoSize = true;
            this.labelThread.Location = new System.Drawing.Point(60, 338);
            this.labelThread.Name = "labelThread";
            this.labelThread.Size = new System.Drawing.Size(55, 20);
            this.labelThread.TabIndex = 19;
            this.labelThread.Text = "Thread";
            // 
            // textBoxCore
            // 
            this.textBoxCore.Location = new System.Drawing.Point(121, 261);
            this.textBoxCore.Name = "textBoxCore";
            this.textBoxCore.Size = new System.Drawing.Size(348, 27);
            this.textBoxCore.TabIndex = 18;
            this.textBoxCore.TextChanged += new System.EventHandler(this.textBoxCore_TextChanged);
            this.textBoxCore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValutazione_KeyPress);
            // 
            // labelCore
            // 
            this.labelCore.AutoSize = true;
            this.labelCore.Location = new System.Drawing.Point(75, 264);
            this.labelCore.Name = "labelCore";
            this.labelCore.Size = new System.Drawing.Size(40, 20);
            this.labelCore.TabIndex = 17;
            this.labelCore.Text = "Core";
            // 
            // textBoxSocket
            // 
            this.textBoxSocket.Location = new System.Drawing.Point(121, 197);
            this.textBoxSocket.Name = "textBoxSocket";
            this.textBoxSocket.Size = new System.Drawing.Size(348, 27);
            this.textBoxSocket.TabIndex = 16;
            // 
            // labelSocket
            // 
            this.labelSocket.AutoSize = true;
            this.labelSocket.Location = new System.Drawing.Point(62, 200);
            this.labelSocket.Name = "labelSocket";
            this.labelSocket.Size = new System.Drawing.Size(53, 20);
            this.labelSocket.TabIndex = 15;
            this.labelSocket.Text = "Socket";
            // 
            // textBoxFrequenza
            // 
            this.textBoxFrequenza.Location = new System.Drawing.Point(121, 136);
            this.textBoxFrequenza.Name = "textBoxFrequenza";
            this.textBoxFrequenza.Size = new System.Drawing.Size(348, 27);
            this.textBoxFrequenza.TabIndex = 14;
            this.textBoxFrequenza.TextChanged += new System.EventHandler(this.textBoxFrequenza_TextChanged);
            // 
            // textBoxValutazione
            // 
            this.textBoxValutazione.Location = new System.Drawing.Point(121, 74);
            this.textBoxValutazione.MaxLength = 2;
            this.textBoxValutazione.Name = "textBoxValutazione";
            this.textBoxValutazione.Size = new System.Drawing.Size(348, 27);
            this.textBoxValutazione.TabIndex = 13;
            this.textBoxValutazione.TextChanged += new System.EventHandler(this.textBoxValutazione_TextChanged);
            this.textBoxValutazione.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValutazione_KeyPress);
            // 
            // labelFrequenza
            // 
            this.labelFrequenza.AutoSize = true;
            this.labelFrequenza.Location = new System.Drawing.Point(38, 139);
            this.labelFrequenza.Name = "labelFrequenza";
            this.labelFrequenza.Size = new System.Drawing.Size(77, 20);
            this.labelFrequenza.TabIndex = 12;
            this.labelFrequenza.Text = "Frequenza";
            // 
            // labelValutazione
            // 
            this.labelValutazione.AutoSize = true;
            this.labelValutazione.Location = new System.Drawing.Point(29, 77);
            this.labelValutazione.Name = "labelValutazione";
            this.labelValutazione.Size = new System.Drawing.Size(86, 20);
            this.labelValutazione.TabIndex = 11;
            this.labelValutazione.Text = "Valutazione";
            // 
            // buttonConferma
            // 
            this.buttonConferma.Location = new System.Drawing.Point(280, 8);
            this.buttonConferma.Name = "buttonConferma";
            this.buttonConferma.Size = new System.Drawing.Size(238, 41);
            this.buttonConferma.TabIndex = 10;
            this.buttonConferma.Text = "Conferma";
            this.buttonConferma.UseVisualStyleBackColor = true;
            this.buttonConferma.Click += new System.EventHandler(this.buttonConferma_Click);
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoEllipsis = true;
            this.labelTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitolo.Location = new System.Drawing.Point(3, 2);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(271, 47);
            this.labelTitolo.TabIndex = 3;
            this.labelTitolo.Text = "Cpu";
            this.labelTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InserisciCpu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InserisciCpu";
            this.Size = new System.Drawing.Size(526, 420);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitolo;
        private System.Windows.Forms.Button buttonConferma;
        private System.Windows.Forms.TextBox textBoxSocket;
        private System.Windows.Forms.Label labelSocket;
        private System.Windows.Forms.TextBox textBoxFrequenza;
        private System.Windows.Forms.TextBox textBoxValutazione;
        private System.Windows.Forms.Label labelFrequenza;
        private System.Windows.Forms.Label labelValutazione;
        private System.Windows.Forms.TextBox textBoxThread;
        private System.Windows.Forms.Label labelThread;
        private System.Windows.Forms.TextBox textBoxCore;
        private System.Windows.Forms.Label labelCore;
    }
}
