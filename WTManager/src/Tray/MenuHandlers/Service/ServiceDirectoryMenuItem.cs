using System.Diagnostics;
using System.IO;

namespace WTManager.Tray.MenuHandlers.Service
{
    public class ServiceDirectoryMenuItem : ServiceMenuItem
    {
        public ServiceDirectoryMenuItem(ITrayController controller, Config.Service service) 
            : base(controller, service) { }

        protected override string DisplayText => "Open data directory…";

        protected override string ImageKey => "service-open-data-directory";

        protected override bool IsVisible => Directory.Exists(this.Service.DataDirectory);

        protected override void Action()
        {
            Process.Start(this.Service.DataDirectory);
        }
    }
}