
namespace APL.Forms
{
    partial class FormCatalogo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cpuButton = new System.Windows.Forms.Button();
            this.schedaMadreButton = new System.Windows.Forms.Button();
            this.ramButton = new System.Windows.Forms.Button();
            this.memoriaButton = new System.Windows.Forms.Button();
            this.alimentatoreButton = new System.Windows.Forms.Button();
            this.schedaVideoButton = new System.Windows.Forms.Button();
            this.casepcButton = new System.Windows.Forms.Button();
            this.dissipatoreButton = new System.Windows.Forms.Button();
            this.buttonAggiungi = new System.Windows.Forms.Button();
            this.listView_record = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.listViewCatalogo = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.buttonRimuovi = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cpuButton
            // 
            this.cpuButton.Location = new System.Drawing.Point(964, 466);
            this.cpuButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cpuButton.Name = "cpuButton";
            this.cpuButton.Size = new System.Drawing.Size(151, 49);
            this.cpuButton.TabIndex = 0;
            this.cpuButton.Text = "cpu";
            this.cpuButton.UseVisualStyleBackColor = true;
            this.cpuButton.Click += new System.EventHandler(this.cpu_Click);
            // 
            // schedaMadreButton
            // 
            this.schedaMadreButton.Location = new System.Drawing.Point(964, 169);
            this.schedaMadreButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.schedaMadreButton.Name = "schedaMadreButton";
            this.schedaMadreButton.Size = new System.Drawing.Size(151, 49);
            this.schedaMadreButton.TabIndex = 1;
            this.schedaMadreButton.Text = "schedaMadre";
            this.schedaMadreButton.UseVisualStyleBackColor = true;
            this.schedaMadreButton.Click += new System.EventHandler(this.schedaMadre_Click);
            // 
            // ramButton
            // 
            this.ramButton.Location = new System.Drawing.Point(964, 241);
            this.ramButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ramButton.Name = "ramButton";
            this.ramButton.Size = new System.Drawing.Size(151, 49);
            this.ramButton.TabIndex = 2;
            this.ramButton.Text = "ram";
            this.ramButton.UseVisualStyleBackColor = true;
            this.ramButton.Click += new System.EventHandler(this.ram_Click);
            // 
            // memoriaButton
            // 
            this.memoriaButton.Location = new System.Drawing.Point(964, 92);
            this.memoriaButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.memoriaButton.Name = "memoriaButton";
            this.memoriaButton.Size = new System.Drawing.Size(151, 49);
            this.memoriaButton.TabIndex = 3;
            this.memoriaButton.Text = "memoria";
            this.memoriaButton.UseVisualStyleBackColor = true;
            this.memoriaButton.Click += new System.EventHandler(this.memoria_Click);
            // 
            // alimentatoreButton
            // 
            this.alimentatoreButton.Location = new System.Drawing.Point(964, 550);
            this.alimentatoreButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.alimentatoreButton.Name = "alimentatoreButton";
            this.alimentatoreButton.Size = new System.Drawing.Size(151, 49);
            this.alimentatoreButton.TabIndex = 4;
            this.alimentatoreButton.Text = "alimentatore";
            this.alimentatoreButton.UseVisualStyleBackColor = true;
            this.alimentatoreButton.Click += new System.EventHandler(this.alimentatore_Click);
            // 
            // schedaVideoButton
            // 
            this.schedaVideoButton.Location = new System.Drawing.Point(964, 315);
            this.schedaVideoButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.schedaVideoButton.Name = "schedaVideoButton";
            this.schedaVideoButton.Size = new System.Drawing.Size(151, 49);
            this.schedaVideoButton.TabIndex = 5;
            this.schedaVideoButton.Text = "schedaVideo";
            this.schedaVideoButton.UseVisualStyleBackColor = true;
            this.schedaVideoButton.Click += new System.EventHandler(this.schedaVideo_Click);
            // 
            // casepcButton
            // 
            this.casepcButton.Location = new System.Drawing.Point(964, 390);
            this.casepcButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.casepcButton.Name = "casepcButton";
            this.casepcButton.Size = new System.Drawing.Size(151, 49);
            this.casepcButton.TabIndex = 6;
            this.casepcButton.Text = "casepc";
            this.casepcButton.UseVisualStyleBackColor = true;
            this.casepcButton.Click += new System.EventHandler(this.casepc_Click);
            // 
            // dissipatoreButton
            // 
            this.dissipatoreButton.Location = new System.Drawing.Point(964, 16);
            this.dissipatoreButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dissipatoreButton.Name = "dissipatoreButton";
            this.dissipatoreButton.Size = new System.Drawing.Size(151, 49);
            this.dissipatoreButton.TabIndex = 7;
            this.dissipatoreButton.Text = "dissipatore";
            this.dissipatoreButton.UseVisualStyleBackColor = true;
            this.dissipatoreButton.Click += new System.EventHandler(this.dissipatore_Click);
            // 
            // buttonAggiungi
            // 
            this.buttonAggiungi.Location = new System.Drawing.Point(642, 701);
            this.buttonAggiungi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonAggiungi.Name = "buttonAggiungi";
            this.buttonAggiungi.Size = new System.Drawing.Size(151, 56);
            this.buttonAggiungi.TabIndex = 10;
            this.buttonAggiungi.Text = "Aggiungi";
            this.buttonAggiungi.UseVisualStyleBackColor = true;
            this.buttonAggiungi.Click += new System.EventHandler(this.buttonAggiungi_Click);
            // 
            // listView_record
            // 
            this.listView_record.BackColor = System.Drawing.SystemColors.HighlightText;
            this.listView_record.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView_record.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView_record.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.listView_record.HideSelection = false;
            this.listView_record.Location = new System.Drawing.Point(12, 13);
            this.listView_record.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView_record.Name = "listView_record";
            this.listView_record.Size = new System.Drawing.Size(945, 586);
            this.listView_record.TabIndex = 12;
            this.listView_record.UseCompatibleStateImageBehavior = false;
            this.listView_record.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Modello";
            this.columnHeader1.Width = 230;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Categoria";
            this.columnHeader2.Width = 230;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Marca";
            this.columnHeader3.Width = 230;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Prezzo";
            this.columnHeader4.Width = 230;
            // 
            // listViewCatalogo
            // 
            this.listViewCatalogo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewCatalogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listViewCatalogo.HideSelection = false;
            this.listViewCatalogo.Location = new System.Drawing.Point(12, 642);
            this.listViewCatalogo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listViewCatalogo.Name = "listViewCatalogo";
            this.listViewCatalogo.Size = new System.Drawing.Size(608, 258);
            this.listViewCatalogo.TabIndex = 13;
            this.listViewCatalogo.UseCompatibleStateImageBehavior = false;
            this.listViewCatalogo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Modello";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Categoria";
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Marca";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Prezzo";
            this.columnHeader8.Width = 150;
            // 
            // buttonRimuovi
            // 
            this.buttonRimuovi.Location = new System.Drawing.Point(806, 701);
            this.buttonRimuovi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonRimuovi.Name = "buttonRimuovi";
            this.buttonRimuovi.Size = new System.Drawing.Size(151, 56);
            this.buttonRimuovi.TabIndex = 14;
            this.buttonRimuovi.Text = "Rimuovi";
            this.buttonRimuovi.UseVisualStyleBackColor = true;
            this.buttonRimuovi.Click += new System.EventHandler(this.buttonRimuovi_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(642, 780);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(315, 120);
            this.button1.TabIndex = 15;
            this.button1.Text = "Confronta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonConfronta_Click);
            // 
            // FormCatalogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 905);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRimuovi);
            this.Controls.Add(this.listViewCatalogo);
            this.Controls.Add(this.listView_record);
            this.Controls.Add(this.buttonAggiungi);
            this.Controls.Add(this.dissipatoreButton);
            this.Controls.Add(this.casepcButton);
            this.Controls.Add(this.schedaVideoButton);
            this.Controls.Add(this.alimentatoreButton);
            this.Controls.Add(this.memoriaButton);
            this.Controls.Add(this.ramButton);
            this.Controls.Add(this.schedaMadreButton);
            this.Controls.Add(this.cpuButton);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormCatalogo";
            this.Text = "FormCatalog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cpuButton;
        private System.Windows.Forms.Button schedaMadreButton;
        private System.Windows.Forms.Button ramButton;
        private System.Windows.Forms.Button memoriaButton;
        private System.Windows.Forms.Button alimentatoreButton;
        private System.Windows.Forms.Button schedaVideoButton;
        private System.Windows.Forms.Button casepcButton;
        private System.Windows.Forms.Button dissipatoreButton;
        private System.Windows.Forms.Button buttonAggiungi;
        private System.Windows.Forms.ListView listView_record;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView listViewCatalogo;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button buttonRimuovi;
        private System.Windows.Forms.Button button1;
    }
}