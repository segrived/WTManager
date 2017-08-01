using System;
using System.Collections.Generic;

namespace WTManager
{
    [Serializable]
    public class Configuration
    {
        /// <summary>
        /// Program preferences
        /// </summary>
        public Preferences Preferences { get; set; }

        /// <summary>
        /// Services
        /// </summary>
        public List<Service> Services { get; set; }

        public static Configuration Defaults =>
            new Configuration { Preferences = new Preferences(), Services = new List<Service>() };
    }

    [Serializable]
    public class Preferences
    {
        /// <summary>
        /// Path to config editor executable 
        /// </summary>
        public string EditorPath { get; set; }

        /// <summary>
        /// Path to log viewer executable
        /// </summary>
        public string LogViewerPath { get; set; }
    }

    [Serializable]
    public class ServiceGroup
    {
        public string ServiceName { get; set; }

        public List<Service> Services { get; set; }

        public ServiceGroup(string name)
        {
            this.ServiceName = name;
            this.Services = new List<Service>();
        }
    }

    [Serializable]
    public class Service
    {
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

        public Service()
        {
            this.LogFiles = new List<string>();
            this.ConfigFiles = new List<string>();
        }

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
