using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WTManager
{
    public static class Helpers
    {
        private static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static readonly string ConfigPath = Path.Combine(AppData, "WTManager", "services.yml");
        public static readonly string PreferencesPath = Path.Combine(AppData, "WTManager", "prefs.yml");

        public static IEnumerable<Service> ReadConfigFile() {
            using (var stream = File.OpenRead(ConfigPath))
            using (var reader = new StreamReader(stream)) {
                var des = new YamlDotNet.Serialization.Deserializer(ignoreUnmatched: true);
                var servicesData = des.Deserialize<List<ServiceConfigData>>(reader);
                return servicesData.Select(sd => new Service(sd));
            }
        }

        public static Preferences ReadPreferencesFile() {
            using (var stream = File.OpenRead(PreferencesPath))
            using (var reader = new StreamReader(stream)) {
                var des = new YamlDotNet.Serialization.Deserializer(ignoreUnmatched: true);
                var servicesData = des.Deserialize<Preferences>(reader);
                return servicesData;
            }
        }

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection) {
            return new HashSet<T>(collection);
        }

        public static ToolStripMenuItem CreateMenuHeader(string text) {
            return new ToolStripMenuItem(text) {
                TextAlign = ContentAlignment.TopCenter,
                Enabled = false,
                Font = new Font(FontFamily.GenericSansSerif, 9.0f, FontStyle.Bold)
            };
        }

        public static ToolStripMenuItem CreateMenuItem(string text, Image icon, EventHandler handler, string name = null) {
            var item = new ToolStripMenuItem(text) { Image = icon, Name = name };
            item.Click += handler;
            return item;
        }
    }
}