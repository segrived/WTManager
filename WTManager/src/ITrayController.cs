using System.Windows.Forms;
using WTManager.TrayMenu;

namespace WTManager
{
    /// <summary>
    /// Tray menu controller
    /// </summary>
    public interface ITrayController
    {
        /// <summary>
        /// Display system baloon message
        /// </summary>
        /// <param name="title">Message title</param>
        /// <param name="message">Message text</param>
        /// <param name="icon">Message icon key</param>
        void ShowBaloon(string title, string message, ToolTipIcon icon);

        /// <summary>
        /// Adds new item to menu
        /// </summary>
        /// <param name="menuItem">Menu item instance</param>
        void AddMenuItem(WtMenuItem menuItem);

        /// <summary>
        /// Removes all exists menu items
        /// </summary>
        void ClearMenu();

        /// <summary>
        /// Force update all exists menu items
        /// </summary>
        void UpdateTrayMenu();
    }
}