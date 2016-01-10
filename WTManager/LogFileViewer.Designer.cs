namespace WTManager
{
    partial class LogFileViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogFileViewer));
            this.logFileContent = new System.Windows.Forms.TextBox();
            this.logFileNameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logFileContent
            // 
            this.logFileContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logFileContent.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logFileContent.Location = new System.Drawing.Point(12, 25);
            this.logFileContent.Multiline = true;
            this.logFileContent.Name = "logFileContent";
            this.logFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logFileContent.Size = new System.Drawing.Size(644, 365);
            this.logFileContent.TabIndex = 0;
            // 
            // logFileNameLbl
            // 
            this.logFileNameLbl.AutoSize = true;
            this.logFileNameLbl.Location = new System.Drawing.Point(9, 9);
            this.logFileNameLbl.Name = "logFileNameLbl";
            this.logFileNameLbl.Size = new System.Drawing.Size(64, 13);
            this.logFileNameLbl.TabIndex = 1;
            this.logFileNameLbl.Text = "%fileName%";
            // 
            // LogFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 402);
            this.Controls.Add(this.logFileNameLbl);
            this.Controls.Add(this.logFileContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogFileViewer";
            this.Text = "LogFileViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogFileViewer_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox logFileContent;
        private System.Windows.Forms.Label logFileNameLbl;
    }
}