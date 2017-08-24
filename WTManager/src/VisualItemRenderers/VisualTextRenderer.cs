using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;
using WTManager.Lib;

namespace WTManager.VisualItemRenderers
{
    public class VisualTextRenderer : VisualItemRenderer
    {
        public VisualTextRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        public override Control CreateControl()
        {
            var textBox = new WtTextBox();
            return textBox;
        }

        public override void SetValue(Control control, object value)
        {
            if (value != null)
                ((TextBox) control).Text = value.ToString();
        }

        public override object GetValue(Control control)
        {
            return ((TextBox) control).Text;
        }
    }
}