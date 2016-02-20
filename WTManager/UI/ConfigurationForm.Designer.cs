﻿namespace WTManager.UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.applyChangesBtn = new System.Windows.Forms.Button();
            this.cancelChangesBtn = new System.Windows.Forms.Button();
            this.removeServiceBtn = new System.Windows.Forms.Button();
            this.editServiceBtn = new System.Windows.Forms.Button();
            this.addServiceBtn = new System.Windows.Forms.Button();
            this.servicesListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectLogViewerPathBtn = new System.Windows.Forms.Button();
            this.selectConfigEditorPathBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logViewerPathTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.configEditorPathTb = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // applyChangesBtn
            // 
            this.applyChangesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyChangesBtn.Location = new System.Drawing.Point(103, 387);
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
            this.cancelChangesBtn.Location = new System.Drawing.Point(260, 387);
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
            this.removeServiceBtn.Location = new System.Drawing.Point(283, 99);
            this.removeServiceBtn.Name = "removeServiceBtn";
            this.removeServiceBtn.Size = new System.Drawing.Size(105, 30);
            this.removeServiceBtn.TabIndex = 1;
            this.removeServiceBtn.Text = "Remove";
            this.removeServiceBtn.UseVisualStyleBackColor = true;
            this.removeServiceBtn.Click += new System.EventHandler(this.removeServiceBtn_Click);
            // 
            // editServiceBtn
            // 
            this.editServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editServiceBtn.Location = new System.Drawing.Point(283, 63);
            this.editServiceBtn.Name = "editServiceBtn";
            this.editServiceBtn.Size = new System.Drawing.Size(105, 30);
            this.editServiceBtn.TabIndex = 1;
            this.editServiceBtn.Text = "Edit";
            this.editServiceBtn.UseVisualStyleBackColor = true;
            this.editServiceBtn.Click += new System.EventHandler(this.editServiceBtn_Click);
            // 
            // addServiceBtn
            // 
            this.addServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addServiceBtn.Location = new System.Drawing.Point(283, 27);
            this.addServiceBtn.Name = "addServiceBtn";
            this.addServiceBtn.Size = new System.Drawing.Size(105, 30);
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
            this.servicesListBox.Location = new System.Drawing.Point(11, 27);
            this.servicesListBox.Name = "servicesListBox";
            this.servicesListBox.Size = new System.Drawing.Size(266, 237);
            this.servicesListBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.servicesListBox);
            this.groupBox1.Controls.Add(this.addServiceBtn);
            this.groupBox1.Controls.Add(this.editServiceBtn);
            this.groupBox1.Controls.Add(this.removeServiceBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(399, 275);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.selectLogViewerPathBtn);
            this.groupBox2.Controls.Add(this.selectConfigEditorPathBtn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.logViewerPathTb);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.configEditorPathTb);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox2.Size = new System.Drawing.Size(399, 85);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferences";
            // 
            // selectLogViewerPathBtn
            // 
            this.selectLogViewerPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectLogViewerPathBtn.Location = new System.Drawing.Point(335, 50);
            this.selectLogViewerPathBtn.Name = "selectLogViewerPathBtn";
            this.selectLogViewerPathBtn.Size = new System.Drawing.Size(53, 23);
            this.selectLogViewerPathBtn.TabIndex = 2;
            this.selectLogViewerPathBtn.Text = "...";
            this.selectLogViewerPathBtn.UseVisualStyleBackColor = true;
            this.selectLogViewerPathBtn.Click += new System.EventHandler(this.selectLogViewerPathBtn_Click);
            // 
            // selectConfigEditorPathBtn
            // 
            this.selectConfigEditorPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectConfigEditorPathBtn.Location = new System.Drawing.Point(335, 21);
            this.selectConfigEditorPathBtn.Name = "selectConfigEditorPathBtn";
            this.selectConfigEditorPathBtn.Size = new System.Drawing.Size(53, 23);
            this.selectConfigEditorPathBtn.TabIndex = 2;
            this.selectConfigEditorPathBtn.Text = "...";
            this.selectConfigEditorPathBtn.UseVisualStyleBackColor = true;
            this.selectConfigEditorPathBtn.Click += new System.EventHandler(this.selectConfigEditorPathBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "Log viewer:";
            // 
            // logViewerPathTb
            // 
            this.logViewerPathTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logViewerPathTb.Location = new System.Drawing.Point(110, 50);
            this.logViewerPathTb.Name = "logViewerPathTb";
            this.logViewerPathTb.Size = new System.Drawing.Size(219, 23);
            this.logViewerPathTb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Config editor:";
            // 
            // configEditorPathTb
            // 
            this.configEditorPathTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configEditorPathTb.Location = new System.Drawing.Point(110, 21);
            this.configEditorPathTb.Name = "configEditorPathTb";
            this.configEditorPathTb.Size = new System.Drawing.Size(219, 23);
            this.configEditorPathTb.TabIndex = 0;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 429);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.applyChangesBtn);
            this.Controls.Add(this.cancelChangesBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigurationForm";
            this.Text = "WTManager Configuration";
            this.Load += new System.EventHandler(this.ServiceConfigForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox servicesListBox;
        private System.Windows.Forms.Button addServiceBtn;
        private System.Windows.Forms.Button editServiceBtn;
        private System.Windows.Forms.Button removeServiceBtn;
        private System.Windows.Forms.Button cancelChangesBtn;
        private System.Windows.Forms.Button applyChangesBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button selectLogViewerPathBtn;
        private System.Windows.Forms.Button selectConfigEditorPathBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logViewerPathTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox configEditorPathTb;
    }
}