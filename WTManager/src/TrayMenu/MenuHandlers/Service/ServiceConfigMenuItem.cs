using System.Diagnostics;
using System.IO;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceConfigMenuItem : FileOperationMenuItem
    {
        public ServiceConfigMenuItem(IWtTrayMenuController controller, string fileName) 
            : base(controller, fileName) { }

        protected override string DisplayText 
            => $"Edit {Path.GetFileName(this.FileName)}";

        protected override string ImageKey => "config";

        protected override void Action()
        {
            bool isValidEditor = File.Exists(ConfigManager.Preferences.EditorPath);
            string editorPath = isValidEditor ? "notepad.exe" : ConfigManager.Preferences.EditorPath;
            Process.Start(editorPath, this.FileName);
        }
    }
}