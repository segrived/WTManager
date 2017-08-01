using System.Windows.Forms;
using WTManager.UI.MenuHandlers;

namespace WTManager.UI
{
    public interface IWtTrayMenuController
    {
        void ShowBaloon(string title, string message, ToolTipIcon icon);
        void AddMenuItem(WtMenuItem menuItem);
        void ClearMenu();
    }
}