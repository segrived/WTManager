using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WTManager
{
    public partial class MainForm : Form
    {
        private Dictionary<string, ServiceControllerStatus> StatusCache;
        private readonly Dictionary<string, Image> Icons;

        public MainForm() {
            this.InitializeComponent();
            this.StatusCache = new Dictionary<string, ServiceControllerStatus>();
            this.Icons = new Dictionary<string, Image>();
            this.InitApplication();
        }

        protected override void SetVisibleCore(bool value) {
            base.SetVisibleCore(false);
        }

        private static void OpenInEditor(string fileName) {
            string editorPath;
            if (Preferences.Prefs.EditorPath == null || !File.Exists(Preferences.Prefs.EditorPath)) {
                editorPath = "notepad.exe";
            } else {
                editorPath = Preferences.Prefs.EditorPath;
            }
            Process.Start(editorPath, fileName);
        }

        private void StartService(Service s) {
            s.Controller.Start();
            s.Controller.WaitForStatus(ServiceControllerStatus.Running);
            if (Preferences.Prefs.ShowBaloon) {
                this.trayIcon.ShowBalloonTip(Preferences.Prefs.BaloonTipTime, "Started",
                    $"Service `{s.DisplayName}` was started", ToolTipIcon.Info);
            }
        }

        private void StopService(Service s) {
            s.Controller.Stop();
            s.Controller.WaitForStatus(ServiceControllerStatus.Stopped);
            if (Preferences.Prefs.ShowBaloon) {
                this.trayIcon.ShowBalloonTip(Preferences.Prefs.BaloonTipTime, "Stopped",
                    $"Service `{s.DisplayName}` was stopped", ToolTipIcon.Info);
            }
        }

        private void RestartService(Service s) {
            s.Controller.Stop();
            s.Controller.WaitForStatus(ServiceControllerStatus.Stopped);
            s.Controller.Start();
            s.Controller.WaitForStatus(ServiceControllerStatus.Running);
            if (Preferences.Prefs.ShowBaloon) {
                this.trayIcon.ShowBalloonTip(Preferences.Prefs.BaloonTipTime, "Restarted",
                    $"Service `{s.DisplayName}` was restarted", ToolTipIcon.Info);
            }
        }

        private void InitTrayMenu(bool forceBaloonDisable = false) {
            this.StatusCache.Clear();
            this.trayMenu.Items.Clear();

            var serviceGroups = Helpers.ReadConfigFile().GroupBy(x => x.Group);

            foreach (var group in serviceGroups) {
                if (!String.IsNullOrEmpty(group.Key)) {
                    this.trayMenu.Items.Add(Helpers.CreateMenuHeader(group.Key));
                }
                foreach (var service in group) {
                    var tsmi = new ToolStripMenuItem(service.ServiceInfo.DisplayName) {
                        Tag = service,
                    };

                    var startItem = Helpers.CreateMenuItem("Start Service", this.Icons["start"],
                        async (s, e) => {
                            await Task.Factory.StartNew(() => this.StartService(service));
                            this.UpdateTrayMenu();
                        }, "StartMenuItem");
                    var stopItem = Helpers.CreateMenuItem("Stop service", this.Icons["stop"],
                        async (s, e) => {
                            await Task.Factory.StartNew(() => this.StopService(service));
                            this.UpdateTrayMenu();
                        }, "StopMenuItem");
                    var restartItem = Helpers.CreateMenuItem("Restart service", this.Icons["reload"],
                        async (s, e) => {
                            await Task.Factory.StartNew(() => this.RestartService(service));
                            this.UpdateTrayMenu();
                        }, "RestartMenuItem");

                    tsmi.DropDownItems.Add(startItem);
                    tsmi.DropDownItems.Add(restartItem);
                    tsmi.DropDownItems.Add(stopItem);

                    if (service.HasConfigs) {
                        tsmi.DropDownItems.Add("-");
                        tsmi.DropDownItems.Add(Helpers.CreateMenuHeader("Config files:"));

                        foreach (string configFile in service.Configs) {
                            var title = "Edit " + Path.GetFileName(configFile);
                            var item = Helpers.CreateMenuItem(title, this.Icons["config"], (s, e) => {
                                OpenInEditor(configFile);
                            });
                            tsmi.DropDownItems.Add(item);
                        }
                    }

                    if (service.HasLogs) {
                        tsmi.DropDownItems.Add("-");
                        tsmi.DropDownItems.Add(Helpers.CreateMenuHeader("Log files:"));

                        foreach (string logFile in service.Logs) {
                            var title = "Show " + Path.GetFileName(logFile);
                            var item = Helpers.CreateMenuItem(title, this.Icons["log"], (s, e) => {
                                new LogFileViewer(logFile).Show();
                            });
                            tsmi.DropDownItems.Add(item);
                        }
                    }

                    if (service.HasCommands) {
                        tsmi.DropDownItems.Add("-");
                        tsmi.DropDownItems.Add(Helpers.CreateMenuHeader("Associated commands:"));

                        foreach (var cmd in service.Commands) {
                            var item = Helpers.CreateMenuItem(cmd.Name, this.Icons["command"], (s, e) => {
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

                    if (service.ServiceInfo.OpenInBrowser && service.ServiceInfo.UsedPort != 0) {
                        tsmi.DropDownItems.Add("-");
                        var item = Helpers.CreateMenuItem("Open in browser...", this.Icons["browser"],
                            (s, e) => Process.Start($"http://localhost:{service.ServiceInfo.UsedPort}"), "OpenInBrowserMenuItem");
                        tsmi.DropDownItems.Add(item);
                    }

                    if (service.HasDataDirectory) {
                        var item = Helpers.CreateMenuItem("Open data directory...", this.Icons["folder"],
                            (s, e) => Process.Start(service.DataDirectory));
                        tsmi.DropDownItems.Add(item);
                    }
                    this.trayMenu.Items.Add(tsmi);
                }
                // add separator between groups
                this.trayMenu.Items.Add("-");
            }

            var confMenuItem = Helpers.CreateMenuItem("Open config file", this.Icons["config"],
                (s, e) => OpenInEditor(Helpers.ConfigPath));
            this.trayMenu.Items.Add(confMenuItem);

            var reloadMenuItem = Helpers.CreateMenuItem("Reload configuration", this.Icons["reload"],
                (s, e) => this.InitTrayMenu());
            this.trayMenu.Items.Add(reloadMenuItem);

            var exitMenuItem = Helpers.CreateMenuItem("Exit", this.Icons["exit"],
                (s, e) => Application.Exit());
            this.trayMenu.Items.Add(exitMenuItem);

            if (Preferences.Prefs.ShowBaloon && !forceBaloonDisable) {
                this.trayIcon.ShowBalloonTip(Preferences.Prefs.BaloonTipTime, "Initialized",
                    "Tray menu was initialized", ToolTipIcon.Info);
            }
        }

        private void InitApplication() {
            this.trayMenu.Renderer = new MyToolStripMenuRenderer();

            if (!File.Exists(Helpers.ConfigPath)) {
                var path = Path.GetDirectoryName(Helpers.ConfigPath);
                Directory.CreateDirectory(path);
                File.Create(Helpers.ConfigPath);
            }

            var resSet = IconResources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resSet) {
                string iconName = ((string)entry.Key).ToLower();
                Image iconData = ((Icon)entry.Value).ToBitmap();
                this.Icons.Add(iconName, iconData);
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
                        menuItem.Image = this.Icons["started"];
                        tsMenuItem.DropDownItems["StartMenuItem"].Visible = false;
                        tsMenuItem.DropDownItems["StopMenuItem"].Visible = true;
                        tsMenuItem.DropDownItems["RestartMenuItem"].Visible = true;
                        menuItem.Enabled = true;
                        break;

                    case ServiceControllerStatus.Stopped:
                        menuItem.Image = this.Icons["stopped"];
                        tsMenuItem.DropDownItems["StartMenuItem"].Visible = true;
                        tsMenuItem.DropDownItems["StopMenuItem"].Visible = false;
                        tsMenuItem.DropDownItems["RestartMenuItem"].Visible = false;
                        menuItem.Enabled = true;
                        break;

                    default:
                        menuItem.Image = this.Icons["pending"];
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
    }
}