using System.ComponentModel;
using System.Windows.Forms;

namespace WtManager.Controls.WtStyle
{
    public class WtTextBox : TextBox
    {
        public WtTextBox()
        {
            this.SetControlDefaults();
        }

        private void SetControlDefaults()
        {
            this.AutoSize = false;
        }

        [DefaultValue(false)]
        [Browsable(true)]
        public override bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }
    }
}
