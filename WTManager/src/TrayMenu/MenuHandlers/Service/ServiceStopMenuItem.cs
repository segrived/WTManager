using System.Threading.Tasks;
using WTManager.Helpers;

namespace WTManager.TrayMenu.MenuHandlers.Service
{
    public class ServiceStopMenuItem : ServiceMenuItem
    {
        public ServiceStopMenuItem(IWtTrayMenuController controller, Config.Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Stop service";

        protected override string ImageKey => "stop";

        protected override bool IsVisible => this.Service.IsStarted;

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.StopService);
            //this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was stopped", ToolTipIcon.Info);
        }
    }
}