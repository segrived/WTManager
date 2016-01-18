using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Helpers;

namespace WTManager
{
    public partial class MainForm : Form
    {
        private Dictionary<string, ServiceControllerStatus> StatusCache =
            new Dictionary<string, ServiceControllerStatus>();

        public MainForm() {
            this.InitializeComponent();
            this.InitApplication();
        }

        private void ShowBaloon(string title, string message, ToolTipIcon icon = ToolTipIcon.Info) {
            if (!ConfigManager.Preferences.ShowBaloon) {
                return;
            }
            var timeout = ConfigManager.Preferences.BaloonTipTime;
            this.trayIcon.ShowBalloonTip(timeout, title, message, ToolTipIcon.Info);
        }

        private static void OpenInEditor(string fileName) {
            string editorPath;
            if (String.IsNullOrEmpty(ConfigManager.Preferences.EditorPath) ||
                !File.Exists(ConfigManager.Preferences.EditorPath)) {
                editorPath = "notepad.exe";
            } else {
                editorPath = ConfigManager.Preferences.EditorPath;
            }
            Process.Start(editorPath, fileName);
        }

        private void InitTrayMenu(bool forceBaloonDisable = false) {
            this.StatusCache.Clear();
            this.trayMenu.Items.Clear();
            ConfigManager.Instance.ReloadConfig();

            var serviceGroups = ConfigManager.Services
                .Where(s => ServiceHelpers.IsServiceExists(s.ServiceName))
                .GroupBy(x => x.Group);

            foreach (var group in serviceGroups) {
                if (!String.IsNullOrEmpty(group.Key)) {
                    this.trayMenu.Items.Add(MenuHelpers.CreateMenuHeader(group.Key));
                }
                foreach (var service in group) {
                    var tsmi = new ToolStripMenuItem(service.DisplayName) {
                        Tag = service
                    };

                    var startItem = MenuHelpers.CreateMenuItem("Start Service", IconsManager.Icons["start"],
                        async (s, e) => {
                            await Task.Factory.StartNew(() => ServiceHelpers.StartService(service));
                            this.ShowBaloon("Started", $"Service `{service.DisplayName}` was started");
                            this.UpdateTrayMenu();
                        }, "StartMenuItem");
                    var stopItem = MenuHelpers.CreateMenuItem("Stop service", IconsManager.Icons["stop"],
                        async (s, e) => {
                            await Task.Factory.StartNew(() => ServiceHelpers.StopService(service));
                            this.ShowBaloon("Stopped", $"Service `{service.DisplayName}` was stopped");
                            this.UpdateTrayMenu();
                        }, "StopMenuItem");
                    var restartItem = MenuHelpers.CreateMenuItem("Restart service", IconsManager.Icons["reload"],
                        async (s, e) => {
                            await Task.Factory.StartNew(() => ServiceHelpers.RestartService(service));
                            this.ShowBaloon("Restrted", $"Service `{service.DisplayName}` was restarted");
                            this.UpdateTrayMenu();
                        }, "RestartMenuItem");

                    tsmi.DropDownItems.Add(startItem);
                    tsmi.DropDownItems.Add(restartItem);
                    tsmi.DropDownItems.Add(stopItem);

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
                    var logFiles = service.LogFiles?.Where(File.Exists);
                    if (!logFiles.IsNullOrEmpty()) {
                        tsmi.DropDownItems.Add("-");
                        tsmi.DropDownItems.Add(MenuHelpers.CreateMenuHeader("Log files:"));

                        foreach (string logFile in logFiles) {
                            var title = $"Show {Path.GetFileName(logFile)}";
                            var item = MenuHelpers.CreateMenuItem(title, IconsManager.Icons["log"], (s, e) => {
                                var viewer = ConfigManager.Preferences.LogViewerPath;
                                if (String.IsNullOrEmpty(viewer) || viewer == "internal") {
                                    new LogFileViewer(logFile).Show();
                                } else {
                                    if (File.Exists(viewer)) {
                                        Process.Start(viewer, logFile);
                                    } else {
                                        MessageBox.Show($"Can't use selected log viewer `{viewer}`, check your configuration");
                                    }
                                }

                            });
                            tsmi.DropDownItems.Add(item);
                        }
                    }

                    if (!service.Commands.IsNullOrEmpty()) {
                        tsmi.DropDownItems.Add("-");
                        tsmi.DropDownItems.Add(MenuHelpers.CreateMenuHeader("Associated commands:"));

                        foreach (var cmd in service.Commands) {
                            var item = MenuHelpers.CreateMenuItem(cmd.Name, IconsManager.Icons["command"], (s, e) => {
                                try {
                                    Process.Start(cmd.Command, cmd.Arguments);
                                } catch {
                                    MessageBox.Show($"Can't execute command: {cmd.Command}", "ERROR",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            });
                            tsmi.DropDownItems.Add(item);
                        }
                    }

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
                    this.trayMenu.Items.Add(tsmi);
                }
                // add separator between groups
                this.trayMenu.Items.Add("-");
            }

            var confMenuItem = MenuHelpers.CreateMenuItem("Open config file", IconsManager.Icons["config"],
                (s, e) => OpenInEditor(ConfigManager.ConfigPath));
            this.trayMenu.Items.Add(confMenuItem);

            var reloadMenuItem = MenuHelpers.CreateMenuItem("Reload configuration", IconsManager.Icons["reload"],
                (s, e) => this.InitTrayMenu());
            this.trayMenu.Items.Add(reloadMenuItem);

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
                Directory.CreateDirectory(path);
            }

            this.InitTrayMenu(true);
        }

        private void UpdateTrayMenu() {
            foreach (ToolStripItem menuItem in this.trayMenu.Items) {
                if (menuItem is ToolStripSeparator || menuItem.Tag == null)
                    continue;

                var tsMenuItem = (ToolStripMenuItem)menuItem;
                var service = (Service)menuItem.Tag;

                service.Controller.Refresh();
                if (StatusCache.ContainsKey(service.ServiceName) &&
                    service.Controller.Status == StatusCache[service.ServiceName]) {
                    continue;
                }
                StatusCache[service.ServiceName] = service.Controller.Status;
                switch (service.Controller.Status) {
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

        private void trayMenu_Opening(object sender, CancelEventArgs e) {
            this.UpdateTrayMenu();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.CloseReason != CloseReason.UserClosing && e.CloseReason != CloseReason.TaskManagerClosing) {
                return;
            }
            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void trayIcon_MouseUp(object sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Left) {
                return;
            }
            const BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", flags);
            mi.Invoke(this.trayIcon, null);
        }

        protected override void SetVisibleCore(bool value) {
            base.SetVisibleCore(false);
        }
    }
}