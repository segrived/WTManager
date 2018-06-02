using System.Windows.Forms;
using WtManager.Controls.WtStyle;
using WtManager.Controls.WtStyle.WtConfigurator;

namespace WtManager.VisualItemRenderers
{
    public class VisualFileSelectorRenderer : VisualItemRenderer
    {
        public VisualFileSelectorRenderer(IVisualSourceObject source) 
            : base(source) { }

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
        public VisualDirectorySelectorRenderer(IVisualSourceObject source) 
            : base(source) { }

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