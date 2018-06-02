using System.Drawing;
using System.Windows.Forms;

namespace WtManager.Controls
{
    internal class WtToolStripMenuRenderer : ToolStripProfessionalRenderer
    {
        public WtToolStripMenuRenderer() 
            : base(new MyColorTable()) { }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e) 
            => this.DrawBackground(e);

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) 
            => this.DrawBackground(e);

        private void DrawBackground(ToolStripItemRenderEventArgs e)
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