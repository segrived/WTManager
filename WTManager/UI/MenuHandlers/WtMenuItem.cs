using System;
using System.Drawing;
using System.Windows.Forms;
using WTManager.Controls;

namespace WTManager.UI.MenuHandlers
{
    public abstract class WtMenuItem
    {
        protected IWtTrayMenuController Controller { get; private set; }

        protected virtual string DisplayText { get; } = String.Empty;

        public virtual bool IsEnabled => true;

        protected virtual Image Image { get; } = null;

        protected WtMenuItem(IWtTrayMenuController controller)
        {
            this.Controller = controller;
        }

        protected virtual void Action()
        {
        }

        protected virtual void UpdateState()
        {
        }

        private ToolStripItem ToMenuItem()
        {
            if (this.DisplayText == "-")
                return new ToolStripSeparator();

            var item = new WtToolStripMenuItem(this.DisplayText);
            item.Click += (sender, args) => this.Action();
            item.Image = this.Image;
            item.Tag = this;
            return item;
        }

        public static implicit operator ToolStripItem(WtMenuItem item)
        {
            return item.ToMenuItem();
        }
    }
}