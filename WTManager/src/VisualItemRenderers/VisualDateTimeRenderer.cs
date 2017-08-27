using System;
using System.Windows.Forms;
using WTManager.Controls.WtStyle.WtConfigurator;

namespace WTManager.VisualItemRenderers
{
    public class VisualDateTimeRenderer : VisualItemRenderer
    {
        public VisualDateTimeRenderer(IVisualSourceObject source) 
            : base(source) { }

        protected override Control CreateControl()
        {
            var picker = new DateTimePicker
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "MM/dd/yyyy hh:mm:ss"
            };
            return picker;
        }

        public override void SetValue(object value)
        {
            if (value is DateTime dt)
            {
                if (dt <= DateTime.MinValue || dt >= DateTime.MaxValue)
                    dt = DateTime.Now;
                ((DateTimePicker) this.Control).Value = dt;
            }
        }

        public override object GetValue()
        {
            return ((DateTimePicker) this.Control).Value;
        }
    }
}