using System.Windows.Forms;
using WTManager.Controls.WtStyle.WtConfigurator;

namespace WTManager.VisualItemRenderers
{
    public abstract class VisualItemRenderer
    {
        public Control Control { get; private set; }

        protected IVisualProviderObject VisualProvider { get; private set; }

        protected VisualItemRenderer(IVisualProviderObject provider)
        {
            this.VisualProvider = provider;
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