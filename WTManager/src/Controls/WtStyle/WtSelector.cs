using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WTManager.Controls.WtStyle
{
    public partial class MetaSelector<T> : WtUserControl where T : class
    {
        protected MetaSelector()
        {
            this.InitializeComponent();
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

        public override string ToString()
        {
            return this.SelectedDataTextBox.Text;
        }
    }

    public class WtFontSelector : MetaSelector<Font>
    {
        private readonly FontConverter _fontConverter;

        public WtFontSelector()
        {
            this.SelectedDataTextBox.ReadOnly = true;
            this._fontConverter = new FontConverter();
        }

        protected override Font Request()
        {
            var fontDialog = new FontDialog
            {
                ShowEffects = false,
                ShowApply = false,
                FontMustExist = true
            };

            if (this.CurrentState!= null)
                fontDialog.Font = this.CurrentState;

            return fontDialog.ShowDialog() != DialogResult.OK ? null : fontDialog.Font;
        }

        protected override string Serialize(Font dataObject)
        {
            return this._fontConverter.ConvertToString(dataObject);
        }

        protected override Font Deserialize(string serializedData)
        {
            try
            {
                return this._fontConverter.ConvertFrom(serializedData) as Font;
            }
            catch
            {
                return null;
            }
        }
    }
    
    public class WtFileSelector : MetaSelector<string>
    {
        [Category("WT Controls")]
        [DisplayName("FileRequestFilter")]  
        public string FileRequestFilter { get; set; }

        public WtFileSelector()
        {
            this.FileRequestFilter = String.Empty;
        }

        protected override string Request()
        {
            var dialog = new OpenFileDialog
            {
                Filter = this.FileRequestFilter,
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

        protected override string Deserialize(string serializedData)
        {
            return serializedData;
        }
    }
}