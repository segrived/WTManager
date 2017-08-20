using System;
using System.Collections;
using System.Linq;
using System.Windows.Forms;
using WTManager.Lib;

namespace WTManager.Controls.WtStyle
{
    public interface IWtCollectionControl
    {
        void SetItems(IEnumerable items);
    }

    public class WtComboBox : ComboBox
    {
        public object GetSelectedValue()
        {
            var comboItem = this.SelectedItem as ComboBoxItem;

            if (comboItem != null)
                return comboItem.Value;

            return this.SelectedItem;
        }

        public void SetItems(IEnumerable items)
        {
            this.Items.Clear();
            this.Items.AddRange(items.Cast<object>().ToArray());
        }

        #region Helpers

        private int FindIndex(object value)
        {
            bool IsEqual(object item)
            {
                if (item == null && value == null)
                    return true;

                var comparable = item as IComparable;
                if (comparable != null && comparable.CompareTo(value) == 0)
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
            this.SelectedIndex = this.FindIndex(value);
        }

        #endregion
    }
}