using System.Collections;
using System.Linq;
using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;

namespace WTManager.VisualItemRenderers
{
    public abstract class VisualItemsEditorRenderer<T> : VisualItemRenderer
    {
        protected VisualItemsEditorRenderer(IVisualSourceObject source) 
            : base(source) { }

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

    public class VisualDialogItemsEditorRenderer<T> : VisualItemsEditorRenderer<T> where T : IVisualSourceObject, new()
    {
        public VisualDialogItemsEditorRenderer(IVisualSourceObject source) 
            : base(source) { }

        protected override object CreateHandler()
        {
            var dialog = new WtDialog();

            dialog.AddVisualSourceObject(new VisualSourceItemParameters(new T()));

            if (dialog.ShowModal() == DialogResult.OK)
                return dialog.GetSourceObject<T>();

            return null;
        }

        protected override object EditHandler(object arg)
        {
            var dialog = new WtDialog();
            var visualObject = (T)arg;

            dialog.AddVisualSourceObject(new VisualSourceItemParameters(visualObject));

            if (dialog.ShowModal() == DialogResult.OK)
                return dialog.GetSourceObject<T>();

            return null;
        }
    }
    
    public class VisualFilesItemsEditorRenderer : VisualItemsEditorRenderer<string>
    {
        public VisualFilesItemsEditorRenderer(IVisualSourceObject source) 
            : base(source) { }

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