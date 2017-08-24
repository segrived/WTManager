using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Helpers;
using WTManager.Lib;

namespace WTManager.Controls.WtStyle.WtConfigurator
{
    public partial class WtConfigurator : WtUserControl
    {
        private int _currentTopCoord;
        private DynamicPropertiesProcessor _processor;

        public void FillSettings(IVisualProviderObject propClass, params string[] groupNames)
        {
            this._currentTopCoord = 0;

            this._processor = new DynamicPropertiesProcessor(propClass);

            if (groupNames.Length == 0)
                groupNames = this._processor.EnumerateGroupNames().ToArray();

            for (int i = 0; i < groupNames.Length; i++)
            {
                var propertyGroups = this._processor.GetGroupProperties(groupNames[i]);

                bool isLastGroup = i == groupNames.Length - 1;
                var group = this.CreateGroup(propClass, groupNames[i], propertyGroups, this.FillLastGroup && isLastGroup);

                this._currentTopCoord += group.Height + 10;

                this.Controls.Add(group);
            }
        }

        private GroupBox CreateGroup(IVisualProviderObject propClass, string groupName, IEnumerable<PropertyInfo> props, bool isLastGroup)
        {
            var mainGroupBoxContainer = new GroupBox
            {
                Text = groupName,
                Font = this.GroupTitleFont
            };

            var panel = new Panel { Dock = DockStyle.Fill };
            mainGroupBoxContainer.Controls.Add(panel);

            int initTop = 0;

            var properties = props.ToArray();

            Control lastControl = null;

            for (int i = 0; i < properties.Length; i++)
            {
                var prop = properties[i];
                var rendererAttr = prop.GetCustomAttribute<VisualItemAttribute>();

                if (rendererAttr == null)
                    continue;

                var renderer = Activator.CreateInstance(rendererAttr.RendererType, propClass) as VisualItemRenderer;

                if (renderer == null)
                    continue;

                var customData = prop.GetCustomAttribute<VisualItemCustomizationAttribute>();

                var control = renderer.CreateControl();
                control.Font = this.ControlFont;

                int controlHeight = this.ItemHeight;
                if (customData != null && customData.CustomHeight != -1)
                    controlHeight = customData.CustomHeight;

                control.Location = new Point(this.HorizontalItemPadding, initTop);
                control.Size = new Size(panel.Width - this.HorizontalItemPadding * 2, controlHeight);
                control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;

                if (i == properties.Length - 1)
                    lastControl = control;

                if ( this.LabelConfiguration.ShowLables)
                {
                    bool setInternalLabelResult = renderer.SetLabel(control, rendererAttr.DisplayText, this.LabelConfiguration);

                    if (!setInternalLabelResult)
                    {
                        var label = this.CreateLabel(rendererAttr.DisplayText);
                        label.Location = new Point(this.HorizontalItemPadding, initTop);
                        label.Height = controlHeight;

                        control.Left = label.Right;
                        control.Width = panel.Width - label.Right - this.HorizontalItemPadding;
                        control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

                        panel.Controls.Add(label);
                    }
                }

                renderer.SetValue(control, prop.GetValue(propClass));

                void ApplyRendererValue()
                {
                    try { prop.SetValue(propClass, renderer.GetValue(control)); }
                    catch (Exception) { /* ... */ }
                }

                control.Tag = new Action(ApplyRendererValue);

                initTop += controlHeight + this.PaddingBetweenItems;

                panel.Controls.Add(control);
            }

            mainGroupBoxContainer.Size = new Size(this.Width, panel.Top + initTop);
            mainGroupBoxContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            mainGroupBoxContainer.Top = this._currentTopCoord;

            if (lastControl != null && this.FillLastControl) 
                lastControl.Anchor |= AnchorStyles.Bottom;

            if (isLastGroup)
            {
                mainGroupBoxContainer.Height = this.Height - mainGroupBoxContainer.Top;
                mainGroupBoxContainer.Anchor |= AnchorStyles.Bottom;
            }

            this.Controls.Add(mainGroupBoxContainer);

            return mainGroupBoxContainer;
        }

        private Label CreateLabel(string text)
        {
            return new Label
            {
                TextAlign = ContentAlignment.MiddleLeft,
                Anchor = AnchorStyles.Left | AnchorStyles.Top,
                Width = this.LabelWidth,
                Text = $"{text}" + this.LabelConfiguration.LabelPostfix,
                AutoEllipsis = true,
                Font = this.LabelFont
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

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!this.DesignMode)
                return;

            using(var titleFont = new Font(DefaultFont, FontStyle.Bold))
            using(var brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawString(this.Name, titleFont, brush, 0, 0);

                e.Graphics.DrawString("Dynamic configurator", DefaultFont, brush, 0, 20);
                e.Graphics.DrawString("Use FillSettings<T> method in your code to fill this screen", DefaultFont, brush, 0, 40);
            }
        }
    }
}
