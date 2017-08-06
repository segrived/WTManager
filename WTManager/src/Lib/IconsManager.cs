using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace WTManager.Lib
{
    public static class IconsManager
    {
        public static readonly Dictionary<string, Image> Icons
            = new Dictionary<string, Image>();

        static IconsManager()
        {
            var resSet = Resources.Graphics.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            foreach (DictionaryEntry entry in resSet)
            {
                if (!(entry.Value is Icon))
                    continue;

                string iconName = ((string)entry.Key).ToLower();
                Image iconData = ((Icon)entry.Value).ToBitmap();

                Icons.Add(iconName, iconData);
            }
        }
    }
}
