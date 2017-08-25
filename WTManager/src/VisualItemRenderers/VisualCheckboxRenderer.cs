using System;
using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;
using WTManager.Lib;

namespace WTManager.VisualItemRenderers
{
    public class VisualCheckboxRenderer : VisualItemRenderer, IDependentStateProvider
    {
        public VisualCheckboxRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override Control CreateControl()
        {
            var checkbox = new WtCheckBox();
            checkbox.CheckedChanged += this.Checkbox_OnCheckedChanged;
            return checkbox;
        }

        public override void SetValue(object value)
        {
            if (!(value is bool))
                return;

            ((WtCheckBox)this.Control).Checked = (bool)value;
        }

        public override object GetValue()
        {
            return ((WtCheckBox)this.Control).Checked;
        }

        public override bool SetLabel(string text, LabelRendererConfiguration config)
        {
            this.Control.Text = text;
            return true;
        }

        public event Action<string, bool> StateChanged;
        public bool CurrentState => (this.Control as WtCheckBox)?.Checked ?? false;

        private void Checkbox_OnCheckedChanged(object sender, EventArgs eventArgs)
        {
            if (!(sender is WtCheckBox checkbox))
                return;

            this.StateChanged?.Invoke(checkbox.Name, checkbox.Checked);
        }
    }
}