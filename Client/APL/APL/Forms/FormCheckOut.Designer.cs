
namespace APL.Forms
{
    partial class FormCheckOut
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
            this.panelSfondo = new System.Windows.Forms.Panel();
            this.textBoxAnno = new System.Windows.Forms.TextBox();
            this.labelSplit = new System.Windows.Forms.Label();
            this.buttonConfermaCheckout = new System.Windows.Forms.Button();
            this.textBoxNumeroCarta = new System.Windows.Forms.TextBox();
            this.labelNumeroCarta = new System.Windows.Forms.Label();
            this.textBoxCVV = new System.Windows.Forms.TextBox();
            this.labelCVV = new System.Windows.Forms.Label();
            this.textBoxMese = new System.Windows.Forms.TextBox();
            this.labelDataScadenzaCarta = new System.Windows.Forms.Label();
            this.textBoxIndirizzoFatturazione = new System.Windows.Forms.TextBox();
            this.labelIndirizzoFatturazione = new System.Windows.Forms.Label();
            this.labelTitoloInfoCarta = new System.Windows.Forms.Label();
            this.labelTotale = new System.Windows.Forms.Label();
            this.labelTitolo = new System.Windows.Forms.Label();
            this.listViewCheckOut = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panelSfondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSfondo
            // 
            this.panelSfondo.Controls.Add(this.textBoxAnno);
            this.panelSfondo.Controls.Add(this.labelSplit);
            this.panelSfondo.Controls.Add(this.buttonConfermaCheckout);
            this.panelSfondo.Controls.Add(this.textBoxNumeroCarta);
            this.panelSfondo.Controls.Add(this.labelNumeroCarta);
            this.panelSfondo.Controls.Add(this.textBoxCVV);
            this.panelSfondo.Controls.Add(this.labelCVV);
            this.panelSfondo.Controls.Add(this.textBoxMese);
            this.panelSfondo.Controls.Add(this.labelDataScadenzaCarta);
            this.panelSfondo.Controls.Add(this.textBoxIndirizzoFatturazione);
            this.panelSfondo.Controls.Add(this.labelIndirizzoFatturazione);
            this.panelSfondo.Controls.Add(this.labelTitoloInfoCarta);
            this.panelSfondo.Controls.Add(this.labelTotale);
            this.panelSfondo.Controls.Add(this.labelTitolo);
            this.panelSfondo.Controls.Add(this.listViewCheckOut);
            this.panelSfondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSfondo.Location = new System.Drawing.Point(0, 0);
            this.panelSfondo.Name = "panelSfondo";
            this.panelSfondo.Size = new System.Drawing.Size(1077, 592);
            this.panelSfondo.TabIndex = 0;
            // 
            // textBoxAnno
            // 
            this.textBoxAnno.Location = new System.Drawing.Point(777, 220);
            this.textBoxAnno.MaxLength = 2;
            this.textBoxAnno.Name = "textBoxAnno";
            this.textBoxAnno.Size = new System.Drawing.Size(49, 27);
            this.textBoxAnno.TabIndex = 8;
            this.textBoxAnno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroCarta_KeyPress);
            // 
            // labelSplit
            // 
            this.labelSplit.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSplit.Location = new System.Drawing.Point(746, 209);
            this.labelSplit.Name = "labelSplit";
            this.labelSplit.Size = new System.Drawing.Size(25, 43);
            this.labelSplit.TabIndex = 14;
            this.labelSplit.Text = "/";
            // 
            // buttonConfermaCheckout
            // 
            this.buttonConfermaCheckout.Location = new System.Drawing.Point(691, 512);
            this.buttonConfermaCheckout.Name = "buttonConfermaCheckout";
            this.buttonConfermaCheckout.Size = new System.Drawing.Size(312, 68);
            this.buttonConfermaCheckout.TabIndex = 13;
            this.buttonConfermaCheckout.Text = "Conferma Acquisto";
            this.buttonConfermaCheckout.UseVisualStyleBackColor = true;
            this.buttonConfermaCheckout.Click += new System.EventHandler(this.buttonConfermaCheckout_Click);
            // 
            // textBoxNumeroCarta
            // 
            this.textBoxNumeroCarta.Location = new System.Drawing.Point(691, 307);
            this.textBoxNumeroCarta.MaxLength = 16;
            this.textBoxNumeroCarta.Name = "textBoxNumeroCarta";
            this.textBoxNumeroCarta.Size = new System.Drawing.Size(178, 27);
            this.textBoxNumeroCarta.TabIndex = 10;
            this.textBoxNumeroCarta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroCarta_KeyPress);
            // 
            // labelNumeroCarta
            // 
            this.labelNumeroCarta.AutoSize = true;
            this.labelNumeroCarta.Location = new System.Drawing.Point(691, 283);
            this.labelNumeroCarta.Name = "labelNumeroCarta";
            this.labelNumeroCarta.Size = new System.Drawing.Size(106, 20);
            this.labelNumeroCarta.TabIndex = 11;
            this.labelNumeroCarta.Text = "Numero  Carta";
            // 
            // textBoxCVV
            // 
            this.textBoxCVV.Location = new System.Drawing.Point(896, 220);
            this.textBoxCVV.MaxLength = 3;
            this.textBoxCVV.Name = "textBoxCVV";
            this.textBoxCVV.Size = new System.Drawing.Size(107, 27);
            this.textBoxCVV.TabIndex = 9;
            this.textBoxCVV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroCarta_KeyPress);
            // 
            // labelCVV
            // 
            this.labelCVV.AutoSize = true;
            this.labelCVV.Location = new System.Drawing.Point(906, 197);
            this.labelCVV.Name = "labelCVV";
            this.labelCVV.Size = new System.Drawing.Size(36, 20);
            this.labelCVV.TabIndex = 9;
            this.labelCVV.Text = "CVV";
            // 
            // textBoxMese
            // 
            this.textBoxMese.Location = new System.Drawing.Point(691, 220);
            this.textBoxMese.MaxLength = 2;
            this.textBoxMese.Name = "textBoxMese";
            this.textBoxMese.Size = new System.Drawing.Size(49, 27);
            this.textBoxMese.TabIndex = 7;
            this.textBoxMese.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumeroCarta_KeyPress);
            // 
            // labelDataScadenzaCarta
            // 
            this.labelDataScadenzaCarta.AutoSize = true;
            this.labelDataScadenzaCarta.Location = new System.Drawing.Point(691, 189);
            this.labelDataScadenzaCarta.Name = "labelDataScadenzaCarta";
            this.labelDataScadenzaCarta.Size = new System.Drawing.Size(147, 20);
            this.labelDataScadenzaCarta.TabIndex = 7;
            this.labelDataScadenzaCarta.Text = "Data Scadenza Carta";
            // 
            // textBoxIndirizzoFatturazione
            // 
            this.textBoxIndirizzoFatturazione.Location = new System.Drawing.Point(691, 133);
            this.textBoxIndirizzoFatturazione.Name = "textBoxIndirizzoFatturazione";
            this.textBoxIndirizzoFatturazione.Size = new System.Drawing.Size(313, 27);
            this.textBoxIndirizzoFatturazione.TabIndex = 6;
            // 
            // labelIndirizzoFatturazione
            // 
            this.labelIndirizzoFatturazione.AutoSize = true;
            this.labelIndirizzoFatturazione.Location = new System.Drawing.Point(691, 111);
            this.labelIndirizzoFatturazione.Name = "labelIndirizzoFatturazione";
            this.labelIndirizzoFatturazione.Size = new System.Drawing.Size(151, 20);
            this.labelIndirizzoFatturazione.TabIndex = 5;
            this.labelIndirizzoFatturazione.Text = "Indirizzo Fatturazione";
            // 
            // labelTitoloInfoCarta
            // 
            this.labelTitoloInfoCarta.AutoSize = true;
            this.labelTitoloInfoCarta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitoloInfoCarta.Location = new System.Drawing.Point(714, 48);
            this.labelTitoloInfoCarta.Name = "labelTitoloInfoCarta";
            this.labelTitoloInfoCarta.Size = new System.Drawing.Size(273, 28);
            this.labelTitoloInfoCarta.TabIndex = 4;
            this.labelTitoloInfoCarta.Text = "Inserisci Informazioni Carta";
            // 
            // labelTotale
            // 
            this.labelTotale.AutoSize = true;
            this.labelTotale.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTotale.Location = new System.Drawing.Point(29, 424);
            this.labelTotale.Name = "labelTotale";
            this.labelTotale.Size = new System.Drawing.Size(64, 25);
            this.labelTotale.TabIndex = 3;
            this.labelTotale.Text = "Totale";
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoEllipsis = true;
            this.labelTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTitolo.Location = new System.Drawing.Point(29, 11);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(297, 67);
            this.labelTitolo.TabIndex = 2;
            this.labelTitolo.Text = "CheckOut";
            // 
            // listViewCheckOut
            // 
            this.listViewCheckOut.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewCheckOut.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.listViewCheckOut.HideSelection = false;
            this.listViewCheckOut.Location = new System.Drawing.Point(29, 88);
            this.listViewCheckOut.Name = "listViewCheckOut";
            this.listViewCheckOut.Size = new System.Drawing.Size(609, 303);
            this.listViewCheckOut.TabIndex = 0;
            this.listViewCheckOut.UseCompatibleStateImageBehavior = false;
            this.listViewCheckOut.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Modello";
            this.columnHeader1.Width = 600;
            // 
            // FormCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 592);
            this.Controls.Add(this.panelSfondo);
            this.Name = "FormCheckOut";
            this.Load += new System.EventHandler(this.FormCheckOut_Load);
            this.panelSfondo.ResumeLayout(false);
            this.panelSfondo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSfondo;
        private System.Windows.Forms.ListView listViewCheckOut;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label labelTitolo;
        private System.Windows.Forms.Label labelTotale;
        private System.Windows.Forms.Label labelTitoloInfoCarta;
        private System.Windows.Forms.Label labelIndirizzoFatturazione;
        private System.Windows.Forms.TextBox textBoxIndirizzoFatturazione;
        private System.Windows.Forms.Label labelCVV;
        private System.Windows.Forms.TextBox textBoxMese;
        private System.Windows.Forms.Label labelDataScadenzaCarta;
        private System.Windows.Forms.TextBox textBoxCVV;
        private System.Windows.Forms.TextBox textBoxNumeroCarta;
        private System.Windows.Forms.Label labelNumeroCarta;
        private System.Windows.Forms.Button buttonConfermaCheckout;
        private System.Windows.Forms.Label labelSplit;
        private System.Windows.Forms.TextBox textBoxAnno;
    }
}
