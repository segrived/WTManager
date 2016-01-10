using System.Windows.Forms;

namespace WTManager
{
    internal class MyToolStripMenuRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) {
            if (e.Item.Enabled)
                base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) {
            if (e.Item.Enabled)
                base.OnRenderMenuItemBackground(e);
        }
    }
}