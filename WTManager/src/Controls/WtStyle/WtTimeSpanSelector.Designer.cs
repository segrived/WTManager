namespace WTManager.Controls.WtStyle
{
    partial class WtTimeSpanSelector
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
            this.NumberSelector = new System.Windows.Forms.NumericUpDown();
            this.UnitSelector = new WTManager.Controls.WtStyle.WtComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumberSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // NumberSelector
            // 
            this.NumberSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NumberSelector.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NumberSelector.Location = new System.Drawing.Point(0, 0);
            this.NumberSelector.Margin = new System.Windows.Forms.Padding(0);
            this.NumberSelector.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumberSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumberSelector.Name = "NumberSelector";
            this.NumberSelector.Size = new System.Drawing.Size(199, 20);
            this.NumberSelector.TabIndex = 0;
            this.NumberSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UnitSelector
            // 
            this.UnitSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UnitSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UnitSelector.FormattingEnabled = true;
            this.UnitSelector.Location = new System.Drawing.Point(205, 0);
            this.UnitSelector.Margin = new System.Windows.Forms.Padding(0);
            this.UnitSelector.Name = "UnitSelector";
            this.UnitSelector.Size = new System.Drawing.Size(171, 21);
            this.UnitSelector.TabIndex = 1;
            // 
            // WtTimeSpanSelector
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.UnitSelector);
            this.Controls.Add(this.NumberSelector);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WtTimeSpanSelector";
            this.Size = new System.Drawing.Size(376, 21);
            ((System.ComponentModel.ISupportInitialize)(this.NumberSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NumberSelector;
        private WtComboBox UnitSelector;
    }
}
