using System.Diagnostics;

namespace WTManager.Tray.MenuHandlers
{
    class SystemServicesManagerMenuItem : WtMenuItem
    {
        public SystemServicesManagerMenuItem(ITrayController controller) 
            : base(controller) { }

        protected override string DisplayText => "System services manager";

        protected override void Action()
        {
            Process.Start("services.msc");
        }
    }
}
