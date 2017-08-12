using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

namespace WTManager.Controls.WtSelectorControl
{
    public partial class MetaSelectorControl<T> : UserControl where T : class
    {
        protected MetaSelectorControl()
        {
            this.InitializeComponent();
        }

        public override string ToString()
        {
            return this.SelectedDataTextBox.Text;
        }

        #region Virtual methods

        protected virtual T Request()
        {
            return null;
        }

        protected virtual string Serialize(T dataObject)
        {
            return dataObject.ToString();
        }

        protected virtual T Deserialize(string serializedData)
        {
            return null;
        }

        #endregion

        #region Event handlers

        private void Button_SelectContent_OnClick(object sender, EventArgs e)
        {
            var data = this.Request();

            if (data == null)
                return;

            this.CurrentState = data;
        }

        #endregion

        public T CurrentState
        {
            get { return this.Deserialize(this.SelectedDataTextBox.Text); }
            set { this.UpdateTextBoxValue(value); }
        }

        private void UpdateTextBoxValue(T objectData)
        {
            if (objectData == null)
                return;

            this.SelectedDataTextBox.Text = this.Serialize(objectData);
        }
    }
}