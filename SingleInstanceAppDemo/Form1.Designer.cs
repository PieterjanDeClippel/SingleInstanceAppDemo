namespace SingleInstanceAppDemo
{
    partial class Form1
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btnMaakBestanden = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listBox1.FormattingEnabled = true;
			this.listBox1.IntegralHeight = false;
			this.listBox1.Location = new System.Drawing.Point(12, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(301, 251);
			this.listBox1.TabIndex = 0;
			// 
			// btnMaakBestanden
			// 
			this.btnMaakBestanden.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMaakBestanden.Location = new System.Drawing.Point(12, 269);
			this.btnMaakBestanden.Name = "btnMaakBestanden";
			this.btnMaakBestanden.Size = new System.Drawing.Size(300, 23);
			this.btnMaakBestanden.TabIndex = 2;
			this.btnMaakBestanden.Text = "Create files and open folder";
			this.btnMaakBestanden.UseVisualStyleBackColor = true;
			this.btnMaakBestanden.Click += new System.EventHandler(this.btnMaakBestanden_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(325, 304);
			this.Controls.Add(this.btnMaakBestanden);
			this.Controls.Add(this.listBox1);
			this.IsMdiContainer = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btnMaakBestanden;
	}
}

