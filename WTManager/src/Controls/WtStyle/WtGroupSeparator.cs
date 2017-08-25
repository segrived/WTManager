using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

// ReSharper disable MemberCanBePrivate.Global

namespace WTManager.Controls.WtStyle
{
    public class WtGroupSeparator : Panel
    {
        [Category("WT Controls")]
        [DisplayName(nameof(TextPadding))]
        public int TextPadding { get; set; } = 5;

        [Category("WT Controls")]
        [DisplayName(nameof(LeftLineWidth))]
        public int LeftLineWidth { get; set; } = 20;

        public WtGroupSeparator()
        {
            this.SetStyle(ControlStyles.ContainerControl, true);
            this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.Selectable, false);

            this.TabStop = false;
        }

        protected override Padding DefaultPadding => new Padding(3);

        public override Rectangle DisplayRectangle
        {
            get
            {
                return new Rectangle(
                    this.Padding.Left, 
                    this.Font.Height + this.Padding.Top, 
                    Math.Max(this.ClientSize.Width - this.Padding.Horizontal, 0), 
                    Math.Max(this.ClientSize.Height - this.Font.Height - this.Padding.Vertical, 0));
            }
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (var pen = new Pen(ControlPaint.Dark(SystemColors.Control, 0.0f)))
            {
                var size = e.Graphics.MeasureString(this.Text, this.Font);

                float height = size.Height / 2;

                e.Graphics.DrawLine(pen, 0, height, this.LeftLineWidth, height);
                e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Color.Black), 25, 0);

                float rightLineX = this.TextPadding + size.Width + this.TextPadding;

                e.Graphics.DrawLine(pen, this.LeftLineWidth + rightLineX, height, this.Width, height);
            }
        }
    }
}
