using System.Diagnostics;

namespace WTManager.UI.MenuHandlers
{
    public class ServiceOpenBrowserMenuItem : ServiceMenuItem
    {
        public ServiceOpenBrowserMenuItem(IWtTrayMenuController controller, Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Open in browser…";

        protected override string ImageKey => "browser";

        protected override void Action()
        {
            Process.Start(this.Service.DataDirectory);
        }
    }
}