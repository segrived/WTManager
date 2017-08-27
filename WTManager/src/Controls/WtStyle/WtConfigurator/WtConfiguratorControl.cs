using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WTManager.Helpers;
using WTManager.VisualItemRenderers;

namespace WTManager.Controls.WtStyle.WtConfigurator
{
    /// <summary>
    /// !!! TODO: Refactor !!!
    /// </summary>
    public partial class WtConfiguratorControl : WtUserControl
    {
        private int _currentTopCoord;
        private DynamicPropertiesProcessor _processor;

        private readonly List<IDependentStateProvider> _dependentProvidersCache;
        private readonly ScrollableControl _mainPanel;

        public WtConfiguratorControl()
        {
            this._dependentProvidersCache = new List<IDependentStateProvider>();

            this._mainPanel = new ScrollableControl
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            this.Controls.Add(this._mainPanel);
        }

        public void FillSettings(IVisualSourceObject propClass, params string[] groupNames)
        {
            // initialize
            this._currentTopCoord = 0;
            this._processor = new DynamicPropertiesProcessor(propClass);

            if (groupNames == null || groupNames.Length == 0)
                groupNames = this._processor.EnumerateGroupNames().ToArray();

            for (int i = 0; i < groupNames.Length; i++)
            {
                var propertyGroups = this._processor.GetGroupProperties(groupNames[i]);

                // empty group, skipping
                if (propertyGroups.Count == 0)
                    continue;

                bool isLastGroup = i == groupNames.Length - 1;
                var group = this.CreateGroup(propClass, groupNames[i], propertyGroups, this.FillLastGroup && isLastGroup);

                this._currentTopCoord += group.Height;
            }
        }

        private Control CreateGroup(IVisualSourceObject propClass, string groupName, IEnumerable<PropertyInfo> props, bool isLastGroup)
        {
            var mainGroupBoxContainer = new WtGroupSeparator
            {
                Text = groupName,
                Font = this.GroupTitleFont,
                Width = this._mainPanel.Width
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

                if (renderer?.Control == null)
                    continue;

                var customData = prop.GetCustomAttribute<VisualItemCustomizationAttribute>();

                renderer.Control.Font = this.ControlFont;

                int controlHeight = this.ItemHeight;
                if (customData != null && customData.CustomHeight != -1)
                    controlHeight = customData.CustomHeight;

                renderer.Control.Location = new Point(this.HorizontalItemPadding, initTop);
                renderer.Control.Size = new Size(panel.Width - this.HorizontalItemPadding * 2, controlHeight);
                renderer.Control.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
                renderer.Control.Name = prop.Name;

                if (i == properties.Length - 1)
                    lastControl = renderer.Control;

                if ( this.LabelConfiguration.ShowLables)
                {
                    bool setInternalLabelResult = renderer.SetLabel(rendererAttr.DisplayText, this.LabelConfiguration);

                    if (!setInternalLabelResult)
                    {
                        var label = this.CreateLabel(rendererAttr.DisplayText);
                        label.Location = new Point(this.HorizontalItemPadding, initTop);
                        label.Height = controlHeight;

                        renderer.Control.Left = label.Right;
                        renderer.Control.Width = panel.Width - label.Right - this.HorizontalItemPadding;
                        renderer.Control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

                        panel.Controls.Add(label);
                    }
                }

                renderer.SetValue(prop.GetValue(propClass));

                if (renderer is IDependentStateProvider dependentStateProvider)
                    this._dependentProvidersCache.Add(dependentStateProvider);

                void ApplyRendererValue()
                {
                    try { prop.SetValue(propClass, renderer.GetValue()); }
                    catch (Exception) { /* ... */ }
                }

                renderer.Control.Tag = new Action(ApplyRendererValue);

                initTop += controlHeight + this.PaddingBetweenItems;

                panel.Controls.Add(renderer.Control);
            }

            mainGroupBoxContainer.Size = new Size(this._mainPanel.Width, panel.Top + initTop);
            mainGroupBoxContainer.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            mainGroupBoxContainer.Top = this._currentTopCoord;

            if (lastControl != null && this.FillLastControl) 
                lastControl.Anchor |= AnchorStyles.Bottom;

            if (isLastGroup && this._currentTopCoord + initTop < this._mainPanel.Height)
            {
                mainGroupBoxContainer.Height = this._mainPanel.Height - mainGroupBoxContainer.Top;
                mainGroupBoxContainer.Anchor |= AnchorStyles.Bottom;
            }

            this._mainPanel.Controls.Add(mainGroupBoxContainer);

            this.InitDependentControls();

            return mainGroupBoxContainer;
        }

        private void UpdateDependentControlsState(string controlName, bool isChecked)
        {
            this.SuspendLayout();

            var dependentControlNames = this._processor.FindDependentControls(controlName);
            foreach (string depenentControlName in dependentControlNames)
            {
                var control = this.Controls.Find(depenentControlName, true);
                if (control.Length != 1)
                    continue;

                control.First().Enabled = isChecked;
            }

            this.ResumeLayout();
        }

        private void InitDependentControls()
        {
            foreach (var dependencyControl in this._dependentProvidersCache)
            {
                dependencyControl.StateChanged += this.StateProvider_OnStateChanged;

                if (!(dependencyControl is VisualItemRenderer visualItem) || visualItem.Control == null)
                    return;

                this.UpdateDependentControlsState(visualItem.Control.Name, dependencyControl.CurrentState);
            }
        }

        private void StateProvider_OnStateChanged(string controlName, bool isChecked) 
            => this.UpdateDependentControlsState(controlName, isChecked);

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
            if (this.DesignMode)
            {
                using (var titleFont = new Font(DefaultFont, FontStyle.Bold))
                using (var brush = new SolidBrush(Color.Black))
                {
                    e.Graphics.DrawString(this.Name, titleFont, brush, 0, 0);
                    e.Graphics.DrawString("Dynamic configurator", DefaultFont, brush, 0, 20);
                    e.Graphics.DrawString("Use FillSettings<T> method in your code to fill this screen", DefaultFont, brush, 0, 40);
                }
                return;
            }
            base.OnPaint(e);
        }
    }
}
