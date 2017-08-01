namespace WTManager.UI.MenuHandlers
{
    public class ServiceTopMenuItem : ServiceMenuItem
    {
        public ServiceTopMenuItem(IWtTrayMenuController controller, Service service)
            : base(controller, service) { }

        protected override string DisplayText => this.Service.DisplayName;
    }
}