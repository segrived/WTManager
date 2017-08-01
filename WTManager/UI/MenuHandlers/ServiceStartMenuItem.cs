using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Helpers;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceStartMenuItem : ServiceMenuItem
    {
        public ServiceStartMenuItem(IWtTrayMenuController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Start service";

        protected override string ImageKey => "start";

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.StartService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was started", ToolTipIcon.Info);
        }
    }
}