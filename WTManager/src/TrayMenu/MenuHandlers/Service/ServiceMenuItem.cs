using System.ServiceProcess;
using WTManager.Helpers;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceMenuItem : WtMenuItem
    {
        protected Service Service { get; private set; }

        protected override bool IsEnabled => 
            this.ServiceStatus == ServiceControllerStatus.Running ||
            this.ServiceStatus == ServiceControllerStatus.Paused || 
            this.ServiceStatus == ServiceControllerStatus.Stopped;

        protected ServiceControllerStatus ServiceStatus
            => this.Service.GetController().Status;

        protected ServiceMenuItem(IWtTrayMenuController controller, Service service)
            : base(controller)
        {
            this.Service = service;
        }
    }
}