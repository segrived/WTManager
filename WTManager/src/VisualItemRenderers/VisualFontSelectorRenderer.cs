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

        protected override Control CreateControl()
        {
            return new WtFontSelector();
        }

        public override void SetValue(object value)
        {
            ((WtFontSelector) this.Control).CurrentState = (Font)value;
        }

        public override object GetValue()
        {
            return ((WtFontSelector) this.Control).CurrentState;
        }
    }
}