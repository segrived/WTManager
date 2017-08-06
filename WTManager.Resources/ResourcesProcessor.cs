using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

namespace WTManager.Resources
{
    public static class ResourcesProcessor
    {
        private static readonly Dictionary<string, object> ResourcesCache;

        public static event Action ThemeChanged;

        private static string _themeName;

        public static string ThemeName
        {
            get { return _themeName; }
            set
            {
                if (_themeName == value)
                    return;

                _themeName = value;
                ResourcesCache.Clear();

                ThemeChanged?.Invoke();
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

        public static string GetThemesRootDirectory()
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;

            string assemblyFolder = Path.GetDirectoryName(assemblyLocation);

            if (assemblyFolder == null)
                return null;

            return Path.Combine(assemblyFolder, "themes");
        }

        private static Stream GetThemeFileStream(string baseCategory, string resourceName)
        {
            string fullFileName = Path.Combine(GetThemesRootDirectory(), ThemeName, baseCategory, resourceName);

            int lastDotIndex = fullFileName.LastIndexOf('.');
            string subStr = fullFileName.Substring(0, lastDotIndex).Replace('.', '\\');
            fullFileName = subStr + fullFileName.Substring(lastDotIndex);

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
            Stream stream = null;

            try
            {
                var resource = default(T);

                if (ResourcesCache.ContainsKey(resourceName) && ResourcesCache[resourceName] is T)
                    return (T) ResourcesCache[resourceName];

                stream = GetResourceStream(baseCategory, $"{resourceName}");

                if (stream == null)
                    return resource;

                resource = objectProducer.Invoke(stream);
                ResourcesCache[resourceName] = resource;

                return resource;
            }
            finally
            {
                stream?.Dispose();
            }
        }

        public static Icon GetIcon(string iconName)
        {
            return GetResource(iconName + ".ico", "Images", stream => new Icon(stream));
        }

        public static Image GetImage(string imageName)
        {
            return GetResource(imageName + ".png", "Images", stream => new Bitmap(stream));
        }

        public static IEnumerable<string> GetThemesList()
        {
            return Directory
                .EnumerateDirectories(GetThemesRootDirectory())
                .Select(dir => new DirectoryInfo(dir).Name);
        }
    }
}
