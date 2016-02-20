using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WTManager.Controls;

namespace WTManager.UI
{

    public partial class ConfigurationForm : SystemFontForm
    {
        public ConfigurationForm() {
            InitializeComponent();

            this.servicesListBox.Format += (s, e) => {
                var service = (Service)e.Value;
                e.Value = $"{service.ServiceName} - {service.DisplayName}";
            };
        }

        private void ServiceConfigForm_Load(object sender, EventArgs e) {
            this.servicesListBox.Items.AddRange(ConfigManager.Services.ToArray());

            this.logViewerPathTb.Text = ConfigManager.Preferences.LogViewerPath;
            this.configEditorPathTb.Text = ConfigManager.Preferences.EditorPath;
        }

        private void removeServiceBtn_Click(object sender, EventArgs e) {
            var selectedService = this.servicesListBox.SelectedItem;
            if (selectedService != null) {
                this.servicesListBox.Items.Remove(selectedService);
            }
        }

        private void applyChangesBtn_Click(object sender, EventArgs e) {
            var conf = ConfigManager.Instance.Config;
            conf.Services = this.servicesListBox.Items.OfType<Service>();
            conf.Preferences.EditorPath = this.configEditorPathTb.Text;
            conf.Preferences.LogViewerPath = this.logViewerPathTb.Text;

            ConfigManager.Instance.SaveConfig();
            this.Close();
        }

        private void addServiceBtn_Click(object sender, EventArgs e) {
            using (var f = new AddEditServiceForm()) {
                var result = f.ShowDialog();
                if (f.DialogResult != DialogResult.OK || f.Service == null) {
                    return;
                }
                this.servicesListBox.Items.Add(f.Service);
            }
        }

        private void editServiceBtn_Click(object sender, EventArgs e) {
            var selectedService = this.servicesListBox.SelectedItem;
            if (selectedService == null) {
                return;
            }
            var index = this.servicesListBox.SelectedIndex;
            using (var f = new AddEditServiceForm((Service)selectedService)) {
                var result = f.ShowDialog();
                if (f.DialogResult != DialogResult.OK) {
                    return;
                }
                this.servicesListBox.Items[index] = f.Service;
            }
        }


        private void selectConfigEditorPathBtn_Click(object sender, EventArgs e) {
            var execPath = this.RequestExecutablePath();
            if (execPath != null) {
                this.configEditorPathTb.Text = execPath;
            }
        }

        private void selectLogViewerPathBtn_Click(object sender, EventArgs e) {
            var execPath = this.RequestExecutablePath();
            if (execPath != null) {
                this.logViewerPathTb.Text = execPath;
            }
        }

        private string RequestExecutablePath() {
            var dialog = new OpenFileDialog {
                Filter = "Executable files|*.exe;*.bat;*.cmd",
                CheckFileExists = true,
                ValidateNames = true
            };
            if (dialog.ShowDialog() == DialogResult.OK) {
                var execPath = dialog.FileName;
                if (execPath != null && File.Exists(execPath)) {
                    return execPath;
                }
            }
            return null;
        }
    }
}
