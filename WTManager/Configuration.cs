using System.Collections.Generic;

namespace WTManager
{
    public class Configuration
    {
        /// <summary>
        /// Program preferences
        /// </summary>
        public Preferences Preferences { get; set; }

        /// <summary>
        /// Services
        /// </summary>
        public IEnumerable<Service> Services { get; set; }

        public static Configuration Defaults =>
            new Configuration { Preferences = new Preferences(), Services = new List<Service>() };
    }

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
        public IEnumerable<string> ConfigFiles { get; set; }

        /// <summary>
        /// Service log files
        /// </summary>
        public IEnumerable<string> LogFiles { get; set; }

        /// <summary>
        /// Service data directory (for example WWW for web-servers)
        /// </summary>
        public string DataDirectory { get; set; }

        /// <summary>
        /// Browser URL
        /// </summary>
        public string BrowserUrl { get; set; }

        #region Equals/GetHashCode
        public override bool Equals(object obj) {
            if (obj == null || GetType() != obj.GetType()) {
                return false;
            }
            var otherService = (Service)obj;
            return otherService.ServiceName == this.ServiceName;
        }

        public override int GetHashCode() {
            return this.ServiceName.GetHashCode();
        }
        #endregion
    }
}
