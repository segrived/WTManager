using System;
using System.IO;
using System.Linq;
using WTManager.Config;
using WTManager.Tray.MenuHandlers;
using WTManager.Tray.MenuHandlers.Service;

namespace WTManager.Tray
{
    /// <summary>
    /// Tray menu generator
    /// </summary>
    public class WtMenuGenerator
    {
        private readonly ITrayController _controller;

        public WtMenuGenerator(ITrayController controller)
        {
            this._controller = controller;
        }

        public void CreateRootMenu()
        {
            var services = ConfigManager.Instance.Config.Services;

            var serviceGroups = services.GroupBy(s => s.Group);

            this._controller.ClearMenu();

            foreach (var group in serviceGroups)
            {
                if (! String.IsNullOrEmpty(group.Key))
                    this._controller.AddMenuItem(new TitleMenuItem(this._controller, group.Key));

                foreach (var service in group)
                    this._controller.AddMenuItem(this.CreateServiceMenu(service));

                this._controller.AddMenuItem(new SeparatorMenuItem(this._controller));
            }

            this._controller.AddMenuItem(new SystemServicesManagerMenuItem(this._controller));
            this._controller.AddMenuItem(new SeparatorMenuItem(this._controller));

            this._controller.AddMenuItem(new ApplicationConfigMenuItem(this._controller));
            this._controller.AddMenuItem(new ApplicationExitMenuItem(this._controller));
        }

        private WtMenuItem CreateServiceMenu(Service service)
        {
            var topServiceMenuItem = new ServiceTopMenuItem(this._controller, service);

            topServiceMenuItem.AddSubItem(new ServiceStartMenuItem(this._controller, service));
            topServiceMenuItem.AddSubItem(new ServiceRestartMenuItem(this._controller, service));
            topServiceMenuItem.AddSubItem(new ServiceStopMenuItem(this._controller, service));

            topServiceMenuItem.AddSubItem(new SeparatorMenuItem(this._controller));

            if (service.ConfigFiles.Count > 0)
            {
                topServiceMenuItem.AddSubItem(new TitleMenuItem(this._controller, "Config files"));
                foreach (string file in service.ConfigFiles.Where(File.Exists))
                    topServiceMenuItem.AddSubItem(new ServiceConfigMenuItem(this._controller, file));

                topServiceMenuItem.AddSubItem(new SeparatorMenuItem(this._controller));
            }
            if (service.LogFiles.Count > 0)
            {
                topServiceMenuItem.AddSubItem(new TitleMenuItem(this._controller, "Log files"));
                foreach (string file in service.LogFiles.Where(File.Exists))
                    topServiceMenuItem.AddSubItem(new ServiceLogMenuItem(this._controller, file));

                topServiceMenuItem.AddSubItem(new SeparatorMenuItem(this._controller));
            }

            topServiceMenuItem.AddSubItem(new ServiceDirectoryMenuItem(this._controller, service));
            topServiceMenuItem.AddSubItem(new ServiceBrowserMenuItem(this._controller, service));

            topServiceMenuItem.AddSubItem(new SeparatorMenuItem(this._controller));

            topServiceMenuItem.AddSubItem(new ServiceEditMenuItem(this._controller, service));

            return topServiceMenuItem;
        }
    }
}