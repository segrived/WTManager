using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;
using WTManager.Lib;

namespace WTManager.VisualItemRenderers
{
    public class VisualFileSelectorRenderer : VisualItemRenderer
    {
        public VisualFileSelectorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        public override Control CreateControl()
        {
            return new WtFileSelector();
        }

        public override void SetValue(Control control, object value)
        {
            ((WtFileSelector) control).CurrentState = (string)value;
        }

        public override object GetValue(Control control)
        {
            return ((WtFileSelector) control).CurrentState;
        }
    }

    public class VisualDirectorySelectorRenderer : VisualItemRenderer
    {
        public VisualDirectorySelectorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        public override Control CreateControl()
        {
            return new WtDirectorySelector();
        }

        public override void SetValue(Control control, object value)
        {
            ((WtDirectorySelector) control).CurrentState = (string)value;
        }

        public override object GetValue(Control control)
        {
            return ((WtDirectorySelector) control).CurrentState;
        }
    }
}