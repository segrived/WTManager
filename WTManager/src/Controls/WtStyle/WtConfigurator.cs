using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Lib;
using WTManager.Resources;

namespace WTManager.Controls.WtStyle
{
    public class WtConfigurator : WtUserControl
    {
        #region Designer properties

        [Category("WT Controls")]
        [DisplayName("ItemHeight")]
        private int ItemHeight { get; set; } = 22;

        [Category("WT Controls")]
        [DisplayName("LabelWidth")]
        private int LabelWidth { get; set; } = 120;

        [Category("WT Controls")]
        [DisplayName("HorizontalItemPadding")]
        [Description("Padding on left and right size of each item")]
        private int HorizontalItemPadding { get; set; } = 5;

        [Category("WT Controls")]
        [DisplayName("VerticalPaddingBetweenButtons")]
        private int PaddingBetweenItems { get; set; } = 12;

        #endregion

        public void FillSettings<T>(T propClass)
        {
            int topCoord = 0;

            if (propClass.GetType().GetCustomAttribute<VisualProviderAttribute>() == null)
                return;

            var props = propClass.GetType().GetProperties()
                .Where(prop => prop.GetCustomAttribute<VisualItemRendererAttribute>() != null)
                .OrderBy(prop => prop.GetCustomAttribute<VisualItemRendererAttribute>().SortIndex);

            foreach (var prop in props)
            {
                var rendererAttr = prop.GetCustomAttribute<VisualItemRendererAttribute>();

                if (rendererAttr == null)
                    continue;

                var rendererType = rendererAttr.RendererType;

                if (rendererType == null || ! rendererType.IsSubclassOf(typeof(VisualItemRenderer)))
                    continue;

                var renderer = rendererType
                    .GetConstructor(Type.EmptyTypes)
                    ?.Invoke(new object[] { }) as VisualItemRenderer;

                if (renderer == null)
                    continue;

                var control = renderer.CreateControl();

                control.Left = this.HorizontalItemPadding;
                control.Width = this.Width - this.HorizontalItemPadding * 2;

                control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                control.Top = topCoord;
                control.Height = this.ItemHeight;

                if (renderer.UseInnerLabel)
                    renderer.SetLabel(control, rendererAttr.DisplayText);
                else
                {
                    var label = this.CreateLabel(rendererAttr.DisplayText, topCoord);
                    control.Left = label.Right;
                    control.Width = this.Width - label.Right - this.HorizontalItemPadding;

                    this.Controls.Add(label);
                }

                renderer.SetValue(control, prop.GetValue(propClass));
                control.Tag = new Action(() => prop.SetValue(propClass, renderer.GetValue(control)));

                topCoord += this.ItemHeight + this.PaddingBetweenItems;

                this.Controls.Add(control);
            }
        }

        private Label CreateLabel(string text, int topCoord)
        {
            return new Label
            {
                Height = this.ItemHeight,
                TextAlign = ContentAlignment.MiddleLeft,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Width = this.LabelWidth,
                Top = topCoord,
                Left = this.HorizontalItemPadding,
                Text = $"{text}:"
            };
        }

        public void ApplySettings()
        {
            foreach (Control control in this.Controls)
            {
                var applySettingAction = control.Tag as Action;
                applySettingAction?.Invoke();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!this.DesignMode)
                return;

            e.Graphics.DrawString("Dynamic configurator", DefaultFont, new SolidBrush(Color.Black), 0, 0);
            e.Graphics.DrawString("Use FillSettings<T> method in your code to fill this screen", DefaultFont, new SolidBrush(Color.Black), 0, 20);
        }
    }

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
