
using System;

namespace APL.UserControls.Amministratore.Inserimento
{
    partial class InserisciDissipatore
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
            this.buttonRimuoviCpuSocket = new System.Windows.Forms.Button();
            this.labelAggiungiCpuSocket = new System.Windows.Forms.Label();
            this.buttonAggiungiCpuSocket = new System.Windows.Forms.Button();
            this.textBoxAggiungiCpuSocket = new System.Windows.Forms.TextBox();
            this.buttonConferma = new System.Windows.Forms.Button();
            this.textBoxCpuSocket = new System.Windows.Forms.TextBox();
            this.textBoxValutazione = new System.Windows.Forms.TextBox();
            this.labelWatt = new System.Windows.Forms.Label();
            this.labelValutazione = new System.Windows.Forms.Label();
            this.labelTitolo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRimuoviCpuSocket);
            this.panel1.Controls.Add(this.labelAggiungiCpuSocket);
            this.panel1.Controls.Add(this.buttonAggiungiCpuSocket);
            this.panel1.Controls.Add(this.textBoxAggiungiCpuSocket);
            this.panel1.Controls.Add(this.buttonConferma);
            this.panel1.Controls.Add(this.textBoxCpuSocket);
            this.panel1.Controls.Add(this.textBoxValutazione);
            this.panel1.Controls.Add(this.labelWatt);
            this.panel1.Controls.Add(this.labelValutazione);
            this.panel1.Controls.Add(this.labelTitolo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 420);
            this.panel1.TabIndex = 0;
            // 
            // buttonRimuoviCpuSocket
            // 
            this.buttonRimuoviCpuSocket.Location = new System.Drawing.Point(184, 350);
            this.buttonRimuoviCpuSocket.Name = "buttonRimuoviCpuSocket";
            this.buttonRimuoviCpuSocket.Size = new System.Drawing.Size(202, 48);
            this.buttonRimuoviCpuSocket.TabIndex = 19;
            this.buttonRimuoviCpuSocket.Text = "Rimuovi Cpu Socket";
            this.buttonRimuoviCpuSocket.UseVisualStyleBackColor = true;
            this.buttonRimuoviCpuSocket.Click += new System.EventHandler(this.buttonRimuoviCpuSocket_Click);
            // 
            // labelAggiungiCpuSocket
            // 
            this.labelAggiungiCpuSocket.AutoSize = true;
            this.labelAggiungiCpuSocket.Location = new System.Drawing.Point(169, 220);
            this.labelAggiungiCpuSocket.Name = "labelAggiungiCpuSocket";
            this.labelAggiungiCpuSocket.Size = new System.Drawing.Size(232, 20);
            this.labelAggiungiCpuSocket.TabIndex = 18;
            this.labelAggiungiCpuSocket.Text = "Inserisci una Cpu Socket alla volta";
            // 
            // buttonAggiungiCpuSocket
            // 
            this.buttonAggiungiCpuSocket.Location = new System.Drawing.Point(184, 276);
            this.buttonAggiungiCpuSocket.Name = "buttonAggiungiCpuSocket";
            this.buttonAggiungiCpuSocket.Size = new System.Drawing.Size(202, 48);
            this.buttonAggiungiCpuSocket.TabIndex = 17;
            this.buttonAggiungiCpuSocket.Text = "Aggiungi Cpu Socket";
            this.buttonAggiungiCpuSocket.UseVisualStyleBackColor = true;
            this.buttonAggiungiCpuSocket.Click += new System.EventHandler(this.buttonAggiungiCpuSocket_Click);
            // 
            // textBoxAggiungiCpuSocket
            // 
            this.textBoxAggiungiCpuSocket.Location = new System.Drawing.Point(107, 243);
            this.textBoxAggiungiCpuSocket.Name = "textBoxAggiungiCpuSocket";
            this.textBoxAggiungiCpuSocket.Size = new System.Drawing.Size(348, 27);
            this.textBoxAggiungiCpuSocket.TabIndex = 16;
            // 
            // buttonConferma
            // 
            this.buttonConferma.Location = new System.Drawing.Point(280, 3);
            this.buttonConferma.Name = "buttonConferma";
            this.buttonConferma.Size = new System.Drawing.Size(238, 41);
            this.buttonConferma.TabIndex = 15;
            this.buttonConferma.Text = "Conferma";
            this.buttonConferma.UseVisualStyleBackColor = true;
            this.buttonConferma.Click += new System.EventHandler(this.buttonConferma_Click);
            // 
            // textBoxCpuSocket
            // 
            this.textBoxCpuSocket.Location = new System.Drawing.Point(107, 128);
            this.textBoxCpuSocket.Multiline = true;
            this.textBoxCpuSocket.Name = "textBoxCpuSocket";
            this.textBoxCpuSocket.ReadOnly = true;
            this.textBoxCpuSocket.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBoxCpuSocket.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCpuSocket.Size = new System.Drawing.Size(348, 78);
            this.textBoxCpuSocket.TabIndex = 14;
            // 
            // textBoxValutazione
            // 
            this.textBoxValutazione.Location = new System.Drawing.Point(107, 77);
            this.textBoxValutazione.MaxLength = 2;
            this.textBoxValutazione.Name = "textBoxValutazione";
            this.textBoxValutazione.Size = new System.Drawing.Size(348, 27);
            this.textBoxValutazione.TabIndex = 13;
            this.textBoxValutazione.TextChanged += new System.EventHandler(this.textBoxValutazione_TextChanged);
            this.textBoxValutazione.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxValutazione_KeyPress);
            // 
            // labelWatt
            // 
            this.labelWatt.AutoSize = true;
            this.labelWatt.Location = new System.Drawing.Point(18, 131);
            this.labelWatt.Name = "labelWatt";
            this.labelWatt.Size = new System.Drawing.Size(83, 20);
            this.labelWatt.TabIndex = 12;
            this.labelWatt.Text = "Cpu Socket";
            // 
            // labelValutazione
            // 
            this.labelValutazione.AutoSize = true;
            this.labelValutazione.Location = new System.Drawing.Point(15, 80);
            this.labelValutazione.Name = "labelValutazione";
            this.labelValutazione.Size = new System.Drawing.Size(86, 20);
            this.labelValutazione.TabIndex = 11;
            this.labelValutazione.Text = "Valutazione";
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoEllipsis = true;
            this.labelTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitolo.Location = new System.Drawing.Point(3, 0);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(271, 47);
            this.labelTitolo.TabIndex = 10;
            this.labelTitolo.Text = "Dissipatore";
            this.labelTitolo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InserisciDissipatore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "InserisciDissipatore";
            this.Size = new System.Drawing.Size(526, 420);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonConferma;
        private System.Windows.Forms.TextBox textBoxCpuSocket;
        private System.Windows.Forms.TextBox textBoxValutazione;
        private System.Windows.Forms.Label labelWatt;
        private System.Windows.Forms.Label labelValutazione;
        private System.Windows.Forms.Label labelTitolo;
        private System.Windows.Forms.TextBox textBoxAggiungiCpuSocket;
        private System.Windows.Forms.Button buttonAggiungiCpuSocket;
        private System.Windows.Forms.Label labelAggiungiCpuSocket;
        private System.Windows.Forms.Button buttonRimuoviCpuSocket;
    }
}
