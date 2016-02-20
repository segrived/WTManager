using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTManager.UI
{

    public partial class ServiceConfigForm : Form
    {
        private List<Service> _services;

        public ServiceConfigForm() {
            InitializeComponent();
            this._services = ConfigManager.Services.ToList();
        }

        private void ServiceConfigForm_Load(object sender, EventArgs e) {
            var items = ConfigManager.Services;
            this.servicesListBox.DisplayMember = "DisplayName";
            this.servicesListBox.Items.AddRange(items.ToArray());
        }

        private void removeServiceBtn_Click(object sender, EventArgs e) {
            var selectedService = this.servicesListBox.SelectedItem;
            if (selectedService != null) {
                this.servicesListBox.Items.Remove(selectedService);
                var serviceInstance = selectedService as Service;
                this._services.Remove(serviceInstance);
            }
        }

        private void applyChangesBtn_Click(object sender, EventArgs e) {
            ConfigManager.Instance.Config.Services = this._services;
            ConfigManager.Instance.SaveConfig();
            this.Close();
        }

        private void addServiceBtn_Click(object sender, EventArgs e) {
            new AddEditServiceForm().ShowDialog();
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
