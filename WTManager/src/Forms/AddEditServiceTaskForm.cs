using System;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Resources;

namespace WTManager.Forms
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class AddEditServiceTaskForm : WtManagerForm
    {
        public ServiceTask Task { get; private set; }

        private void InitForm(ServiceTask task)
        {
            this.Task = task;
            this.serviceTaskCofiguration.FillSettings(task);
        }

        public AddEditServiceTaskForm()
        {
            this.InitializeComponent();
        }

        private AddEditServiceTaskForm(ServiceTask task) : this()
        {
            this.InitForm(task);
        }

        public static ServiceTask AddItem()
        {
            var addDialog = new AddEditServiceTaskForm(new ServiceTask());
            if (addDialog.ShowDialog() == DialogResult.OK)
                return addDialog.Task;

            return null;
        }

        public static ServiceTask EditItem(ServiceTask serviceToEdit)
        {
            if (serviceToEdit == null)
                return null;

            var addDialog = new AddEditServiceTaskForm(serviceToEdit);
            if (addDialog.ShowDialog() == DialogResult.OK)
                return addDialog.Task;

            return null;
        }


        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            this.serviceTaskCofiguration.ApplySettings();
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
