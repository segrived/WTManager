using System.ComponentModel;
using System.Drawing;

namespace WtManager.Controls.WtStyle.WtConfigurator
{
    public partial class WtConfiguratorControl
    {
        [Category("WT Controls")]
        [DisplayName("ControlFont")]
        public Font ControlFont { get; set; } = SystemFonts.DefaultFont;

        [Category("WT Controls")]
        [DisplayName("LabelFont")]
        public Font LabelFont { get; set; } = SystemFonts.DefaultFont;

        [Category("WT Controls")]
        [DisplayName("GroupTitleFont")]
        public Font GroupTitleFont { get; set; } = SystemFonts.DefaultFont;

        [Category("WT Controls")]
        [DisplayName("ItemHeight")]
        public int ItemHeight { get; set; } = 22;

        [Category("WT Controls")]
        [DisplayName("LabelWidth")]
        public int LabelWidth { get; set; } = 120;

        [Category("WT Controls")]
        [DisplayName("HorizontalItemPadding")]
        [Description("Padding on left and right size of each item")]
        public int HorizontalItemPadding { get; set; } = 5;

        [Category("WT Controls")]
        [DisplayName("VerticalPaddingBetweenButtons")]
        public int PaddingBetweenItems { get; set; } = 12;

        [Category("WT Controls")]
        [DisplayName("FillLastGroup")]
        public bool FillLastGroup { get; set; } = false;

        [Category("WT Controls")]
        [DisplayName("FillLastControl")]
        public bool FillLastControl { get; set; } = false;

        [Category("WT Controls")]
        [DisplayName("LabelConfiguration")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public LabelRendererConfiguration LabelConfiguration { get; set; } = new LabelRendererConfiguration();
    }

    public class LabelRendererConfiguration
    {
        [Category("WT Controls")]
        [DisplayName("ShowExternalLables")]
        public bool ShowLables { get; set; } = true;

        [Category("WT Controls")]
        [DisplayName("LabelPostfix")]
        public string LabelPostfix { get; set; } = ":";
    }
}
