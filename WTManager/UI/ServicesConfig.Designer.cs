namespace WTManager.UI
{
    partial class ServiceConfigForm
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.applyChangesBtn = new System.Windows.Forms.Button();
            this.cancelChangesBtn = new System.Windows.Forms.Button();
            this.removeServiceBtn = new System.Windows.Forms.Button();
            this.editServiceBtn = new System.Windows.Forms.Button();
            this.addServiceBtn = new System.Windows.Forms.Button();
            this.servicesListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // applyChangesBtn
            // 
            this.applyChangesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyChangesBtn.Location = new System.Drawing.Point(306, 340);
            this.applyChangesBtn.Name = "applyChangesBtn";
            this.applyChangesBtn.Size = new System.Drawing.Size(151, 30);
            this.applyChangesBtn.TabIndex = 1;
            this.applyChangesBtn.Text = "Apply changes";
            this.applyChangesBtn.UseVisualStyleBackColor = true;
            this.applyChangesBtn.Click += new System.EventHandler(this.applyChangesBtn_Click);
            // 
            // cancelChangesBtn
            // 
            this.cancelChangesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelChangesBtn.Location = new System.Drawing.Point(306, 376);
            this.cancelChangesBtn.Name = "cancelChangesBtn";
            this.cancelChangesBtn.Size = new System.Drawing.Size(151, 30);
            this.cancelChangesBtn.TabIndex = 1;
            this.cancelChangesBtn.Text = "Cancel changes";
            this.cancelChangesBtn.UseVisualStyleBackColor = true;
            this.cancelChangesBtn.Click += new System.EventHandler(this.removeServiceBtn_Click);
            // 
            // removeServiceBtn
            // 
            this.removeServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeServiceBtn.Location = new System.Drawing.Point(306, 86);
            this.removeServiceBtn.Name = "removeServiceBtn";
            this.removeServiceBtn.Size = new System.Drawing.Size(151, 30);
            this.removeServiceBtn.TabIndex = 1;
            this.removeServiceBtn.Text = "Remove";
            this.removeServiceBtn.UseVisualStyleBackColor = true;
            this.removeServiceBtn.Click += new System.EventHandler(this.removeServiceBtn_Click);
            // 
            // editServiceBtn
            // 
            this.editServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editServiceBtn.Location = new System.Drawing.Point(306, 50);
            this.editServiceBtn.Name = "editServiceBtn";
            this.editServiceBtn.Size = new System.Drawing.Size(151, 30);
            this.editServiceBtn.TabIndex = 1;
            this.editServiceBtn.Text = "Edit";
            this.editServiceBtn.UseVisualStyleBackColor = true;
            this.editServiceBtn.Click += new System.EventHandler(this.editServiceBtn_Click);
            // 
            // addServiceBtn
            // 
            this.addServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addServiceBtn.Location = new System.Drawing.Point(306, 14);
            this.addServiceBtn.Name = "addServiceBtn";
            this.addServiceBtn.Size = new System.Drawing.Size(151, 30);
            this.addServiceBtn.TabIndex = 1;
            this.addServiceBtn.Text = "Add";
            this.addServiceBtn.UseVisualStyleBackColor = true;
            this.addServiceBtn.Click += new System.EventHandler(this.addServiceBtn_Click);
            // 
            // servicesListBox
            // 
            this.servicesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.servicesListBox.FormattingEnabled = true;
            this.servicesListBox.IntegralHeight = false;
            this.servicesListBox.ItemHeight = 15;
            this.servicesListBox.Location = new System.Drawing.Point(14, 14);
            this.servicesListBox.Name = "servicesListBox";
            this.servicesListBox.Size = new System.Drawing.Size(286, 392);
            this.servicesListBox.TabIndex = 0;
            // 
            // ServiceConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 418);
            this.Controls.Add(this.applyChangesBtn);
            this.Controls.Add(this.cancelChangesBtn);
            this.Controls.Add(this.removeServiceBtn);
            this.Controls.Add(this.editServiceBtn);
            this.Controls.Add(this.addServiceBtn);
            this.Controls.Add(this.servicesListBox);
            this.Name = "ServiceConfigForm";
            this.Text = "ServicesConfig";
            this.Load += new System.EventHandler(this.ServiceConfigForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox servicesListBox;
        private System.Windows.Forms.Button addServiceBtn;
        private System.Windows.Forms.Button editServiceBtn;
        private System.Windows.Forms.Button removeServiceBtn;
        private System.Windows.Forms.Button cancelChangesBtn;
        private System.Windows.Forms.Button applyChangesBtn;
    }
}