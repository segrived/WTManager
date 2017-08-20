using System.ComponentModel;
using System.Windows.Forms;
using WTManager.Controls;
using WTManager.Tray;

namespace WTManager.Forms
{
    [DesignerCategory("Form")]
    public partial class MainForm : WtManagerMainForm
    {
        private readonly TrayMenu _uiTray;

        public MainForm()
        {
            this.InitializeComponent();

            this._uiTray = new TrayMenu(this.trayIcon);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing && e.CloseReason != CloseReason.TaskManagerClosing)
                return;

            this.Hide();

            e.Cancel = true;
        }

        protected override void Dispose(bool disposing)
        {
            this._uiTray?.Dispose();

            if (disposing)
                this.components?.Dispose();

            base.Dispose(disposing);
        }
    }
}