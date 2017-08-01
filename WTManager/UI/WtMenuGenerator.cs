using System.IO;
using System.Linq;
using WTManager.UI.MenuHandlers;

namespace WTManager.UI
{
    /// <summary>
    /// Tray menu generator
    /// </summary>
    public class WtMenuGenerator
    {
        private readonly IWtTrayMenuController _controller;

        public WtMenuGenerator(IWtTrayMenuController controller)
        {
            this._controller = controller;
        }

        public void CreateRootMenu()
        {
            var services = ConfigManager.Services;

            var serviceGroups = services.GroupBy(s => s.Group);

            this._controller.ClearMenu();

            foreach (var group in serviceGroups)
            {
                foreach (var service in group)
                    this._controller.AddMenuItem(this.CreateServiceMenu(service));

                this._controller.AddMenuItem(new SeparatorMenuItem(this._controller));
            }

            this._controller.AddMenuItem(new AppConfigMenuItem(this._controller));
            this._controller.AddMenuItem(new ExitMenuItem(this._controller));
        }

        private WtMenuItem CreateServiceMenu(Service service)
        {
            var topServiceMenuItem = new ServiceTopMenuItem(this._controller, service);

            topServiceMenuItem.SubItems.Add(new ServiceStartMenuItem(this._controller, service));
            topServiceMenuItem.SubItems.Add(new ServiceRestartMenuItem(this._controller, service));
            topServiceMenuItem.SubItems.Add(new ServiceStopMenuItem(this._controller, service));

            topServiceMenuItem.SubItems.Add(new SeparatorMenuItem(this._controller));

            foreach (string file in service.ConfigFiles.Where(File.Exists))
                topServiceMenuItem.SubItems.Add(new ServiceOpenConfigMenuItem(this._controller, file));

            foreach (string file in service.LogFiles.Where(File.Exists))
                topServiceMenuItem.SubItems.Add(new ServiceOpenLogMenuItem(this._controller, file));

            topServiceMenuItem.SubItems.Add(new ServiceOpenDirectoryMenuItem(this._controller, service));
            topServiceMenuItem.SubItems.Add(new ServiceOpenBrowserMenuItem(this._controller, service));
            topServiceMenuItem.SubItems.Add(new SeparatorMenuItem(this._controller));
            topServiceMenuItem.SubItems.Add(new ServiceEditMenuItem(this._controller, service));

            return topServiceMenuItem;
        }
    }
}