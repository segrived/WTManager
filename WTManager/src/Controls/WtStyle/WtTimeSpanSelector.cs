using System;

namespace WtManager.Controls.WtStyle
{
    public partial class WtTimeSpanSelector : WtUserControl
    {
        public WtTimeSpanSelector()
        {
            this.InitializeComponent();
            this.UnitSelector.SetEnumItems<TimeUnit>();
        }

        public TimeSpan ToTimeSpan()
        {
            int unitNumber = 0;

            var selectedValue = this.UnitSelector.GetSelectedValue();
            if (selectedValue is TimeUnit timeUnit)
                unitNumber = (int)timeUnit;

            decimal seconds = this.NumberSelector.Value * unitNumber;
            var timeSpan = TimeSpan.FromSeconds((double)seconds);

            return timeSpan;
        }
    }

    public enum TimeUnit
    {
        Minute = 60,
        Hour   = Minute * 60,
        Day    = Hour * 24,
        Week   = Day * 7
    }
}
