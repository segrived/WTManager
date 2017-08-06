using WTManager.Forms;

namespace WTManager.TrayMenu.MenuHandlers
{
    public class ApplicationConfigMenuItem : WtMenuItem
    {
        public ApplicationConfigMenuItem(IWtTrayMenuController controller) 
            : base(controller) { }

        protected override string DisplayText => "Program configuration";

        protected override string ImageKey => "config";

        protected override void Action()
        {
            new ConfigurationForm().ShowDialog();
        }
    }
}