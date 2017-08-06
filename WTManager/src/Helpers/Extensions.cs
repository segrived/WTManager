using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WTManager.Helpers
{
    public static class Extensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> collection)
        {
            return new HashSet<T>(collection);
        }

        public static void AppendText(this RichTextBox textBox, string text, Color color)
        {
            textBox.SelectionStart = textBox.TextLength;
            textBox.SelectionLength = 0;
            textBox.SelectionColor = color;
            textBox.AppendText(text);
            textBox.SelectionColor = textBox.ForeColor;
        }

        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
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

                while (stack.Count > 0) // Clean up in case of an exception.
                {
                    enumerator = stack.Pop();
                    enumerator.Dispose();
                }
            }
        }

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
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                using (var reader = new StreamReader(fileName))
                    return (T) serializer.Deserialize(reader);
            }
            catch
            {
                return new T();
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

        #endregion
    }
}
