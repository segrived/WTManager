using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using Newtonsoft.Json;
using WTManager.Controls.WtStyle;
using WTManager.Helpers;
using WTManager.Lib;
using WTManager.Resources;
using SystemFontConverter = System.Drawing.FontConverter;

namespace WTManager.Config
{
    [Flags]
    public enum VisualItemFlags
    {
        RestrictManualEdit = 1 << 0
    }

    [Serializable]
    [VisualProvider]
    public class Configuration 
    {
        public Configuration()
        {
            this.MenuFont = SystemFonts.MenuFont;
            this.ConfigEditorPath = "notepad.exe";
            this.Services = new List<Service>();
        }

        [JsonProperty(PropertyName = "editor.config")]
        [VisualItemRenderer(typeof(VisualFileSelectorRenderer), "Config editor path", 0)]
        public string ConfigEditorPath { get; set; }

        [JsonProperty(PropertyName = "editor.log")]
        [VisualItemRenderer(typeof(VisualFileSelectorRenderer), "Log viewer path", 100)]
        public string LogViewerPath { get; set; }

        [JsonProperty(PropertyName = "ui.menu-font")]
        [VisualItemRenderer(typeof(VisualFontSelectorRenderer), "Tray menu font", 200)]
        [JsonConverter(typeof(FontConverter))]
        public Font MenuFont { get; set; }

        [JsonProperty(PropertyName = "ui.show-popup")]
        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Show tray menu popups", 300)]
        public bool ShowPopup { get; set; }

        [JsonProperty(PropertyName = "ui.show-menu-beyound-taskbar")]
        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Show menu beyound taskbar", 400)]
        public bool ShowMenuBeyoundTaskbar { get; set; }

        [JsonProperty(PropertyName = "system.run-on-start")]
        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Run WTManager on start", 500)]
        public bool RunOnStart { get; set; }

        [JsonProperty(PropertyName = "ui.tray-open-on-left-click")]
        [VisualItemRenderer(typeof(VisualCheckboxRenderer), "Open tray menu on left click", 600)]
        public bool OpenTrayMenuOnLeftClick { get; set; }

        [JsonProperty(PropertyName = "ui.theme-name")]
        [VisualItemRenderer(typeof(VisualThemeSelectorRenderer), "Theme name", 250)]
        public string ThemeName { get; set; }

        public List<Service> Services { get; set; }
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

    public class ThemesColectionProvider : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ComboBoxItem("Default", null);
            foreach(string themeName in ResourcesProcessor.GetThemesList())
                yield return new ComboBoxItem(themeName);
        }
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

        public ServiceController Controller => this.GetController();

        public ServiceControllerStatus Status => this.Controller.Status;

        public bool IsStarted => this.Status == ServiceControllerStatus.Running;

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
