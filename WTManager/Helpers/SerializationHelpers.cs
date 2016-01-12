using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTManager.Helpers
{
    public static class SerializationHelpers
    {
        private static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string ConfigPath = Path.Combine(AppData, "WTManager", "services.yml");
        public static readonly string PreferencesPath = Path.Combine(AppData, "WTManager", "prefs.yml");

        public static IEnumerable<Service> ReadServicesConfFile() {
            using (var stream = File.OpenRead(ConfigPath))
            using (var reader = new StreamReader(stream)) {
                var des = new YamlDotNet.Serialization.Deserializer(ignoreUnmatched: true);
                return des.Deserialize<List<Service>>(reader);
            }
        }

        public static Preferences ReadPreferencesConfFile() {
            using (var stream = File.OpenRead(PreferencesPath))
            using (var reader = new StreamReader(stream)) {
                var des = new YamlDotNet.Serialization.Deserializer(ignoreUnmatched: true);
                var servicesData = des.Deserialize<Preferences>(reader);
                return servicesData;
            }
        }
    }
}
