using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Forms;
using WTManager.Helpers;

namespace WTManager.Tray
{
    #region Base specialized menu items

    /// <summary>
    /// Base service related menu item, contains reference to linked service
    /// </summary>
    public class ServiceMenuItem : WtMenuItem
    {
        protected Service Service { get; private set; }

        protected ServiceMenuItem(ITrayController controller, Service service)
            : base(controller)
        {
            this.Service = service;
        }
    }

    public class FileOperationMenuItem : WtMenuItem
    {
        protected string FileName { get; private set; }

        protected FileOperationMenuItem(ITrayController controller, string fileName)
            : base(controller)
        {
            this.FileName = fileName;
        }
    }

    #endregion

    #region Service-releted items

    /// <summary>
    /// Service top menu item, contain all other sub items
    /// </summary>
    public class ServiceTopMenuItem : ServiceMenuItem
    {
        public ServiceTopMenuItem(ITrayController controller, Service service)
            : base(controller, service) { }

        protected override string DisplayText => this.Service.DisplayName;

        protected override bool IsEnabled => !this.Service.IsInPendingState();

        protected override string ImageKey
        {
            get
            {
                if (this.Service.IsStarted())
                    return "service-status-started";
                if (this.Service.IsStopped())
                    return "service-status-stopped";
                if (this.Service.IsInPendingState())
                    return "service-status-pending";

                return base.ImageKey;
            }
        }
    }

    public class ServiceGroupMenuItem : WtMenuItem
    {
        private string GroupName { get; set; }

        public ServiceGroupMenuItem(ITrayController controller, string groupName)
            : base(controller)
        {
            this.GroupName = groupName;
        }

        protected override string DisplayText => this.GroupName;
    }

    /// <summary>
    /// "Edit configuration" service menu item
    /// </summary>
    public class ServiceConfigMenuItem : FileOperationMenuItem
    {
        public ServiceConfigMenuItem(ITrayController controller, string fileName) 
            : base(controller, fileName) { }

        protected override string DisplayText 
            => $"Edit {Path.GetFileName(this.FileName)}";

        protected override string ImageKey => "service-edit-config";

        protected override void Action()
        {
            bool isValidEditor = File.Exists(ConfigManager.Instance.Config.ConfigEditorPath);

            // if config editor wasn't set we will just use default notepad application
            string editorPath = !isValidEditor 
                ? "notepad.exe" 
                : ConfigManager.Instance.Config.ConfigEditorPath;

            Process.Start(editorPath, this.FileName);
        }
    }

    /// <summary>
    /// "Open data directory" service menu item
    /// </summary>
    public class ServiceDirectoryMenuItem : ServiceMenuItem
    {
        public ServiceDirectoryMenuItem(ITrayController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Open data directory…";

        protected override string ImageKey => "service-open-data-directory";

        protected override bool IsVisible => Directory.Exists(this.Service.DataDirectory);

        protected override void Action()
        {
            Process.Start(this.Service.DataDirectory);
        }
    }

    /// <summary>
    /// "Open in browser" service memu item
    /// </summary>
    public class ServiceBrowserMenuItem : ServiceMenuItem
    {
        public ServiceBrowserMenuItem(ITrayController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Open in browser…";

        protected override string ImageKey => "service-open-browser";

        protected override bool IsVisible => !String.IsNullOrEmpty(this.Service.BrowserUrl);

        protected override void Action()
        {
            Process.Start($"http://{this.Service.BrowserUrl}");
        }
    }

    /// <summary>
    /// Service signle log entity menu item
    /// </summary>
    public class ServiceLogMenuItem : FileOperationMenuItem
    {
        public ServiceLogMenuItem(ITrayController controller, string fileName) 
            : base(controller, fileName) { }

        protected override string DisplayText 
            => $"Show {Path.GetFileName(this.FileName)}";

        protected override string ImageKey => "service-show-log";

        protected override void Action()
        {
            string viewer = ConfigManager.Instance.Config.LogViewerPath;

            if (string.IsNullOrEmpty(viewer) || viewer == "internal")
            {
                new LogFileViewerForm(this.FileName).Show();
                return;
            }

            if (File.Exists(viewer))
                Process.Start(viewer, this.FileName);
            else
                MessageBox.Show($"Can't use selected log viewer ({viewer}), check your configuration");
        }
    }

    public class ServiceEditMenuItem : ServiceMenuItem
    {
        public ServiceEditMenuItem(ITrayController controller, Service service)
            : base(controller, service) { }

        protected override string DisplayText { get; } = "Edit configuration";

        protected override string ImageKey => "service-config";

        protected override void Action()
        {
            if (AddEditServiceForm.EditItem(this.Service) != null)
                ConfigManager.Instance.SaveConfig();
        }
    }

    public class ServiceRestartMenuItem : ServiceMenuItem
    {
        public ServiceRestartMenuItem(ITrayController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Restart service";

        protected override string ImageKey => "service-restart";

        protected override bool IsVisible => this.Service.IsStarted();

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.RestartService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was restarted", ToolTipIcon.Info);
        }
    }

    public class ServiceStartMenuItem : ServiceMenuItem
    {
        public ServiceStartMenuItem(ITrayController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Start service";

        protected override string ImageKey => "service-start";

        protected override bool IsVisible => this.Service.IsStopped();

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.StartService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was started", ToolTipIcon.Info);
        }
    }

    public class ServiceStopMenuItem : ServiceMenuItem
    {
        public ServiceStopMenuItem(ITrayController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Stop service";

        protected override string ImageKey => "service-stop";

        protected override bool IsVisible => this.Service.IsStarted();

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.StopService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was stopped", ToolTipIcon.Info);
        }
    }

    #endregion
    
    #region Root menu items

    public class SystemServicesManagerMenuItem : WtMenuItem
    {
        public SystemServicesManagerMenuItem(ITrayController controller) 
            : base(controller) { }

        protected override string DisplayText => "System services manager";

        protected override void Action()
        {
            Process.Start("services.msc");
        }
    }

    public class ApplicationConfigMenuItem : WtMenuItem
    {
        public ApplicationConfigMenuItem(ITrayController controller) 
            : base(controller) { }

        protected override string DisplayText => "Program configuration";

        protected override string ImageKey => "settings-manager";

        protected override void Action()
        {
            new ConfigurationForm().ShowDialog();
        }
    }

    public class ApplicationExitMenuItem : WtMenuItem
    {
        public ApplicationExitMenuItem(ITrayController controller) 
            : base(controller) { }

        protected override string DisplayText => "Exit";

        protected override string ImageKey => "app-exit";

        protected override void Action()
        {
            Application.Exit();
        }
    }

    #endregion

    #region Menu handlers

    public class TitleMenuItem : WtMenuItem
    {
        protected override Font ItemFont => ConfigManager.Instance.Config.MenuTitleFont;

        protected override string DisplayText { get; }

        protected override bool IsEnabled => false;

        public TitleMenuItem(ITrayController controller, string text)
            : base(controller)
        {
            this.DisplayText = text;
        }
    }

    public class SeparatorMenuItem : WtMenuItem
    {
        public SeparatorMenuItem(ITrayController controller)
            : base(controller) { }

        protected override ToolStripItem ToMenuItem()
        {
            return new ToolStripSeparator();
        }
    }

    #endregion
}