namespace WTManager.Controls.WtStyle
{
    partial class WtItemEditor
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ItemsListBox = new System.Windows.Forms.ListBox();
            this.AddItemButton = new System.Windows.Forms.Button();
            this.EditItemButton = new System.Windows.Forms.Button();
            this.RemoveItemButton = new System.Windows.Forms.Button();
            this.DownItemButton = new System.Windows.Forms.Button();
            this.UpItemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ItemsListBox
            // 
            this.ItemsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsListBox.FormattingEnabled = true;
            this.ItemsListBox.IntegralHeight = false;
            this.ItemsListBox.Location = new System.Drawing.Point(0, 0);
            this.ItemsListBox.Name = "ItemsListBox";
            this.ItemsListBox.Size = new System.Drawing.Size(276, 356);
            this.ItemsListBox.TabIndex = 0;
            this.ItemsListBox.SelectedIndexChanged += new System.EventHandler(this.ItemsListBox_OnSelectedIndexChanged);
            this.ItemsListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ItemsListBox_OnKeyUp);
            this.ItemsListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ItemsListBox_OnMouseDoubleClick);
            // 
            // AddItemButton
            // 
            this.AddItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.AddItemButton.Location = new System.Drawing.Point(282, 2);
            this.AddItemButton.Name = "AddItemButton";
            this.AddItemButton.Size = new System.Drawing.Size(30, 30);
            this.AddItemButton.TabIndex = 1;
            this.AddItemButton.UseVisualStyleBackColor = true;
            this.AddItemButton.Click += new System.EventHandler(this.AddItemButton_OnClick);
            // 
            // EditItemButton
            // 
            this.EditItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.EditItemButton.Location = new System.Drawing.Point(282, 38);
            this.EditItemButton.Name = "EditItemButton";
            this.EditItemButton.Size = new System.Drawing.Size(30, 30);
            this.EditItemButton.TabIndex = 1;
            this.EditItemButton.UseVisualStyleBackColor = true;
            this.EditItemButton.Click += new System.EventHandler(this.EditItemButton_OnClick);
            // 
            // RemoveItemButton
            // 
            this.RemoveItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.RemoveItemButton.Location = new System.Drawing.Point(282, 74);
            this.RemoveItemButton.Name = "RemoveItemButton";
            this.RemoveItemButton.Size = new System.Drawing.Size(30, 30);
            this.RemoveItemButton.TabIndex = 1;
            this.RemoveItemButton.UseVisualStyleBackColor = true;
            this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_OnClick);
            // 
            // DownItemButton
            // 
            this.DownItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DownItemButton.Location = new System.Drawing.Point(282, 325);
            this.DownItemButton.Name = "DownItemButton";
            this.DownItemButton.Size = new System.Drawing.Size(30, 30);
            this.DownItemButton.TabIndex = 1;
            this.DownItemButton.UseVisualStyleBackColor = true;
            this.DownItemButton.Click += new System.EventHandler(this.DownItemButton_OnClick);
            // 
            // UpItemButton
            // 
            this.UpItemButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.UpItemButton.Location = new System.Drawing.Point(282, 289);
            this.UpItemButton.Name = "UpItemButton";
            this.UpItemButton.Size = new System.Drawing.Size(30, 30);
            this.UpItemButton.TabIndex = 1;
            this.UpItemButton.UseVisualStyleBackColor = true;
            this.UpItemButton.Click += new System.EventHandler(this.UpItemButton_OnClick);
            // 
            // WtItemEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.UpItemButton);
            this.Controls.Add(this.DownItemButton);
            this.Controls.Add(this.RemoveItemButton);
            this.Controls.Add(this.EditItemButton);
            this.Controls.Add(this.AddItemButton);
            this.Controls.Add(this.ItemsListBox);
            this.Name = "WtItemEditor";
            this.Size = new System.Drawing.Size(312, 356);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ItemsListBox;
        private System.Windows.Forms.Button AddItemButton;
        private System.Windows.Forms.Button EditItemButton;
        private System.Windows.Forms.Button RemoveItemButton;
        private System.Windows.Forms.Button DownItemButton;
        private System.Windows.Forms.Button UpItemButton;
    }
}
