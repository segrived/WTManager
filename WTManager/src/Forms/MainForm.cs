using System.ComponentModel;
using System.Windows.Forms;
using WTManager.Config;
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

            ConfigManager.Instance.ConfigSaved += this.InitTrayMenu;
            this.InitTrayMenu();

        }

        private void InitTrayMenu()
        {
            this._uiTray.RecreateMenu();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.UserClosing && e.CloseReason != CloseReason.TaskManagerClosing)
                return;

            this.Hide();
            this.ShowInTaskbar = false;

            e.Cancel = true;
        }
    }
}