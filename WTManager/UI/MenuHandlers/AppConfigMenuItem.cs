namespace WTManager.UI.MenuHandlers
{
    public class AppConfigMenuItem : WtMenuItem
    {
        public AppConfigMenuItem(IWtTrayMenuController controller) 
            : base(controller) { }

        protected override string DisplayText { get; } = "Program configuration";

        protected override void Action()
        {
            new ConfigurationForm().ShowDialog();
        }
    }
}