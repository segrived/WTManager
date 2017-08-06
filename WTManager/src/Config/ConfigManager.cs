using System;
using System.IO;
using WTManager.Helpers;

namespace WTManager.Config
{
    public class ConfigManager
    {
        private static readonly Lazy<ConfigManager> LazyInstance =
            new Lazy<ConfigManager>(() => new ConfigManager());

        public static ConfigManager Instance => LazyInstance.Value;

        public Configuration Config { get; private set; }

        public event Action ConfigSaved;

        private ConfigManager()
        {
            this.Config = Extensions.DeserializeFile<Configuration>(this.GetConfigFileName());
        }

        public void SaveConfig()
        {
            if (this.Config.SerializeFile(this.GetConfigFileName()))
                this.ConfigSaved?.Invoke();
        }

        #region Utils

        private string GetConfigFileName()
        {
            string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appDataDir, "WTManager", "config.xml");
        }

        #endregion
    }
}
