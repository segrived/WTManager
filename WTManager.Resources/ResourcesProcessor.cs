using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace WtManager.Resources
{
    public static class ResourcesProcessor
    {
        private const string THEMES_DIRECTORY = "themes";

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
            Stream resourceStream = null;

            if (ThemeName != null)
                resourceStream = GetThemeFileStream(baseCategory, resourceName);

            // fallback to default embedded resource if theme file is not exist
            return resourceStream ?? GetEmbeddedFileStream(baseCategory, resourceName);
        }

        public static string GetThemesRootDirectory()
        {
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;

            string assemblyFolder = Path.GetDirectoryName(assemblyLocation);

            if (assemblyFolder == null)
                return null;

            return Path.Combine(assemblyFolder, THEMES_DIRECTORY);
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

            return assembly.GetManifestResourceStream($"{defaultNamespace}.{baseCategory}.{resourceName}");
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

        public static string GetLocalizationFile(string language)
        {
            return GetResource(language + ".ini", "Locales", stream => new StreamReader(stream).ReadToEnd());
        }

        public static IEnumerable<string> GetThemesList()
        {
            if (! Directory.Exists(GetThemesRootDirectory()))
                yield break;

            var subDirs = Directory.EnumerateDirectories(GetThemesRootDirectory());
            foreach (string dir in subDirs)
                yield return new DirectoryInfo(dir).Name;
        }
    }
}
