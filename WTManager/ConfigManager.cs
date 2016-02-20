using System;
using System.Collections.Generic;
using System.IO;
using WTManager.Helpers;

namespace WTManager
{
    public delegate void ConfigSavedHandler(object sender, EventArgs e);

    public class ConfigManager
    {
        private static readonly string AppData
            = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string ConfigPath
            = Path.Combine(AppData, "WTManager", "config.yml");

        private static readonly Lazy<ConfigManager> _instance =
            new Lazy<ConfigManager>(() => new ConfigManager());

        public static ConfigManager Instance => _instance.Value;

        public static Preferences Preferences => _instance.Value.Config.Preferences;

        public static IEnumerable<Service> Services => _instance.Value.Config.Services;

        public Configuration Config { get; private set; }


        private Configuration GetConfig() {
            if (!File.Exists(ConfigPath)) {
                SerializationHelpers.SerializeFile(ConfigPath, Configuration.Defaults);
            }
            return SerializationHelpers.DeserializeFile<Configuration>(ConfigPath);
        }

        public void ReloadConfig() => this.Config = this.GetConfig();

        public void SaveConfig() {
            try {
                SerializationHelpers.SerializeFile(ConfigPath, this.Config);
                this.OnConfigSaved(new EventArgs());
            } catch {
                // TODO
            }
        }

        public event ConfigSavedHandler ConfigSaved;

        protected virtual void OnConfigSaved(EventArgs e) {
            ConfigSaved?.Invoke(this, new EventArgs());
        }

        private ConfigManager() {
            ReloadConfig();
        }
    }
}
