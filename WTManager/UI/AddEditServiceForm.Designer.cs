namespace WTManager.UI
{
    partial class AddEditServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddEditServiceForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectDataDirectoryBtn = new System.Windows.Forms.Button();
            this.serviceDataDirectoryTb = new System.Windows.Forms.TextBox();
            this.serviceBrowserUrlTb = new System.Windows.Forms.TextBox();
            this.logsAndConfigsGb = new System.Windows.Forms.GroupBox();
            this.removeConfigFileBtn = new System.Windows.Forms.Button();
            this.removeLogFileBtn = new System.Windows.Forms.Button();
            this.addConfigFileBtn = new System.Windows.Forms.Button();
            this.addLogFileBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.configFilesLb = new System.Windows.Forms.ListBox();
            this.logFilesLb = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serviceNameLbl = new System.Windows.Forms.Label();
            this.serviceNameCb = new System.Windows.Forms.ComboBox();
            this.serviceDisplayNameTb = new System.Windows.Forms.TextBox();
            this.serviceGroupCb = new System.Windows.Forms.ComboBox();
            this.serviceDisplayNameLbl = new System.Windows.Forms.Label();
            this.serviceGroupLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.logsAndConfigsGb.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.selectDataDirectoryBtn);
            this.groupBox2.Controls.Add(this.serviceDataDirectoryTb);
            this.groupBox2.Controls.Add(this.serviceBrowserUrlTb);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(13, 338);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox2.Size = new System.Drawing.Size(555, 124);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Additional features";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label6.Location = new System.Drawing.Point(121, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(410, 15);
            this.label6.TabIndex = 3;
            this.label6.Text = "(Optional) Directory with data files, for examples Web-server WWW directory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(121, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(254, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "(Optional) Browser URL, will be added to menu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(11, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data directory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Browser URL:";
            // 
            // selectDataDirectoryBtn
            // 
            this.selectDataDirectoryBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectDataDirectoryBtn.Location = new System.Drawing.Point(509, 74);
            this.selectDataDirectoryBtn.Name = "selectDataDirectoryBtn";
            this.selectDataDirectoryBtn.Size = new System.Drawing.Size(35, 23);
            this.selectDataDirectoryBtn.TabIndex = 1;
            this.selectDataDirectoryBtn.Text = "...";
            this.selectDataDirectoryBtn.UseVisualStyleBackColor = true;
            this.selectDataDirectoryBtn.Click += new System.EventHandler(this.selectDataDirectoryBtn_Click);
            // 
            // serviceDataDirectoryTb
            // 
            this.serviceDataDirectoryTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceDataDirectoryTb.Location = new System.Drawing.Point(124, 74);
            this.serviceDataDirectoryTb.Name = "serviceDataDirectoryTb";
            this.serviceDataDirectoryTb.Size = new System.Drawing.Size(379, 23);
            this.serviceDataDirectoryTb.TabIndex = 0;
            // 
            // serviceBrowserUrlTb
            // 
            this.serviceBrowserUrlTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceBrowserUrlTb.Location = new System.Drawing.Point(124, 21);
            this.serviceBrowserUrlTb.Name = "serviceBrowserUrlTb";
            this.serviceBrowserUrlTb.Size = new System.Drawing.Size(420, 23);
            this.serviceBrowserUrlTb.TabIndex = 0;
            // 
            // logsAndConfigsGb
            // 
            this.logsAndConfigsGb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logsAndConfigsGb.Controls.Add(this.removeConfigFileBtn);
            this.logsAndConfigsGb.Controls.Add(this.removeLogFileBtn);
            this.logsAndConfigsGb.Controls.Add(this.addConfigFileBtn);
            this.logsAndConfigsGb.Controls.Add(this.addLogFileBtn);
            this.logsAndConfigsGb.Controls.Add(this.label2);
            this.logsAndConfigsGb.Controls.Add(this.label1);
            this.logsAndConfigsGb.Controls.Add(this.configFilesLb);
            this.logsAndConfigsGb.Controls.Add(this.logFilesLb);
            this.logsAndConfigsGb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logsAndConfigsGb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logsAndConfigsGb.Location = new System.Drawing.Point(13, 132);
            this.logsAndConfigsGb.Name = "logsAndConfigsGb";
            this.logsAndConfigsGb.Padding = new System.Windows.Forms.Padding(8);
            this.logsAndConfigsGb.Size = new System.Drawing.Size(555, 200);
            this.logsAndConfigsGb.TabIndex = 6;
            this.logsAndConfigsGb.TabStop = false;
            this.logsAndConfigsGb.Text = "Logs and configs";
            // 
            // removeConfigFileBtn
            // 
            this.removeConfigFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeConfigFileBtn.Enabled = false;
            this.removeConfigFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeConfigFileBtn.Image")));
            this.removeConfigFileBtn.Location = new System.Drawing.Point(494, 148);
            this.removeConfigFileBtn.Name = "removeConfigFileBtn";
            this.removeConfigFileBtn.Size = new System.Drawing.Size(50, 33);
            this.removeConfigFileBtn.TabIndex = 2;
            this.removeConfigFileBtn.UseVisualStyleBackColor = true;
            this.removeConfigFileBtn.Click += new System.EventHandler(this.removeConfigFileBtn_Click);
            // 
            // removeLogFileBtn
            // 
            this.removeLogFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLogFileBtn.Enabled = false;
            this.removeLogFileBtn.Image = ((System.Drawing.Image)(resources.GetObject("removeLogFileBtn.Image")));
            this.removeLogFileBtn.Location = new System.Drawing.Point(494, 63);
            this.removeLogFileBtn.Name = "removeLogFileBtn";
            this.removeLogFileBtn.Size = new System.Drawing.Size(50, 33);
            this.removeLogFileBtn.TabIndex = 2;
            this.removeLogFileBtn.UseVisualStyleBackColor = true;
            this.removeLogFileBtn.Click += new System.EventHandler(this.removeLogFileBtn_Click);
            // 
            // addConfigFileBtn
            // 
            this.addConfigFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addConfigFileBtn.Image = global::WTManager.ButtonImages.Add;
            this.addConfigFileBtn.Location = new System.Drawing.Point(494, 109);
            this.addConfigFileBtn.Name = "addConfigFileBtn";
            this.addConfigFileBtn.Size = new System.Drawing.Size(50, 33);
            this.addConfigFileBtn.TabIndex = 2;
            this.addConfigFileBtn.UseVisualStyleBackColor = true;
            this.addConfigFileBtn.Click += new System.EventHandler(this.addConfigFileBtn_Click);
            // 
            // addLogFileBtn
            // 
            this.addLogFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addLogFileBtn.Image = global::WTManager.ButtonImages.Add;
            this.addLogFileBtn.Location = new System.Drawing.Point(494, 24);
            this.addLogFileBtn.Name = "addLogFileBtn";
            this.addLogFileBtn.Size = new System.Drawing.Size(50, 33);
            this.addLogFileBtn.TabIndex = 2;
            this.addLogFileBtn.UseVisualStyleBackColor = true;
            this.addLogFileBtn.Click += new System.EventHandler(this.addLogFileBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Config files:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log files:";
            // 
            // configFilesLb
            // 
            this.configFilesLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFilesLb.FormattingEnabled = true;
            this.configFilesLb.ItemHeight = 15;
            this.configFilesLb.Location = new System.Drawing.Point(122, 109);
            this.configFilesLb.Name = "configFilesLb";
            this.configFilesLb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.configFilesLb.Size = new System.Drawing.Size(366, 79);
            this.configFilesLb.TabIndex = 0;
            this.configFilesLb.SelectedIndexChanged += new System.EventHandler(this.configFilesLb_SelectedIndexChanged);
            // 
            // logFilesLb
            // 
            this.logFilesLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logFilesLb.FormattingEnabled = true;
            this.logFilesLb.ItemHeight = 15;
            this.logFilesLb.Location = new System.Drawing.Point(122, 24);
            this.logFilesLb.Name = "logFilesLb";
            this.logFilesLb.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.logFilesLb.Size = new System.Drawing.Size(366, 79);
            this.logFilesLb.TabIndex = 0;
            this.logFilesLb.SelectedIndexChanged += new System.EventHandler(this.logFilesLb_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.serviceNameLbl);
            this.groupBox1.Controls.Add(this.serviceNameCb);
            this.groupBox1.Controls.Add(this.serviceDisplayNameTb);
            this.groupBox1.Controls.Add(this.serviceGroupCb);
            this.groupBox1.Controls.Add(this.serviceDisplayNameLbl);
            this.groupBox1.Controls.Add(this.serviceGroupLbl);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(555, 112);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic service configuration";
            // 
            // serviceNameLbl
            // 
            this.serviceNameLbl.AutoSize = true;
            this.serviceNameLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.serviceNameLbl.Location = new System.Drawing.Point(11, 24);
            this.serviceNameLbl.Name = "serviceNameLbl";
            this.serviceNameLbl.Size = new System.Drawing.Size(52, 15);
            this.serviceNameLbl.TabIndex = 1;
            this.serviceNameLbl.Text = "Service:";
            // 
            // serviceNameCb
            // 
            this.serviceNameCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceNameCb.FormattingEnabled = true;
            this.serviceNameCb.Location = new System.Drawing.Point(122, 21);
            this.serviceNameCb.Name = "serviceNameCb";
            this.serviceNameCb.Size = new System.Drawing.Size(422, 23);
            this.serviceNameCb.TabIndex = 0;
            this.serviceNameCb.SelectedIndexChanged += new System.EventHandler(this.serviceNameCb_SelectedIndexChanged);
            // 
            // serviceDisplayNameTb
            // 
            this.serviceDisplayNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceDisplayNameTb.Location = new System.Drawing.Point(122, 50);
            this.serviceDisplayNameTb.Name = "serviceDisplayNameTb";
            this.serviceDisplayNameTb.Size = new System.Drawing.Size(422, 23);
            this.serviceDisplayNameTb.TabIndex = 2;
            // 
            // serviceGroupCb
            // 
            this.serviceGroupCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceGroupCb.FormattingEnabled = true;
            this.serviceGroupCb.Location = new System.Drawing.Point(122, 79);
            this.serviceGroupCb.Name = "serviceGroupCb";
            this.serviceGroupCb.Size = new System.Drawing.Size(422, 23);
            this.serviceGroupCb.TabIndex = 0;
            // 
            // serviceDisplayNameLbl
            // 
            this.serviceDisplayNameLbl.AutoSize = true;
            this.serviceDisplayNameLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.serviceDisplayNameLbl.Location = new System.Drawing.Point(11, 53);
            this.serviceDisplayNameLbl.Name = "serviceDisplayNameLbl";
            this.serviceDisplayNameLbl.Size = new System.Drawing.Size(83, 15);
            this.serviceDisplayNameLbl.TabIndex = 1;
            this.serviceDisplayNameLbl.Text = "Display name:";
            // 
            // serviceGroupLbl
            // 
            this.serviceGroupLbl.AutoSize = true;
            this.serviceGroupLbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.serviceGroupLbl.Location = new System.Drawing.Point(11, 82);
            this.serviceGroupLbl.Name = "serviceGroupLbl";
            this.serviceGroupLbl.Size = new System.Drawing.Size(45, 15);
            this.serviceGroupLbl.TabIndex = 1;
            this.serviceGroupLbl.Text = "Group:";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Image = global::WTManager.ButtonImages.Cancel;
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(430, 471);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cancelBtn.Size = new System.Drawing.Size(138, 36);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Image = global::WTManager.ButtonImages.Ok;
            this.OkBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkBtn.Location = new System.Drawing.Point(297, 471);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.OkBtn.Size = new System.Drawing.Size(127, 36);
            this.OkBtn.TabIndex = 7;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // AddEditServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.logsAndConfigsGb);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEditServiceForm";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Service";
            this.Load += new System.EventHandler(this.AddEditServiceForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.logsAndConfigsGb.ResumeLayout(false);
            this.logsAndConfigsGb.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox serviceNameCb;
        private System.Windows.Forms.Label serviceNameLbl;
        private System.Windows.Forms.TextBox serviceDisplayNameTb;
        private System.Windows.Forms.Label serviceDisplayNameLbl;
        private System.Windows.Forms.ComboBox serviceGroupCb;
        private System.Windows.Forms.Label serviceGroupLbl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox logsAndConfigsGb;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectDataDirectoryBtn;
        private System.Windows.Forms.TextBox serviceDataDirectoryTb;
        private System.Windows.Forms.TextBox serviceBrowserUrlTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox logFilesLb;
        private System.Windows.Forms.ListBox configFilesLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addLogFileBtn;
        private System.Windows.Forms.Button addConfigFileBtn;
        private System.Windows.Forms.Button removeLogFileBtn;
        private System.Windows.Forms.Button removeConfigFileBtn;
    }
}