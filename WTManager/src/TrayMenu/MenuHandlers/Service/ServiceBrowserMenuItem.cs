using System;
using System.Diagnostics;

namespace WTManager.TrayMenu.MenuHandlers.Service
{
    public class ServiceBrowserMenuItem : ServiceMenuItem
    {
        public ServiceBrowserMenuItem(IWtTrayMenuController controller, Config.Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Open in browser…";

        protected override string ImageKey => "browser";

        protected override bool IsVisible => !String.IsNullOrEmpty(this.Service.BrowserUrl);

        protected override void Action()
        {
            Process.Start(this.Service.DataDirectory);
        }
    }
}