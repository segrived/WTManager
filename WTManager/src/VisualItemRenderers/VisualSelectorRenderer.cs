using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls.WtStyle;
using WTManager.Controls.WtStyle.WtConfigurator;
using WTManager.Helpers;
using WTManager.Lib;
using WTManager.Resources;

namespace WTManager.VisualItemRenderers
{
    public abstract class VisualSelectorRenderer : VisualItemRenderer
    {
        protected VisualSelectorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override Control CreateControl()
        {
            var combobox = new WtComboBox {DropDownStyle = ComboBoxStyle.DropDownList};

            combobox.SetItems(this.GetItems());
            this.ConfigureControl(combobox);
            return combobox;
        }

        protected abstract IEnumerable<ComboBoxItem> GetItems();

        protected virtual void ConfigureControl(WtComboBox combobox) {}

        public override void SetValue( object value)
        {
            ((WtComboBox)this.Control).SelectByValue(value);
        }

        public override object GetValue()
        {
            return ((WtComboBox)this.Control).GetSelectedValue();
        }
    }

    public class VisualThemeSelectorRenderer : VisualSelectorRenderer
    {
        public VisualThemeSelectorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override IEnumerable<ComboBoxItem> GetItems()
        {
            yield return new ComboBoxItem("<Default>", null);
            foreach(string themeName in ResourcesProcessor.GetThemesList())
                yield return new ComboBoxItem(themeName);
        }
    }

    public class VisualServiceSelectorRenderer : VisualSelectorRenderer
    {
        public VisualServiceSelectorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override IEnumerable<ComboBoxItem> GetItems() 
            => ServiceHelpers.GetAllServices().Select(s => s.ServiceName).Select(s => new ComboBoxItem(s));
    }

    public class VisualServiceGroupSelectorRenderer : VisualSelectorRenderer
    {
        public VisualServiceGroupSelectorRenderer(IVisualProviderObject provider) 
            : base(provider) { }

        protected override IEnumerable<ComboBoxItem> GetItems()
        {
            if (ConfigManager.Instance.Config.Services != null)
                return ConfigManager.Instance.Config.Services
                    .Select(serv => serv.Group)
                    .Where(g => !String.IsNullOrWhiteSpace(g))
                    .Distinct()
                    .Select(gr => new ComboBoxItem(gr));

            return Enumerable.Empty<ComboBoxItem>();
        }

        protected override void ConfigureControl(WtComboBox combobox)
        {
            combobox.DropDownStyle = ComboBoxStyle.DropDown;
        }
    }
}