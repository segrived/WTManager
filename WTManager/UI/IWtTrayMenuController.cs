using System.Windows.Forms;

namespace WTManager.UI
{
    public interface IWtTrayMenuController
    {
        void ShowBaloon(string title, string message, ToolTipIcon icon);
    }
}