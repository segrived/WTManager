using System.Collections;
using System.Linq;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;
using WTManager.Forms;
using WTManager.Lib;

namespace WTManager.VisualItemRenderers
{
    public abstract class VisualItemsEditorRenderer<T> : VisualItemRenderer
    {
        protected VisualItemsEditorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override Control CreateControl()
        {
            var itemEditor = new WtItemEditor
            {
                AddRequest = this.CreateHandler,
                EditRequest = this.EditHandler
            };
            this.ConfigureControl(itemEditor);
            return itemEditor;
        }

        protected virtual void ConfigureControl(WtItemEditor control) { }

        public override void SetValue(object value)
        {
            if (!(value is IEnumerable enumerable))
                return;
            ((WtItemEditor)this.Control).SetItems(enumerable.Cast<object>());
        }

        public override object GetValue()
        {
            return ((WtItemEditor) this.Control).GetItems<T>();
        }

        protected virtual object CreateHandler() => null;

        protected virtual object EditHandler(object arg) => null;
    }

    public class VisualServicesItemsEditorRenderer : VisualItemsEditorRenderer<Service>
    {
        public VisualServicesItemsEditorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override object CreateHandler() 
            => AddEditServiceForm.AddItem();

        protected override object EditHandler(object arg) 
            => AddEditServiceForm.EditItem(arg as Service);
    }

    public class VisualFilesItemsEditorRenderer : VisualItemsEditorRenderer<string>
    {
        public VisualFilesItemsEditorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override void ConfigureControl(WtItemEditor control)
        {
            control.ShowEditButton = false;
            control.ShowUpButton = false;
            control.ShowDownButton = false;
        }

        protected override object CreateHandler()
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                return openFileDialog.FileName;

            return null;
        }
    }
}