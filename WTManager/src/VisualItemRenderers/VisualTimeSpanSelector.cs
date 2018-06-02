using System.Windows.Forms;
using WtManager.Controls.WtStyle;
using WtManager.Controls.WtStyle.WtConfigurator;

namespace WtManager.VisualItemRenderers
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