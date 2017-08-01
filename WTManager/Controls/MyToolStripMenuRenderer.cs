using System.Drawing;
using System.Windows.Forms;

namespace WTManager.Controls
{
    internal class MyToolStripMenuRenderer : ToolStripProfessionalRenderer
    {
        public MyToolStripMenuRenderer() 
            : base(new MyColorTable()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
                base.OnRenderMenuItemBackground(e);
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
                base.OnRenderMenuItemBackground(e);
        }

        private class MyColorTable : ProfessionalColorTable
        {
            public override Color ImageMarginGradientBegin  => Color.White;
            public override Color ImageMarginGradientMiddle => Color.White;
            public override Color ImageMarginGradientEnd    => Color.White;
        }
    }
}