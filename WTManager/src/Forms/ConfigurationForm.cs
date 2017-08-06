using System;
using System.Drawing;
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
    public partial class ConfigurationForm : WtManagerForm
    {
        private const string REQ_EXECUTABLE = "Executable files|*.exe;*.bat;*.cmd";
        private const string REQ_ICON = "Icon|*.ico";

        public ConfigurationForm()
        {
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

        private void upServiceBtn_Click(object sender, EventArgs e)
        {
            this.servicesListBox.MoveSelectedItem(-1);
        }

        private void downServiceBtn_Click(object sender, EventArgs e)
        {
            this.servicesListBox.MoveSelectedItem(1);
        }

        #endregion

        #region Window-related buttons

        private void okBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.SaveConfiguration();
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Preferences option buttons (File & font selection)
        
        private void selectConfigEditorPathBtn_Click(object sender, EventArgs e)
        {
            string execPath = RequestFilePath(REQ_EXECUTABLE);
            if (execPath != null)
                this.configEditorPathTb.Text = execPath;
        }

        private void selectLogViewerPathBtn_Click(object sender, EventArgs e)
        {
            string execPath = RequestFilePath(REQ_EXECUTABLE);
            if (execPath != null)
                this.logViewerPathTb.Text = execPath;
        }

        private void selectCustomTrayIconBtn_Click(object sender, EventArgs e)
        {
            string execPath = RequestFilePath(REQ_ICON);
            if (execPath != null)
                this.customTrayIconTb.Text = execPath;
        }

        private void selectMenuFontBtn_Click(object sender, EventArgs e)
        {
            var font = this.RequestFont();
            if (font == null)
                return;

            var cvt = new FontConverter();
            this.menuFontTb.Text = cvt.ConvertToString(font);
        }
        
        #endregion

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

        #region Services list box event handlers

        private void servicesListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.servicesListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
                this.EditServiceByListIndex(index);
        }

        private void servicesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool anyServicesSelected = this.servicesListBox.SelectedIndices.Count > 0;
            bool oneServiceSelected = this.servicesListBox.SelectedIndices.Count == 1;

            bool IsFirstIndexSelected() =>
                this.servicesListBox.SelectedIndices[0] == 0;

            bool IsLastIndexSelected() => 
                this.servicesListBox.SelectedIndices[0] == this.servicesListBox.Items.Count - 1;

            this.editServiceBtn.Enabled = oneServiceSelected;
            this.removeServiceBtn.Enabled = anyServicesSelected;

            this.upServiceBtn.Enabled = oneServiceSelected && !IsFirstIndexSelected();
            this.downServiceBtn.Enabled = oneServiceSelected && !IsLastIndexSelected();
        }

        #endregion

        #region Base form override

        public override void ApplySettings(Configuration configuration)
        {
            if (configuration.Services != null)
            {
                var items = configuration.Services.Cast<object>().ToArray();
                this.servicesListBox.Items.AddRange(items);
            }

            this.logViewerPathTb.Text = configuration.LogViewerPath;
            this.configEditorPathTb.Text = configuration.EditorPath;
            this.customTrayIconTb.Text = configuration.CustomTrayIcon;
            this.cbShowPopupMessages.Checked = configuration.ShowPopups;
            this.cbShowMenuBeyondTaskbar.Checked = configuration.ShowMenuBeyondTaskbar;

            var font = new Font(configuration.MenuFontName, configuration.MenuFontSize);
            this.menuFontTb.Text = new FontConverter().ConvertToString(font);

            this.cbAutoStartApplication.Checked = SchedulerHelpers.IsAutostartTaskInstalled();
        }

        public override void UpdateSettings(Configuration configuration)
        {
            configuration.Services = this.servicesListBox.Items.OfType<Service>().ToList();
            configuration.EditorPath = this.configEditorPathTb.Text;
            configuration.LogViewerPath = this.logViewerPathTb.Text;
            configuration.ShowPopups = this.cbShowPopupMessages.Checked;
            configuration.CustomTrayIcon = this.customTrayIconTb.Text;
            configuration.ShowMenuBeyondTaskbar = this.cbShowMenuBeyondTaskbar.Checked;

            if (new FontConverter().ConvertFromString(this.menuFontTb.Text) is Font font)
            {
                configuration.MenuFontSize = font.Size;
                configuration.MenuFontName = font.Name;
            }

            SchedulerHelpers.UpdateAutoStartSetting(this.cbAutoStartApplication.Checked);
        }

        protected override void ApplyTheme()
        {
            this.addServiceBtn.Image = ResourcesProcessor.GetImage("dialog.add");
            this.editServiceBtn.Image = ResourcesProcessor.GetImage("dialog.edit");
            this.removeServiceBtn.Image = ResourcesProcessor.GetImage("dialog.remove");

            this.applyBtn.Image = ResourcesProcessor.GetImage("dialog.ok");
            this.cancelBtn.Image = ResourcesProcessor.GetImage("dialog.cancel");

            this.upServiceBtn.Image = ResourcesProcessor.GetImage("dialog.up");
            this.downServiceBtn.Image = ResourcesProcessor.GetImage("dialog.down");
        }

        #endregion

        private Font RequestFont()
        {
            var fontDialog = new FontDialog
            {
                ShowEffects = false,
                ShowApply = false,
                FontMustExist = true
            };

            return fontDialog.ShowDialog() != DialogResult.OK ? null : fontDialog.Font;
        }

        private static string RequestFilePath(string reqString)
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
    }
}
