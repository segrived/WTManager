using System.Windows.Forms;

namespace WTManager.Tray.MenuHandlers
{
    public sealed class SeparatorMenuItem : WtMenuItem
    {
        public SeparatorMenuItem(ITrayController controller)
            : base(controller) { }

        protected override ToolStripItem ToMenuItem()
        {
            return new ToolStripSeparator();
        }
    }
}