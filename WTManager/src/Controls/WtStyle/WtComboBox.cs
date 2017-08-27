using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using WTManager.Lib;

namespace WTManager.Controls.WtStyle
{
    public class WtComboBox : ComboBox
    {
        public object GetSelectedValue()
        {
            if (this.SelectedItem is ComboBoxItem comboItem)
                return comboItem.Value;

            return this.SelectedItem ?? this.Text;
        }

        public void SetItems(IEnumerable items)
        {
            this.Items.Clear();
            this.Items.AddRange(items.Cast<object>().ToArray());
            // select first item
            this.SelectedIndex = 0;
        }

        public void SetEnumItems<T>() where T : struct 
            => this.SetItems(ComboBoxItem.FromEnum<T>());

        #region Helpers

        private int FindIndex(object value)
        {
            bool IsEqual(object item)
            {
                if (item == null && value == null)
                    return true;

                if (item is IComparable comparable && comparable.CompareTo(value) == 0)
                    return true;

                return false;
            }

            for (int i = 0; i < this.Items.Count; i++)
            {
                var comboItem = this.Items[i] as ComboBoxItem;
                if (comboItem == null && IsEqual(this.Items[i]) || comboItem != null && IsEqual(comboItem.Value))
                    return i;
            }
            return -1;
        }

        public void SelectByValue(object value)
        {
            var itemIndex = this.FindIndex(value);
            this.SelectedIndex = itemIndex == -1 ? 0 : itemIndex;
        }

        #endregion
    }
}