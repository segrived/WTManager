using System.Diagnostics;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceOpenDirectoryMenuItem : ServiceMenuItem
    {
        public ServiceOpenDirectoryMenuItem(IWtTrayMenuController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText { get; } = "Open data directory…";

        protected override void Action()
        {
            Process.Start($"http://{this.Service.BrowserUrl}");
        }
    }
}