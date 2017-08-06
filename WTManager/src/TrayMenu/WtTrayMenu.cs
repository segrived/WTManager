using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Lib;

namespace WTManager.TrayMenu
{
    public class WtTrayMenu : IWtTrayMenuController, IDisposable
    {
        private const int BALOON_SHOW_TIME = 3000;
        private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

        private readonly NotifyIcon _notifyIcon;
        private readonly Timer _updateTimer;

        private ContextMenuStrip ContextMenu => this._notifyIcon.ContextMenuStrip;

        public WtTrayMenu(NotifyIcon uiTrayIcon)
        {
            this._notifyIcon = uiTrayIcon;
            this._notifyIcon.ContextMenuStrip.Opening += this.ContextMenuStrip_OnOpening;
            this._notifyIcon.ContextMenuStrip.MouseUp += this.ContextMenuStrip_OnMouseUp;
            this._notifyIcon.ContextMenuStrip.Renderer = new WtToolStripMenuRenderer();

            this.UpdateTrayIcon();

            this._updateTimer = new Timer {Interval = 1000};
            this._updateTimer.Tick += this.UpdateTimer_OnTick;
            this._updateTimer.Start();

            ConfigManager.Instance.ConfigSaved += this.Instance_OnConfigSaved;
        }

        private void Instance_OnConfigSaved()
        {
            this.UpdateTrayIcon();
            this.UpdateTrayMenu();
        }

        private void UpdateTrayIcon()
        {
            string customIcon = ConfigManager.Preferences.CustomTrayIcon;

            if (!String.IsNullOrEmpty(customIcon) && File.Exists(customIcon))
                this._notifyIcon.Icon = Icon.ExtractAssociatedIcon(customIcon);
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

            var position = Cursor.Position;
            var dropDownDirection = ToolStripDropDownDirection.Default;

            bool beyondTaskbar = ConfigManager.Preferences.ShowMenuBeyondTaskbar;

            switch (Taskbar.Position)
            {
                case TaskbarPosition.Right:
                    dropDownDirection = ToolStripDropDownDirection.Left;
                    int rightXPos = beyondTaskbar ? Taskbar.CurrentBounds.Left : Cursor.Position.X;
                    position = new Point(rightXPos, Cursor.Position.Y);
                    break;                
                case TaskbarPosition.Left:
                    dropDownDirection = ToolStripDropDownDirection.Right;
                    int leftXPos = beyondTaskbar ? Taskbar.CurrentBounds.Right : Cursor.Position.X;
                    position = new Point(leftXPos, Cursor.Position.Y);
                    break;
                case TaskbarPosition.Top:
                    dropDownDirection = ToolStripDropDownDirection.Right;
                    int topYPos = beyondTaskbar ? Taskbar.CurrentBounds.Bottom : Cursor.Position.Y;
                    position = new Point(Cursor.Position.X, topYPos);
                    break;
                case TaskbarPosition.Bottom:
                    dropDownDirection = ToolStripDropDownDirection.Default;
                    int bottomYPos = beyondTaskbar ? Taskbar.CurrentBounds.Top : Cursor.Position.Y;
                    position = new Point(Cursor.Position.X, bottomYPos - this.ContextMenu.Height);
                    break;
            }
            this.ContextMenu.Show(position, dropDownDirection);
        }

        public void InitMenu()
        {
            new WtMenuGenerator(this).CreateRootMenu();
            this.UpdateTrayMenu();
        }

        private void UpdateTimer_OnTick(object sender, EventArgs eventArgs)
        {
            this.UpdateTrayMenu();
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

        #region IWtTrayMenuController

        public void AddMenuItem(WtMenuItem menuItem)
        {
            this.ContextMenu.Items.Add(menuItem);
        }

        public void ClearMenu()
        {
            this.ContextMenu.Items.Clear();
        }

        public void UpdateTrayMenu()
        {
            foreach (ToolStripItem tsItem in this.ContextMenu.Items)
                this.UpdateMenuItemState(tsItem.Tag as WtMenuItem);
        }

        public void ShowBaloon(string title, string message, ToolTipIcon icon)
        {
            if (!ConfigManager.Preferences.ShowPopups)
                return;

            if (!Enum.IsDefined(typeof(ToolTipIcon), icon))
                throw new ArgumentOutOfRangeException(nameof(icon));

            this._notifyIcon.ShowBalloonTip(BALOON_SHOW_TIME, title, message, ToolTipIcon.Info);
        }

        #endregion
    }
}