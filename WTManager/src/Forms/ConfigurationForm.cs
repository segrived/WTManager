using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;

namespace WTManager.Forms
{
    public interface IConfigurable
    {
        /// <summary>
        /// Apply settings to form
        /// </summary>
        void ApplySettings(Configuration configuration);

        /// <summary>
        /// Updates settings before save
        /// </summary>
        void UpdateSettings(Configuration configuration);
    }

    [System.ComponentModel.DesignerCategory("Form")]
    public partial class ConfigurationForm : WtManagerForm, IConfigurable
    {
        public ConfigurationForm() {
            this.InitializeComponent();
        }

        private void ServiceConfigForm_Load(object sender, EventArgs e)
        {
            this.servicesListBox.Format += (s, ea) =>
            {
                var service = (Service)ea.Value;
                ea.Value = $"{service.ServiceName} - {service.DisplayName}";
            };
        }

        private void selectConfigEditorPathBtn_Click(object sender, EventArgs e)
        {
            string execPath = RequestExecutablePath(REQ_EXECUTABLE);
            if (execPath != null)
                this.configEditorPathTb.Text = execPath;
        }

        private void selectLogViewerPathBtn_Click(object sender, EventArgs e)
        {
            string execPath = RequestExecutablePath(REQ_EXECUTABLE);
            if (execPath != null)
                this.logViewerPathTb.Text = execPath;
        }

        private void selectCustomTrayIconBtn_Click(object sender, EventArgs e)
        {
            string execPath = RequestExecutablePath(REQ_ICON);
            if (execPath != null)
                this.customTrayIconTb.Text = execPath;
        }

        private void servicesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.servicesListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
                this.EditServiceByListIndex(index);
        }

        #region Services-related buttons
        private void addServiceBtn_Click(object sender, EventArgs e)
        {
            using (var f = new AddEditServiceForm())
            {
                if (f.ShowDialog() != DialogResult.OK || f.Service == null)
                    return;

                this.servicesListBox.Items.Add(f.Service);
                this.SaveConfiguration();
            }
        }

        private void editServiceBtn_Click(object sender, EventArgs e)
        {
            var selectedService = this.servicesListBox.SelectedItem;

            if (selectedService == null)
                return;

            this.EditServiceByListIndex(this.servicesListBox.SelectedIndex);
        }

        private void removeServiceBtn_Click(object sender, EventArgs e)
        {
            var selectedService = this.servicesListBox.SelectedItem;

            if (selectedService == null)
                return;

            if (MessageBox.Show("Do you really want to delete selected service(s) from list?", "Removing service(s)", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            var selServices = this.servicesListBox.SelectedItems.OfType<Service>().ToList();
            foreach (var service in selServices)
                this.servicesListBox.Items.Remove(service);

            this.SaveConfiguration();
        }
        #endregion

        #region Window-related buttons
        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.SaveConfiguration();
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private const string REQ_EXECUTABLE = "Executable files|*.exe;*.bat;*.cmd";
        private const string REQ_ICON = "Icon|*.ico";

        private static string RequestExecutablePath(string reqString)
        {
            var dialog = new OpenFileDialog
            {
                Filter = reqString,
                CheckFileExists = true,
                ValidateNames = true
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return null;

            string filePath = dialog.FileName;

            if (filePath != null && File.Exists(filePath))
                return filePath;

            return null;
        }

        void EditServiceByListIndex(int index)
        {
            var service = (Service)this.servicesListBox.Items[index];
            using (var f = new AddEditServiceForm(service))
            {
                var result = f.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                this.servicesListBox.Items[index] = f.Service;
                this.SaveConfiguration();
            }
        }

        private void servicesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editServiceBtn.Enabled = this.servicesListBox.SelectedIndices.Count == 1;
            this.removeServiceBtn.Enabled = this.servicesListBox.SelectedIndices.Count > 0;
        }

        public void ApplySettings(Configuration configuration)
        {
            if (configuration.Services != null)
            {
                var items = configuration.Services.Cast<object>().ToArray();
                this.servicesListBox.Items.AddRange(items);
            }

            this.logViewerPathTb.Text = configuration.Preferences.LogViewerPath;
            this.configEditorPathTb.Text = configuration.Preferences.EditorPath;
            this.customTrayIconTb.Text = configuration.Preferences.CustomTrayIcon;
            this.cbShowPopupMessages.Checked = configuration.Preferences.ShowPopups;
            this.cbShowMenuBeyondTaskbar.Checked = configuration.Preferences.ShowMenuBeyondTaskbar;
        }

        public void UpdateSettings(Configuration configuration)
        {
            configuration.Services = this.servicesListBox.Items.OfType<Service>().ToList();
            configuration.Preferences.EditorPath = this.configEditorPathTb.Text;
            configuration.Preferences.LogViewerPath = this.logViewerPathTb.Text;
            configuration.Preferences.ShowPopups = this.cbShowPopupMessages.Checked;
            configuration.Preferences.CustomTrayIcon = this.customTrayIconTb.Text;
            configuration.Preferences.ShowMenuBeyondTaskbar = this.cbShowMenuBeyondTaskbar.Checked;
        }
    }
}
