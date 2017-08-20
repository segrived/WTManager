namespace WTManager.Forms
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectDataDirectoryBtn = new System.Windows.Forms.Button();
            this.serviceDataDirectoryTb = new System.Windows.Forms.TextBox();
            this.serviceBrowserUrlTb = new System.Windows.Forms.TextBox();
            this.logsAndConfigsGb = new System.Windows.Forms.GroupBox();
            this.wtConfigs = new WTManager.Controls.WtStyle.WtItemEditor();
            this.wtLogs = new WTManager.Controls.WtStyle.WtItemEditor();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.serviceNameLbl = new System.Windows.Forms.Label();
            this.serviceNameCb = new System.Windows.Forms.ComboBox();
            this.serviceDisplayNameTb = new System.Windows.Forms.TextBox();
            this.serviceGroupCb = new System.Windows.Forms.ComboBox();
            this.serviceDisplayNameLbl = new System.Windows.Forms.Label();
            this.serviceGroupLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.applyBtn = new System.Windows.Forms.Button();
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
            this.groupBox2.Size = new System.Drawing.Size(559, 124);
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
            this.selectDataDirectoryBtn.Location = new System.Drawing.Point(513, 74);
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
            this.serviceDataDirectoryTb.Size = new System.Drawing.Size(383, 23);
            this.serviceDataDirectoryTb.TabIndex = 0;
            // 
            // serviceBrowserUrlTb
            // 
            this.serviceBrowserUrlTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceBrowserUrlTb.Location = new System.Drawing.Point(124, 21);
            this.serviceBrowserUrlTb.Name = "serviceBrowserUrlTb";
            this.serviceBrowserUrlTb.Size = new System.Drawing.Size(424, 23);
            this.serviceBrowserUrlTb.TabIndex = 0;
            // 
            // logsAndConfigsGb
            // 
            this.logsAndConfigsGb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logsAndConfigsGb.Controls.Add(this.wtConfigs);
            this.logsAndConfigsGb.Controls.Add(this.wtLogs);
            this.logsAndConfigsGb.Controls.Add(this.label2);
            this.logsAndConfigsGb.Controls.Add(this.label1);
            this.logsAndConfigsGb.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.logsAndConfigsGb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logsAndConfigsGb.Location = new System.Drawing.Point(13, 132);
            this.logsAndConfigsGb.Name = "logsAndConfigsGb";
            this.logsAndConfigsGb.Padding = new System.Windows.Forms.Padding(8);
            this.logsAndConfigsGb.Size = new System.Drawing.Size(559, 200);
            this.logsAndConfigsGb.TabIndex = 6;
            this.logsAndConfigsGb.TabStop = false;
            this.logsAndConfigsGb.Text = "Logs and configs";
            // 
            // wtConfigs
            // 
            this.wtConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wtConfigs.ButtonSize = 30;
            this.wtConfigs.Location = new System.Drawing.Point(122, 110);
            this.wtConfigs.Name = "wtConfigs";
            this.wtConfigs.RemoveConfirmationText = "";
            this.wtConfigs.ShowAddButton = true;
            this.wtConfigs.ShowDownButton = false;
            this.wtConfigs.ShowEditButton = false;
            this.wtConfigs.ShowRemoveButton = true;
            this.wtConfigs.ShowUpButton = false;
            this.wtConfigs.Size = new System.Drawing.Size(422, 79);
            this.wtConfigs.TabIndex = 2;
            this.wtConfigs.UseRemoveConfirmation = true;
            this.wtConfigs.VerticalPaddingBetweenButtons = 5;
            // 
            // wtLogs
            // 
            this.wtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wtLogs.ButtonSize = 30;
            this.wtLogs.Location = new System.Drawing.Point(122, 24);
            this.wtLogs.Name = "wtLogs";
            this.wtLogs.RemoveConfirmationText = "";
            this.wtLogs.ShowAddButton = true;
            this.wtLogs.ShowDownButton = false;
            this.wtLogs.ShowEditButton = false;
            this.wtLogs.ShowRemoveButton = true;
            this.wtLogs.ShowUpButton = false;
            this.wtLogs.Size = new System.Drawing.Size(422, 79);
            this.wtLogs.TabIndex = 2;
            this.wtLogs.UseRemoveConfirmation = true;
            this.wtLogs.VerticalPaddingBetweenButtons = 5;
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
            this.groupBox1.Size = new System.Drawing.Size(559, 112);
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
            this.serviceNameCb.Size = new System.Drawing.Size(426, 23);
            this.serviceNameCb.TabIndex = 0;
            this.serviceNameCb.SelectedIndexChanged += new System.EventHandler(this.serviceNameCb_SelectedIndexChanged);
            // 
            // serviceDisplayNameTb
            // 
            this.serviceDisplayNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceDisplayNameTb.Location = new System.Drawing.Point(122, 50);
            this.serviceDisplayNameTb.Name = "serviceDisplayNameTb";
            this.serviceDisplayNameTb.Size = new System.Drawing.Size(426, 23);
            this.serviceDisplayNameTb.TabIndex = 2;
            // 
            // serviceGroupCb
            // 
            this.serviceGroupCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceGroupCb.FormattingEnabled = true;
            this.serviceGroupCb.Location = new System.Drawing.Point(122, 79);
            this.serviceGroupCb.Name = "serviceGroupCb";
            this.serviceGroupCb.Size = new System.Drawing.Size(426, 23);
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
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(434, 471);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cancelBtn.Size = new System.Drawing.Size(138, 36);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // applyBtn
            // 
            this.applyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applyBtn.Location = new System.Drawing.Point(301, 471);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.applyBtn.Size = new System.Drawing.Size(127, 36);
            this.applyBtn.TabIndex = 7;
            this.applyBtn.Text = "OK";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // AddEditServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.logsAndConfigsGb);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEditServiceForm";
            this.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Service";
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
        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectDataDirectoryBtn;
        private System.Windows.Forms.TextBox serviceDataDirectoryTb;
        private System.Windows.Forms.TextBox serviceBrowserUrlTb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Controls.WtStyle.WtItemEditor wtConfigs;
        private Controls.WtStyle.WtItemEditor wtLogs;
    }
}