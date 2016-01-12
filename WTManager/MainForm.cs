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
using WTManager.Helpers;

namespace WTManager
{
    public partial class MainForm : Form
    {
        private Dictionary<string, ServiceControllerStatus> StatusCache;

        public MainForm() {
            this.InitializeComponent();
            this.StatusCache = new Dictionary<string, ServiceControllerStatus>();
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

        private void InitTrayMenu(bool forceBaloonDisable = false) {
            this.StatusCache.Clear();
            this.trayMenu.Items.Clear();

            var serviceGroups = SerializationHelpers.ReadServicesConfFile().GroupBy(x => x.Group);

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
                            if (Preferences.Prefs.ShowBaloon) {
                                this.trayIcon.ShowBalloonTip(Preferences.Prefs.BaloonTipTime, "Started",
                                    $"Service `{service.DisplayName}` was started", ToolTipIcon.Info);
                            }
                            this.UpdateTrayMenu();
                        }, "StartMenuItem");
                    var stopItem = MenuHelpers.CreateMenuItem("Stop service", IconsManager.Icons["stop"],
                        async (s, e) => {
                            await Task.Factory.StartNew(() => ServiceHelpers.StopService(service));
                            if (Preferences.Prefs.ShowBaloon) {
                                this.trayIcon.ShowBalloonTip(Preferences.Prefs.BaloonTipTime, "Stopped",
                                    $"Service `{service.DisplayName}` was stopped", ToolTipIcon.Info);
                            }
                            this.UpdateTrayMenu();
                        }, "StopMenuItem");
                    var restartItem = MenuHelpers.CreateMenuItem("Restart service", IconsManager.Icons["reload"],
                        async (s, e) => {
                            await Task.Factory.StartNew(() => ServiceHelpers.RestartService(service));
                            if (Preferences.Prefs.ShowBaloon) {
                                this.trayIcon.ShowBalloonTip(Preferences.Prefs.BaloonTipTime, "Restarted",
                                    $"Service `{service.DisplayName}` was restarted", ToolTipIcon.Info);
                            }
                            this.UpdateTrayMenu();
                        }, "RestartMenuItem");

                    tsmi.DropDownItems.Add(startItem);
                    tsmi.DropDownItems.Add(restartItem);
                    tsmi.DropDownItems.Add(stopItem);

                    if (!service.ConfigFiles.IsNullOrEmpty()) {
                        tsmi.DropDownItems.Add("-");
                        tsmi.DropDownItems.Add(MenuHelpers.CreateMenuHeader("Config files:"));

                        foreach (string configFile in service.ConfigFiles) {
                            var title = "Edit " + Path.GetFileName(configFile);
                            var item = MenuHelpers.CreateMenuItem(title, IconsManager.Icons["config"], (s, e) => {
                                OpenInEditor(configFile);
                            });
                            tsmi.DropDownItems.Add(item);
                        }
                    }

                    if (!service.LogFiles.IsNullOrEmpty()) {
                        tsmi.DropDownItems.Add("-");
                        tsmi.DropDownItems.Add(MenuHelpers.CreateMenuHeader("Log files:"));

                        foreach (string logFile in service.LogFiles) {
                            var title = "Show " + Path.GetFileName(logFile);
                            var item = MenuHelpers.CreateMenuItem(title, IconsManager.Icons["log"], (s, e) => {
                                new LogFileViewer(logFile).Show();
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

                    if (service.OpenInBrowser && service.UsedPort != 0) {
                        tsmi.DropDownItems.Add("-");
                        var item = MenuHelpers.CreateMenuItem("Open in browser...", IconsManager.Icons["browser"],
                            (s, e) => Process.Start($"http://localhost:{service.UsedPort}"), "OpenInBrowserMenuItem");
                        tsmi.DropDownItems.Add(item);
                    }

                    if (!String.IsNullOrEmpty(service.DataDirectory)) {
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
                (s, e) => OpenInEditor(SerializationHelpers.ConfigPath));
            this.trayMenu.Items.Add(confMenuItem);

            var reloadMenuItem = MenuHelpers.CreateMenuItem("Reload configuration", IconsManager.Icons["reload"],
                (s, e) => this.InitTrayMenu());
            this.trayMenu.Items.Add(reloadMenuItem);

            var exitMenuItem = MenuHelpers.CreateMenuItem("Exit", IconsManager.Icons["exit"],
                (s, e) => Application.Exit());
            this.trayMenu.Items.Add(exitMenuItem);

            if (Preferences.Prefs.ShowBaloon && !forceBaloonDisable) {
                this.trayIcon.ShowBalloonTip(Preferences.Prefs.BaloonTipTime, "Initialized",
                    "Tray menu was initialized", ToolTipIcon.Info);
            }
        }

        private void InitApplication() {
            this.trayMenu.Renderer = new MyToolStripMenuRenderer();

            if (!File.Exists(SerializationHelpers.ConfigPath)) {
                var path = Path.GetDirectoryName(SerializationHelpers.ConfigPath);
                Directory.CreateDirectory(path);
                File.Create(SerializationHelpers.ConfigPath);
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
    }
}