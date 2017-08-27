using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;

namespace WTManager.VisualItemRenderers
{
    public class VisualTextRenderer : VisualItemRenderer
    {
        public VisualTextRenderer(IVisualProviderObject provider) 
            : base(provider) { }

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