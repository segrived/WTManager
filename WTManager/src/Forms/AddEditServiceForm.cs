using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Helpers;
using WTManager.Resources;

namespace WTManager.Forms
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class AddEditServiceForm : WtManagerForm
    {
        public Service Service { get; private set; }

        private void InitForm(Service service)
        {
            this.Service = service;

            // default dialog result
            this.DialogResult = DialogResult.Cancel;

            if (ConfigManager.Instance.Config.Services != null)
            {
                var groups = ConfigManager.Instance.Config.Services
                    .Select(serv => serv.Group)
                    .Where(g => !String.IsNullOrWhiteSpace(g))
                    .Distinct()
                    .Cast<object>()
                    .ToArray();
                this.serviceGroupCb.Items.AddRange(groups);
            }

            this.wtLogs.SetItems(service.LogFiles);
            this.wtConfigs.SetItems(service.ConfigFiles);

            var services = ServiceHelpers.GetAllServices().Select(s => s.ServiceName);

            if (ConfigManager.Instance.Config.Services != null)
            {
                var alreadyAdded = ConfigManager.Instance.Config.Services.Select(s => s.ServiceName).ToHashSet();
                services = services.Where(s => s == service.ServiceName || !alreadyAdded.Contains(s));
            }

            this.serviceNameCb.Items.AddRange(services.Cast<object>().ToArray());
        }

        public AddEditServiceForm()
        {
            this.InitializeComponent();
        }

        public AddEditServiceForm(Service s) : this()
        {
            this.InitForm(s);

            this.serviceNameCb.SelectedItem = s.ServiceName;
            this.serviceDisplayNameTb.Text = s.DisplayName;
            this.serviceGroupCb.Text = s.Group;
            this.serviceBrowserUrlTb.Text = s.BrowserUrl;
            this.serviceDataDirectoryTb.Text = s.DataDirectory;
        }


        private void serviceNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.serviceNameCb.SelectedItem == null)
                return;

            this.serviceDisplayNameTb.Text = this.serviceNameCb.Text;
        }

        private string[] RequestFiles()
        {
            var dialog = new OpenFileDialog {
                Multiselect = true,
                DereferenceLinks = true,
                ValidateNames = true
            };
            var result = dialog.ShowDialog();
            if (result != DialogResult.OK && dialog.FileNames == null)
                return null;

            return dialog.FileNames;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.Service.ServiceName = this.serviceNameCb.Text;
            this.Service.DisplayName = this.serviceDisplayNameTb.Text;
            this.Service.Group = this.serviceGroupCb.Text;
            this.Service.LogFiles = this.wtLogs.GetItems<string>().ToList();
            this.Service.ConfigFiles = this.wtConfigs.GetItems<string>().ToList();
            this.Service.BrowserUrl = this.serviceBrowserUrlTb.Text;
            this.Service.DataDirectory = this.serviceDataDirectoryTb.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void selectDataDirectoryBtn_Click(object sender, EventArgs e) {
            var currentPath = this.serviceDataDirectoryTb.Text;
            var dialog = new FolderBrowserDialog {
                ShowNewFolderButton = true
            };
            if (Directory.Exists(currentPath)) {
                dialog.SelectedPath = currentPath;
            }
            if (dialog.ShowDialog() == DialogResult.OK) {
                this.serviceDataDirectoryTb.Text = dialog.SelectedPath;
            }
        }

        protected override void ApplyTheme()
        {
            base.ApplyTheme();

            this.applyBtn.Image = ResourcesProcessor.GetImage("dialog.ok");
            this.cancelBtn.Image = ResourcesProcessor.GetImage("dialog.cancel");
        }
    }
}
