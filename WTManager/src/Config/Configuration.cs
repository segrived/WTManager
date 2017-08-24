using System;
using System.Collections.Generic;
using System.Drawing;
using Newtonsoft.Json;
using WTManager.Controls.WtStyle.WtConfigurator;
using WTManager.Helpers;
using WTManager.VisualItemRenderers;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverUpdated.Global

namespace WTManager.Config
{
    [Serializable]
    public class Configuration : IVisualProviderObject
    {
        public const string GROUP_GENERAL = "General";
        public const string GROUP_UI = "UI settings";
        public const string GROUP_SERVICES = "Services";
        public const string GROUP_SYSTEM = "System";

        public Configuration()
        {
            this.MenuFont = SystemFonts.MenuFont;
            this.MenuTitleFont = new Font(SystemFonts.MenuFont.FontFamily, SystemFonts.MenuFont.Size, FontStyle.Bold);
            this.ConfigEditorPath = "notepad.exe";
            this.Services = new List<Service>();
        }

        #region General settings

        /// <summary>
        /// Path to configuration files executable file editor
        /// </summary>
        [VisualItem(typeof(VisualFileSelectorRenderer), "Config editor path", GROUP_GENERAL)]
        public string ConfigEditorPath { get; set; }

        /// <summary>
        /// Path to log viewer executable file editor
        /// </summary>
        [VisualItem(typeof(VisualFileSelectorRenderer), "Log viewer path", GROUP_GENERAL)]
        public string LogViewerPath { get; set; }

        #endregion

        #region System settings

        [JsonIgnore]
        [VisualItem(typeof(VisualCheckboxRenderer), "Run WTManager on start", GROUP_SYSTEM)]
        public bool RunOnStart
        {
            get { return SchedulerHelpers.AutoStartTaskState; }
            set { SchedulerHelpers.AutoStartTaskState = value; }
        }

        #endregion

        #region UI settings

        /// <summary>
        /// Tray menu item font, except group titles
        /// </summary>
        [JsonConverter(typeof(Converters.FontConverter))]
        [VisualItem(typeof(VisualFontSelectorRenderer), "Tray menu font", GROUP_UI)]
        public Font MenuFont { get; set; }

        /// <summary>
        /// Tray menu group title items font
        /// </summary>
        [JsonConverter(typeof(Converters.FontConverter))]
        [VisualItem(typeof(VisualFontSelectorRenderer), "Tray menu title font", GROUP_UI)]
        public Font MenuTitleFont { get; set; }

        /// <summary>
        /// Current icons theme name
        /// </summary>
        [VisualItem(typeof(VisualThemeSelectorRenderer), "Theme name", GROUP_UI)]
        public string ThemeName { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), "Show tray menu popups", GROUP_UI)]
        public bool ShowPopup { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), "Show menu beyound taskbar", GROUP_UI)]
        public bool ShowMenuBeyoundTaskbar { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), "Open tray menu on left click", GROUP_UI)]
        public bool OpenTrayMenuOnLeftClick { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), "Use nested service groups in menu", GROUP_UI)]
        public bool UseNestedServiceGroups { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), "Show service group operations in nested menu (experimental)", GROUP_UI)]
        public bool ShowServiceGroupOperations { get; set; }

        #endregion

        #region Services settings

        [VisualItem(typeof(VisualServicesItemsEditorRenderer), "Services", GROUP_SERVICES)]
        public IEnumerable<Service> Services { get; set; }

        #endregion
    }


    [Serializable]
    public class Service : IVisualProviderObject
    {
        public const string GROUP_GENERAL = "Basic service configuration";
        public const string GROUP_LOGCONFIG = "Logs and config";
        public const string GROUP_ADDITIONAL = "Additional features";

        public Service()
        {
            this.LogFiles = new List<string>();
            this.ConfigFiles = new List<string>();
        }

        /// <summary>
        /// Service name
        /// </summary>
        [VisualItem(typeof(VisualServiceSelectorRenderer), "Service name", GROUP_GENERAL)]
        public string ServiceName { get; set; }

        /// <summary>
        /// Service display name (will be displayed in menu)
        /// </summary>
        [VisualItem(typeof(VisualTextRenderer), "Service display name", GROUP_GENERAL)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Service group (for menu generation)
        /// </summary>
        [VisualItem(typeof(VisualServiceGroupSelectorRenderer), "Service group (optional)", GROUP_GENERAL)]
        public string Group { get; set; }

        /// <summary>
        /// Service configuration files
        /// </summary>
        [VisualItem(typeof(VisualFilesItemsEditorRenderer), "Config files", GROUP_LOGCONFIG)]
        [VisualItemCustomization(customHeight: 80)]
        public IEnumerable<string> ConfigFiles { get; set; }

        /// <summary>
        /// Service log files
        /// </summary>
        [VisualItem(typeof(VisualFilesItemsEditorRenderer), "Log files", GROUP_LOGCONFIG)]
        [VisualItemCustomization(customHeight: 80)]
        public IEnumerable<string> LogFiles { get; set; }

        /// <summary>
        /// Service data directory (for example WWW for web-servers)
        /// </summary>
        [VisualItem(typeof(VisualDirectorySelectorRenderer), "Data directory", GROUP_ADDITIONAL)]
        public string DataDirectory { get; set; }

        /// <summary>
        /// Browser URL
        /// </summary>
        [VisualItem(typeof(VisualFileSelectorRenderer), "Browser URL", GROUP_ADDITIONAL)]
        public string BrowserUrl { get; set; }

        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
