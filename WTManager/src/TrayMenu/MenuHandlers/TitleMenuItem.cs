using System.Drawing;

namespace WTManager.TrayMenu.MenuHandlers
{
    public class TitleMenuItem : WtMenuItem
    {
        protected override FontStyle FontStyle => FontStyle.Bold;

        protected override string DisplayText { get; }

        protected override bool IsEnabled => false;

        public TitleMenuItem(IWtTrayMenuController controller, string text)
            : base(controller)
        {
            this.DisplayText = text;
        }

    }
}
