using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceProcess;
using WTManager.Helpers;

namespace WTManager.Config
{
    [Serializable]
    public class Configuration
    {
        public Configuration()
        {
            this.MenuFontName = SystemFonts.MenuFont.Name;
            this.MenuFontSize = SystemFonts.MenuFont.Size;

            this.Services = new List<Service>();
        }

        /// <summary>
        /// Path to config editor executable 
        /// </summary>
        public string EditorPath { get; set; }

        /// <summary>
        /// Path to log viewer executable
        /// </summary>
        public string LogViewerPath { get; set; }

        /// <summary>
        /// Show popups
        /// </summary>
        public bool ShowPopups { get; set; }

        /// <summary>
        /// Path to custom tray icon
        /// </summary>
        public string CustomTrayIcon { get; set; }

        /// <summary>
        /// Show menu beyond taskbar
        /// </summary>
        public bool ShowMenuBeyondTaskbar { get; set; }

        public string MenuFontName { get; set; }

        public float MenuFontSize { get; set; }

        /// <summary>
        /// Services
        /// </summary>
        public List<Service> Services { get; set; }
    }

    [Serializable]
    public class Service
    {
        public Service()
        {
            this.LogFiles = new List<string>();
            this.ConfigFiles = new List<string>();
        }

        /// <summary>
        /// Service name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Service display name (will be displayed in menu)
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Service group (for menu generation)
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Service configuration files
        /// </summary>
        public List<string> ConfigFiles { get; set; }

        /// <summary>
        /// Service log files
        /// </summary>
        public List<string> LogFiles { get; set; }

        /// <summary>
        /// Service data directory (for example WWW for web-servers)
        /// </summary>
        public string DataDirectory { get; set; }

        /// <summary>
        /// Browser URL
        /// </summary>
        public string BrowserUrl { get; set; }

        public bool IsInPendingState
        {
            get
            {
                switch (this.Controller.Status)
                {
                    case ServiceControllerStatus.StopPending:
                    case ServiceControllerStatus.ContinuePending:
                    case ServiceControllerStatus.PausePending:
                    case ServiceControllerStatus.StartPending:
                        return true;
                    default:
                        return false;
                }
            }
        }

        public ServiceController Controller => this.GetController();

        public ServiceControllerStatus Status => this.Controller.Status;

        public bool IsStarted => this.Status == ServiceControllerStatus.Running;

        public bool IsStopped => this.Status == ServiceControllerStatus.Stopped;

        #region Equals/GetHashCode
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            var otherService = (Service)obj;
            return otherService.ServiceName == this.ServiceName;
        }

        public override int GetHashCode()
        {
            return this.ServiceName.GetHashCode();
        }
        #endregion
    }
}
