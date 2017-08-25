using System.ComponentModel;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Resources;
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

            ConfigManager.Instance.ConfigSaved += this.Instance_OnConfigSaved;
        }

        private void Instance_OnConfigSaved(Configuration config)
        {
            ResourcesProcessor.ThemeName = config.ThemeName;
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