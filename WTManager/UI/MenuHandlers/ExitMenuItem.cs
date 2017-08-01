using System.Windows.Forms;

namespace WTManager.UI.MenuHandlers
{
    public class ExitMenuItem : WtMenuItem
    {
        public ExitMenuItem(IWtTrayMenuController controller) 
            : base(controller) { }

        protected override string DisplayText => "Exit";

        protected override string ImageKey => "exit";

        protected override void Action()
        {
            Application.Exit();
        }
    }
}