﻿
namespace APL.Forms
{
    partial class FormCarrello
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
            this.buttonConferma = new System.Windows.Forms.Button();
            this.buttonRimuovi = new System.Windows.Forms.Button();
            this.listViewCarrello = new System.Windows.Forms.ListView();
            this.column1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.labelTitolo = new System.Windows.Forms.Label();
            this.column6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelSfondo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSfondo
            // 
            this.panelSfondo.Controls.Add(this.buttonConferma);
            this.panelSfondo.Controls.Add(this.buttonRimuovi);
            this.panelSfondo.Controls.Add(this.listViewCarrello);
            this.panelSfondo.Controls.Add(this.labelTitolo);
            this.panelSfondo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSfondo.Location = new System.Drawing.Point(0, 0);
            this.panelSfondo.Name = "panelSfondo";
            this.panelSfondo.Size = new System.Drawing.Size(885, 484);
            this.panelSfondo.TabIndex = 0;
            // 
            // buttonConferma
            // 
            this.buttonConferma.Location = new System.Drawing.Point(676, 134);
            this.buttonConferma.Name = "buttonConferma";
            this.buttonConferma.Size = new System.Drawing.Size(197, 44);
            this.buttonConferma.TabIndex = 12;
            this.buttonConferma.Text = "Conferma Carrello";
            this.buttonConferma.UseVisualStyleBackColor = true;
            this.buttonConferma.Click += new System.EventHandler(this.buttonConferma_Click);
            // 
            // buttonRimuovi
            // 
            this.buttonRimuovi.Location = new System.Drawing.Point(674, 69);
            this.buttonRimuovi.Name = "buttonRimuovi";
            this.buttonRimuovi.Size = new System.Drawing.Size(199, 46);
            this.buttonRimuovi.TabIndex = 11;
            this.buttonRimuovi.Text = "Rimuovi Elemento";
            this.buttonRimuovi.UseVisualStyleBackColor = true;
            this.buttonRimuovi.Click += new System.EventHandler(this.buttonRimuovi_Click);
            // 
            // listViewCarrello
            // 
            this.listViewCarrello.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column1,
            this.column2,
            this.column3,
            this.column4,
            this.column5,
            this.column6});
            this.listViewCarrello.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewCarrello.HideSelection = false;
            this.listViewCarrello.Location = new System.Drawing.Point(35, 66);
            this.listViewCarrello.Name = "listViewCarrello";
            this.listViewCarrello.Size = new System.Drawing.Size(626, 406);
            this.listViewCarrello.TabIndex = 10;
            this.listViewCarrello.UseCompatibleStateImageBehavior = false;
            this.listViewCarrello.View = System.Windows.Forms.View.Details;
            // 
            // column1
            // 
            this.column1.Text = "Modello";
            this.column1.Width = 110;
            // 
            // column2
            // 
            this.column2.Text = "Marca";
            this.column2.Width = 110;
            // 
            // column3
            // 
            this.column3.Text = "Prezzo";
            this.column3.Width = 110;
            // 
            // column4
            // 
            this.column4.Text = "Capienza";
            this.column4.Width = 110;
            // 
            // column5
            // 
            this.column5.Text = "Categoria";
            this.column5.Width = 110;
            // 
            // labelTitolo
            // 
            this.labelTitolo.AutoEllipsis = true;
            this.labelTitolo.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitolo.Location = new System.Drawing.Point(27, 10);
            this.labelTitolo.Name = "labelTitolo";
            this.labelTitolo.Size = new System.Drawing.Size(297, 53);
            this.labelTitolo.TabIndex = 1;
            this.labelTitolo.Text = "Carrello";
            // 
            // column6
            // 
            this.column6.Text = "Tipo";
            this.column6.Width = 110;
            // 
            // FormCarrello
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 484);
            this.Controls.Add(this.panelSfondo);
            this.Name = "FormCarrello";
            this.panelSfondo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSfondo;
        private System.Windows.Forms.Label labelTitolo;
        private System.Windows.Forms.ListView listViewCarrello;
        private System.Windows.Forms.ColumnHeader column1;
        private System.Windows.Forms.ColumnHeader column2;
        private System.Windows.Forms.ColumnHeader column3;
        private System.Windows.Forms.ColumnHeader column4;
        private System.Windows.Forms.ColumnHeader column5;
        private System.Windows.Forms.Button buttonRimuovi;
        private System.Windows.Forms.Button buttonConferma;
        private System.Windows.Forms.ColumnHeader column6;
    }
}