using System;
using System.Collections.Generic;
using WtManager.Resources;

namespace WtManager.Lib
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
                string name =$"Enums.{typeof(T).Name}.{enumItem.ToString()}";
                string localizedDescription = LocalizationManager.Get(name);
                    yield return new ComboBoxItem(localizedDescription, enumItem);

                //var attr = enumItem.GetAttribute<DescriptionAttribute, T>();

                //if (attr?.Description == null)
                //    yield return new ComboBoxItem(enumItem.ToString(), enumItem);

                //if (localizedDescription != null)
                //    yield return new ComboBoxItem(enumItem.ToString(), enumItem);
                //else
                //    yield return new ComboBoxItem(attr?.Description, enumItem);
            }
        }
    }
}
