using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using WtManager.Controls.WtStyle.WtConfigurator;

namespace WtManager.VisualItemRenderers
{
    public abstract class VisualItemRenderer
    {
        public Control Control { get; private set; }

        protected IVisualSourceObject VisualSource { get; private set; }

        [SuppressMessage("ReSharper", "VirtualMemberCallInConstructor")]
        protected VisualItemRenderer(IVisualSourceObject source)
        {
            this.VisualSource = source;
            this.Control = this.CreateControl();
        }

        protected abstract Control CreateControl();
        
        public abstract void SetValue(object value);

        public abstract object GetValue();

        public virtual bool SetLabel(string text, LabelRendererConfiguration config)
        {
            return false;
        }
    }
}