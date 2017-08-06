using System;
using System.Drawing;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Forms;
using WTManager.Resources;

namespace WTManager.Controls
{
    [System.ComponentModel.DesignerCategory("")]
    public class WtManagerForm : Form, IConfigurable
    {
        protected WtManagerForm()
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.UpdateSystemFont();
            
            ResourcesProcessor.ThemeChanged += this.ResourcesProcessor_OnThemeChanged;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.ApplySettings(ConfigManager.Instance.Config);
            this.ApplyTheme();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            ResourcesProcessor.ThemeChanged -= this.ResourcesProcessor_OnThemeChanged;
        }

        private void UpdateSystemFont()
        {
            this.Font = SystemFonts.MessageBoxFont;
        }

        protected void SaveConfiguration(bool autoClose = false)
        {
            this.UpdateSettings(ConfigManager.Instance.Config);
            ConfigManager.Instance.SaveConfig();

            if (autoClose)
                this.Close();
        }

        private void ResourcesProcessor_OnThemeChanged()
        {
            this.ApplyTheme();
        }

        protected virtual void ApplyTheme()
        {
            
        }

        public virtual void ApplySettings(Configuration configuration)
        {
        }

        public virtual void UpdateSettings(Configuration configuration)
        {
        }
    }
}
