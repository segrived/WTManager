using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace WTManager
{
    public class Service
    {
        private static readonly HashSet<string> Services =
            ServiceController.GetServices().Select(s => s.ServiceName).ToHashSet();

        public ServiceConfigData ServiceInfo { get; }
        public ServiceController Controller { get; }

        private string GetFullPath(string path) {
            return path.Replace("$b", this.ServiceInfo.BasePath ?? String.Empty);
        }

        private IEnumerable<string> GetFullPath(IEnumerable<string> path) {
            return path.Select(this.GetFullPath);
        }

        public string DisplayName => String.IsNullOrEmpty(this.ServiceInfo.DisplayName)
                                         ? this.Controller.DisplayName
                                         : this.ServiceInfo.DisplayName;

        public string ServiceName => this.ServiceInfo.ServiceName;

        public string Group => this.ServiceInfo.Group;

        public bool HasConfigs => this.ServiceInfo.ConfFiles != null && this.ServiceInfo.ConfFiles.Any();

        public bool HasLogs => this.ServiceInfo.Logs != null && this.ServiceInfo.Logs.Any();

        public IEnumerable<string> Configs => String.IsNullOrEmpty(this.ServiceInfo.BasePath)
                                                      ? this.ServiceInfo.ConfFiles
                                                      : this.ServiceInfo.ConfFiles.Select(this.GetFullPath);

        public bool HasCommands => this.ServiceInfo.Commands != null && this.ServiceInfo.Commands.Any();

        public IEnumerable<ServiceCommand> Commands => ServiceInfo.Commands;

        public IEnumerable<string> Logs => this.GetFullPath(this.ServiceInfo.Logs);

        public bool HasDataDirectory => !String.IsNullOrEmpty(this.ServiceInfo.DataDirectory);

        public string DataDirectory => this.GetFullPath(this.ServiceInfo.DataDirectory);

        public Service(ServiceConfigData serviceInfo) {
            if (!Services.Contains(serviceInfo.ServiceName)) {
                throw new ServiceNotFoundException($"Service #{serviceInfo.ServiceName} not found");
            }
            this.Controller = new ServiceController(serviceInfo.ServiceName);
            this.ServiceInfo = serviceInfo;
        }
    }
}