
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
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("");
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
            this.button1.Location = new System.Drawing.Point(358, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 69);
            this.button1.TabIndex = 0;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Home);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SlateGray;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 268);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(787, 688);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanel1_ControlAdded);
            // 
            // buttonCarrello
            // 
            this.buttonCarrello.Location = new System.Drawing.Point(576, 12);
            this.buttonCarrello.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCarrello.Name = "buttonCarrello";
            this.buttonCarrello.Size = new System.Drawing.Size(101, 69);
            this.buttonCarrello.TabIndex = 2;
            this.buttonCarrello.Text = "Carrello";
            this.buttonCarrello.UseVisualStyleBackColor = true;
            this.buttonCarrello.Click += new System.EventHandler(this.buttonCarrello_Click);
            // 
            // buttonMyBuild
            // 
            this.buttonMyBuild.Location = new System.Drawing.Point(681, 12);
            this.buttonMyBuild.Name = "buttonMyBuild";
            this.buttonMyBuild.Size = new System.Drawing.Size(126, 69);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(65, 968);
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
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 24);
            this.toolStripMenuItem1.Text = "Menu";
            // 
            // modificaProfiloToolStripMenuItem
            // 
            this.modificaProfiloToolStripMenuItem.Name = "modificaProfiloToolStripMenuItem";
            this.modificaProfiloToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.modificaProfiloToolStripMenuItem.Text = "Modifica Profilo";
            this.modificaProfiloToolStripMenuItem.Click += new System.EventHandler(this.modificaProfiloToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // cronologiaOrdiniToolStripMenuItem
            // 
            this.cronologiaOrdiniToolStripMenuItem.Name = "cronologiaOrdiniToolStripMenuItem";
            this.cronologiaOrdiniToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
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
            this.comboBox1.Location = new System.Drawing.Point(683, 88);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(123, 28);
            this.comboBox1.TabIndex = 6;
            // 
            // Catalogo
            // 
            this.Catalogo.Location = new System.Drawing.Point(469, 12);
            this.Catalogo.Margin = new System.Windows.Forms.Padding(5);
            this.Catalogo.Name = "Catalogo";
            this.Catalogo.Size = new System.Drawing.Size(101, 69);
            this.Catalogo.TabIndex = 7;
            this.Catalogo.Text = "Catalogo";
            this.Catalogo.UseVisualStyleBackColor = true;
            this.Catalogo.Click += new System.EventHandler(this.Catalogo_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.SlateGray;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(825, 268);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(522, 688);
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
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listView.Location = new System.Drawing.Point(22, 85);
            this.listView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listView.Name = "listView";
            this.listView.Scrollable = false;
            this.listView.Size = new System.Drawing.Size(409, 176);
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 968);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Catalogo);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonMyBuild);
            this.Controls.Add(this.buttonCarrello);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MaximumSize = new System.Drawing.Size(1378, 1015);
            this.MinimumSize = new System.Drawing.Size(839, 1015);
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