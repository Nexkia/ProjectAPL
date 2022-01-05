
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    partial class Form2
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
            this.Checkout = new System.Windows.Forms.Button();
            this.buttonMyBuild = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewCarrello = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(491, 94);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 57);
            this.button1.TabIndex = 0;
            this.button1.Text = "Home";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Home);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.SlateGray;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(22, 214);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(787, 550);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint_2);
            // 
            // buttonCarrello
            // 
            this.buttonCarrello.Location = new System.Drawing.Point(601, 94);
            this.buttonCarrello.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCarrello.Name = "buttonCarrello";
            this.buttonCarrello.Size = new System.Drawing.Size(100, 57);
            this.buttonCarrello.TabIndex = 2;
            this.buttonCarrello.Text = "Carrello";
            this.buttonCarrello.UseVisualStyleBackColor = true;
            this.buttonCarrello.Click += new System.EventHandler(this.buttonCarrello_Click);
            // 
            // Checkout
            // 
            this.Checkout.Location = new System.Drawing.Point(602, 15);
            this.Checkout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Checkout.Name = "Checkout";
            this.Checkout.Size = new System.Drawing.Size(100, 55);
            this.Checkout.TabIndex = 3;
            this.Checkout.Text = "Checkout";
            this.Checkout.UseVisualStyleBackColor = true;
            // 
            // buttonMyBuild
            // 
            this.buttonMyBuild.Location = new System.Drawing.Point(709, 15);
            this.buttonMyBuild.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMyBuild.Name = "buttonMyBuild";
            this.buttonMyBuild.Size = new System.Drawing.Size(100, 55);
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(65, 778);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 24);
            this.toolStripMenuItem1.Text = "Menu";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.editToolStripMenuItem.Text = "Modifica Profilo";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Solo";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Build Solo",
            "Build Guidata"});
            this.comboBox1.Location = new System.Drawing.Point(709, 78);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 24);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(495, 15);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 55);
            this.button3.TabIndex = 7;
            this.button3.Text = "Catalogo";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.SlateGray;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(825, 214);
            this.flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(407, 550);
            this.flowLayoutPanel2.TabIndex = 7;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView.HideSelection = false;
            this.listView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.listView.Location = new System.Drawing.Point(22, 67);
            this.listView.Name = "listView";
            this.listView.Scrollable = false;
            this.listView.Size = new System.Drawing.Size(408, 142);
            this.listView.TabIndex = 8;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.Visible = false;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
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
            // listViewCarrello
            // 
            this.listViewCarrello.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewCarrello.HideSelection = false;
            this.listViewCarrello.Location = new System.Drawing.Point(833, 22);
            this.listViewCarrello.Name = "listViewCarrello";
            this.listViewCarrello.Size = new System.Drawing.Size(398, 171);
            this.listViewCarrello.TabIndex = 9;
            this.listViewCarrello.UseCompatibleStateImageBehavior = false;
            this.listViewCarrello.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Modello";
            this.columnHeader3.Width = 81;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Marca";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Prezzo";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Capienza";
            this.columnHeader6.Width = 76;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Categoria";
            this.columnHeader7.Width = 83;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 778);
            this.Controls.Add(this.listViewCarrello);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonMyBuild);
            this.Controls.Add(this.Checkout);
            this.Controls.Add(this.buttonCarrello);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button buttonCarrello;
        private Button Checkout;
        private Button buttonMyBuild;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ComboBox comboBox1;
        private Button button3;
        private FlowLayoutPanel flowLayoutPanel2;
        private ListView listView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ListView listViewCarrello;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
    }
}