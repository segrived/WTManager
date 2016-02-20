namespace WTManager.UI
{
    partial class LogFileViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogFileViewerForm));
            this.logFileContent = new System.Windows.Forms.RichTextBox();
            this.logFileContentWrapper = new System.Windows.Forms.Panel();
            this.logFileContentWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // logFileContent
            // 
            this.logFileContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logFileContent.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logFileContent.Location = new System.Drawing.Point(0, 0);
            this.logFileContent.Name = "logFileContent";
            this.logFileContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.logFileContent.Size = new System.Drawing.Size(642, 376);
            this.logFileContent.TabIndex = 2;
            this.logFileContent.Text = "";
            // 
            // logFileContentWrapper
            // 
            this.logFileContentWrapper.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logFileContentWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logFileContentWrapper.Controls.Add(this.logFileContent);
            this.logFileContentWrapper.Location = new System.Drawing.Point(12, 12);
            this.logFileContentWrapper.Name = "logFileContentWrapper";
            this.logFileContentWrapper.Size = new System.Drawing.Size(644, 378);
            this.logFileContentWrapper.TabIndex = 3;
            // 
            // LogFileViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 402);
            this.Controls.Add(this.logFileContentWrapper);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogFileViewer";
            this.Text = "LogFileViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogFileViewer_FormClosing);
            this.Load += new System.EventHandler(this.LogFileViewer_Load);
            this.logFileContentWrapper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox logFileContent;
        private System.Windows.Forms.Panel logFileContentWrapper;
    }
}