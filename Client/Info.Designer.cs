
namespace Client
{
    partial class Info
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
            this.label1info = new System.Windows.Forms.Label();
            this.label2info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1info
            // 
            this.label1info.AutoEllipsis = true;
            this.label1info.AutoSize = true;
            this.label1info.BackColor = System.Drawing.Color.Transparent;
            this.label1info.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1info.ForeColor = System.Drawing.Color.White;
            this.label1info.Location = new System.Drawing.Point(3, 0);
            this.label1info.Name = "label1info";
            this.label1info.Size = new System.Drawing.Size(130, 32);
            this.label1info.TabIndex = 0;
            this.label1info.Text = "nome pc";
            this.label1info.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1info.Click += new System.EventHandler(this.label1info_Click);
            // 
            // label2info
            // 
            this.label2info.AutoEllipsis = true;
            this.label2info.AutoSize = true;
            this.label2info.BackColor = System.Drawing.Color.White;
            this.label2info.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2info.Location = new System.Drawing.Point(4, 35);
            this.label2info.Name = "label2info";
            this.label2info.Size = new System.Drawing.Size(132, 29);
            this.label2info.TabIndex = 1;
            this.label2info.Text = "messaggio";
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.label2info);
            this.Controls.Add(this.label1info);
            this.Name = "Info";
            this.Size = new System.Drawing.Size(365, 612);
            this.Load += new System.EventHandler(this.Info_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1info;
        private System.Windows.Forms.Label label2info;
    }
}
