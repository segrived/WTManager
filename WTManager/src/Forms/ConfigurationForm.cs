using System;
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

            this._wtConfigurator1.FillSettings(ConfigManager.Instance.Config);

            this.wtListTest1.AddRequest = AddServiceRequest;
            this.wtListTest1.EditRequest = EditServiceRequest;
            this.wtListTest1.SetItems(ConfigManager.Instance.Config.Services);
        }

        private static object AddServiceRequest()
        {
            using (var f = new AddEditServiceForm())
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
            this._wtConfigurator1.ApplySettings();
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
