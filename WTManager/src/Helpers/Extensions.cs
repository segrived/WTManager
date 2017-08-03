using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

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
    }
}
