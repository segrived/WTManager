using System.ComponentModel;
using System.Windows.Forms;

namespace WTManager.Controls
{
    public class WtTextBox : TextBox
    {
        public WtTextBox()
        {
            this.InitializeCompontents();
        }

        private void InitializeCompontents()
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

    public class WtComboBox : ComboBox
    {
        
    }
}
