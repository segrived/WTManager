using System;
using System.IO;
using Newtonsoft.Json;

namespace WTManager.Config
{
    public class ConfigManager
    {
        private static readonly Lazy<ConfigManager> LazyInstance =
            new Lazy<ConfigManager>(() => new ConfigManager());

        public static ConfigManager Instance => LazyInstance.Value;

        public Configuration Config { get; private set; }

        public event Action<Configuration> ConfigSaved;

        private ConfigManager()
        {
            var resultObj = new Configuration();

            try
            {
                string configFileName = this.GetConfigFileName();
                if (File.Exists(configFileName))
                {
                    string fileContent = File.ReadAllText(configFileName);
                    resultObj = JsonConvert.DeserializeObject<Configuration>(fileContent);
                }
            }
            catch { /* ... */ }

            this.Config = resultObj;
        }

        public void SaveConfig()
        {
            try
            {
                string configFileName = this.GetConfigFileName();
                File.WriteAllText(configFileName, JsonConvert.SerializeObject(this.Config, Formatting.Indented));
                this.ConfigSaved?.Invoke(this.Config);
            }
            catch { /* ... */ }    
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
