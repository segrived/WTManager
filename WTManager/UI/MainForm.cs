using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WTManager.Controls;
using WTManager.Interop;
using WTManager.UI.MenuHandlers;

namespace WTManager.UI
{
    [DesignerCategory("Form")]
    public partial class MainForm : WtManagerMainForm
    {
        private readonly WtTrayMenu uiTrayMenu;

        private const bool IsShowBaloon = true;
        
        public MainForm() {
            this.InitializeComponent();

            this.uiTrayMenu = new WtTrayMenu(this.trayIcon);

            this.InitApplication();
        }

        private void InitTrayMenu(bool forceBaloonDisable = false) {

            this.trayMenu.Items.Clear();
            ConfigManager.Instance.ReloadConfig();

            var serviceGroups = ConfigManager.Services.GroupBy(s => s.Group);

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

                    var tsmi = new ToolStripMenuItem(service.DisplayName) {
                        Tag = service,
                        DropDownDirection = dropDownDirection
                    };
                        
                    tsmi.DropDownItems.Add(new ServiceStartMenuItem(this.uiTrayMenu, service));
                    tsmi.DropDownItems.Add(new ServiceStopMenuItem(this.uiTrayMenu, service));
                    tsmi.DropDownItems.Add(new ServiceRestartMenuItem(this.uiTrayMenu, service));

                    //#region Service config files
                    //var configFiles = service.ConfigFiles?.Where(File.Exists);
                    //if (!configFiles.IsNullOrEmpty()) {
                    //    tsmi.DropDownItems.Add("-");
                    //    tsmi.DropDownItems.Add(MenuHelpers.CreateMenuHeader("Config files:"));

                    //    foreach (string configFile in configFiles) {
                    //        var title = $"Edit {Path.GetFileName(configFile)}";
                    //        var item = MenuHelpers.CreateMenuItem(title, IconsManager.Icons["config"], (s, e) => {
                    //            this.OpenInEditor(configFile);
                    //        });
                    //        tsmi.DropDownItems.Add(item);
                    //    }
                    //}
                    //#endregion

                    //#region Service log files
                    //var logFiles = service.LogFiles?.Where(File.Exists);
                    //if (!logFiles.IsNullOrEmpty()) {
                    //    tsmi.DropDownItems.Add("-");
                    //    tsmi.DropDownItems.Add(MenuHelpers.CreateMenuHeader("Log files:"));

                    //    foreach (string logFile in logFiles) {
                    //        var title = $"Show {Path.GetFileName(logFile)}";
                    //        var item = MenuHelpers.CreateMenuItem(title, IconsManager.Icons["log"], (s, e) => {
                    //            this.OpenInLogViewer(logFile);
                    //        });
                    //        tsmi.DropDownItems.Add(item);
                    //    }
                    //}
                    //#endregion

                    tsmi.DropDownItems.Add(new ServiceOpenDirectoryMenuItem(this.uiTrayMenu, service));
                    tsmi.DropDownItems.Add(new ServiceOpenBrowserMenuItem(this.uiTrayMenu, service));

                    tsmi.DropDownItems.Add(new SeparatorMenuItem(this.uiTrayMenu));
                    tsmi.DropDownItems.Add(new ServiceEditMenuItem(this.uiTrayMenu, service));

                    this.trayMenu.Items.Add(tsmi);
                }
                this.trayMenu.Items.Add(new SeparatorMenuItem(this.uiTrayMenu));
            }

            this.trayMenu.Items.Add(new AppConfigMenuItem(this.uiTrayMenu));
            this.trayMenu.Items.Add(new ExitMenuItem(this.uiTrayMenu));

            if (!forceBaloonDisable) {
                this.uiTrayMenu.ShowBaloon("Initialized", "Tray menu was initialized", ToolTipIcon.Info);
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
            ConfigManager.Instance.ConfigSaved += () => this.InitTrayMenu(true);

            this.InitTrayMenu(true);
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

        #endregion



        #region Helpers methods


        void OpenInEditor(string fileName)
        {
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