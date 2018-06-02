using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WtManager.Config;
using WtManager.Controls.WtStyle.WtConfigurator;
using WtManager.Resources;
using WtManager.Helpers;

namespace WtManager.Controls.WtStyle
{
    [System.ComponentModel.DesignerCategory("Form")]
    public partial class WtDialog : WtManagerForm
    {
        private const int BUTTON_WIDTH = 130;
        private const int BUTTON_PADDING = 10;
        private const int BETWEEN_CONIFGURATORS_PADDING = 10;

        private Button _okButton;
        private Button _applyButton;
        private Button _cancelButton;

        private readonly List<DialogItem> _visualSourceObjects;

        public WtDialog()
        {
            this.InitializeComponent();
            this._visualSourceObjects = new List<DialogItem>();
        }

        public void AddVisualSourceObject(DialogItem parameters)
        {
            this._visualSourceObjects.Add(parameters);
        }

        public T GetSourceObject<T>() where T : IVisualSourceObject
        {
            foreach (var visualSource in this._visualSourceObjects)
            {
                if (visualSource.VisualObject is T)
                    return (T)(visualSource.VisualObject);
            }
            return default(T);
        }

        private void PrepareForm()
        {
            if (this._visualSourceObjects.Count < 1)
                return;

            int paddingsTotalWidth = (this._visualSourceObjects.Count - 1) * BETWEEN_CONIFGURATORS_PADDING;

            // configurator width
            int currentLeft = 0;

            float totalScale = this._visualSourceObjects.Sum(s => s.Scale);
            if (totalScale > 1.0f)
                throw new InvalidOperationException("Total scale should be less then 1");
            float dynamicScaleCount = this._visualSourceObjects.Count(s => Math.Abs(s.Scale) < 0.00001);
            
            for (int i = 0; i < this._visualSourceObjects.Count; i++)
            {
                var visualObj = this._visualSourceObjects[i];

                var scale = visualObj.Scale > 0 ? visualObj.Scale : (1.0f - totalScale) / dynamicScaleCount;

                int confWidth = (int)((this.ContentPanel.Width - paddingsTotalWidth) * scale);

                var configurator = this.CreateConfiguratorControl(currentLeft, confWidth);

                visualObj.CofiguratorCusomizer?.Invoke(configurator);

                configurator.FillSettings(visualObj.VisualObject, visualObj.Groups.ToArray());

                if (this._visualSourceObjects.IsLastIndex(i))
                    configurator.Anchor |= AnchorStyles.Right;

                this.ContentPanel.Controls.Add(configurator);
                currentLeft += confWidth + BETWEEN_CONIFGURATORS_PADDING;
            }

            this.CreateButtons();
        }

        private WtConfiguratorControl CreateConfiguratorControl(int currentLeft, int width)
        {
            return new WtConfiguratorControl
            {
                GroupTitleFont = new Font(SystemFonts.MessageBoxFont, FontStyle.Bold),
                ControlFont = SystemFonts.MessageBoxFont,
                LabelFont = SystemFonts.MessageBoxFont,
                Location = new Point(currentLeft, 0),
                Size = new Size(width, this.ContentPanel.Height),
                Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom
            };
        }

        public DialogResult ShowModal()
        {
            this.PrepareForm();
            this.ShowDialog();

            return this.DialogResult;
        }

        private void CreateButtons()
        {
            int buttonRightCoord = this.ButtonsPanel.Width - BUTTON_WIDTH - BUTTON_PADDING;

            this._cancelButton = this.CreateButton("DialogButtons.Cancel", "dialog.cancel");
            this._cancelButton.Left = buttonRightCoord;
            this._cancelButton.Click += this.Cancel_OnClick;
            this.ButtonsPanel.Controls.Add(this._cancelButton);
            buttonRightCoord -= BUTTON_WIDTH + BUTTON_PADDING;

            this._applyButton = this.CreateButton("DialogButtons.Apply", "dialog.apply");
            this._applyButton.Left = buttonRightCoord;
            this._applyButton.Click += this.Apply_OnClick;
            this.ButtonsPanel.Controls.Add(this._applyButton);
            buttonRightCoord -= BUTTON_WIDTH + BUTTON_PADDING;

            this._okButton = this.CreateButton("DialogButtons.Ok", "dialog.ok");
            this._okButton.Left = buttonRightCoord;
            this._okButton.Click += this.Ok_OnClick;
            this.ButtonsPanel.Controls.Add(this._okButton);
        }

        private void Ok_OnClick(object sender, EventArgs eventArgs)
        {
            this.DialogResult = DialogResult.OK;
            this.ApplyChanges();
            this.Close();
        }

        private void Apply_OnClick(object sender, EventArgs eventArgs)
        {
            this.ApplyChanges();
        }

        private void Cancel_OnClick(object sender, EventArgs eventArgs)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ApplyChanges()
        {
            var configControls = this.GetAllChildren().OfType<WtConfiguratorControl>();
            foreach(var configControl in configControls)
                configControl.ApplySettings();

            this.Enabled = false;
            ConfigManager.Instance.SaveConfig();
            this.Enabled = true;
        }

        private Button CreateButton(string localizationKey, string imageKey)
        {
            var button = new Button
            {
                Width = BUTTON_WIDTH,
                Height = this.ButtonsPanel.Height,
                Text = LocalizationManager.Get(localizationKey),
                Image = ResourcesProcessor.GetImage(imageKey),
                Anchor = AnchorStyles.Bottom | AnchorStyles.Right,
                ImageAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(8, 3, 3, 3),
                Font = SystemFonts.MessageBoxFont
            };
            return button;
        }
    }

    public class DialogItem
    {
        public IVisualSourceObject VisualObject { get; private set; }
        public List<string> Groups { get; private set; }
        public Action<WtConfiguratorControl> CofiguratorCusomizer { get; private set; }

        public float Scale { get; set; }

        public DialogItem(IVisualSourceObject visualObject, Action<WtConfiguratorControl> customizer = null)
        {
            this.VisualObject = visualObject;
            this.Groups = new List<string>();
            this.CofiguratorCusomizer = customizer;
        }

        public void AddGroup(string groupName)
        {
            this.Groups.Add(groupName);
        }
    }


}
