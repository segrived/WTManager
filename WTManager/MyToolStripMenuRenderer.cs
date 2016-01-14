using System.Drawing;
using System.Windows.Forms;

namespace WTManager
{
    internal class MyColorTable : ProfessionalColorTable
    {
        public override Color ImageMarginGradientBegin {
            get { return Color.White; }
        }

        public override Color ImageMarginGradientMiddle {
            get { return Color.White; }
        }

        public override Color ImageMarginGradientEnd {
            get { return Color.White; }
        }
    }

    internal class MyToolStripMenuRenderer : ToolStripProfessionalRenderer
    {
        public MyToolStripMenuRenderer() : base(new MyColorTable()) {

        }

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