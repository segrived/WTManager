using System;
using System.Linq;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;

namespace WTManager.Forms
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class ConfigurationForm : WtManagerForm
    {
        public ConfigurationForm()
        {
            this.InitializeComponent();

            this.basicConfigurationEditor.FillSettings(ConfigManager.Instance.Config);

            this.servicesList.AddRequest = AddServiceRequest;
            this.servicesList.EditRequest = EditServiceRequest;
            this.servicesList.SetItems(ConfigManager.Instance.Config.Services);
        }

        private static object AddServiceRequest()
        {
            using (var f = new AddEditServiceForm(new Service()))
                return f.ShowDialog() == DialogResult.OK ? f.Service : null;
        }

        private static object EditServiceRequest(object arg)
        {
            using (var f = new AddEditServiceForm(arg as Service))
                return f.ShowDialog() == DialogResult.OK ? f.Service : null;
        }

        #region Window-related buttons

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.basicConfigurationEditor.ApplySettings();

            ConfigManager.Instance.Config.Services = this.servicesList.GetItems<Service>().ToList();

            this.SaveConfiguration();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion


    }
}
