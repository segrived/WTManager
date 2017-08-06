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
            this.OkBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.removeServiceBtn = new System.Windows.Forms.Button();
            this.editServiceBtn = new System.Windows.Forms.Button();
            this.addServiceBtn = new System.Windows.Forms.Button();
            this.servicesListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupsListBox = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbShowPopupMessages = new System.Windows.Forms.CheckBox();
            this.selectLogViewerPathBtn = new System.Windows.Forms.Button();
            this.selectConfigEditorPathBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.logViewerPathTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.configEditorPathTb = new System.Windows.Forms.TextBox();
            this.selectCustomTrayIconBtn = new System.Windows.Forms.Button();
            this.lblCustomTrayIcon = new System.Windows.Forms.Label();
            this.customTrayIconTb = new System.Windows.Forms.TextBox();
            this.cbShowMenuBeyondTaskbar = new System.Windows.Forms.CheckBox();
            this.selectMenuFontBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuFontTb = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Image = ((System.Drawing.Image)(resources.GetObject("OkBtn.Image")));
            this.OkBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkBtn.Location = new System.Drawing.Point(688, 519);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.OkBtn.Size = new System.Drawing.Size(151, 30);
            this.OkBtn.TabIndex = 1;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Image = ((System.Drawing.Image)(resources.GetObject("cancelBtn.Image")));
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(845, 519);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cancelBtn.Size = new System.Drawing.Size(151, 30);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // removeServiceBtn
            // 
            this.removeServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeServiceBtn.Enabled = false;
            this.removeServiceBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeServiceBtn.Image")));
            this.removeServiceBtn.Location = new System.Drawing.Point(486, 99);
            this.removeServiceBtn.Name = "removeServiceBtn";
            this.removeServiceBtn.Size = new System.Drawing.Size(53, 30);
            this.removeServiceBtn.TabIndex = 1;
            this.removeServiceBtn.UseVisualStyleBackColor = true;
            this.removeServiceBtn.Click += new System.EventHandler(this.removeServiceBtn_Click);
            // 
            // editServiceBtn
            // 
            this.editServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editServiceBtn.Enabled = false;
            this.editServiceBtn.Image = ((System.Drawing.Image)(resources.GetObject("editServiceBtn.Image")));
            this.editServiceBtn.Location = new System.Drawing.Point(486, 63);
            this.editServiceBtn.Name = "editServiceBtn";
            this.editServiceBtn.Size = new System.Drawing.Size(53, 30);
            this.editServiceBtn.TabIndex = 1;
            this.editServiceBtn.UseVisualStyleBackColor = true;
            this.editServiceBtn.Click += new System.EventHandler(this.editServiceBtn_Click);
            // 
            // addServiceBtn
            // 
            this.addServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addServiceBtn.Image = ((System.Drawing.Image)(resources.GetObject("addServiceBtn.Image")));
            this.addServiceBtn.Location = new System.Drawing.Point(486, 27);
            this.addServiceBtn.Name = "addServiceBtn";
            this.addServiceBtn.Size = new System.Drawing.Size(53, 30);
            this.addServiceBtn.TabIndex = 1;
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
            this.servicesListBox.Location = new System.Drawing.Point(181, 27);
            this.servicesListBox.Name = "servicesListBox";
            this.servicesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.servicesListBox.Size = new System.Drawing.Size(299, 463);
            this.servicesListBox.TabIndex = 0;
            this.servicesListBox.SelectedIndexChanged += new System.EventHandler(this.servicesListBox_SelectedIndexChanged);
            this.servicesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.servicesListBox_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupsListBox);
            this.groupBox1.Controls.Add(this.servicesListBox);
            this.groupBox1.Controls.Add(this.addServiceBtn);
            this.groupBox1.Controls.Add(this.editServiceBtn);
            this.groupBox1.Controls.Add(this.removeServiceBtn);
            this.groupBox1.Location = new System.Drawing.Point(446, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(550, 501);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // groupsListBox
            // 
            this.groupsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsListBox.FormattingEnabled = true;
            this.groupsListBox.IntegralHeight = false;
            this.groupsListBox.ItemHeight = 15;
            this.groupsListBox.Location = new System.Drawing.Point(11, 27);
            this.groupsListBox.Name = "groupsListBox";
            this.groupsListBox.Size = new System.Drawing.Size(164, 463);
            this.groupsListBox.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.selectMenuFontBtn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.menuFontTb);
            this.groupBox2.Controls.Add(this.selectCustomTrayIconBtn);
            this.groupBox2.Controls.Add(this.lblCustomTrayIcon);
            this.groupBox2.Controls.Add(this.customTrayIconTb);
            this.groupBox2.Controls.Add(this.cbShowMenuBeyondTaskbar);
            this.groupBox2.Controls.Add(this.cbShowPopupMessages);
            this.groupBox2.Controls.Add(this.selectLogViewerPathBtn);
            this.groupBox2.Controls.Add(this.selectConfigEditorPathBtn);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.logViewerPathTb);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.configEditorPathTb);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox2.Size = new System.Drawing.Size(428, 501);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferences";
            // 
            // cbShowPopupMessages
            // 
            this.cbShowPopupMessages.AutoSize = true;
            this.cbShowPopupMessages.Location = new System.Drawing.Point(14, 193);
            this.cbShowPopupMessages.Name = "cbShowPopupMessages";
            this.cbShowPopupMessages.Size = new System.Drawing.Size(147, 19);
            this.cbShowPopupMessages.TabIndex = 3;
            this.cbShowPopupMessages.Text = "Show popup messages";
            this.cbShowPopupMessages.UseVisualStyleBackColor = true;
            // 
            // selectLogViewerPathBtn
            // 
            this.selectLogViewerPathBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectLogViewerPathBtn.Location = new System.Drawing.Point(364, 50);
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
            this.selectConfigEditorPathBtn.Location = new System.Drawing.Point(364, 21);
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
            this.logViewerPathTb.Location = new System.Drawing.Point(118, 50);
            this.logViewerPathTb.Name = "logViewerPathTb";
            this.logViewerPathTb.Size = new System.Drawing.Size(240, 23);
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
            this.configEditorPathTb.Location = new System.Drawing.Point(118, 21);
            this.configEditorPathTb.Name = "configEditorPathTb";
            this.configEditorPathTb.Size = new System.Drawing.Size(240, 23);
            this.configEditorPathTb.TabIndex = 0;
            // 
            // selectCustomTrayIconBtn
            // 
            this.selectCustomTrayIconBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectCustomTrayIconBtn.Location = new System.Drawing.Point(364, 79);
            this.selectCustomTrayIconBtn.Name = "selectCustomTrayIconBtn";
            this.selectCustomTrayIconBtn.Size = new System.Drawing.Size(53, 23);
            this.selectCustomTrayIconBtn.TabIndex = 6;
            this.selectCustomTrayIconBtn.Text = "...";
            this.selectCustomTrayIconBtn.UseVisualStyleBackColor = true;
            this.selectCustomTrayIconBtn.Click += new System.EventHandler(this.selectCustomTrayIconBtn_Click);
            // 
            // lblCustomTrayIcon
            // 
            this.lblCustomTrayIcon.AutoSize = true;
            this.lblCustomTrayIcon.Location = new System.Drawing.Point(11, 82);
            this.lblCustomTrayIcon.Name = "lblCustomTrayIcon";
            this.lblCustomTrayIcon.Size = new System.Drawing.Size(101, 15);
            this.lblCustomTrayIcon.TabIndex = 5;
            this.lblCustomTrayIcon.Text = "Custom tray icon:";
            // 
            // customTrayIconTb
            // 
            this.customTrayIconTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customTrayIconTb.Location = new System.Drawing.Point(118, 79);
            this.customTrayIconTb.Name = "customTrayIconTb";
            this.customTrayIconTb.Size = new System.Drawing.Size(240, 23);
            this.customTrayIconTb.TabIndex = 4;
            // 
            // cbShowMenuBeyondTaskbar
            // 
            this.cbShowMenuBeyondTaskbar.AutoSize = true;
            this.cbShowMenuBeyondTaskbar.Location = new System.Drawing.Point(14, 218);
            this.cbShowMenuBeyondTaskbar.Name = "cbShowMenuBeyondTaskbar";
            this.cbShowMenuBeyondTaskbar.Size = new System.Drawing.Size(173, 19);
            this.cbShowMenuBeyondTaskbar.TabIndex = 3;
            this.cbShowMenuBeyondTaskbar.Text = "Show menu beyond taskbar";
            this.cbShowMenuBeyondTaskbar.UseVisualStyleBackColor = true;
            // 
            // selectMenuFontBtn
            // 
            this.selectMenuFontBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectMenuFontBtn.Location = new System.Drawing.Point(364, 111);
            this.selectMenuFontBtn.Name = "selectMenuFontBtn";
            this.selectMenuFontBtn.Size = new System.Drawing.Size(53, 23);
            this.selectMenuFontBtn.TabIndex = 9;
            this.selectMenuFontBtn.Text = "...";
            this.selectMenuFontBtn.UseVisualStyleBackColor = true;
            this.selectMenuFontBtn.Click += new System.EventHandler(this.selectMenuFontBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Menu font:";
            // 
            // menuFontTb
            // 
            this.menuFontTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuFontTb.Location = new System.Drawing.Point(118, 111);
            this.menuFontTb.Name = "menuFontTb";
            this.menuFontTb.ReadOnly = true;
            this.menuFontTb.Size = new System.Drawing.Size(240, 23);
            this.menuFontTb.TabIndex = 7;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.cancelBtn);
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button selectLogViewerPathBtn;
        private System.Windows.Forms.Button selectConfigEditorPathBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logViewerPathTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox configEditorPathTb;
        private System.Windows.Forms.ListBox groupsListBox;
        private System.Windows.Forms.CheckBox cbShowPopupMessages;
        private System.Windows.Forms.Button selectCustomTrayIconBtn;
        private System.Windows.Forms.Label lblCustomTrayIcon;
        private System.Windows.Forms.TextBox customTrayIconTb;
        private System.Windows.Forms.CheckBox cbShowMenuBeyondTaskbar;
        private System.Windows.Forms.Button selectMenuFontBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox menuFontTb;
    }
}