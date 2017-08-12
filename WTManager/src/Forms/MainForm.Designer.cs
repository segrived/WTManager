using WTManager.Tray;

namespace WTManager.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // trayMenu
            // 
            this.trayMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.ShowItemToolTips = false;
            this.trayMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipText = "Hello";
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 35);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.NotifyIcon trayIcon;
    }
}

