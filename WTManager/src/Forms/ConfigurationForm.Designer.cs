using WTManager.Controls.WtSelectorControl;

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
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.removeServiceBtn = new System.Windows.Forms.Button();
            this.editServiceBtn = new System.Windows.Forms.Button();
            this.addServiceBtn = new System.Windows.Forms.Button();
            this.servicesListBox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.upServiceBtn = new System.Windows.Forms.Button();
            this.downServiceBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fontSelector = new WTManager.Controls.WtSelectorControl.FontSelectorControl();
            this.logEditorSelector = new WTManager.Controls.WtSelectorControl.FileSelectorControl();
            this.configEditorSelector = new WTManager.Controls.WtSelectorControl.FileSelectorControl();
            this.themeNameCb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomTrayIcon = new System.Windows.Forms.Label();
            this.cbOpenMenuByLeftClick = new System.Windows.Forms.CheckBox();
            this.cbAutoStartApplication = new System.Windows.Forms.CheckBox();
            this.cbShowMenuBeyondTaskbar = new System.Windows.Forms.CheckBox();
            this.cbShowPopupMessages = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            // removeServiceBtn
            // 
            this.removeServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeServiceBtn.Enabled = false;
            this.removeServiceBtn.Location = new System.Drawing.Point(294, 99);
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
            this.editServiceBtn.Location = new System.Drawing.Point(294, 63);
            this.editServiceBtn.Name = "editServiceBtn";
            this.editServiceBtn.Size = new System.Drawing.Size(53, 30);
            this.editServiceBtn.TabIndex = 1;
            this.editServiceBtn.UseVisualStyleBackColor = true;
            this.editServiceBtn.Click += new System.EventHandler(this.editServiceBtn_Click);
            // 
            // addServiceBtn
            // 
            this.addServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addServiceBtn.Location = new System.Drawing.Point(294, 27);
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
            this.servicesListBox.Location = new System.Drawing.Point(11, 27);
            this.servicesListBox.Name = "servicesListBox";
            this.servicesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.servicesListBox.Size = new System.Drawing.Size(277, 463);
            this.servicesListBox.TabIndex = 0;
            this.servicesListBox.SelectedIndexChanged += new System.EventHandler(this.servicesListBox_SelectedIndexChanged);
            this.servicesListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.servicesListBox_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.servicesListBox);
            this.groupBox1.Controls.Add(this.addServiceBtn);
            this.groupBox1.Controls.Add(this.editServiceBtn);
            this.groupBox1.Controls.Add(this.upServiceBtn);
            this.groupBox1.Controls.Add(this.downServiceBtn);
            this.groupBox1.Controls.Add(this.removeServiceBtn);
            this.groupBox1.Location = new System.Drawing.Point(446, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(358, 501);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Services";
            // 
            // upServiceBtn
            // 
            this.upServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.upServiceBtn.Enabled = false;
            this.upServiceBtn.Location = new System.Drawing.Point(294, 424);
            this.upServiceBtn.Name = "upServiceBtn";
            this.upServiceBtn.Size = new System.Drawing.Size(53, 30);
            this.upServiceBtn.TabIndex = 1;
            this.upServiceBtn.UseVisualStyleBackColor = true;
            this.upServiceBtn.Click += new System.EventHandler(this.upServiceBtn_Click);
            // 
            // downServiceBtn
            // 
            this.downServiceBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.downServiceBtn.Enabled = false;
            this.downServiceBtn.Location = new System.Drawing.Point(294, 460);
            this.downServiceBtn.Name = "downServiceBtn";
            this.downServiceBtn.Size = new System.Drawing.Size(53, 30);
            this.downServiceBtn.TabIndex = 1;
            this.downServiceBtn.UseVisualStyleBackColor = true;
            this.downServiceBtn.Click += new System.EventHandler(this.downServiceBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.fontSelector);
            this.groupBox2.Controls.Add(this.logEditorSelector);
            this.groupBox2.Controls.Add(this.configEditorSelector);
            this.groupBox2.Controls.Add(this.themeNameCb);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblCustomTrayIcon);
            this.groupBox2.Controls.Add(this.cbOpenMenuByLeftClick);
            this.groupBox2.Controls.Add(this.cbAutoStartApplication);
            this.groupBox2.Controls.Add(this.cbShowMenuBeyondTaskbar);
            this.groupBox2.Controls.Add(this.cbShowPopupMessages);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox2.Size = new System.Drawing.Size(428, 501);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferences";
            // 
            // fontSelector
            // 
            this.fontSelector.CurrentState = null;
            this.fontSelector.Location = new System.Drawing.Point(94, 99);
            this.fontSelector.Name = "fontSelector";
            this.fontSelector.Size = new System.Drawing.Size(326, 24);
            this.fontSelector.TabIndex = 12;
            // 
            // logEditorSelector
            // 
            this.logEditorSelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.logEditorSelector.CurrentState = null;
            this.logEditorSelector.FileRequestFilter = "Executable files|*.exe;*.bat;*.cmd";
            this.logEditorSelector.Location = new System.Drawing.Point(94, 63);
            this.logEditorSelector.Margin = new System.Windows.Forms.Padding(0);
            this.logEditorSelector.Name = "logEditorSelector";
            this.logEditorSelector.Size = new System.Drawing.Size(326, 24);
            this.logEditorSelector.TabIndex = 11;
            // 
            // configEditorSelector
            // 
            this.configEditorSelector.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.configEditorSelector.CurrentState = null;
            this.configEditorSelector.FileRequestFilter = "Executable files|*.exe;*.bat;*.cmd";
            this.configEditorSelector.Location = new System.Drawing.Point(94, 24);
            this.configEditorSelector.Margin = new System.Windows.Forms.Padding(0);
            this.configEditorSelector.Name = "configEditorSelector";
            this.configEditorSelector.Size = new System.Drawing.Size(326, 24);
            this.configEditorSelector.TabIndex = 11;
            // 
            // themeNameCb
            // 
            this.themeNameCb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.themeNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.themeNameCb.FormattingEnabled = true;
            this.themeNameCb.ItemHeight = 18;
            this.themeNameCb.Location = new System.Drawing.Point(94, 135);
            this.themeNameCb.Name = "themeNameCb";
            this.themeNameCb.Size = new System.Drawing.Size(323, 24);
            this.themeNameCb.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Menu font:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCustomTrayIcon
            // 
            this.lblCustomTrayIcon.Location = new System.Drawing.Point(11, 135);
            this.lblCustomTrayIcon.Name = "lblCustomTrayIcon";
            this.lblCustomTrayIcon.Size = new System.Drawing.Size(70, 24);
            this.lblCustomTrayIcon.TabIndex = 5;
            this.lblCustomTrayIcon.Text = "Icon theme:";
            this.lblCustomTrayIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbOpenMenuByLeftClick
            // 
            this.cbOpenMenuByLeftClick.AutoSize = true;
            this.cbOpenMenuByLeftClick.Location = new System.Drawing.Point(14, 240);
            this.cbOpenMenuByLeftClick.Name = "cbOpenMenuByLeftClick";
            this.cbOpenMenuByLeftClick.Size = new System.Drawing.Size(175, 19);
            this.cbOpenMenuByLeftClick.TabIndex = 3;
            this.cbOpenMenuByLeftClick.Text = "Open tray menu by left click";
            this.cbOpenMenuByLeftClick.UseVisualStyleBackColor = true;
            // 
            // cbAutoStartApplication
            // 
            this.cbAutoStartApplication.AutoSize = true;
            this.cbAutoStartApplication.Location = new System.Drawing.Point(14, 215);
            this.cbAutoStartApplication.Name = "cbAutoStartApplication";
            this.cbAutoStartApplication.Size = new System.Drawing.Size(230, 19);
            this.cbAutoStartApplication.TabIndex = 3;
            this.cbAutoStartApplication.Text = "Run WTManager when Windows starts";
            this.cbAutoStartApplication.UseVisualStyleBackColor = true;
            // 
            // cbShowMenuBeyondTaskbar
            // 
            this.cbShowMenuBeyondTaskbar.AutoSize = true;
            this.cbShowMenuBeyondTaskbar.Location = new System.Drawing.Point(14, 190);
            this.cbShowMenuBeyondTaskbar.Name = "cbShowMenuBeyondTaskbar";
            this.cbShowMenuBeyondTaskbar.Size = new System.Drawing.Size(173, 19);
            this.cbShowMenuBeyondTaskbar.TabIndex = 3;
            this.cbShowMenuBeyondTaskbar.Text = "Show menu beyond taskbar";
            this.cbShowMenuBeyondTaskbar.UseVisualStyleBackColor = true;
            // 
            // cbShowPopupMessages
            // 
            this.cbShowPopupMessages.AutoSize = true;
            this.cbShowPopupMessages.Location = new System.Drawing.Point(14, 165);
            this.cbShowPopupMessages.Name = "cbShowPopupMessages";
            this.cbShowPopupMessages.Size = new System.Drawing.Size(147, 19);
            this.cbShowPopupMessages.TabIndex = 3;
            this.cbShowPopupMessages.Text = "Show popup messages";
            this.cbShowPopupMessages.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Log viewer:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Config editor:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 561);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.applyBtn);
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
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbShowPopupMessages;
        private System.Windows.Forms.Label lblCustomTrayIcon;
        private System.Windows.Forms.CheckBox cbShowMenuBeyondTaskbar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAutoStartApplication;
        private System.Windows.Forms.Button upServiceBtn;
        private System.Windows.Forms.Button downServiceBtn;
        private System.Windows.Forms.ComboBox themeNameCb;
        private System.Windows.Forms.CheckBox cbOpenMenuByLeftClick;
        private FileSelectorControl configEditorSelector;
        private FileSelectorControl logEditorSelector;
        private FontSelectorControl fontSelector;
    }
}