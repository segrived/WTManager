namespace WTManager.Tray.MenuHandlers.Service
{
    public class ServiceMenuItem : WtMenuItem
    {
        protected Config.Service Service { get; private set; }

        protected ServiceMenuItem(ITrayController controller, Config.Service service)
            : base(controller)
        {
            this.Service = service;
        }
    }
}