using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;
using WTManager.Lib;

namespace WTManager.VisualItemRenderers
{
    public class VisualCheckboxRenderer : VisualItemRenderer
    {
        public VisualCheckboxRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        public override Control CreateControl()
        {
            return new WtCheckBox();
        }

        public override void SetValue(Control control, object value)
        {
            if (!(value is bool))
                return;

            ((WtCheckBox)control).Checked = (bool)value;
        }

        public override object GetValue(Control control)
        {
            return ((WtCheckBox)control).Checked;
        }

        public override bool SetLabel(Control control, string text, LabelRendererConfiguration config)
        {
            control.Text = text;
            return true;
        }
    }
}