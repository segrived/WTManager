using System.Drawing;
using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;

namespace WTManager.VisualItemRenderers
{
    public class VisualFontSelectorRenderer : VisualItemRenderer
    {
        public VisualFontSelectorRenderer(IVisualSourceObject source) 
            : base(source) { }

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