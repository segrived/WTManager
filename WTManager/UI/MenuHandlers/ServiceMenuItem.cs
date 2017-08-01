namespace WTManager.UI.MenuHandlers
{
    public class ServiceMenuItem : WtMenuItem
    {
        protected Service Service { get; private set; }

        public ServiceMenuItem(IWtTrayMenuController controller, Service service)
            : base(controller)
        {
            this.Service = service;
        }
    }
}