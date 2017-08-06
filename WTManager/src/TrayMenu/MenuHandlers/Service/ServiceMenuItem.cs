namespace WTManager.TrayMenu.MenuHandlers.Service
{
    public class ServiceMenuItem : WtMenuItem
    {
        protected Config.Service Service { get; private set; }

        protected ServiceMenuItem(IWtTrayMenuController controller, Config.Service service)
            : base(controller)
        {
            this.Service = service;
        }
    }
}