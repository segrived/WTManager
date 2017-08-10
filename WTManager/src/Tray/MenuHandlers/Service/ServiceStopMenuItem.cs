using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Helpers;

namespace WTManager.Tray.MenuHandlers.Service
{
    public class ServiceStopMenuItem : ServiceMenuItem
    {
        public ServiceStopMenuItem(ITrayController controller, Config.Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Stop service";

        protected override string ImageKey => "service-stop";

        protected override bool IsVisible => this.Service.IsStarted;

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.StopService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was stopped", ToolTipIcon.Info);
        }
    }
}