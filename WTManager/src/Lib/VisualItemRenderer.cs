using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WTManager.Controls.WtStyle;
using WTManager.Resources;

namespace WTManager.Lib
{
    public abstract class VisualItemRenderer
    {
        public abstract Control CreateControl();
        
        public abstract void SetValue(Control control, object value);
        public abstract object GetValue(Control control);

        public virtual bool UseInnerLabel => false;

        public virtual void SetLabel(Control control, string text) { }
    }

    public class VisualCheckboxRenderer : VisualItemRenderer
    {
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

        public override bool UseInnerLabel => true;

        public override void SetLabel(Control control, string text)
            => control.Text = text;
    }

    public class VisualFileSelectorRenderer : VisualItemRenderer
    {
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

    public class VisualFontSelectorRenderer : VisualItemRenderer
    {
        public override Control CreateControl()
        {
            return new WtFontSelector();
        }

        public override void SetValue(Control control, object value)
        {
            ((WtFontSelector) control).CurrentState = (Font)value;
        }

        public override object GetValue(Control control)
        {
            return ((WtFontSelector) control).CurrentState;
        }
    }

    public abstract class VisualSelectorRenderer : VisualItemRenderer
    {
        public override Control CreateControl()
        {
            var combobox = new WtComboBox();
            combobox.SetItems(this.GetItems());
            this.PrepareCombobox(combobox);
            return combobox;
        }

        protected abstract IEnumerable<ComboBoxItem> GetItems();

        protected virtual void PrepareCombobox(WtComboBox combobox) {}

        public override void SetValue(Control control, object value)
        {
            ((WtComboBox)control).SelectByValue(value);
        }

        public override object GetValue(Control control)
        {
            return ((WtComboBox) control).GetSelectedValue();
        }
    }

    public class VisualThemeSelectorRenderer : VisualSelectorRenderer
    {
        protected override IEnumerable<ComboBoxItem> GetItems()
        {
            yield return new ComboBoxItem("<Default>", null);
            foreach(string themeName in ResourcesProcessor.GetThemesList())
                yield return new ComboBoxItem(themeName);
        }

        protected override void PrepareCombobox(WtComboBox combobox)
        {
            combobox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}