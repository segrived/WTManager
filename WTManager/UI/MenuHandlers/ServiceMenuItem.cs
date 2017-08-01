using System.ServiceProcess;
using WTManager.Helpers;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceMenuItem : WtMenuItem
    {
        protected Service Service { get; private set; }

        protected ServiceControllerStatus ServiceStatus
            => this.Service.GetController().Status;

        public ServiceMenuItem(IWtTrayMenuController controller, Service service)
            : base(controller)
        {
            this.Service = service;
        }
    }
}