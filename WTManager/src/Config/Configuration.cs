using System;
using System.Collections.Generic;
using System.Drawing;
using System.ServiceProcess;
using Newtonsoft.Json;
using WTManager.Helpers;
using WTManager.Lib;
using SystemFontConverter = System.Drawing.FontConverter;

namespace WTManager.Config
{
    [Serializable]
    [VisualProvider]
    public class Configuration 
    {
        public Configuration()
        {
            this.MenuFont = SystemFonts.MenuFont;
            this.MenuTitleFont = new Font(SystemFonts.MenuFont.FontFamily, SystemFonts.MenuFont.Size, FontStyle.Bold);
            this.ConfigEditorPath = "notepad.exe";
            this.Services = new List<Service>();
        }

        [VisualItemRenderer(typeof(VisualFileSelectorRenderer), "Config editor path", 0)]
        [VisualItemRendererGroup("Basic preferences")]
        public string ConfigEditorPath { get; set; }

        [VisualItemRenderer(typeof(VisualFileSelectorRenderer), "Log viewer path", 100)]
        [VisualItemRendererGroup("Basic preferences")]
        public string LogViewerPath { get; set; }

        [JsonConverter(typeof(FontConverter))]
        [VisualItemRenderer(typeof(VisualFontSelectorRenderer), "Tray menu font", 200)]
        [VisualItemRendererGroup("Basic preferences")]
        public Font MenuFont { get; set; }

        [JsonConverter(typeof(FontConverter))]
        [VisualItemRenderer(typeof(VisualFontSelectorRenderer), "Tray menu title font", 225)]
        [VisualItemRendererGroup("Basic preferences")]
        public Font MenuTitleFont { get; set; }

        [VisualItemRenderer(typeof(VisualThemeSelectorRenderer), "Theme name", 250)]
        [VisualItemRendererGroup("Basic preferences")]
        public string ThemeName { get; set; }

        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Show tray menu popups", 300)]
        [VisualItemRendererGroup("Basic preferences")]
        public bool ShowPopup { get; set; }

        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Show menu beyound taskbar", 400)]
        [VisualItemRendererGroup("Basic preferences")]
        public bool ShowMenuBeyoundTaskbar { get; set; }

        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Run WTManager on start", 500)]
        [VisualItemRendererGroup("Basic preferences")]
        public bool RunOnStart { get; set; }

        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Open tray menu on left click", 600)]
        [VisualItemRendererGroup("Basic preferences")]
        public bool OpenTrayMenuOnLeftClick { get; set; }

        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Use nested service groups in menu", 700)]
        [VisualItemRendererGroup("Basic preferences")]
        public bool UseNestedServiceGroups { get; set; }

        public List<Service> Services { get; set; }
    }

    public class VisualItemRendererGroupAttribute : Attribute
    {
        public string Group { get; private set; }

        public VisualItemRendererGroupAttribute(string groupName)
        {
            this.Group = groupName;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class VisualProviderAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class VisualItemRendererAttribute : Attribute
    {
        public Type RendererType { get; private set; }
        public string DisplayText { get; private set; }
        public int SortIndex { get; private set; }

        public VisualItemRendererAttribute(Type rendererType, string displayText, int sortIndex)
        {
            this.RendererType = rendererType;
            this.DisplayText = displayText;
            this.SortIndex = sortIndex;
        }
    }

    public class FontConverter : JsonConverter
    {
        private readonly SystemFontConverter _converter;

        public FontConverter()
        {
            this._converter = new SystemFontConverter();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var fontObject = value as Font;

            if (fontObject == null)
                return;

            writer.WriteValue(this._converter.ConvertToString(fontObject));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            string serializedData = reader.Value as string;

            if (serializedData == null)
                return null;

            return this._converter.ConvertFromString(serializedData);
        }

        public override bool CanConvert(Type objectType) 
            => objectType == typeof(Font);
    }



    [Serializable]
    public class Service
    {
        public Service()
        {
            this.LogFiles = new List<string>();
            this.ConfigFiles = new List<string>();
        }

        /// <summary>
        /// Service name
        /// </summary>
        public string ServiceName { get; set; }

        /// <summary>
        /// Service display name (will be displayed in menu)
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Service group (for menu generation)
        /// </summary>
        public string Group { get; set; }

        /// <summary>
        /// Service configuration files
        /// </summary>
        public List<string> ConfigFiles { get; set; }

        /// <summary>
        /// Service log files
        /// </summary>
        public List<string> LogFiles { get; set; }

        /// <summary>
        /// Service data directory (for example WWW for web-servers)
        /// </summary>
        public string DataDirectory { get; set; }

        /// <summary>
        /// Browser URL
        /// </summary>
        public string BrowserUrl { get; set; }

        public bool IsInPendingState
        {
            get
            {
                switch (this.Controller.Status)
                {
                    case ServiceControllerStatus.StopPending:
                    case ServiceControllerStatus.ContinuePending:
                    case ServiceControllerStatus.PausePending:
                    case ServiceControllerStatus.StartPending:
                        return true;
                    default:
                        return false;
                }
            }
        }

        [JsonIgnore]
        public ServiceController Controller => this.GetController();

        [JsonIgnore]
        public ServiceControllerStatus Status => this.Controller.Status;

        [JsonIgnore]
        public bool IsStarted => this.Status == ServiceControllerStatus.Running;

        [JsonIgnore]
        public bool IsStopped => this.Status == ServiceControllerStatus.Stopped;

        public override string ToString()
        {
            return this.DisplayName;
        }

        #region Equals/GetHashCode
        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            var otherService = (Service)obj;
            return otherService.ServiceName == this.ServiceName;
        }

        public override int GetHashCode()
        {
            return this.ServiceName.GetHashCode();
        }
        #endregion
    }
}
