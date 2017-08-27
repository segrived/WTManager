using WTManager.Config;
using WTManager.Controls;

namespace WTManager.Forms
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class ServiceTasksListForm : WtManagerForm
    {
        public ServiceTasksListForm()
        {
            this.InitializeComponent();
            this.serviceTasksConfiguration.FillSettings(ConfigManager.Instance.Config, Configuration.GROUP_TASKS);
        }

        private void applyBtn_Click(object sender, System.EventArgs e)
        {
            this.serviceTasksConfiguration.ApplySettings();
            this.SaveConfiguration();
        }
    }
}
