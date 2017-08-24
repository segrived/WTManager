using System.ComponentModel;

namespace WTManager.Controls.WtStyle.WtConfigurator
{
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