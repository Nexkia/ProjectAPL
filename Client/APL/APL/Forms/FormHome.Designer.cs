
using System.Drawing;
using System.Windows.Forms;

namespace APL.Forms
{
    partial class FormHome
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("");
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonCarrello = new System.Windows.Forms.Button();
            this.buttonMyBuild = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaProfiloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cronologiaOrdiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Catalogo = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Home);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SlateGray;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(19, 201);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(689, 516);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanel1_ControlAdded);
            // 
            // buttonCarrello
            // 
            this.buttonCarrello.Location = new System.Drawing.Point(504, 9);
            this.buttonCarrello.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCarrello.Name = "buttonCarrello";
            this.buttonCarrello.Size = new System.Drawing.Size(88, 52);
            this.buttonCarrello.TabIndex = 2;
            this.buttonCarrello.Text = "Carrello";
            this.buttonCarrello.UseVisualStyleBackColor = true;
            this.buttonCarrello.Click += new System.EventHandler(this.buttonCarrello_Click);
            // 
            // buttonMyBuild
            // 
            this.buttonMyBuild.Location = new System.Drawing.Point(596, 9);
            this.buttonMyBuild.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMyBuild.Name = "buttonMyBuild";
            this.buttonMyBuild.Size = new System.Drawing.Size(110, 52);
            this.buttonMyBuild.TabIndex = 4;
            this.buttonMyBuild.Text = "My Build";
            this.buttonMyBuild.UseVisualStyleBackColor = true;
            this.buttonMyBuild.Click += new System.EventHandler(this.buttonMyBuild_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(54, 732);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificaProfiloToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.cronologiaOrdiniToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(45, 19);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // modificaProfiloToolStripMenuItem
            // 
            this.modificaProfiloToolStripMenuItem.Name = "modificaProfiloToolStripMenuItem";
            this.modificaProfiloToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.modificaProfiloToolStripMenuItem.Text = "Modifica Profilo";
            this.modificaProfiloToolStripMenuItem.Click += new System.EventHandler(this.modificaProfiloToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // cronologiaOrdiniToolStripMenuItem
            // 
            this.cronologiaOrdiniToolStripMenuItem.Name = "cronologiaOrdiniToolStripMenuItem";
            this.cronologiaOrdiniToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.cronologiaOrdiniToolStripMenuItem.Text = "Cronologia Ordini";
            this.cronologiaOrdiniToolStripMenuItem.Click += new System.EventHandler(this.cronologiaOrdiniToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Build Solo",
            "Build Guidata"});
            this.comboBox1.Location = new System.Drawing.Point(598, 66);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 23);
            this.comboBox1.TabIndex = 6;
            // 
            // Catalogo
            // 
            this.Catalogo.Location = new System.Drawing.Point(410, 9);
            this.Catalogo.Margin = new System.Windows.Forms.Padding(4);
            this.Catalogo.Name = "Catalogo";
            this.Catalogo.Size = new System.Drawing.Size(88, 52);
            this.Catalogo.TabIndex = 7;
            this.Catalogo.Text = "Catalogo";
            this.Catalogo.UseVisualStyleBackColor = true;
            this.Catalogo.Click += new System.EventHandler(this.Catalogo_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.SlateGray;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(722, 201);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(457, 516);
            this.flowLayoutPanel2.TabIndex = 7;
            this.flowLayoutPanel2.Visible = false;
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listView.HideSelection = false;
            this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView.Location = new System.Drawing.Point(19, 64);
            this.listView.Name = "listView";
            this.listView.Scrollable = false;
            this.listView.Size = new System.Drawing.Size(358, 133);
            this.listView.TabIndex = 8;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Modello";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Categoria";
            this.columnHeader2.Width = 150;
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 732);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Catalogo);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonMyBuild);
            this.Controls.Add(this.buttonCarrello);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1208, 771);
            this.MinimumSize = new System.Drawing.Size(736, 771);
            this.Name = "FormHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHome";
            this.Load += new System.EventHandler(this.FormHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonCarrello;
        private Button buttonMyBuild;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem modificaProfiloToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ComboBox comboBox1;
        private Button Catalogo;
        private FlowLayoutPanel flowLayoutPanel2;
        private ListView listView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ToolStripMenuItem cronologiaOrdiniToolStripMenuItem;
    }
}