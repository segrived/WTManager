using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using WTManager.Resources;

namespace WTManager.Controls.WtStyle
{
    public partial class WtItemEditor : WtUserControl
    {
        #region Private fields

        private bool _showAddButton = true;
        private bool _showEditButton = true;
        private bool _showRemoveButton = true;
        private bool _showUpButton = true;
        private bool _showDownButton = true;

        private int _verticalPaddingBetweenButtons = 5;
        private int _buttonSize = 30;

        #endregion

        #region Designer properties

        [Category("WT Controls")]
        [DisplayName("VerticalPaddingBetweenButtons")]
        public int VerticalPaddingBetweenButtons
        {
            get { return this._verticalPaddingBetweenButtons; }
            set
            {
                this._verticalPaddingBetweenButtons = value;
                this.UpdateInterface();
            }
        }

        [Category("WT Controls")]
        [DisplayName("ButtonSize")]
        public int ButtonSize
        {
            get { return this._buttonSize; }
            set
            {
                this._buttonSize = value; 
                this.UpdateInterface();
            }
        }

        [Category("WT Controls")]
        [DisplayName("RemoveConfirmationText")]
        public string RemoveConfirmationText { get; set; } = String.Empty;

        [Category("WT Controls")]
        [DisplayName("ShowAddButton")]
        public bool ShowAddButton
        {
            get { return this._showAddButton; }
            set
            {
                this._showAddButton = value; 
                this.UpdateInterface();
            }
        }

        [Category("WT Controls")]
        [DisplayName("ShowEditButton")]
        public bool ShowEditButton
        {
            get { return this._showEditButton; }
            set
            {
                this._showEditButton = value;
                this.UpdateInterface();
            }
        }

        [Category("WT Controls")]
        [DisplayName("ShowRemoveButton")]
        public bool ShowRemoveButton
        {
            get { return this._showRemoveButton; }
            set
            {
                this._showRemoveButton = value;
                this.UpdateInterface();
            }
        }

        [Category("WT Controls")]
        [DisplayName("ShowUpButton")]
        public bool ShowUpButton
        {
            get { return this._showUpButton; }
            set
            {
                this._showUpButton = value;
                this.UpdateInterface();
            }
        }

        [Category("WT Controls")]
        [DisplayName("ShowDownButton")]
        public bool ShowDownButton
        {
            get { return this._showDownButton; }
            set
            {
                this._showDownButton = value;
                this.UpdateInterface();
            }
        }

        [Category("WT Controls")]
        [DisplayName("UseRemoveConfirmation")]
        [Description("If true, when user try to remove item, confirmation screen will be shown")]
        public bool UseRemoveConfirmation { get; set; } = true;

        [Category("WT Controls")]
        [DisplayName("EditOnDoubleClick")]
        [Description("If true, edit action will be executed on item double click")]
        public bool EditOnDoubleClick { get; set; } = true;

        [Category("WT Controls")]
        [DisplayName("RemoveItemOnDeleteKeyPress")]
        public bool RemoveItemOnDeleteKeyPress { get; set; } = true;

        #endregion

        #region Add/edit functions

        public Func<object> AddRequest = null;
        public Func<object, object> EditRequest = null;

        #endregion

        #region Constructors

        public WtItemEditor() => this.InitializeComponent();

        #endregion

        #region Form control event handlers

        private void AddItemButton_OnClick(object sender, EventArgs eventArgs)
            => this.AddNewItem();

        private void EditItemButton_OnClick(object sender, EventArgs eventArgs)
            => this.EditSelectedItem();

        private void RemoveItemButton_OnClick(object sender, EventArgs eventArgs) 
            => this.RemoveSelectedItems();

        private void DownItemButton_OnClick(object sender, EventArgs eventArgs) 
            => this.MoveSelectedItem(1);

        private void UpItemButton_OnClick(object sender, EventArgs eventArgs) 
            => this.MoveSelectedItem(-1);

        private void ItemsListBox_OnSelectedIndexChanged(object sender, EventArgs eventArgs) 
            => this.UpdateButtonEnability();

        private void ItemsListBox_OnMouseDoubleClick(object sender, MouseEventArgs mouseEventArgs)
        {
            if (this.EditOnDoubleClick)
                this.EditSelectedItem();
        }

        private void ItemsListBox_OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            if (this.RemoveItemOnDeleteKeyPress && keyEventArgs.KeyCode == Keys.Delete)
                this.RemoveSelectedItems();
        }

        #endregion

        #region Get/set items logic

        public IEnumerable<T> GetItems<T>()
        {
            return this.ItemsListBox.Items.OfType<T>();
        }

        public void SetItems(IEnumerable<object> items)
        {
            this.ItemsListBox.Items.AddRange(items.ToArray());
            this.UpdateButtonEnability();
        }

        #endregion

        #region Interface update logic

        private void UpdateInterface()
        {
            int topCoord = 0;
            int bottomCoord = this.Height;

            this.ItemsListBox.Location = new Point(0, 0);
            this.ItemsListBox.Size = new Size(this.Width - this.ButtonSize - 5, this.Height);

            this.RelocateUpButton(this.AddItemButton, this.ShowAddButton, ref topCoord);
            this.RelocateUpButton(this.EditItemButton, this.ShowEditButton, ref topCoord);
            this.RelocateUpButton(this.RemoveItemButton, this.ShowRemoveButton, ref topCoord);
            this.RelocateDownButton(this.DownItemButton, this.ShowDownButton, ref bottomCoord);
            this.RelocateDownButton(this.UpItemButton, this.ShowUpButton, ref bottomCoord);
        }

        private void RelocateUpButton(Control btn, bool isVisible, ref int topCoord)
        {
            btn.Visible = isVisible;
            btn.Size = new Size(this.ButtonSize, this.ButtonSize);

            if (!isVisible)
                return;

            int btnLeftCoord = this.Width - btn.Width;
            btn.Location = new Point(btnLeftCoord, topCoord);
            topCoord += btn.Height + this.VerticalPaddingBetweenButtons;
        }

        private void RelocateDownButton(Control btn, bool isVisible, ref int bottomCoord)
        {
            btn.Visible = isVisible;
            btn.Size = new Size(this.ButtonSize, this.ButtonSize);
            if (!isVisible)
                return;

            int btnLeftCoord = this.Width - btn.Width;
            int btnTopCoord = bottomCoord - btn.Height;
            btn.Location = new Point(btnLeftCoord, btnTopCoord);
            bottomCoord = btnTopCoord - this.VerticalPaddingBetweenButtons;
        }

        private void UpdateButtonEnability()
        {
            bool IsAnyItemSelected() =>
                this.ItemsListBox.SelectedIndices.Count > 0;

            bool IsOneItemSelected() =>
                this.ItemsListBox.SelectedIndices.Count == 1;

            bool IsFirstIndexSelected() =>
                this.ItemsListBox.SelectedIndices[0] == 0;

            bool IsLastIndexSelected() =>
                this.ItemsListBox.SelectedIndices[0] == this.ItemsListBox.Items.Count - 1;

            this.EditItemButton.Enabled = IsOneItemSelected();
            this.RemoveItemButton.Enabled = IsAnyItemSelected();

            this.UpItemButton.Enabled = IsOneItemSelected() && !IsFirstIndexSelected();
            this.DownItemButton.Enabled = IsOneItemSelected() && !IsLastIndexSelected();
        }

        #endregion

        #region Base form override

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.UpdateInterface();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.UpdateButtonEnability();
        }

        #endregion

        #region Add/edit/remove/up/down logic

        private void AddNewItem()
        {
            var newItem = this.AddRequest?.Invoke();
            if (newItem != null)
                this.ItemsListBox.Items.Add(newItem);
        }

        private void EditSelectedItem()
        {
            int index = this.ItemsListBox.SelectedIndex;

            if (index == -1)
                return;

            var item = this.EditRequest?.Invoke(this.ItemsListBox.SelectedItem);
            if (item != null)
                this.ItemsListBox.Items[index] = item;
        }

        private void RemoveSelectedItems()
        {
            if (this.ItemsListBox.SelectedItems.Count == 0)
                return;

            if (this.UseRemoveConfirmation)
            {
                string text = String.IsNullOrEmpty(this.RemoveConfirmationText) 
                    ? "Do you really want to delete selected item(s)?"
                    : this.RemoveConfirmationText;

                string title = "Remove item confirmation";

                if (MessageBox.Show(this, text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
            }

            var selectedItems = this.ItemsListBox.SelectedItems.OfType<object>().ToList();
            foreach (var service in selectedItems)
                this.ItemsListBox.Items.Remove(service);
        }

        private void MoveSelectedItem(int direction)
        {
            if (this.ItemsListBox.SelectedItem == null || this.ItemsListBox.SelectedIndex < 0)
                return;
            
            int newIndex = this.ItemsListBox.SelectedIndex + direction;
            if (newIndex < 0 || newIndex >= this.ItemsListBox.Items.Count)
                return;

            var selected = this.ItemsListBox.SelectedItem;

            this.ItemsListBox.Items.Remove(selected);
            this.ItemsListBox.Items.Insert(newIndex, selected);
            this.ItemsListBox.SetSelected(newIndex, true);
        }

        #endregion

        #region Themes support

        protected override void ApplyTheme()
        {
            this.AddItemButton.Image = ResourcesProcessor.GetImage("dialog.add");
            this.EditItemButton.Image = ResourcesProcessor.GetImage("dialog.edit");
            this.RemoveItemButton.Image = ResourcesProcessor.GetImage("dialog.remove");

            this.UpItemButton.Image = ResourcesProcessor.GetImage("dialog.up");
            this.DownItemButton.Image = ResourcesProcessor.GetImage("dialog.down");
        }

        #endregion
    }
}