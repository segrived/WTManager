using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.TrayMenu;

namespace WTManager.Forms
{
    [DesignerCategory("Form")]
    public partial class MainForm : WtManagerMainForm
    {
        private readonly WtTrayMenu _uiTrayMenu;

        public MainForm()
        {
            this.InitializeComponent();

            this._uiTrayMenu = new WtTrayMenu(this.trayIcon);

            ConfigManager.Instance.ConfigSaved += this.InitTrayMenu;
            this.InitTrayMenu();

        }

        private void InitTrayMenu()
        {
            ConfigManager.Instance.ReloadConfig();
            this._uiTrayMenu.RecreateMenu();
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