namespace WTManager.Controls.WtStyle
{
    partial class MetaSelector<T>
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
            this.SelectObjectButton = new System.Windows.Forms.Button();
            this.SelectedDataTextBox = new WTManager.Controls.WtStyle.WtTextBox();
            this.SuspendLayout();
            // 
            // SelectObjectButton
            // 
            this.SelectObjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectObjectButton.Location = new System.Drawing.Point(146, 0);
            this.SelectObjectButton.Margin = new System.Windows.Forms.Padding(0);
            this.SelectObjectButton.Name = "SelectObjectButton";
            this.SelectObjectButton.Size = new System.Drawing.Size(54, 21);
            this.SelectObjectButton.TabIndex = 1;
            this.SelectObjectButton.Text = "...";
            this.SelectObjectButton.UseVisualStyleBackColor = true;
            this.SelectObjectButton.Click += new System.EventHandler(this.Button_SelectContent_OnClick);
            // 
            // SelectedDataTextBox
            // 
            this.SelectedDataTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectedDataTextBox.Location = new System.Drawing.Point(0, 0);
            this.SelectedDataTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.SelectedDataTextBox.MinimumSize = new System.Drawing.Size(0, 21);
            this.SelectedDataTextBox.Name = "SelectedDataTextBox";
            this.SelectedDataTextBox.Size = new System.Drawing.Size(140, 21);
            this.SelectedDataTextBox.TabIndex = 0;
            // 
            // MetaSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.SelectObjectButton);
            this.Controls.Add(this.SelectedDataTextBox);
            this.Name = "MetaSelector";
            this.Size = new System.Drawing.Size(200, 21);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button SelectObjectButton;
        protected WtTextBox SelectedDataTextBox;
    }
}
