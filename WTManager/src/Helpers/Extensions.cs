using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using WTManager.Lib;

namespace WTManager.Helpers
{
    public static class Extensions
    {
        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }

        #region IEnumerable helpers

        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection)
        {
            return new HashSet<T>(collection);
        }

        /// <summary>
        /// https://stackoverflow.com/a/30441479/1250699
        /// </summary>
        public static IEnumerable<TSource> RecursiveSelect<TSource>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TSource>> childSelector)
        {
            var stack = new Stack<IEnumerator<TSource>>();
            var enumerator = source.GetEnumerator();

            try
            {
                while (true)
                {
                    if (enumerator.MoveNext())
                    {
                        TSource element = enumerator.Current;
                        yield return element;

                        stack.Push(enumerator);
                        enumerator = childSelector(element).GetEnumerator();
                    }
                    else if (stack.Count > 0)
                    {
                        enumerator.Dispose();
                        enumerator = stack.Pop();
                    }
                    else
                    {
                        yield break;
                    }
                }
            }
            finally
            {
                enumerator.Dispose();

                while (stack.Count > 0)
                {
                    enumerator = stack.Pop();
                    enumerator.Dispose();
                }
            }
        }

        #endregion

        #region Serialization helpers

        public static bool SerializeFile<T>(this T obj, string fileName)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var writer = new StreamWriter(fileName))
                    serializer.Serialize(writer, obj);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static T DeserializeFile<T>(string fileName) where T : new()
        {
            var resultObj = new T();
            try
            {
                if (!File.Exists(fileName))
                    return resultObj;

                var serializer = new XmlSerializer(typeof(T));

                using (var reader = new StreamReader(fileName))
                    return (T) serializer.Deserialize(reader);
            }
            catch
            {
                return resultObj;
            }
        }

        #endregion

        #region UI extensions

        public static void MoveSelectedItem(this ListBox listBox, int direction)
        {
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
                return;
            
            int newIndex = listBox.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
                return;

            var selected = listBox.SelectedItem;

            listBox.Items.Remove(selected);
            listBox.Items.Insert(newIndex, selected);
            listBox.SetSelected(newIndex, true);
        }

        public static int FindIndex<T>(this ComboBox cb, T value) where T : IEquatable<T>
        {
            for (int i = 0; i < cb.Items.Count; i++)
            {
                var comboItem = cb.Items[i] as ComboBoxItem;

                if (comboItem == null)
                {
                    if (cb.Items[i] == null && value == null)
                        return i;

                    if (cb.Items[i] is T && ((T) cb.Items[i]).Equals(value))
                        return i;
                }
                else
                {
                    if (comboItem.Value == null && value == null)
                        return i;

                    if (comboItem.Value is T && ((T)comboItem.Value).Equals(value))
                        return i;
                }
            }
            return -1;
        }

        public static void SelectByValue<T>(this ComboBox cb, T value) where T : IEquatable<T>
        {
            cb.SelectedIndex = cb.FindIndex(value);
        }

        #endregion
    }
}
