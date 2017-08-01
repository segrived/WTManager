using System.Diagnostics;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceOpenDirectoryMenuItem : ServiceMenuItem
    {
        public ServiceOpenDirectoryMenuItem(IWtTrayMenuController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Open data directory…";

        protected override string ImageKey => "folder";

        protected override void Action()
        {
            Process.Start($"http://{this.Service.BrowserUrl}");
        }
    }
}