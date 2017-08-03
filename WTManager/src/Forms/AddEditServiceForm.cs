using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WTManager.Controls;
using WTManager.Helpers;

namespace WTManager.Forms
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class AddEditServiceForm : WtManagerForm
    {
        public Service Service { get; private set; }

        private void InitForm(Service service) {
            this.InitializeComponent();

            this.Service = service;

            // default dialog result
            this.DialogResult = DialogResult.Cancel;

            if (ConfigManager.Services != null) {
                var groups = ConfigManager.Services
                    .Select(serv => serv.Group)
                    .Where(g => !String.IsNullOrWhiteSpace(g))
                    .Distinct()
                    .Cast<object>()
                    .ToArray();
                this.serviceGroupCb.Items.AddRange(groups);
            }

            var services = ServiceHelpers.GetAllServices().Select(s => s.ServiceName);

            if (ConfigManager.Services != null)
            {
                var alreadyAdded = ConfigManager.Services.Select(s => s.ServiceName).ToHashSet();
                services = services.Where(s => s == service.ServiceName || !alreadyAdded.Contains(s));
            }

            this.serviceNameCb.Items.AddRange(services.Cast<object>().ToArray());
        }

        public AddEditServiceForm() {
            this.InitForm(new Service());
        }

        public AddEditServiceForm(Service s) {
            this.InitForm(s);

            this.serviceNameCb.SelectedItem = s.ServiceName;
            this.serviceDisplayNameTb.Text = s.DisplayName;
            this.serviceGroupCb.Text = s.Group;
            this.serviceBrowserUrlTb.Text = s.BrowserUrl;
            this.serviceDataDirectoryTb.Text = s.DataDirectory;

            if (s.LogFiles != null) {
                this.logFilesLb.Items.AddRange(s.LogFiles.Cast<object>().ToArray());
            }
            if (s.ConfigFiles != null) {
                this.configFilesLb.Items.AddRange(s.ConfigFiles.Cast<object>().ToArray());
            }
        }

        private void AddEditServiceForm_Load(object sender, EventArgs e) {

        }

        private void serviceNameCb_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.serviceNameCb.SelectedItem == null) {
                return;
            }
            this.serviceDisplayNameTb.Text = this.serviceNameCb.Text;
        }

        private void removeLogFileBtn_Click(object sender, EventArgs e) {
            if (this.logFilesLb.SelectedItems.Count == 0)
                return;
            foreach (string s in this.logFilesLb.SelectedItems.OfType<string>().ToList()) {
                this.logFilesLb.Items.Remove(s);
            }
        }

        private void removeConfigFileBtn_Click(object sender, EventArgs e) {
            if (this.configFilesLb.SelectedItems.Count == 0)
                return;
            foreach (string s in this.configFilesLb.SelectedItems.OfType<string>().ToList()) {
                this.configFilesLb.Items.Remove(s);
            }
        }

        private void addLogFileBtn_Click(object sender, EventArgs e)
        {
            this.logFilesLb.Items.AddRange(this.RequestFiles().Cast<object>().ToArray());
        }

        private void addConfigFileBtn_Click(object sender, EventArgs e)
        {
            this.configFilesLb.Items.AddRange(this.RequestFiles().Cast<object>().ToArray());
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

        private void cancelBtn_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e) {
            this.Service.ServiceName = this.serviceNameCb.Text;
            this.Service.DisplayName = this.serviceDisplayNameTb.Text;
            this.Service.Group = this.serviceGroupCb.Text;
            this.Service.LogFiles = this.logFilesLb.Items.OfType<string>().ToList();
            this.Service.ConfigFiles = this.configFilesLb.Items.OfType<string>().ToList();
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

        private void logFilesLb_SelectedIndexChanged(object sender, EventArgs e) {
            this.removeLogFileBtn.Enabled = this.logFilesLb.SelectedIndices.Count > 0;
        }

        private void configFilesLb_SelectedIndexChanged(object sender, EventArgs e) {
            this.removeConfigFileBtn.Enabled = this.configFilesLb.SelectedIndices.Count > 0;
        }
    }
}
