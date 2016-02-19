using System;
using System.Collections.Generic;
using System.IO;
using WTManager.Helpers;

namespace WTManager
{
    public sealed class ConfigManager
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

        // Default configuration
        private Configuration GetDefaults() {
            var conf = new Configuration {
                Preferences = new Preferences {
                    ShowBaloon = true,
                    BaloonTipTime = 3000
                },
                Services = new List<Service>()
            };
            return conf;
        }

        private Configuration GetConfig() {
            if (!File.Exists(ConfigPath)) {
                SerializationHelpers.SerializeFile(ConfigPath, this.GetDefaults());
            }
            return SerializationHelpers.DeserializeFile<Configuration>(ConfigPath);
        }

        public void ReloadConfig() => this.Config = this.GetConfig();

        public void SaveConfig() {
            SerializationHelpers.SerializeFile(ConfigPath, this.Config);
        }

        private ConfigManager() {
            ReloadConfig();
        }
    }
}
