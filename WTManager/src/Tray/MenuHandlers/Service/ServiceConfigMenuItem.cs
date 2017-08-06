using System.Diagnostics;
using System.IO;
using WTManager.Config;

namespace WTManager.Tray.MenuHandlers.Service
{
    public class ServiceConfigMenuItem : FileOperationMenuItem
    {
        public ServiceConfigMenuItem(ITrayController controller, string fileName) 
            : base(controller, fileName) { }

        protected override string DisplayText 
            => $"Edit {Path.GetFileName(this.FileName)}";

        protected override string ImageKey => "service-edit-config";

        protected override void Action()
        {
            bool isValidEditor = File.Exists(ConfigManager.Instance.Config.EditorPath);

            string editorPath = isValidEditor 
                ? "notepad.exe" 
                : ConfigManager.Instance.Config.EditorPath;

            Process.Start(editorPath, this.FileName);
        }
    }
}