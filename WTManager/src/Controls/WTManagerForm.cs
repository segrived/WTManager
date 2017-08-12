using System;
using System.Drawing;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Resources;

namespace WTManager.Controls
{
    [System.ComponentModel.DesignerCategory("")]
    public class WtManagerForm : Form, IConfigurableForm
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

            this.ApplySettings();
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
            this.UpdateSettings();
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

        public virtual void ApplySettings()
        {
        }

        public virtual void UpdateSettings()
        {
        }
    }

    #region 

    public interface IConfigurableForm
    {
        /// <summary>
        /// Apply settings to form
        /// </summary>
        void ApplySettings();

        /// <summary>
        /// Updates settings before save
        /// </summary>
        void UpdateSettings();
    }

    #endregion
}
