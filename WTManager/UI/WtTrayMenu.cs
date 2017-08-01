using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Controls;
using WTManager.Lib;
using WTManager.UI.MenuHandlers;

namespace WTManager.UI
{
    public class WtTrayMenu : IWtTrayMenuController, IDisposable
    {
        private const int BALOON_SHOW_TIME = 3000;
        private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

        private readonly NotifyIcon _notifyIcon;

        private ContextMenuStrip ContextMenu => this._notifyIcon.ContextMenuStrip;

        private Timer _updateTimer;

        public WtTrayMenu(NotifyIcon uiTrayIcon)
        {
            this._notifyIcon = uiTrayIcon;
            this._notifyIcon.ContextMenuStrip.Opening += this.ContextMenuStrip_OnOpening;
            this._notifyIcon.ContextMenuStrip.MouseUp += this.ContextMenuStrip_OnMouseUp;
            this._notifyIcon.ContextMenuStrip.Renderer = new WtToolStripMenuRenderer();

            this._updateTimer = new Timer {Interval = 1000};
            this._updateTimer.Tick += this.UpdateTimer_OnTick;
            this._updateTimer.Start();
        }

        public void Dispose()
        {
            this._updateTimer.Tick -= this.UpdateTimer_OnTick;
            this._updateTimer.Stop();

            this._notifyIcon.ContextMenuStrip.Opening -= this.ContextMenuStrip_OnOpening;
            this._notifyIcon.ContextMenuStrip.MouseUp -= this.ContextMenuStrip_OnMouseUp;
            this._notifyIcon.Dispose();
        }

        private void ContextMenuStrip_OnMouseUp(object o, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", FLAGS);
            mi.Invoke(this._notifyIcon, null);
        }

        private void ContextMenuStrip_OnOpening(object o, CancelEventArgs cancelEventArgs)
        {
            ToolStripDropDownDirection dropDownDirection;
            switch (Taskbar.Position)
            {
                case TaskbarPosition.Right:
                    dropDownDirection = ToolStripDropDownDirection.Left;
                    break;                
                case TaskbarPosition.Left:
                case TaskbarPosition.Top:
                    dropDownDirection = ToolStripDropDownDirection.Right;
                    break;
                default:
                    dropDownDirection = ToolStripDropDownDirection.Default;
                    break;

            }
            this.ContextMenu.Show(Cursor.Position, dropDownDirection);
        }

        public void ShowBaloon(string title, string message, ToolTipIcon icon)
        {
            if (!Enum.IsDefined(typeof(ToolTipIcon), icon))
                throw new ArgumentOutOfRangeException(nameof(icon));

            this._notifyIcon.ShowBalloonTip(BALOON_SHOW_TIME, title, message, ToolTipIcon.Info);
        }

        public void AddMenuItem(WtMenuItem menuItem)
        {
            this.ContextMenu.Items.Add(menuItem);
        }

        public void ClearMenu()
        {
            this.ContextMenu.Items.Clear();
        }

        public void InitMenu()
        {
            new WtMenuGenerator().CreateRootMenu(this);
            this.UpdateTrayMenu();
        }

        private void UpdateTimer_OnTick(object sender, EventArgs eventArgs)
        {
            this.UpdateTrayMenu();
        }

        private void UpdateTrayMenu()
        {
            foreach (ToolStripItem tsItem in this.ContextMenu.Items)
                this.UpdateMenuItemState(tsItem.Tag as WtMenuItem);
        }

        private void UpdateMenuItemState(WtMenuItem menuItem)
        {
            if (menuItem == null)
                return;

            menuItem.UpdateState();

            if (menuItem.SubItems == null || menuItem.SubItems.Count == 0)
                return;

            foreach(var subItem in menuItem.SubItems)
                this.UpdateMenuItemState(subItem);
        }
    }

    public class WtMenuGenerator
    {
        public void CreateRootMenu(IWtTrayMenuController controller)
        {
            var services = ConfigManager.Services;

            var serviceGroups = services.GroupBy(s => s.Group);

            controller.ClearMenu();

            foreach (var group in serviceGroups)
            {
                foreach (var service in group)
                    controller.AddMenuItem(this.CreateServiceMenu(controller, service));

                controller.AddMenuItem(new SeparatorMenuItem(controller));
            }

            controller.AddMenuItem(new AppConfigMenuItem(controller));
            controller.AddMenuItem(new ExitMenuItem(controller));
        }

        private WtMenuItem CreateServiceMenu(IWtTrayMenuController controller, Service service)
        {
            var topServiceMenuItem = new ServiceTopMenuItem(controller, service);

            topServiceMenuItem.SubItems.Add(new ServiceStartMenuItem(controller, service));
            topServiceMenuItem.SubItems.Add(new ServiceRestartMenuItem(controller, service));

            foreach (string file in service.ConfigFiles.Where(File.Exists))
                topServiceMenuItem.SubItems.Add(new ServiceOpenConfigMenuItem(controller, file));

            foreach (string file in service.LogFiles.Where(File.Exists))
                topServiceMenuItem.SubItems.Add(new ServiceOpenLogMenuItem(controller, file));

            topServiceMenuItem.SubItems.Add(new ServiceOpenDirectoryMenuItem(controller, service));
            topServiceMenuItem.SubItems.Add(new ServiceOpenBrowserMenuItem(controller, service));
            topServiceMenuItem.SubItems.Add(new SeparatorMenuItem(controller));
            topServiceMenuItem.SubItems.Add(new ServiceEditMenuItem(controller, service));

            return topServiceMenuItem;
        }
    }
}