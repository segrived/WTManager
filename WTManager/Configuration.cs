using System.Collections.Generic;

namespace WTManager
{
    public class Configuration
    {
        public Preferences Preferences { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }

    public class Preferences
    {
        public string EditorPath { get; set; }
        public bool ShowBaloon { get; set; }
        public int BaloonTipTime { get; set; }
        public string LogViewerPath { get; set; }
    }

    public class ServiceCommand
    {
        /// <summary>
        /// Command name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Command argumetns
        /// </summary>
        public string Arguments { get; set; }

        /// <summary>
        /// Path to command
        /// </summary>
        public string Command { get; set; }
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
        /// Service configuration files
        /// </summary>
        public IEnumerable<string> ConfigFiles { get; set; }

        public IEnumerable<string> LogFiles { get; set; }

        public string DataDirectory { get; set; }

        public IEnumerable<ServiceCommand> Commands { get; set; }
        public string BrowserUrl { get; set; }
        public string Group { get; set; }

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
    }
}
