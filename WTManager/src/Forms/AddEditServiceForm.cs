using System;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
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
            this.serviceItemConfiguration.FillSettings(service);
        }

        public AddEditServiceForm()
        {
            this.InitializeComponent();
        }

        private AddEditServiceForm(Service s) : this()
        {
            this.InitForm(s);
        }

        public static Service AddItem()
        {
            var addDialog = new AddEditServiceForm(new Service());
            if (addDialog.ShowDialog() == DialogResult.OK)
                return addDialog.Service;

            return null;
        }

        public static Service EditItem(Service serviceToEdit)
        {
            if (serviceToEdit == null)
                return null;

            var addDialog = new AddEditServiceForm(serviceToEdit);
            if (addDialog.ShowDialog() == DialogResult.OK)
                return addDialog.Service;

            return null;
        }


        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.serviceItemConfiguration.ApplySettings();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void ApplyTheme()
        {
            base.ApplyTheme();

            this.applyBtn.Image = ResourcesProcessor.GetImage("dialog.ok");
            this.cancelBtn.Image = ResourcesProcessor.GetImage("dialog.cancel");
        }
    }
}
