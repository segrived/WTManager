using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Interop;
using WTManager.UI.MenuHandlers;

namespace WTManager.UI
{
    public class WtTrayMenu : IWtTrayMenuController, IDisposable
    {
        private const int BALOON_SHOW_TIME = 3000;
        private const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.NonPublic;

        private readonly NotifyIcon _notifyIcon;

        private ContextMenuStrip ContextMenu => this._notifyIcon.ContextMenuStrip;

        public WtTrayMenu(NotifyIcon uiTrayIcon)
        {
            this._notifyIcon = uiTrayIcon;
            this._notifyIcon.ContextMenuStrip.Opening += this.ContextMenuStrip_OnOpening;
            this._notifyIcon.ContextMenuStrip.MouseUp += this.ContextMenuStrip_OnMouseUp;
        }

        public void Dispose()
        {
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

        public void InitMenu(IEnumerable<Service> services)
        {
            this.ContextMenu.Items.Clear();

            var serviceGroups = services.GroupBy(s => s.Group);

            foreach (var group in serviceGroups)
            {
                foreach (var service in group)
                {
                    ToolStripDropDownDirection dropDownDirection;
                    switch (Taskbar.Position)
                    {                            
                        case TaskbarPosition.Right:
                            dropDownDirection = ToolStripDropDownDirection.Left;
                            break;
                        default:
                            dropDownDirection = ToolStripDropDownDirection.Default;
                            break;
                    }

                    var tsmi = new ToolStripMenuItem(service.DisplayName)
                    {
                        Tag = service,
                        DropDownDirection = dropDownDirection
                    };
                        
                    tsmi.DropDownItems.Add(new ServiceStartMenuItem(this, service));
                    tsmi.DropDownItems.Add(new ServiceStopMenuItem(this, service));
                    tsmi.DropDownItems.Add(new ServiceRestartMenuItem(this, service));

                    foreach (string file in service.ConfigFiles.Where(File.Exists))
                        tsmi.DropDownItems.Add(new ServiceOpenConfigMenuItem(this, file));

                    foreach (string file in service.LogFiles.Where(File.Exists))
                        tsmi.DropDownItems.Add(new ServiceOpenLogMenuItem(this, file));

                    tsmi.DropDownItems.Add(new ServiceOpenDirectoryMenuItem(this, service));
                    tsmi.DropDownItems.Add(new ServiceOpenBrowserMenuItem(this, service));

                    tsmi.DropDownItems.Add(new SeparatorMenuItem(this));
                    tsmi.DropDownItems.Add(new ServiceEditMenuItem(this, service));

                    this.ContextMenu.Items.Add(tsmi);
                }
                this.ContextMenu.Items.Add(new SeparatorMenuItem(this));
            }

            this.ContextMenu.Items.Add(new AppConfigMenuItem(this));
            this.ContextMenu.Items.Add(new ExitMenuItem(this));
        }

        public void UpdateTrayMenu()
        {

        }
    }
}