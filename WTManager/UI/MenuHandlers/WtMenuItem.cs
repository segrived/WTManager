using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WTManager.Controls;

namespace WTManager.UI.MenuHandlers
{
    public abstract class WtMenuItem
    {
        protected IWtTrayMenuController Controller { get; private set; }

        protected virtual string DisplayText { get; } = String.Empty;

        public IList<WtMenuItem> SubItems { get; private set; }

        protected virtual bool IsEnabled => true;

        protected  virtual bool IsVisible => true;

        protected virtual string ImageKey { get; } = null;

        private WtToolStripMenuItem _internalMenuStripItem;

        protected WtMenuItem(IWtTrayMenuController controller)
        {
            this.Controller = controller;
            this.SubItems = new List<WtMenuItem>();
            this._internalMenuStripItem = null;
        }

        protected virtual void Action()
        {
        }

        public virtual void UpdateState()
        {
            if (this._internalMenuStripItem == null)
                return;

            // Update item enability
            this._internalMenuStripItem.Enabled = this.IsEnabled;

            this._internalMenuStripItem.Visible = this.IsVisible;

            // Update display text
            this._internalMenuStripItem.Text = this.DisplayText;

            // Update image
            if (this.ImageKey == null || !IconsManager.Icons.ContainsKey(this.ImageKey))
                return;

            if (this._internalMenuStripItem.Image != IconsManager.Icons[this.ImageKey])
                this._internalMenuStripItem.Image = IconsManager.Icons[this.ImageKey];
        }

        protected virtual ToolStripItem ToMenuItem()
        {
            if (this._internalMenuStripItem == null)
            {
                this._internalMenuStripItem = new WtToolStripMenuItem(this.DisplayText);
                this._internalMenuStripItem.Click += (sender, args) => this.Action();
                this._internalMenuStripItem.Tag = this;
            }

            if (this.SubItems != null)
            {
                var subItems = this.SubItems.Select(si => si.ToMenuItem()).ToArray();
                this._internalMenuStripItem.DropDownItems.AddRange(subItems);
            }

            return this._internalMenuStripItem;
        }

        public static implicit operator ToolStripItem(WtMenuItem item)
        {
            return item.ToMenuItem();
        }
    }
}