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
            this.servicesListBox = new System.Windows.Forms.ListBox();
            this.addServiceBtn = new System.Windows.Forms.Button();
            this.editServiceBtn = new System.Windows.Forms.Button();
            this.removeServiceBtn = new System.Windows.Forms.Button();
            this.cancelChangesBtn = new System.Windows.Forms.Button();
            this.applyChangesBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // servicesListBox
            // 
            this.servicesListBox.FormattingEnabled = true;
            this.servicesListBox.Location = new System.Drawing.Point(12, 12);
            this.servicesListBox.Name = "servicesListBox";
            this.servicesListBox.Size = new System.Drawing.Size(386, 368);
            this.servicesListBox.TabIndex = 0;
            // 
            // addServiceBtn
            // 
            this.addServiceBtn.Location = new System.Drawing.Point(404, 12);
            this.addServiceBtn.Name = "addServiceBtn";
            this.addServiceBtn.Size = new System.Drawing.Size(190, 42);
            this.addServiceBtn.TabIndex = 1;
            this.addServiceBtn.Text = "Add new service";
            this.addServiceBtn.UseVisualStyleBackColor = true;
            this.addServiceBtn.Click += new System.EventHandler(this.addServiceBtn_Click);
            // 
            // editServiceBtn
            // 
            this.editServiceBtn.Location = new System.Drawing.Point(404, 60);
            this.editServiceBtn.Name = "editServiceBtn";
            this.editServiceBtn.Size = new System.Drawing.Size(190, 42);
            this.editServiceBtn.TabIndex = 1;
            this.editServiceBtn.Text = "Edit selected";
            this.editServiceBtn.UseVisualStyleBackColor = true;
            this.editServiceBtn.Click += new System.EventHandler(this.editServiceBtn_Click);
            // 
            // removeServiceBtn
            // 
            this.removeServiceBtn.Location = new System.Drawing.Point(404, 108);
            this.removeServiceBtn.Name = "removeServiceBtn";
            this.removeServiceBtn.Size = new System.Drawing.Size(190, 42);
            this.removeServiceBtn.TabIndex = 1;
            this.removeServiceBtn.Text = "Remove selected";
            this.removeServiceBtn.UseVisualStyleBackColor = true;
            this.removeServiceBtn.Click += new System.EventHandler(this.removeServiceBtn_Click);
            // 
            // cancelChangesBtn
            // 
            this.cancelChangesBtn.Location = new System.Drawing.Point(404, 335);
            this.cancelChangesBtn.Name = "cancelChangesBtn";
            this.cancelChangesBtn.Size = new System.Drawing.Size(190, 42);
            this.cancelChangesBtn.TabIndex = 1;
            this.cancelChangesBtn.Text = "Cancel changes";
            this.cancelChangesBtn.UseVisualStyleBackColor = true;
            this.cancelChangesBtn.Click += new System.EventHandler(this.removeServiceBtn_Click);
            // 
            // applyChangesBtn
            // 
            this.applyChangesBtn.Location = new System.Drawing.Point(404, 287);
            this.applyChangesBtn.Name = "applyChangesBtn";
            this.applyChangesBtn.Size = new System.Drawing.Size(190, 42);
            this.applyChangesBtn.TabIndex = 1;
            this.applyChangesBtn.Text = "Apply changes";
            this.applyChangesBtn.UseVisualStyleBackColor = true;
            this.applyChangesBtn.Click += new System.EventHandler(this.applyChangesBtn_Click);
            // 
            // ServiceConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 389);
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