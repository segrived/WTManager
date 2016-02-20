using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WTManager.Controls;

namespace WTManager.UI
{

    public partial class ServiceConfigForm : SystemFontForm
    {
        public ServiceConfigForm() {
            InitializeComponent();

            this.servicesListBox.Format += (s, e) => {
                var service = (Service)e.Value;
                e.Value = $"{service.ServiceName} - {service.DisplayName}";
            };
        }

        private void ServiceConfigForm_Load(object sender, EventArgs e) {
            this.servicesListBox.Items.AddRange(ConfigManager.Services.ToArray());
        }

        private void removeServiceBtn_Click(object sender, EventArgs e) {
            var selectedService = this.servicesListBox.SelectedItem;
            if (selectedService != null) {
                this.servicesListBox.Items.Remove(selectedService);
            }
        }

        private void applyChangesBtn_Click(object sender, EventArgs e) {
            ConfigManager.Instance.Config.Services = this.servicesListBox.Items.OfType<Service>();
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
    }
}
