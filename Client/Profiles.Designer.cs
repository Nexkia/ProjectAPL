
using System.Drawing;

namespace Client
{
    partial class Profiles
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
            this.label1Prototypes = new System.Windows.Forms.Label();
            this.label2Prototypes = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3Prototypes = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1Prototypes
            // 
            this.label1Prototypes.AutoEllipsis = true;
            this.label1Prototypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Prototypes.Location = new System.Drawing.Point(9, 13);
            this.label1Prototypes.Name = "label1Prototypes";
            this.label1Prototypes.Size = new System.Drawing.Size(365, 61);
            this.label1Prototypes.TabIndex = 0;
            this.label1Prototypes.Text = "titolo";
            this.label1Prototypes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1Prototypes.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2Prototypes
            // 
            this.label2Prototypes.AutoEllipsis = true;
            this.label2Prototypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2Prototypes.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2Prototypes.Location = new System.Drawing.Point(3, 13);
            this.label2Prototypes.Name = "label2Prototypes";
            this.label2Prototypes.Size = new System.Drawing.Size(359, 61);
            this.label2Prototypes.TabIndex = 1;
            this.label2Prototypes.Text = "qui va il testo";
            this.label2Prototypes.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.label1Prototypes);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 85);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.BurlyWood;
            this.panel2.Controls.Add(this.label2Prototypes);
            this.panel2.Location = new System.Drawing.Point(380, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(380, 85);
            this.panel2.TabIndex = 3;
            // 
            // label3Prototypes
            // 
            this.label3Prototypes.AutoEllipsis = true;
            this.label3Prototypes.BackColor = System.Drawing.Color.Transparent;
            this.label3Prototypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3Prototypes.Location = new System.Drawing.Point(4, 88);
            this.label3Prototypes.Name = "label3Prototypes";
            this.label3Prototypes.Size = new System.Drawing.Size(744, 198);
            this.label3Prototypes.TabIndex = 4;
            this.label3Prototypes.Text = "descrizione";
            this.label3Prototypes.Click += new System.EventHandler(this.lbl_MessageClick1);
            this.label3Prototypes.MouseEnter += new System.EventHandler(this.lblMessage_MouseEnter);
            this.label3Prototypes.MouseLeave += new System.EventHandler(this.lblMessage_MouseLeave);
            // 
            // Profiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3Prototypes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Profiles";
            this.Size = new System.Drawing.Size(751, 297);
            this.Load += new System.EventHandler(this.prototypes_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1Prototypes;
        private System.Windows.Forms.Label label2Prototypes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3Prototypes;
    }
}
