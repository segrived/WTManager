using System.Windows.Forms;

namespace WTManager.TrayMenu.MenuHandlers
{
    public class ApplicationExitMenuItem : WtMenuItem
    {
        public ApplicationExitMenuItem(IWtTrayMenuController controller) 
            : base(controller) { }

        protected override string DisplayText => "Exit";

        protected override string ImageKey => "exit";

        protected override void Action()
        {
            Application.Exit();
        }
    }
}