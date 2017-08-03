using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using WTManager.Forms;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceLogMenuItem : FileOperationMenuItem
    {
        public ServiceLogMenuItem(IWtTrayMenuController controller, string fileName) 
            : base(controller, fileName) { }

        protected override string DisplayText 
            => $"Show {Path.GetFileName(this.FileName)}";

        protected override string ImageKey => "log";

        protected override void Action()
        {
            string viewer = ConfigManager.Preferences.LogViewerPath;

            if (string.IsNullOrEmpty(viewer) || viewer == "internal")
            {
                new LogFileViewerForm(this.FileName).Show();
                return;
            }

            if (File.Exists(viewer))
                Process.Start(viewer, this.FileName);
            else
                MessageBox.Show($"Can't use selected log viewer ({viewer}), check your configuration");
        }
    }
}