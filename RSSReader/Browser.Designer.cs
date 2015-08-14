namespace RSSReader
{
    partial class Browser
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
            this.rsswebBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // rsswebBrowser
            // 
            this.rsswebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rsswebBrowser.Location = new System.Drawing.Point(0, 0);
            this.rsswebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.rsswebBrowser.Name = "rsswebBrowser";
            this.rsswebBrowser.Size = new System.Drawing.Size(784, 562);
            this.rsswebBrowser.TabIndex = 0;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.rsswebBrowser);
            this.Name = "Browser";
            this.Text = "Browser";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser rsswebBrowser;
    }
}