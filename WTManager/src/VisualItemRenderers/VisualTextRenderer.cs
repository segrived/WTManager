using System.Windows.Forms;
using WtManager.Controls.WtStyle;
using WtManager.Controls.WtStyle.WtConfigurator;

namespace WtManager.VisualItemRenderers
{
    public class VisualTextRenderer : VisualItemRenderer
    {
        public VisualTextRenderer(IVisualSourceObject source) 
            : base(source) { }

        protected override Control CreateControl()
        {
            var textBox = new WtTextBox();
            return textBox;
        }

        public override void SetValue(object value)
        {
            if (value != null)
                ((WtTextBox)this.Control).Text = value.ToString();
        }

        public override object GetValue()
        {
            return ((WtTextBox)this.Control).Text;
        }
    }
}