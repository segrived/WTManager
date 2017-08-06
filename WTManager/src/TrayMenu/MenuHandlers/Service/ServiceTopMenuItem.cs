namespace WTManager.TrayMenu.MenuHandlers.Service
{
    public class ServiceTopMenuItem : ServiceMenuItem
    {
        public ServiceTopMenuItem(IWtTrayMenuController controller, Config.Service service)
            : base(controller, service) { }

        protected override string DisplayText => this.Service.DisplayName;

        protected override bool IsEnabled => !this.Service.IsInPendingState;

        protected override string ImageKey
        {
            get
            {
                if (this.Service.IsStarted)
                    return "started";
                if (this.Service.IsStopped)
                    return "stopped";
                if (this.Service.IsInPendingState)
                    return "pending";

                return base.ImageKey;
            }
        }
    }
}