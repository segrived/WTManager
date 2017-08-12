using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Helpers;
using WTManager.Lib;
using WTManager.Resources;

namespace WTManager.Forms
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class ConfigurationForm : WtManagerForm
    {
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

            if (!(selectedService is Service))
                return;

            this.EditService((Service)this.servicesListBox.SelectedItem);
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

        void EditService(Service service)
        {
            int index = this.servicesListBox.Items.IndexOf(service);

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
            {
                var service = (Service) this.servicesListBox.Items[index];
                this.EditService(service);
            }
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

        public override void ApplySettings()
        {
            var configuration = ConfigManager.Instance.Config;

            if (configuration.Services != null)
            {
                var items = configuration.Services.Cast<object>().ToArray();
                this.servicesListBox.Items.AddRange(items);
            }

            this.logEditorSelector.CurrentState = configuration.LogViewerPath;
            this.configEditorSelector.CurrentState = configuration.EditorPath;
            this.fontSelector.CurrentState = new Font(configuration.MenuFontName, configuration.MenuFontSize);

            this.cbShowPopupMessages.Checked = configuration.ShowPopups;
            this.cbShowMenuBeyondTaskbar.Checked = configuration.ShowMenuBeyondTaskbar;
            this.cbOpenMenuByLeftClick.Checked = configuration.OpenTrayMenuLeftClick;

            this.cbAutoStartApplication.Checked = SchedulerHelpers.IsAutostartTaskInstalled();

            this.themeNameCb.Items.Add(new ComboBoxItem("<Internal>", null));
            foreach(string themeName in ResourcesProcessor.GetThemesList())
                this.themeNameCb.Items.Add(new ComboBoxItem(themeName));

            this.themeNameCb.SelectByValue(configuration.ThemeName);
        }

        public override void UpdateSettings()
        {
            var configuration = ConfigManager.Instance.Config;

            configuration.Services = this.servicesListBox.Items.OfType<Service>().ToList();
            configuration.ShowPopups = this.cbShowPopupMessages.Checked;
            configuration.ShowMenuBeyondTaskbar = this.cbShowMenuBeyondTaskbar.Checked;
            configuration.OpenTrayMenuLeftClick = this.cbOpenMenuByLeftClick.Checked;

            configuration.EditorPath = this.configEditorSelector.CurrentState;
            configuration.LogViewerPath = this.logEditorSelector.CurrentState;
            configuration.MenuFontSize = this.fontSelector.CurrentState.Size;
            configuration.MenuFontName = this.fontSelector.CurrentState.Name;

            var themeValue = this.themeNameCb.SelectedItem as ComboBoxItem;

            if (themeValue != null)
            {
                string themeName = themeValue.Value as string;
                ResourcesProcessor.ThemeName = themeName;

                configuration.ThemeName = themeName;
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
    }
}
