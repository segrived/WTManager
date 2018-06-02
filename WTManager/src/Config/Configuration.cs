using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.ServiceProcess;
using Newtonsoft.Json;
using WtManager.Controls.WtStyle.WtConfigurator;
using WtManager.Helpers;
using WtManager.VisualItemRenderers;

// ReSharper disable ArgumentsStyleLiteral
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable CollectionNeverUpdated.Global

namespace WtManager.Config
{
    [Serializable]
    public class Configuration : IVisualSourceObject
    {
        public const string GROUP_GENERAL = "General";
        public const string GROUP_UI = "UI settings";
        public const string GROUP_SERVICES = "Services";
        public const string GROUP_TASKS = "Service tasks";
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
        [VisualItem(typeof(VisualFileSelectorRenderer), GROUP_GENERAL)]
        public string ConfigEditorPath { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), GROUP_GENERAL)]
        public bool UseInternalLogViewer { get; set; }

        /// <summary>
        /// Path to log viewer executable file editor
        /// </summary>
        [VisualItem(typeof(VisualFileSelectorRenderer), GROUP_GENERAL)]
        [VisualItemDependentOn(nameof(UseInternalLogViewer), reverseDependent: true)]
        public string LogViewerPath { get; set; }

        /// <summary>
        /// Path to log viewer executable file editor
        /// </summary>
        [VisualItem(typeof(VisualLanguageSelectorRenderer), GROUP_GENERAL)]
        public string Language { get; set; }

        #endregion

        #region System settings

        [JsonIgnore]
        [VisualItem(typeof(VisualCheckboxRenderer), GROUP_SYSTEM)]
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
        [VisualItem(typeof(VisualFontSelectorRenderer), GROUP_UI)]
        public Font MenuFont { get; set; }

        /// <summary>
        /// Tray menu group title items font
        /// </summary>
        [JsonConverter(typeof(Converters.FontConverter))]
        [VisualItem(typeof(VisualFontSelectorRenderer), GROUP_UI)]
        public Font MenuTitleFont { get; set; }

        /// <summary>
        /// Current icons theme name
        /// </summary>
        [VisualItem(typeof(VisualThemeSelectorRenderer), GROUP_UI)]
        public string ThemeName { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), GROUP_UI)]
        public bool ShowPopup { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), GROUP_UI)]
        public bool ShowMenuBeyoundTaskbar { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), GROUP_UI)]
        public bool OpenTrayMenuOnLeftClick { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), GROUP_UI)]
        public bool UseNestedServiceGroups { get; set; }

        [VisualItem(typeof(VisualCheckboxRenderer), GROUP_UI)]
        [VisualItemDependentOn(nameof(UseNestedServiceGroups))]
        public bool ShowServiceGroupOperations { get; set; }

        #endregion

        #region Services settings

        [VisualItem(typeof(VisualDialogItemsEditorRenderer<Service>), GROUP_SERVICES)]
        public IEnumerable<Service> Services { get; set; }

        #endregion

        [VisualItem(typeof(VisualDialogItemsEditorRenderer<ServiceTask>), GROUP_TASKS)]
        public IEnumerable<ServiceTask> Tasks { get; set; }

        public string LocalizationPrefix => "Configuration";
    }

    [Serializable]
    public class ServiceTask : IVisualSourceObject
    {
        public const string GROUP_GENERAL = "General configuration";
        public const string GROUP_REPEAT = "Repeat process cofiguration";

        [VisualItem(typeof(VisualTextRenderer), GROUP_GENERAL)]
        public string TaskName { get; set; }

        [VisualItem(typeof(VisualServiceSelectorRenderer), GROUP_GENERAL)]
        public string ServiceName { get; set; }

        [VisualItem(typeof(VisualEnumSelectorType<ServiceGroupOperationType>), GROUP_GENERAL)]
        public ServiceGroupOperationType OperationType { get; set; }

        [VisualItem(typeof(VisualDateTimeRenderer), GROUP_GENERAL)]
        public DateTime ExecuteTime { get; set; }

        public override string ToString()
        {
            return $"{this.TaskName} (Service: {this.ServiceName}, operation: {this.OperationType}, trigger on {this.ExecuteTime})";
        }

        public string LocalizationPrefix => "ServiceTask";
    }

    [Serializable]
    public class Service : IVisualSourceObject
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
        [VisualItem(typeof(VisualServiceSelectorRenderer), GROUP_GENERAL)]
        public string ServiceName { get; set; }

        /// <summary>
        /// Service display name (will be displayed in menu)
        /// </summary>
        [VisualItem(typeof(VisualTextRenderer), GROUP_GENERAL)]
        public string DisplayName { get; set; }

        /// <summary>
        /// Service group (for menu generation)
        /// </summary>
        [VisualItem(typeof(VisualServiceGroupSelectorRenderer), GROUP_GENERAL)]
        public string Group { get; set; }

        /// <summary>
        /// Service configuration files
        /// </summary>
        [VisualItem(typeof(VisualFilesItemsEditorRenderer), GROUP_LOGCONFIG)]
        [VisualItemCustomization(customHeight: 80)]
        public IEnumerable<string> ConfigFiles { get; set; }

        /// <summary>
        /// Service log files
        /// </summary>
        [VisualItem(typeof(VisualFilesItemsEditorRenderer), GROUP_LOGCONFIG)]
        [VisualItemCustomization(customHeight: 80)]
        public IEnumerable<string> LogFiles { get; set; }

        /// <summary>
        /// Service data directory (for example WWW for web-servers)
        /// </summary>
        [VisualItem(typeof(VisualDirectorySelectorRenderer), GROUP_ADDITIONAL)]
        public string DataDirectory { get; set; }

        /// <summary>
        /// Browser URL
        /// </summary>
        [VisualItem(typeof(VisualFileSelectorRenderer), GROUP_ADDITIONAL)]
        public string BrowserUrl { get; set; }

        public override string ToString()
        {
            return this.DisplayName;
        }

        [JsonIgnore]
        public ServiceController Controller => ServiceHelpers.GetServiceController(this.ServiceName);

        public string LocalizationPrefix => "Service";
    }

    public enum ServiceGroupOperationType
    {
        [Description("Start")]
        Start,

        [Description("Stop")]
        Stop,

        [Description("Restart")]
        Restart
    }
}
