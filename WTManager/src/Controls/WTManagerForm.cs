using System.Drawing;
using System.Windows.Forms;

namespace WTManager.Controls
{
    [System.ComponentModel.DesignerCategory("")]
    public class WtManagerForm : Form
    {
        protected WtManagerForm()
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            this.UpdateSystemFont();
        }

        private void UpdateSystemFont()
        {
            this.Font = SystemFonts.MessageBoxFont;
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
