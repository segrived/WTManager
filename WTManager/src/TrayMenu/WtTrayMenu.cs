using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Helpers;
using WTManager.Lib;

namespace WTManager.TrayMenu
{
    public class WtTrayMenu : IWtTrayMenuController, IDisposable, IEnumerable<WtMenuItem>
    {
        private const int BALOON_SHOW_TIME = 3000;
        private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

        private readonly MethodInfo _showContextMenuMethod = null;
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

            // just cache
            this._showContextMenuMethod = typeof(NotifyIcon).GetMethod("ShowContextMenu", FLAGS);

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
            foreach (var menuItem in this)
                menuItem.Dispose();
  
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

            this._showContextMenuMethod?.Invoke(this._notifyIcon, null);
        }

        private void ContextMenuStrip_OnOpening(object o, CancelEventArgs cancelEventArgs)
        {
            this.ShowContextMenu(this.ContextMenu);
        }

        private void ShowContextMenu(ContextMenuStrip menu)
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
            menu.Show(position, dropDownDirection);
        }

        public void RecreateMenu()
        {
            new WtMenuGenerator(this).CreateRootMenu();
            this.UpdateTrayMenu();
        }

        private void UpdateTimer_OnTick(object sender, EventArgs eventArgs)
        {
            this.UpdateTrayMenu();
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
            foreach (var menuItem in this)
                menuItem.UpdateState();
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

        public IEnumerator<WtMenuItem> GetEnumerator()
        {
            foreach (ToolStripItem tsItem in this.ContextMenu.Items)
            {
                var wtMenuItem = tsItem.Tag as WtMenuItem;

                if (wtMenuItem == null)
                    continue;

                // yield root item
                yield return wtMenuItem;

                foreach (var subItem in wtMenuItem.SubItems.RecursiveSelect(subItem => subItem.SubItems))
                {
                    // recursively yield all sub items
                    yield return subItem;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}