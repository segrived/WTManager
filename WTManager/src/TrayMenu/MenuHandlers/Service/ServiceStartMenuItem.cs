using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Helpers;

namespace WTManager.TrayMenu.MenuHandlers.Service
{
    public class ServiceStartMenuItem : ServiceMenuItem
    {
        public ServiceStartMenuItem(ITrayController controller, Config.Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Start service";

        protected override string ImageKey => "service-start";

        protected override bool IsVisible => this.Service.IsStopped;

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.StartService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was started", ToolTipIcon.Info);
        }
    }
}