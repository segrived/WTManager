using System.Drawing;
using System.Windows.Forms;

namespace WTManager.Controls
{
    public sealed class WtToolStripMenuItem : ToolStripMenuItem
    {
        public WtToolStripMenuItem()
        {
            this.Font = new Font(FontFamily.GenericSansSerif, 9.0f, FontStyle.Bold);
            this.Enabled = false;
            this.TextAlign = ContentAlignment.TopCenter;
        }

        public WtToolStripMenuItem(string text) 
            : base(text) { }
    }
}
