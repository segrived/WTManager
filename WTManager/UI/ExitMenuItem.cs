using System.Windows.Forms;
using WTManager.UI.MenuHandlers;

namespace WTManager.UI
{
    public class ExitMenuItem : WtMenuItem
    {
        public ExitMenuItem(IWtTrayMenuController controller) 
            : base(controller) { }

        protected override string DisplayText { get; } = "Exit";

        protected override void Action()
        {
            Application.Exit();
        }
    }
}