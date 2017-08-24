using System.Windows.Forms;
using WTManager.Controls.WtStyle.WtConfigurator;

namespace WTManager.Lib
{
    public abstract class VisualItemRenderer
    {
        protected VisualItemRenderer(IVisualProviderObject provider)
        {
            this.VisualProvider = provider;
        }

        protected IVisualProviderObject VisualProvider { get; set; }

        public abstract Control CreateControl();
        
        public abstract void SetValue(Control control, object value);

        public abstract object GetValue(Control control);

        public virtual bool SetLabel(Control control, string text, LabelRendererConfiguration config)
        {
            return false;
        }
    }
}