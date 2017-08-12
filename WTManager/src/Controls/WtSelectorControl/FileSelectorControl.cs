using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace WTManager.Controls.WtSelectorControl
{
    public class FileSelectorControl : MetaSelectorControl<string>
    {
        [DisplayName("FileRequestFilter")]  
        public string FileRequestFilter { private get; set; }

        public FileSelectorControl()
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