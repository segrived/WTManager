namespace WTManager.UI.MenuHandlers
{
    public class AppConfigMenuItem : WtMenuItem
    {
        public AppConfigMenuItem(IWtTrayMenuController controller) 
            : base(controller) { }

        protected override string DisplayText => "Program configuration";

        protected override string ImageKey => "config";

        protected override void Action()
        {
            new ConfigurationForm().ShowDialog();
        }
    }
}