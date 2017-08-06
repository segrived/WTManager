using WTManager.Forms;

namespace WTManager.Tray.MenuHandlers
{
    public class ApplicationConfigMenuItem : WtMenuItem
    {
        public ApplicationConfigMenuItem(ITrayController controller) 
            : base(controller) { }

        protected override string DisplayText => "Program configuration";

        protected override string ImageKey => "settings-manager";

        protected override void Action()
        {
            new ConfigurationForm().ShowDialog();
        }
    }
}