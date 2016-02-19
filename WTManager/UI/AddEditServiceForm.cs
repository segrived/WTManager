using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Helpers;

namespace WTManager.UI
{
    public partial class AddEditServiceForm : Form
    {
        private enum FormMode { Adding, Editing };

        private FormMode _formMode;
        private Service _service;

        private IEnumerable<string> _groupNames;

        public DialogResult Result { get; private set; }

        private void InitForm() {
            InitializeComponent();

            var groups = ConfigManager.Services.Select(serv => serv.Group);
            this.serviceGroupCb.Items.AddRange(groups.Distinct().ToArray());

            var services = ServiceHelpers.GetAllServices().Select(s => s.ServiceName);
            this.serviceNameCb.Items.AddRange(services.ToArray());
        }

        public AddEditServiceForm() {
            InitForm();
            this._service = new Service();
            this._formMode = FormMode.Adding;
        }

        public AddEditServiceForm(Service s) {
            InitForm();
            this._service = s;
            this._formMode = FormMode.Editing;

            this.serviceNameCb.SelectedItem = s.ServiceName;
            this.serviceDisplayNameTb.Text = s.DisplayName;
            this.serviceGroupCb.Text = s.Group;
        }

        private void AddEditServiceForm_Load(object sender, EventArgs e) {

        }

        private void serviceNameCb_SelectedIndexChanged(object sender, EventArgs e) {
            if (this.serviceNameCb.SelectedItem == null) {
                return;
            }
            this.serviceDisplayNameTb.Text = this.serviceNameCb.Text;
        }
    }
}
