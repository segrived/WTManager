using System.Threading.Tasks;
using System.Windows.Forms;
using WTManager.Helpers;

namespace WTManager.TrayMenu.MenuHandlers.Service
{
    public class ServiceRestartMenuItem : ServiceMenuItem
    {
        public ServiceRestartMenuItem(ITrayController controller, Config.Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Restart service";

        protected override string ImageKey => "service-restart";

        protected override bool IsVisible => this.Service.IsStarted;

        protected override async void Action()
        {
            await Task.Factory.StartNew(this.Service.RestartService);
            this.Controller.ShowBaloon("Started", $"Service {this.Service.DisplayName} was restarted", ToolTipIcon.Info);
        }
    }
}