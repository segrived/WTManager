using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace WTManager.Resources
{
    public static class ResourcesProcessor
    {
        private static readonly Dictionary<string, object> ResourcesCache;

        private static string _themeName;

        public static string ThemeName
        {
            get { return _themeName; }
            set
            {
                _themeName = value;
                ResourcesCache.Clear();
            }
        }

        static ResourcesProcessor()
        {
            ResourcesCache = new Dictionary<string, object>();
        }

        private static Stream GetResourceStream(string baseCategory, string resourceName)
        {
            return ThemeName != null 
                ? GetThemeFileStream(baseCategory, resourceName) 
                : GetEmbeddedFileStream(baseCategory, resourceName);
        }

        private static Stream GetThemeFileStream(string baseCategory, string resourceName)
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;

            string assemblyFolder = Path.GetDirectoryName(assemblyLocation);

            if (assemblyFolder == null)
                return null;

            string themeDirectory = Path.Combine(assemblyFolder, "themes", ThemeName);
            string fullFileName = Path.Combine(themeDirectory, baseCategory, resourceName);

            if (!File.Exists(fullFileName))
                return null;

            try
            {
                return new FileStream(fullFileName, FileMode.Open);
            }
            catch
            {
                return null;
            }
        }

        private static Stream GetEmbeddedFileStream(string baseCategory, string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string defaultNamespace = assembly.GetName().Name;

            return assembly.GetManifestResourceStream($"{defaultNamespace}.Resources.{baseCategory}.{resourceName}");
        }

        private static T GetResource<T>(string resourceName, string baseCategory, Func<Stream, T> objectProducer)
        {
            var resource = default(T);

            if (ResourcesCache.ContainsKey(resourceName) && ResourcesCache[resourceName] is T)
                return (T)ResourcesCache[resourceName];

            var stream = GetResourceStream(baseCategory, $"{resourceName}");

            if (stream == null)
                return resource;

            resource = objectProducer.Invoke(stream);
            ResourcesCache[resourceName] = resource;

            return resource;
        }

        public static Icon GetIcon(string iconName)
        {
            return GetResource(iconName + ".ico", "Images", stream => new Icon(stream));
        }

        public static Image GetImage(string imageName)
        {
            return GetResource(imageName + ".png", "Images", stream => new Bitmap(stream));
        }
    }
}
