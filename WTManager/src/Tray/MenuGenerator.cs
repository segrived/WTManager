using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WtManager.Config;

namespace WtManager.Tray
{
    /// <summary>
    /// Tray menu generator
    /// </summary>
    public class MenuGenerator : IMenuGenerator
    {
        private readonly ITrayController _controller;

        public MenuGenerator(ITrayController controller)
        {
            this._controller = controller;
        }

        public IEnumerable<WtMenuItem> GenerateMenu()
        {
            var services = ConfigManager.Instance.Config.Services;

            var serviceGroups = services.GroupBy(s => s.Group).OrderBy(gr => gr.Key);

            var menuItems = new List<WtMenuItem>();

            this._controller.ClearMenu();

            foreach (var group in serviceGroups)
            {
                if (ConfigManager.Instance.Config.UseNestedServiceGroups)
                {
                    var groupMenuItem = new ServiceGroupMenuItem(this._controller, group.Key);

                    foreach (var service in group)
                        groupMenuItem.AddSubItem(this.CreateServiceMenu(service));

                    if (ConfigManager.Instance.Config.ShowServiceGroupOperations)
                    {
                        groupMenuItem.AddSubItem(new SeparatorMenuItem(this._controller));
                        groupMenuItem.AddSubItem(new ServiceGroupStartMenuItem(this._controller, group.Key));
                        groupMenuItem.AddSubItem(new ServiceGroupStopMenuItem(this._controller, group.Key));
                        groupMenuItem.AddSubItem(new ServiceGroupRestartMenuItem(this._controller, group.Key));
                    }
                    menuItems.Add(groupMenuItem);
                }
                else
                {
                    if (!String.IsNullOrEmpty(group.Key))
                        menuItems.Add(new TitleMenuItem(this._controller, group.Key));

                    foreach (var service in group)
                        menuItems.Add(this.CreateServiceMenu(service));
                    
                    menuItems.Add(new SeparatorMenuItem(this._controller));
                }
            }

            if (ConfigManager.Instance.Config.UseNestedServiceGroups)
                menuItems.Add(new SeparatorMenuItem(this._controller));

            menuItems.Add(new ServiceTasksManagerMenuItem(this._controller));
            menuItems.Add(new SystemServicesManagerMenuItem(this._controller));
            menuItems.Add(new SeparatorMenuItem(this._controller));

            menuItems.Add(new ApplicationConfigMenuItem(this._controller));
            menuItems.Add(new ApplicationExitMenuItem(this._controller));

            return menuItems;
        }

        private WtMenuItem CreateServiceMenu(Service service)
        {
            var topServiceMenuItem = new ServiceTopMenuItem(this._controller, service);

            topServiceMenuItem.AddSubItem(new ServiceStartMenuItem(this._controller, service));
            topServiceMenuItem.AddSubItem(new ServiceRestartMenuItem(this._controller, service));
            topServiceMenuItem.AddSubItem(new ServiceStopMenuItem(this._controller, service));

            topServiceMenuItem.AddSubItem(new SeparatorMenuItem(this._controller));

            if (service.ConfigFiles.Any())
            {
                topServiceMenuItem.AddSubItem(new TitleMenuItem(this._controller, "Config files"));
                foreach (string file in service.ConfigFiles.Where(File.Exists))
                    topServiceMenuItem.AddSubItem(new ServiceConfigMenuItem(this._controller, file));

                topServiceMenuItem.AddSubItem(new SeparatorMenuItem(this._controller));
            }
            if (service.LogFiles.Any())
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

    #region Utils

    public interface IMenuGenerator
    {
        IEnumerable<WtMenuItem> GenerateMenu();
    }

    #endregion
}