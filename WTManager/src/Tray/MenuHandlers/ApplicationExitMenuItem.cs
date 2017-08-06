using System.Windows.Forms;

namespace WTManager.Tray.MenuHandlers
{
    public class ApplicationExitMenuItem : WtMenuItem
    {
        public ApplicationExitMenuItem(ITrayController controller) 
            : base(controller) { }

        protected override string DisplayText => "Exit";

        protected override string ImageKey => "app-exit";

        protected override void Action()
        {
            Application.Exit();
        }
    }
}