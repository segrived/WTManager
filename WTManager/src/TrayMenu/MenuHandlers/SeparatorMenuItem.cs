using System.Windows.Forms;

namespace WTManager.UI.MenuHandlers
{
    public sealed class SeparatorMenuItem : WtMenuItem
    {
        public SeparatorMenuItem(IWtTrayMenuController controller)
            : base(controller) { }

        protected override ToolStripItem ToMenuItem()
        {
            return new ToolStripSeparator();
        }
    }
}