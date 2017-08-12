using System.Drawing;
using System.Windows.Forms;

namespace WTManager.Controls.WtSelectorControl
{
    public class FontSelectorControl : MetaSelectorControl<Font>
    {
        private readonly FontConverter _fontConverter;

        public FontSelectorControl()
        {
            this.SelectedDataTextBox.ReadOnly = true;
            this._fontConverter = new FontConverter();
        }

        protected override Font Request()
        {
            var fontDialog = new FontDialog
            {
                ShowEffects = false,
                ShowApply = false,
                FontMustExist = true
            };

            if (this.CurrentState!= null)
                fontDialog.Font = this.CurrentState;

            return fontDialog.ShowDialog() != DialogResult.OK ? null : fontDialog.Font;
        }

        protected override string Serialize(Font dataObject)
        {
            return this._fontConverter.ConvertToString(dataObject);
        }

        protected override Font Deserialize(string serializedData)
        {
            try
            {
                return this._fontConverter.ConvertFrom(serializedData) as Font;
            }
            catch
            {
                return null;
            }
        }
    }
}