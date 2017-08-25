using System;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Resources;

namespace WTManager.Forms
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class ConfigurationForm : WtManagerForm
    {
        public ConfigurationForm()
        {
            this.InitializeComponent();

            this.basicConfigurationEditor.FillSettings(ConfigManager.Instance.Config, Configuration.GROUP_GENERAL, Configuration.GROUP_SYSTEM, Configuration.GROUP_UI);
            this.servicesConfigurationEditor.FillSettings(ConfigManager.Instance.Config, Configuration.GROUP_SERVICES);
        }

        #region Window-related buttons

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            this.basicConfigurationEditor.ApplySettings();
            this.servicesConfigurationEditor.ApplySettings();

            this.SaveConfiguration();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void ApplyTheme()
        {
            base.ApplyTheme();
            this.applyBtn.Image = ResourcesProcessor.GetImage("dialog.ok");
            this.cancelBtn.Image = ResourcesProcessor.GetImage("dialog.cancel");
        }

        #endregion
    }
}
