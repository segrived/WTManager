using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Controls;
using WTManager.Helpers;
using WTManager.Interop;

namespace WTManager.UI
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class MainForm : WTManagerForm
    {
        private const bool IsShowBaloon = true;
        private const int BaloonShowTime = 3000;

        private Dictionary<string, ServiceControllerStatus> _statusCache =
            new Dictionary<string, ServiceControllerStatus>();

        public MainForm() {
            this.InitializeComponent();
            this.InitApplication();
        }

        private void InitTrayMenu(bool forceBaloonDisable = false) {
            this._statusCache.Clear();
            this.trayMenu.Items.Clear();
            ConfigManager.Instance.ReloadConfig();

            var serviceGroups = ConfigManager.Services
                ?.Where(s => ServiceHelpers.IsServiceExists(s.ServiceName))
                ?.GroupBy(x => x.Group).ToList();

            if (serviceGroups != null) {
                foreach (var group in serviceGroups) {
                    if (!String.IsNullOrEmpty(group.Key)) {
                        this.trayMenu.Items.Add(MenuHelpers.CreateMenuHeader(group.Key));
                    }
                    foreach (var service in group) {
                        ToolStripDropDownDirection dropDownDirection;
                        switch (Taskbar.Position)
                        {                            
                            case TaskbarPosition.Right:
                                dropDownDirection = ToolStripDropDownDirection.Left;
                                break;
                            case TaskbarPosition.Top:
                            case TaskbarPosition.Bottom:
                            case TaskbarPosition.Left:                                
                            default:
                                dropDownDirection = ToolStripDropDownDirection.Default;
                                break;
                        }                        

                        var tsmi = new ToolStripMenuItem(service.DisplayName) {
                            Tag = service,
                            DropDownDirection = dropDownDirection
                        };

                        #region Service start/restart/stop menu items
                        var startItem = MenuHelpers.CreateMenuItem("Start Service", IconsManager.Icons["start"],
                            async (s, e) => {
                                await Task.Factory.StartNew(() => service.StartService());
                                this.ShowBaloon("Started", $"Service `{service.DisplayName}` was started");
                                this.UpdateTrayMenu();
                            }, "StartMenuItem");
                        var stopItem = MenuHelpers.CreateMenuItem("Stop service", IconsManager.Icons["stop"],
                            async (s, e) => {
                                await Task.Factory.StartNew(() => service.StopService());
                                this.ShowBaloon("Stopped", $"Service `{service.DisplayName}` was stopped");
                                this.UpdateTrayMenu();
                            }, "StopMenuItem");
                        var restartItem = MenuHelpers.CreateMenuItem("Restart service", IconsManager.Icons["reload"],
                            async (s, e) => {
                                await Task.Factory.StartNew(() => service.RestartService());
                                this.ShowBaloon("Restarted", $"Service `{service.DisplayName}` was restarted");
                                this.UpdateTrayMenu();
                            }, "RestartMenuItem");

                        tsmi.DropDownItems.Add(startItem);
                        tsmi.DropDownItems.Add(restartItem);
                        tsmi.DropDownItems.Add(stopItem);
                        #endregion

                        #region Service config files
                        var configFiles = service.ConfigFiles?.Where(File.Exists);
                        if (!configFiles.IsNullOrEmpty()) {
                            tsmi.DropDownItems.Add("-");
                            tsmi.DropDownItems.Add(MenuHelpers.CreateMenuHeader("Config files:"));

                            foreach (string configFile in configFiles) {
                                var title = $"Edit {Path.GetFileName(configFile)}";
                                var item = MenuHelpers.CreateMenuItem(title, IconsManager.Icons["config"], (s, e) => {
                                    OpenInEditor(configFile);
                                });
                                tsmi.DropDownItems.Add(item);
                            }
                        }
                        #endregion

                        #region Service log files
                        var logFiles = service.LogFiles?.Where(File.Exists);
                        if (!logFiles.IsNullOrEmpty()) {
                            tsmi.DropDownItems.Add("-");
                            tsmi.DropDownItems.Add(MenuHelpers.CreateMenuHeader("Log files:"));

                            foreach (string logFile in logFiles) {
                                var title = $"Show {Path.GetFileName(logFile)}";
                                var item = MenuHelpers.CreateMenuItem(title, IconsManager.Icons["log"], (s, e) => {
                                    this.OpenInLogViewer(logFile);
                                });
                                tsmi.DropDownItems.Add(item);
                            }
                        }
                        #endregion

                        #region Additional menu items (data directory / open in browser)
                        if (!String.IsNullOrEmpty(service.BrowserUrl)) {
                            tsmi.DropDownItems.Add("-");
                            var item = MenuHelpers.CreateMenuItem("Open in browser...", IconsManager.Icons["browser"],
                                (s, e) => Process.Start($"http://{service.BrowserUrl}"), "OpenInBrowserMenuItem");
                            tsmi.DropDownItems.Add(item);
                        }

                        if (Directory.Exists(service.DataDirectory)) {
                            var item = MenuHelpers.CreateMenuItem("Open data directory...", IconsManager.Icons["folder"],
                                (s, e) => Process.Start(service.DataDirectory));
                            tsmi.DropDownItems.Add(item);
                        }
                        #endregion

                        #region Service configuration menu item
                        tsmi.DropDownItems.Add("-");
                        var editMenuItem = MenuHelpers.CreateMenuItem("Edit configuration", IconsManager.Icons["config"],
                            (s, e) => new AddEditServiceForm(service).ShowDialog());
                        tsmi.DropDownItems.Add(editMenuItem);
                        #endregion

                        this.trayMenu.Items.Add(tsmi);
                    }
                    // add separator between groups
                    this.trayMenu.Items.Add("-");
                }
            }

            var confFormMenuItem = MenuHelpers.CreateMenuItem("Program configuration", IconsManager.Icons["config"],
                (s, e) => new ConfigurationForm().ShowDialog());
            this.trayMenu.Items.Add(confFormMenuItem);

            var exitMenuItem = MenuHelpers.CreateMenuItem("Exit", IconsManager.Icons["exit"],
                (s, e) => Application.Exit());
            this.trayMenu.Items.Add(exitMenuItem);

            if (!forceBaloonDisable) {
                this.ShowBaloon("Initialized", "Tray menu was initialized");
            }
        }

        private void InitApplication() {
            this.trayMenu.Renderer = new MyToolStripMenuRenderer();

            if (!File.Exists(ConfigManager.ConfigPath)) {
                var path = Path.GetDirectoryName(ConfigManager.ConfigPath);
                if (path != null) {
                    Directory.CreateDirectory(path);
                }
            }
            ConfigManager.Instance.ConfigSaved += (s, e) => this.InitTrayMenu(true);

            this.InitTrayMenu(true);
        }

        private void UpdateTrayMenu() {
            foreach (ToolStripItem menuItem in this.trayMenu.Items) {
                if (menuItem is ToolStripSeparator || menuItem.Tag == null)
                    continue;

                var tsMenuItem = (ToolStripMenuItem)menuItem;
                var service = (Service)menuItem.Tag;

                service.GetController().Refresh();
                if (this._statusCache.ContainsKey(service.ServiceName) &&
                    service.GetController().Status == this._statusCache[service.ServiceName]) {
                    continue;
                }
                this._statusCache[service.ServiceName] = service.GetController().Status;
                switch (service.GetController().Status) {
                    case ServiceControllerStatus.Running:
                        menuItem.Image = IconsManager.Icons["started"];
                        tsMenuItem.DropDownItems["StartMenuItem"].Visible = false;
                        tsMenuItem.DropDownItems["StopMenuItem"].Visible = true;
                        tsMenuItem.DropDownItems["RestartMenuItem"].Visible = true;
                        menuItem.Enabled = true;
                        break;

                    case ServiceControllerStatus.Stopped:
                        menuItem.Image = IconsManager.Icons["stopped"];
                        tsMenuItem.DropDownItems["StartMenuItem"].Visible = true;
                        tsMenuItem.DropDownItems["StopMenuItem"].Visible = false;
                        tsMenuItem.DropDownItems["RestartMenuItem"].Visible = false;
                        menuItem.Enabled = true;
                        break;

                    default:
                        menuItem.Image = IconsManager.Icons["pending"];
                        tsMenuItem.DropDownItems["StartMenuItem"].Visible = false;
                        tsMenuItem.DropDownItems["StopMenuItem"].Visible = false;
                        tsMenuItem.DropDownItems["RestartMenuItem"].Visible = false;
                        menuItem.Enabled = false;
                        break;
                }
            }
        }

        #region UI handlers
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason != CloseReason.UserClosing && e.CloseReason != CloseReason.TaskManagerClosing) {
                return;
            }
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void trayMenu_Opening(object sender, CancelEventArgs e) {
            this.UpdateTrayMenu();
            ContextMenuStrip menuStrip = (sender as ContextMenuStrip);
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
                case TaskbarPosition.Bottom:
                default:
                    dropDownDirection = ToolStripDropDownDirection.Default;
                    break;

            }
            menuStrip.Show(Cursor.Position, dropDownDirection);
        }

        private void trayIcon_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) {
                return;
            }
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", flags);
            mi.Invoke(this.trayIcon, null);
        }
        #endregion

        protected override void SetVisibleCore(bool value) {
            base.SetVisibleCore(false);
        }

        #region Helpers methods
        void ShowBaloon(string title, string message, ToolTipIcon icon = ToolTipIcon.Info) {
            if (!Enum.IsDefined(typeof(ToolTipIcon), icon)) {
                throw new ArgumentOutOfRangeException(nameof(icon));
            }
            this.trayIcon.ShowBalloonTip(BaloonShowTime, title, message, ToolTipIcon.Info);
        }

        void OpenInEditor(string fileName) {
            string editorPath;
            if (String.IsNullOrEmpty(ConfigManager.Preferences.EditorPath) ||
                !File.Exists(ConfigManager.Preferences.EditorPath)) {
                editorPath = "notepad.exe";
            } else {
                editorPath = ConfigManager.Preferences.EditorPath;
            }
            Process.Start(editorPath, fileName);
        }

        void OpenInLogViewer(string fileName) {
            var viewer = ConfigManager.Preferences.LogViewerPath;
            if (String.IsNullOrEmpty(viewer) || viewer == "internal") {
                new LogFileViewerForm(fileName).Show();
                return;
            }
            if (File.Exists(viewer)) {
                Process.Start(viewer, fileName);
            } else {
                MessageBox.Show($"Can't use selected log viewer `{viewer}`, check your configuration");
            }
        }
        #endregion
    }
}