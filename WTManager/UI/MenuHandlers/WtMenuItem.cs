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

        public virtual bool IsEnabled => true;

        protected virtual string ImageKey { get; } = null;

        protected WtMenuItem(IWtTrayMenuController controller)
        {
            this.Controller = controller;
            this.SubItems = new List<WtMenuItem>();
        }

        protected virtual void Action()
        {
        }

        public virtual void UpdateState()
        {
        }

        private ToolStripItem ToMenuItem()
        {
            if (this.DisplayText == "-")
                return new ToolStripSeparator();

            var item = new WtToolStripMenuItem(this.DisplayText);

            item.Click += (sender, args) => this.Action();

            if (this.ImageKey != null && IconsManager.Icons.ContainsKey(this.ImageKey))
                item.Image = IconsManager.Icons[this.ImageKey];

            if (this.SubItems != null)
            {
                var subItems = this.SubItems.Select(si => si.ToMenuItem()).ToArray();
                item.DropDownItems.AddRange(subItems);
            }

            item.Tag = this;

            return item;
        }

        public static implicit operator ToolStripItem(WtMenuItem item)
        {
            return item.ToMenuItem();
        }
    }
}