namespace WTManager.TrayMenu.MenuHandlers.Service
{
    public class ServiceTopMenuItem : ServiceMenuItem
    {
        public ServiceTopMenuItem(ITrayController controller, Config.Service service)
            : base(controller, service) { }

        protected override string DisplayText => this.Service.DisplayName;

        protected override bool IsEnabled => !this.Service.IsInPendingState;

        protected override string ImageKey
        {
            get
            {
                if (this.Service.IsStarted)
                    return "service-status-started";
                if (this.Service.IsStopped)
                    return "service-status-stopped";
                if (this.Service.IsInPendingState)
                    return "service-status-pending";

                return base.ImageKey;
            }
        }
    }
}