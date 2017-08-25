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

        protected override Control CreateControl()
        {
            return new WtFileSelector();
        }

        public override void SetValue(object value)
        {
            ((WtFileSelector) this.Control).CurrentState = (string)value;
        }

        public override object GetValue()
        {
            return ((WtFileSelector) this.Control).CurrentState;
        }
    }

    public class VisualDirectorySelectorRenderer : VisualItemRenderer
    {
        public VisualDirectorySelectorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override Control CreateControl()
        {
            return new WtDirectorySelector();
        }

        public override void SetValue(object value)
        {
            ((WtDirectorySelector) this.Control).CurrentState = (string)value;
        }

        public override object GetValue()
        {
            return ((WtDirectorySelector) this.Control).CurrentState;
        }
    }
}