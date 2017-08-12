using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Helpers;
using WTManager.Lib;
using WTManager.Resources;

namespace WTManager.Tray
{
    public class TrayMenu : ITrayController, IEnumerable<WtMenuItem>, IDisposable
    {
        private const int BALOON_SHOW_TIME = 10000;
        private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

        private readonly IMenuGenerator _menuGenerator;

        private readonly MethodInfo _showContextMenuMethod;
        private readonly NotifyIcon _notifyIcon;
        private readonly Timer _updateTimer;

        private ContextMenuStrip ContextMenu => this._notifyIcon.ContextMenuStrip;

        public TrayMenu(NotifyIcon uiTrayIcon)
        {
            // Notify icon
            this._notifyIcon = uiTrayIcon;
            this._notifyIcon.MouseUp += this.NotifyIcon_OnMouseUp;

            // Notify icon context menu
            this._notifyIcon.ContextMenuStrip.Opening += this.ContextMenuStrip_OnOpening;
            this._notifyIcon.ContextMenuStrip.Renderer = new WtToolStripMenuRenderer();

            // Update menu items state timer
            this._updateTimer = new Timer {Interval = 1000};
            this._updateTimer.Tick += this.UpdateTimer_OnTick;
            this._updateTimer.Start();

            this._menuGenerator = new MenuGenerator(this);

            this._showContextMenuMethod = typeof(NotifyIcon).GetMethod("ShowContextMenu", FLAGS);

            // Config / theme subscription
            ConfigManager.Instance.ConfigSaved += this.ConfigManager_OnConfigSaved;
            ResourcesProcessor.ThemeChanged += this.ResourcesProcessor_OnThemeChanged;

            this.RecreateMenu();
            this.UpdateTrayIcon();
        }

        private void UpdateTrayIcon()
        {
            this._notifyIcon.Icon = ResourcesProcessor.GetIcon("tray");
        }

        public void Dispose()
        {
            foreach (var menuItem in this)
                menuItem.Dispose();
  
            this._updateTimer.Tick -= this.UpdateTimer_OnTick;
            this._updateTimer.Stop();
            this._updateTimer.Dispose();

            this._notifyIcon.ContextMenuStrip.Opening -= this.ContextMenuStrip_OnOpening;
            this._notifyIcon.MouseUp -= this.NotifyIcon_OnMouseUp;
            this._notifyIcon.Dispose();

            ConfigManager.Instance.ConfigSaved -= this.ConfigManager_OnConfigSaved;
            ResourcesProcessor.ThemeChanged -= this.ResourcesProcessor_OnThemeChanged;
        }

        #region Event handlers

        private void ConfigManager_OnConfigSaved()
        {
            this.RecreateMenu();
        }

        private void ResourcesProcessor_OnThemeChanged()
        {
            this.UpdateTrayIcon();
        }

        private void UpdateTimer_OnTick(object sender, EventArgs eventArgs)
        {
            this.UpdateTrayMenu();
        }

        private void NotifyIcon_OnMouseUp(object o, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left && e.Button != MouseButtons.Right)
                return;

            if (e.Button == MouseButtons.Left && !ConfigManager.Instance.Config.OpenTrayMenuLeftClick)
                return;

            this._showContextMenuMethod?.Invoke(this._notifyIcon, null);
        }

        private void ContextMenuStrip_OnOpening(object o, CancelEventArgs cancelEventArgs)
        {
            this.ShowContextMenu(this.ContextMenu);
        }

        #endregion

        private void ShowContextMenu(ContextMenuStrip menu)
        {
            var position = Cursor.Position;
            var dropDownDirection = ToolStripDropDownDirection.Default;

            bool beyondTaskbar = ConfigManager.Instance.Config.ShowMenuBeyondTaskbar;

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

        private void RecreateMenu()
        {
            this.ClearMenu();

            foreach(var menuItem in this._menuGenerator.GenerateMenu())
                this.AddMenuItem(menuItem);
            
            this.UpdateTrayMenu();
        }

        #region ITrayController

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
            if (!ConfigManager.Instance.Config.ShowPopups)
                return;

            if (!Enum.IsDefined(typeof(ToolTipIcon), icon))
                throw new ArgumentOutOfRangeException(nameof(icon));

            this._notifyIcon.ShowBalloonTip(BALOON_SHOW_TIME, title, message, ToolTipIcon.Info);
        }

        #endregion

        #region IEnumerable implementation

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

        #endregion
    }

    #region Utils

    /// <summary>
    /// Tray menu controller
    /// </summary>
    public interface ITrayController
    {
        /// <summary>
        /// Display system baloon message
        /// </summary>
        /// <param name="title">Message title</param>
        /// <param name="message">Message text</param>
        /// <param name="icon">Message icon key</param>
        void ShowBaloon(string title, string message, ToolTipIcon icon);

        /// <summary>
        /// Adds new item to menu
        /// </summary>
        /// <param name="menuItem">Menu item instance</param>
        void AddMenuItem(WtMenuItem menuItem);

        /// <summary>
        /// Removes all exists menu items
        /// </summary>
        void ClearMenu();

        /// <summary>
        /// Force update all exists menu items
        /// </summary>
        void UpdateTrayMenu();
    }

    #endregion
}