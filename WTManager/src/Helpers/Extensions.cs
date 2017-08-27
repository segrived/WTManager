using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WTManager.Helpers
{
    public static class Extensions
    {
        #region UI extensions

        public static void InvokeIfRequired(this Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }

        public static IEnumerable<Control> GetAllChildren(this Control ctrl)
        {
            var stack = new Stack<Control>();
            stack.Push(ctrl);

            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);
                yield return next;
            }
        }

        #endregion

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

        public static T GetAttribute<T, TEnum>(this TEnum enumVal) where T : Attribute where TEnum : struct
        {
            if (!(enumVal is Enum))
                return null;

            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }

        public static bool IsLastIndex<T>(this List<T> list, int index)
            => index == list.Count - 1;

    }

}
