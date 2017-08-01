using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Helpers;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceStopMenuItem : ServiceMenuItem
    {
        public ServiceStopMenuItem(IWtTrayMenuController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Stop service";

        protected override string ImageKey => "stop";

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.StopService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was stopped", ToolTipIcon.Info);
        }
    }
}