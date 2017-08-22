namespace WTManager.Forms
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (this.components != null)) {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.servicesList = new WTManager.Controls.WtStyle.WtItemEditor();
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.basicConfigurationEditor = new WTManager.Controls.WtStyle.WtConfigurator();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.servicesList);
            this.groupBox1.Location = new System.Drawing.Point(446, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(358, 501);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // servicesList
            // 
            this.servicesList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.servicesList.ButtonSize = 30;
            this.servicesList.EditOnDoubleClick = true;
            this.servicesList.Location = new System.Drawing.Point(11, 27);
            this.servicesList.Name = "servicesList";
            this.servicesList.RemoveConfirmationText = "";
            this.servicesList.RemoveItemOnDeleteKeyPress = true;
            this.servicesList.ShowAddButton = true;
            this.servicesList.ShowDownButton = true;
            this.servicesList.ShowEditButton = true;
            this.servicesList.ShowRemoveButton = true;
            this.servicesList.ShowUpButton = true;
            this.servicesList.Size = new System.Drawing.Size(336, 463);
            this.servicesList.TabIndex = 0;
            this.servicesList.UseRemoveConfirmation = true;
            this.servicesList.VerticalPaddingBetweenButtons = 5;
            // 
            // applyBtn
            // 
            this.applyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyBtn.Image = ((System.Drawing.Image)(resources.GetObject("applyBtn.Image")));
            this.applyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applyBtn.Location = new System.Drawing.Point(496, 519);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.applyBtn.Size = new System.Drawing.Size(151, 30);
            this.applyBtn.TabIndex = 1;
            this.applyBtn.Text = "OK";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(653, 519);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cancelBtn.Size = new System.Drawing.Size(151, 30);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // basicConfigurationEditor
            // 
            this.basicConfigurationEditor.Location = new System.Drawing.Point(12, 12);
            this.basicConfigurationEditor.Name = "basicConfigurationEditor";
            this.basicConfigurationEditor.Size = new System.Drawing.Size(428, 501);
            this.basicConfigurationEditor.TabIndex = 1;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 561);
            this.Controls.Add(this.basicConfigurationEditor);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.cancelBtn);
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WTManager Configuration";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.WtStyle.WtItemEditor servicesList;
        private Controls.WtStyle.WtConfigurator basicConfigurationEditor;
    }
}