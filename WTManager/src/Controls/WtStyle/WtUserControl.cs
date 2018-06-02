using System;
using System.Windows.Forms;
using WtManager.Resources;

namespace WtManager.Controls.WtStyle
{
    public class WtUserControl : UserControl
    {
        protected WtUserControl()
        {
            ResourcesProcessor.ThemeChanged += this.OnThemeChanged;
        }

        protected override void Dispose(bool disposing)
        {
            ResourcesProcessor.ThemeChanged -= this.OnThemeChanged;
            base.Dispose(disposing);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ApplyTheme();
        }

        private void OnThemeChanged() => this.ApplyTheme();

        protected virtual void ApplyTheme() { }
    }
}
