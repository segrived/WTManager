using System.Drawing;
using System.Windows.Forms;

namespace WTManager.Controls
{
    public class SystemFontForm : Form
    {
        public SystemFontForm() : base() {
            this.Font = SystemFonts.MessageBoxFont;
        }
    }
}
