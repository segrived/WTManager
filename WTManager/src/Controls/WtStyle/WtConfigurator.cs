using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Lib;

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



            var propertyGroups = this.GroupProperties(propClass);
            foreach (var propertyGroup in propertyGroups)
            {
                var group = this.CreateGroup(propClass, propertyGroup.Key, propertyGroup.Value);
                group.Width = this.Width;

                group.Top = topCoord;

                topCoord += group.Height + 10;


                this.Controls.Add(group);
            }
        }

        private GroupBox CreateGroup<T>(T propClass, string groupName, IEnumerable<PropertyInfo> props)
        {
            var group = new GroupBox { Text = groupName };
            var panel = new Panel { Dock = DockStyle.Fill };
            group.Controls.Add(panel);

            int initTop = 0;

            foreach (var prop in props)
            {
                var rendererAttr = prop.GetCustomAttribute<VisualItemRendererAttribute>();

                if (rendererAttr == null)
                    continue;

                var renderer = Activator.CreateInstance(rendererAttr.RendererType) as VisualItemRenderer;

                if (renderer == null)
                    continue;

                var control = renderer.CreateControl();

                control.Left = this.HorizontalItemPadding;
                control.Width = panel.Width - this.HorizontalItemPadding * 2;

                control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                control.Top = initTop;
                control.Height = this.ItemHeight;

                if (renderer.UseInnerLabel)
                    renderer.SetLabel(control, rendererAttr.DisplayText);
                else
                {
                    var label = this.CreateLabel(rendererAttr.DisplayText, initTop);
                    control.Left = label.Right;
                    control.Width = panel.Width - label.Right - this.HorizontalItemPadding;

                    panel.Controls.Add(label);
                }

                renderer.SetValue(control, prop.GetValue(propClass));
                control.Tag = new Action(() => prop.SetValue(propClass, renderer.GetValue(control)));

                initTop += this.ItemHeight + this.PaddingBetweenItems;

                panel.Controls.Add(control);
            }

            group.Size = new Size(this.Width, initTop + panel.Top);

            this.Controls.Add(group);

            return group;
        }

        private Dictionary<string, List<PropertyInfo>> GroupProperties<T>(T inptData)
        {
            if (inptData.GetType().GetCustomAttribute<VisualProviderAttribute>() == null)
                return null;

            var propertiesList = inptData.GetType().GetProperties();

            var dict = new Dictionary<string, List<PropertyInfo>>();

            foreach (var prop in propertiesList)
            {
                var rendererInfo = prop.GetCustomAttribute<VisualItemRendererAttribute>();
                if (rendererInfo == null)
                    continue;

                string groupName = String.Empty;

                var groupInfo = prop.GetCustomAttribute<VisualItemRendererGroupAttribute>();
                if (groupInfo != null)
                    groupName = groupInfo.Group;

                if (! dict.ContainsKey(groupName))
                    dict[groupName] = new List<PropertyInfo>();

                dict[groupName].Add(prop);
            }
            return dict;
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
            foreach (Control control in this.GetAllChildren())
            {
                var applySettingAction = control.Tag as Action;
                applySettingAction?.Invoke();
            }
        }

        private IEnumerable<Control> GetAllChildren()
        {
            var stack = new Stack<Control>();
            stack.Push(this);

            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);
                yield return next;
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
}
