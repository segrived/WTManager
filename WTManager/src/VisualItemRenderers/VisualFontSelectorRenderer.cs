using System.Drawing;
using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;
using WTManager.Lib;

namespace WTManager.VisualItemRenderers
{
    public class VisualFontSelectorRenderer : VisualItemRenderer
    {
        public VisualFontSelectorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        public override Control CreateControl()
        {
            return new WtFontSelector();
        }

        public override void SetValue(Control control, object value)
        {
            ((WtFontSelector) control).CurrentState = (Font)value;
        }

        public override object GetValue(Control control)
        {
            return ((WtFontSelector) control).CurrentState;
        }
    }
}