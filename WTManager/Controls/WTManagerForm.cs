using System.Drawing;
using System.Windows.Forms;

namespace WTManager.Controls
{
    [System.ComponentModel.DesignerCategory("")]
    public class WTManagerForm : Form
    {
        public WTManagerForm() : base() {
            this.Font = SystemFonts.MessageBoxFont;
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }
    }
}
