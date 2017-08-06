using System;
using System.Drawing;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Forms;

namespace WTManager.Controls
{
    [System.ComponentModel.DesignerCategory("")]
    public class WtManagerForm : Form
    {
        protected WtManagerForm()
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.UpdateSystemFont();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var configurableForm = this as IConfigurable;
            configurableForm?.ApplySettings(ConfigManager.Instance.Config);
        }

        private void UpdateSystemFont()
        {
            this.Font = SystemFonts.MessageBoxFont;
        }

        protected void SaveConfiguration(bool autoClose = false)
        {
            var configurableForm = this as IConfigurable;

            if (configurableForm == null)
                return;

            configurableForm.UpdateSettings(ConfigManager.Instance.Config);
            ConfigManager.Instance.SaveConfig();

            if (autoClose)
                this.Close();
        }
    }
}
