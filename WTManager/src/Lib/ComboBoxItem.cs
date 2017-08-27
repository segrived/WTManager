using System;
using System.Collections.Generic;
using System.ComponentModel;
using WTManager.Helpers;

namespace WTManager.Lib
{
    public class ComboBoxItem
    {
        /// <summary>
        /// Combo box item key
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Combo box item value
        /// </summary>
        public object Value { get; private set; }

        public ComboBoxItem(string key)
        {
            this.Key = key;
            this.Value = key;
        }

        public ComboBoxItem(string key, object value)
        {
            this.Key = key;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Key;
        }

        public static IEnumerable<ComboBoxItem> FromEnum<T>() where T : struct
        {
            foreach (T enumItem in Enum.GetValues(typeof(T)))
            {
                var attr = enumItem.GetAttribute<DescriptionAttribute, T>();
                string descritption = attr?.Description ?? enumItem.ToString();
                yield return new ComboBoxItem(descritption, enumItem);
            }
        }
    }
}
