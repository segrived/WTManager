using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
