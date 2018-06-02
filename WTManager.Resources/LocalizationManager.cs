using System.Collections.Generic;
using IniParser.Model;
using IniParser.Parser;

namespace WtManager.Resources
{
    public static class LocalizationManager
    {
        private static LocalizationItem _item;

        public static readonly List<string> LocalesList = new List<string> {"english", "russian"};

        static LocalizationManager()
        {
            UpdateLocale("english");
        }


        public static void UpdateLocale(string locale)
        {
            var localization = ResourcesProcessor.GetLocalizationFile(locale);
            _item = new LocalizationItem(localization);
        }

        public static string Get(string key, params string[] parameters)
        {
            try
            {
                return _item.GetValue(key) ?? key;
            }
            catch
            {
                return key;
            }
        }
    }

    public class LocalizationItem
    {
        private IniData _localizationData;


        public LocalizationItem(string inputStream)
        {
            var parser = new IniDataParser();
            this._localizationData = parser.Parse(inputStream);
        }

        public string GetValue(string key)
        {
            return this._localizationData["Localization"][key];
        }
    }
}
