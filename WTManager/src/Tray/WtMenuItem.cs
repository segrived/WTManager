using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WTManager.Config;
using WTManager.Controls;
using WTManager.Resources;
using WTManager.Tray.MenuHandlers;

namespace WTManager.Tray
{
    public abstract class WtMenuItem : IDisposable
    {
        protected ITrayController Controller { get; private set; }

        /// <summary>
        /// Menu item display text
        /// </summary>
        protected virtual string DisplayText { get; } = String.Empty;

        public IList<WtMenuItem> SubItems { get; private set; }

        protected virtual bool IsEnabled => true;

        protected  virtual bool IsVisible => true;

        protected virtual FontStyle FontStyle => FontStyle.Regular;

        protected virtual string ImageKey { get; } = null;

        private WtToolStripMenuItem _internalMenuStripItem;

        protected WtMenuItem(ITrayController controller)
        {
            this.Controller = controller;
            this.SubItems = new List<WtMenuItem>();

            this._internalMenuStripItem = null;
        }

        public void AddSubItem(WtMenuItem menuItem)
        {
            this.SubItems.Add(menuItem);
        }

        protected virtual void Action()
        {
        }

        public void UpdateState()
        {
            if (this._internalMenuStripItem == null)
                return;

            // Update item enability
            this._internalMenuStripItem.Enabled = this.IsEnabled;

            // Update item visibility
            this._internalMenuStripItem.Visible = this.IsVisible;

            // Update display text
            this._internalMenuStripItem.Text = this.DisplayText;

            // Update image
            if (this.ImageKey == null)
                return;

            var icon = ResourcesProcessor.GetImage($"menu.{this.ImageKey}");

            if (icon == null)
                return;
            
            if (this._internalMenuStripItem.Image != icon)
                this._internalMenuStripItem.Image = icon;
        }

        protected virtual ToolStripItem ToMenuItem()
        {
            if (this._internalMenuStripItem == null)
            {
                this._internalMenuStripItem = new WtToolStripMenuItem(this.DisplayText);

                string fontName = ConfigManager.Instance.Config.MenuFontName;
                float fontSize = ConfigManager.Instance.Config.MenuFontSize;
                this._internalMenuStripItem.Font = new Font(fontName, fontSize, this.FontStyle);

                this._internalMenuStripItem.Click += this.InternalMenuStripItem_OnClick;
                this._internalMenuStripItem.Tag = this;
            }

            if (this.SubItems == null)
                return this._internalMenuStripItem;

            var subItems = this.SubItems.Select(si => si.ToMenuItem()).ToArray();
            this._internalMenuStripItem.DropDownItems.AddRange(subItems);

            return this._internalMenuStripItem;
        }

        private void InternalMenuStripItem_OnClick(object sender, EventArgs eventArgs)
        {
            this.Action();
        }

        public static implicit operator ToolStripItem(WtMenuItem item)
        {
            return item.ToMenuItem();
        }

        public void Dispose()
        {
            this._internalMenuStripItem.Click -= this.InternalMenuStripItem_OnClick;
            this._internalMenuStripItem?.Dispose();
        }
    }
}