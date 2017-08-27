using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;

namespace WTManager.VisualItemRenderers
{
    public class VisualTimeSpanSelector : VisualItemRenderer
    {
        public VisualTimeSpanSelector(IVisualSourceObject source) 
            : base(source) { }

        protected override Control CreateControl()
        {
            return new WtTimeSpanSelector();
        }

        public override void SetValue(object value)
        {
            ((WtTimeSpanSelector) this.Control).Text = value.ToString();
        }

        public override object GetValue()
        {
            return ((WtTimeSpanSelector) this.Control).ToTimeSpan();
        }
    }
}