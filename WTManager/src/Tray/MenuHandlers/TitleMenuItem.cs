using System.Drawing;

namespace WTManager.Tray.MenuHandlers
{
    public class TitleMenuItem : WtMenuItem
    {
        protected override FontStyle FontStyle => FontStyle.Bold;

        protected override string DisplayText { get; }

        protected override bool IsEnabled => false;

        public TitleMenuItem(ITrayController controller, string text)
            : base(controller)
        {
            this.DisplayText = text;
        }

    }
}
