using System;
using System.IO;
using Newtonsoft.Json;
using WtManager.Resources;

namespace WtManager.Config
{
    public class ConfigManager
    {
        private static readonly Lazy<ConfigManager> LazyInstance =
            new Lazy<ConfigManager>(() => new ConfigManager());

        public static ConfigManager Instance => LazyInstance.Value;

        public Configuration Config { get; private set; }

        /// <summary>
        /// Configuration was loaded from file
        /// </summary>
        public event Action<Configuration> ConfigLoaded;

        /// <summary>
        /// Cofiguration was saved to file
        /// </summary>
        public event Action<Configuration> ConfigSaved;

        private ConfigManager()
        {
            this.Config = this.LoadConfig();
        }

        public Configuration LoadConfig()
        {
            var resultObj = new Configuration();

            try
            {
                string configFileName = this.GetConfigFileName();
                if (File.Exists(configFileName))
                {
                    string fileContent = File.ReadAllText(configFileName);
                    resultObj = JsonConvert.DeserializeObject<Configuration>(fileContent);

                    this.PostProcessConfig(resultObj);
                    this.ConfigLoaded?.Invoke(resultObj);
                }
            }
            catch { /* ... */ }

            return resultObj;
        }

        public void SaveConfig()
        {
            try
            {
                string configFileName = this.GetConfigFileName();

                var configDirectory = Path.GetDirectoryName(configFileName);

                if (! Directory.Exists(configDirectory))
                    Directory.CreateDirectory(configDirectory);

                File.WriteAllText(configFileName, JsonConvert.SerializeObject(this.Config, Formatting.Indented));

                this.PostProcessConfig(this.Config);
                this.ConfigSaved?.Invoke(this.Config);
            }
            catch { /* ... */ }    
        }


        /// <summary>
        /// Executes after every load/save config operation
        /// </summary>
        private void PostProcessConfig(Configuration config)
        {
            ResourcesProcessor.ThemeName = config.ThemeName;
            LocalizationManager.UpdateLocale(config.Language);
        }

        #region Utils

        private string GetConfigFileName()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appDataDir, "WTManager", "config.json");
        }

        #endregion
    }
}
