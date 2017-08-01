using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Helpers;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceRestartMenuItem : ServiceMenuItem
    {
        public ServiceRestartMenuItem(IWtTrayMenuController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Restart service";

        protected override string ImageKey => "reload";

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.RestartService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was restarted", ToolTipIcon.Info);
        }
    }
}