
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
            this.textBoxWatt = new System.Windows.Forms.TextBox();
            this.textBoxValutazione = new System.Windows.Forms.TextBox();
            this.textBoxModello = new System.Windows.Forms.TextBox();
            this.labelWatt = new System.Windows.Forms.Label();
            this.labelValutazione = new System.Windows.Forms.Label();
            this.labelModello = new System.Windows.Forms.Label();
            this.labelTitolo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxWatt);
            this.panel1.Controls.Add(this.textBoxValutazione);
            this.panel1.Controls.Add(this.textBoxModello);
            this.panel1.Controls.Add(this.labelWatt);
            this.panel1.Controls.Add(this.labelValutazione);
            this.panel1.Controls.Add(this.labelModello);
            this.panel1.Controls.Add(this.labelTitolo);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(526, 420);
            this.panel1.TabIndex = 0;
            // 
            // textBoxWatt
            // 
            this.textBoxWatt.Location = new System.Drawing.Point(107, 211);
            this.textBoxWatt.Name = "textBoxWatt";
            this.textBoxWatt.Size = new System.Drawing.Size(348, 27);
            this.textBoxWatt.TabIndex = 8;
            // 
            // textBoxValutazione
            // 
            this.textBoxValutazione.Location = new System.Drawing.Point(107, 141);
            this.textBoxValutazione.Name = "textBoxValutazione";
            this.textBoxValutazione.Size = new System.Drawing.Size(348, 27);
            this.textBoxValutazione.TabIndex = 7;
            // 
            // textBoxModello
            // 
            this.textBoxModello.Location = new System.Drawing.Point(107, 73);
            this.textBoxModello.Name = "textBoxModello";
            this.textBoxModello.Size = new System.Drawing.Size(348, 27);
            this.textBoxModello.TabIndex = 6;
            // 
            // labelWatt
            // 
            this.labelWatt.AutoSize = true;
            this.labelWatt.Location = new System.Drawing.Point(40, 211);
            this.labelWatt.Name = "labelWatt";
            this.labelWatt.Size = new System.Drawing.Size(40, 20);
            this.labelWatt.TabIndex = 5;
            this.labelWatt.Text = "Watt";
            // 
            // labelValutazione
            // 
            this.labelValutazione.AutoSize = true;
            this.labelValutazione.Location = new System.Drawing.Point(15, 141);
            this.labelValutazione.Name = "labelValutazione";
            this.labelValutazione.Size = new System.Drawing.Size(86, 20);
            this.labelValutazione.TabIndex = 4;
            this.labelValutazione.Text = "Valutazione";
            // 
            // labelModello
            // 
            this.labelModello.AutoSize = true;
            this.labelModello.Location = new System.Drawing.Point(15, 73);
            this.labelModello.Name = "labelModello";
            this.labelModello.Size = new System.Drawing.Size(65, 20);
            this.labelModello.TabIndex = 3;
            this.labelModello.Text = "Modello";
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoEllipsis = true;
            this.labelTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitolo.Location = new System.Drawing.Point(3, 0);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(520, 47);
            this.labelTitolo.TabIndex = 2;
            this.labelTitolo.Text = "Alimentatore";
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
        private System.Windows.Forms.Label labelModello;
        private System.Windows.Forms.Label labelWatt;
        private System.Windows.Forms.TextBox textBoxWatt;
        private System.Windows.Forms.TextBox textBoxValutazione;
        private System.Windows.Forms.TextBox textBoxModello;
    }
}
