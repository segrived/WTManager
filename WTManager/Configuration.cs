using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;

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
        public string ServiceName { get; set; }

        private string _displayName;
        public string DisplayName {
            get { return _displayName ?? ServiceName; }
            set { _displayName = value; }
        }

        private string _basePath;
        public string BasePath {
            get { return _basePath ?? string.Empty; }
            set { _basePath = value; }
        }

        private IEnumerable<string> _configFiles;
        public IEnumerable<string> ConfigFiles {
            get { return _configFiles?.Select(f => Path.Combine(BasePath, f)); }
            set { _configFiles = value; }
        }

        private IEnumerable<string> _logFiles;
        public IEnumerable<string> LogFiles {
            get { return _logFiles?.Select(f => Path.Combine(BasePath, f)); }
            set { _logFiles = value; }
        }

        private string _dataDirectory;
        public string DataDirectory {
            get
            {
                return String.IsNullOrEmpty(_dataDirectory)
                  ? String.Empty
                  : Path.Combine(BasePath, _dataDirectory ?? String.Empty);
            }
            set { _dataDirectory = value; }
        }

        public IEnumerable<ServiceCommand> Commands { get; set; }
        public string BrowserUrl { get; set; }
        public string Group { get; set; }

        private ServiceController _controller;
        [YamlDotNet.Serialization.YamlIgnore]
        public ServiceController Controller {
            get
            {
                if (_controller == null) {
                    _controller = new ServiceController(ServiceName);
                }
                return _controller;
            }
        }

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
