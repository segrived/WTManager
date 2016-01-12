using System;
using System.Drawing;
using System.Windows.Forms;

namespace WTManager.Helpers
{
    public static class MenuHelpers
    {
        public static ToolStripMenuItem CreateMenuHeader(string text) {
            return new ToolStripMenuItem(text) {
                TextAlign = ContentAlignment.TopCenter,
                Enabled = false,
                Font = new Font(FontFamily.GenericSansSerif, 9.0f, FontStyle.Bold)
            };
        }

        public static ToolStripMenuItem CreateMenuItem(string text, Image icon, EventHandler handler, string name = null) {
            var item = new ToolStripMenuItem(text) { Image = icon, Name = name };
            item.Click += handler;
            return item;
        }
    }
}
