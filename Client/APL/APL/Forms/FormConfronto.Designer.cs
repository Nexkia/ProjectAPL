
namespace APL.Forms
{
    partial class FormConfronto
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
            this.flowLayoutPanelConfronto = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelConfronto
            // 
            this.flowLayoutPanelConfronto.AutoScroll = true;
            this.flowLayoutPanelConfronto.Location = new System.Drawing.Point(37, 49);
            this.flowLayoutPanelConfronto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelConfronto.Name = "flowLayoutPanelConfronto";
            this.flowLayoutPanelConfronto.Size = new System.Drawing.Size(911, 579);
            this.flowLayoutPanelConfronto.TabIndex = 1;
            
            // 
            // Confronto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 639);
            this.Controls.Add(this.flowLayoutPanelConfronto);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Confronto";
            this.Text = "Confronto";
            this.Load += new System.EventHandler(this.Confronto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelConfronto;
    }
}