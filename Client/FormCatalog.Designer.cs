
namespace Client
{
    partial class FormCatalog
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // cpuButton
            // 
            this.cpuButton.Location = new System.Drawing.Point(45, 55);
            this.cpuButton.Name = "cpuButton";
            this.cpuButton.Size = new System.Drawing.Size(75, 23);
            this.cpuButton.TabIndex = 0;
            this.cpuButton.Text = "cpu";
            this.cpuButton.UseVisualStyleBackColor = true;
            this.cpuButton.Click += new System.EventHandler(this.cpu_Click);
            // 
            // schedaMadreButton
            // 
            this.schedaMadreButton.Location = new System.Drawing.Point(141, 55);
            this.schedaMadreButton.Name = "schedaMadreButton";
            this.schedaMadreButton.Size = new System.Drawing.Size(81, 23);
            this.schedaMadreButton.TabIndex = 1;
            this.schedaMadreButton.Text = "schedaMadre";
            this.schedaMadreButton.UseVisualStyleBackColor = true;
            this.schedaMadreButton.Click += new System.EventHandler(this.schedaMadre_Click);
            // 
            // ramButton
            // 
            this.ramButton.Location = new System.Drawing.Point(238, 55);
            this.ramButton.Name = "ramButton";
            this.ramButton.Size = new System.Drawing.Size(75, 23);
            this.ramButton.TabIndex = 2;
            this.ramButton.Text = "ram";
            this.ramButton.UseVisualStyleBackColor = true;
            this.ramButton.Click += new System.EventHandler(this.ram_Click);
            // 
            // memoriaButton
            // 
            this.memoriaButton.Location = new System.Drawing.Point(337, 55);
            this.memoriaButton.Name = "memoriaButton";
            this.memoriaButton.Size = new System.Drawing.Size(75, 23);
            this.memoriaButton.TabIndex = 3;
            this.memoriaButton.Text = "memoria";
            this.memoriaButton.UseVisualStyleBackColor = true;
            this.memoriaButton.Click += new System.EventHandler(this.memoria_Click);
            // 
            // alimentatoreButton
            // 
            this.alimentatoreButton.Location = new System.Drawing.Point(428, 55);
            this.alimentatoreButton.Name = "alimentatoreButton";
            this.alimentatoreButton.Size = new System.Drawing.Size(75, 23);
            this.alimentatoreButton.TabIndex = 4;
            this.alimentatoreButton.Text = "alimentatore";
            this.alimentatoreButton.UseVisualStyleBackColor = true;
            this.alimentatoreButton.Click += new System.EventHandler(this.alimentatore_Click);
            // 
            // schedaVideoButton
            // 
            this.schedaVideoButton.Location = new System.Drawing.Point(523, 55);
            this.schedaVideoButton.Name = "schedaVideoButton";
            this.schedaVideoButton.Size = new System.Drawing.Size(81, 23);
            this.schedaVideoButton.TabIndex = 5;
            this.schedaVideoButton.Text = "schedaVideo";
            this.schedaVideoButton.UseVisualStyleBackColor = true;
            this.schedaVideoButton.Click += new System.EventHandler(this.schedaVideo_Click);
            // 
            // casepcButton
            // 
            this.casepcButton.Location = new System.Drawing.Point(620, 55);
            this.casepcButton.Name = "casepcButton";
            this.casepcButton.Size = new System.Drawing.Size(75, 23);
            this.casepcButton.TabIndex = 6;
            this.casepcButton.Text = "casepc";
            this.casepcButton.UseVisualStyleBackColor = true;
            this.casepcButton.Click += new System.EventHandler(this.casepc_Click);
            // 
            // dissipatoreButton
            // 
            this.dissipatoreButton.Location = new System.Drawing.Point(716, 55);
            this.dissipatoreButton.Name = "dissipatoreButton";
            this.dissipatoreButton.Size = new System.Drawing.Size(75, 23);
            this.dissipatoreButton.TabIndex = 7;
            this.dissipatoreButton.Text = "dissipatore";
            this.dissipatoreButton.UseVisualStyleBackColor = true;
            this.dissipatoreButton.Click += new System.EventHandler(this.dissipatore_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(45, 131);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(746, 379);
            this.checkedListBox1.TabIndex = 8;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // FormCatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 551);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.dissipatoreButton);
            this.Controls.Add(this.casepcButton);
            this.Controls.Add(this.schedaVideoButton);
            this.Controls.Add(this.alimentatoreButton);
            this.Controls.Add(this.memoriaButton);
            this.Controls.Add(this.ramButton);
            this.Controls.Add(this.schedaMadreButton);
            this.Controls.Add(this.cpuButton);
            this.Name = "FormCatalog";
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
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}