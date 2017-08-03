namespace WTManager.Forms
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
            if (disposing && (this.components != null)) {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
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
            this.logFileContent.Size = new System.Drawing.Size(622, 406);
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
            this.logFileContentWrapper.Location = new System.Drawing.Point(14, 14);
            this.logFileContentWrapper.Name = "logFileContentWrapper";
            this.logFileContentWrapper.Size = new System.Drawing.Size(624, 408);
            this.logFileContentWrapper.TabIndex = 3;
            // 
            // LogFileViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 436);
            this.Controls.Add(this.logFileContentWrapper);
            this.Name = "LogFileViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogFileViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LogFileViewer_FormClosing);
            this.logFileContentWrapper.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox logFileContent;
        private System.Windows.Forms.Panel logFileContentWrapper;
    }
}