using System.Drawing;
using System.Windows.Forms;

namespace WTManager.Controls
{
    [System.ComponentModel.DesignerCategory("")]
    public class WtManagerForm : Form
    {
        protected WtManagerForm()
        {
            this.WtFont = SystemFonts.MessageBoxFont;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private Font WtFont
        {
            get => base.Font;
            set => base.Font = value;
        }
    }


    [System.ComponentModel.DesignerCategory("")]
    public class WtManagerMainForm : WtManagerForm
    {
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(false);
        }
    }
}
