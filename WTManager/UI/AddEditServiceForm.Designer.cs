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
            this.serviceNameCb = new System.Windows.Forms.ComboBox();
            this.serviceNameLbl = new System.Windows.Forms.Label();
            this.serviceDisplayNameTb = new System.Windows.Forms.TextBox();
            this.serviceDisplayNameLbl = new System.Windows.Forms.Label();
            this.serviceGroupCb = new System.Windows.Forms.ComboBox();
            this.serviceGroupLbl = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logsAndConfigsGb = new System.Windows.Forms.GroupBox();
            this.removeConfigFileBtn = new System.Windows.Forms.Button();
            this.removeLogFileBtn = new System.Windows.Forms.Button();
            this.addConfigFileBtn = new System.Windows.Forms.Button();
            this.addLogFileBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.configFilesLb = new System.Windows.Forms.ListBox();
            this.logFilesLb = new System.Windows.Forms.ListBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.logsAndConfigsGb.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceNameCb
            // 
            this.serviceNameCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceNameCb.FormattingEnabled = true;
            this.serviceNameCb.Location = new System.Drawing.Point(100, 25);
            this.serviceNameCb.Name = "serviceNameCb";
            this.serviceNameCb.Size = new System.Drawing.Size(331, 21);
            this.serviceNameCb.TabIndex = 0;
            this.serviceNameCb.SelectedIndexChanged += new System.EventHandler(this.serviceNameCb_SelectedIndexChanged);
            // 
            // serviceNameLbl
            // 
            this.serviceNameLbl.AutoSize = true;
            this.serviceNameLbl.Location = new System.Drawing.Point(6, 28);
            this.serviceNameLbl.Name = "serviceNameLbl";
            this.serviceNameLbl.Size = new System.Drawing.Size(46, 13);
            this.serviceNameLbl.TabIndex = 1;
            this.serviceNameLbl.Text = "Service:";
            // 
            // serviceDisplayNameTb
            // 
            this.serviceDisplayNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceDisplayNameTb.Location = new System.Drawing.Point(100, 52);
            this.serviceDisplayNameTb.Name = "serviceDisplayNameTb";
            this.serviceDisplayNameTb.Size = new System.Drawing.Size(332, 20);
            this.serviceDisplayNameTb.TabIndex = 2;
            // 
            // serviceDisplayNameLbl
            // 
            this.serviceDisplayNameLbl.AutoSize = true;
            this.serviceDisplayNameLbl.Location = new System.Drawing.Point(6, 55);
            this.serviceDisplayNameLbl.Name = "serviceDisplayNameLbl";
            this.serviceDisplayNameLbl.Size = new System.Drawing.Size(73, 13);
            this.serviceDisplayNameLbl.TabIndex = 1;
            this.serviceDisplayNameLbl.Text = "Display name:";
            // 
            // serviceGroupCb
            // 
            this.serviceGroupCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceGroupCb.FormattingEnabled = true;
            this.serviceGroupCb.Location = new System.Drawing.Point(100, 78);
            this.serviceGroupCb.Name = "serviceGroupCb";
            this.serviceGroupCb.Size = new System.Drawing.Size(331, 21);
            this.serviceGroupCb.TabIndex = 0;
            // 
            // serviceGroupLbl
            // 
            this.serviceGroupLbl.AutoSize = true;
            this.serviceGroupLbl.Location = new System.Drawing.Point(6, 81);
            this.serviceGroupLbl.Name = "serviceGroupLbl";
            this.serviceGroupLbl.Size = new System.Drawing.Size(39, 13);
            this.serviceGroupLbl.TabIndex = 1;
            this.serviceGroupLbl.Text = "Group:";
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
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic service configuration";
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
            this.logsAndConfigsGb.Location = new System.Drawing.Point(12, 132);
            this.logsAndConfigsGb.Name = "logsAndConfigsGb";
            this.logsAndConfigsGb.Size = new System.Drawing.Size(447, 189);
            this.logsAndConfigsGb.TabIndex = 6;
            this.logsAndConfigsGb.TabStop = false;
            this.logsAndConfigsGb.Text = "Logs and configs";
            // 
            // removeConfigFileBtn
            // 
            this.removeConfigFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeConfigFileBtn.Location = new System.Drawing.Point(389, 138);
            this.removeConfigFileBtn.Name = "removeConfigFileBtn";
            this.removeConfigFileBtn.Size = new System.Drawing.Size(43, 29);
            this.removeConfigFileBtn.TabIndex = 2;
            this.removeConfigFileBtn.Text = "-";
            this.removeConfigFileBtn.UseVisualStyleBackColor = true;
            this.removeConfigFileBtn.Click += new System.EventHandler(this.removeConfigFileBtn_Click);
            // 
            // removeLogFileBtn
            // 
            this.removeLogFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLogFileBtn.Location = new System.Drawing.Point(388, 63);
            this.removeLogFileBtn.Name = "removeLogFileBtn";
            this.removeLogFileBtn.Size = new System.Drawing.Size(43, 29);
            this.removeLogFileBtn.TabIndex = 2;
            this.removeLogFileBtn.Text = "-";
            this.removeLogFileBtn.UseVisualStyleBackColor = true;
            this.removeLogFileBtn.Click += new System.EventHandler(this.removeLogFileBtn_Click);
            // 
            // addConfigFileBtn
            // 
            this.addConfigFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addConfigFileBtn.Location = new System.Drawing.Point(389, 103);
            this.addConfigFileBtn.Name = "addConfigFileBtn";
            this.addConfigFileBtn.Size = new System.Drawing.Size(43, 29);
            this.addConfigFileBtn.TabIndex = 2;
            this.addConfigFileBtn.Text = "+";
            this.addConfigFileBtn.UseVisualStyleBackColor = true;
            this.addConfigFileBtn.Click += new System.EventHandler(this.addConfigFileBtn_Click);
            // 
            // addLogFileBtn
            // 
            this.addLogFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addLogFileBtn.Location = new System.Drawing.Point(389, 28);
            this.addLogFileBtn.Name = "addLogFileBtn";
            this.addLogFileBtn.Size = new System.Drawing.Size(43, 29);
            this.addLogFileBtn.TabIndex = 2;
            this.addLogFileBtn.Text = "+";
            this.addLogFileBtn.UseVisualStyleBackColor = true;
            this.addLogFileBtn.Click += new System.EventHandler(this.addLogFileBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Config files:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log files:";
            // 
            // configFilesLb
            // 
            this.configFilesLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.configFilesLb.FormattingEnabled = true;
            this.configFilesLb.Location = new System.Drawing.Point(99, 103);
            this.configFilesLb.Name = "configFilesLb";
            this.configFilesLb.Size = new System.Drawing.Size(283, 69);
            this.configFilesLb.TabIndex = 0;
            this.configFilesLb.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // logFilesLb
            // 
            this.logFilesLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logFilesLb.FormattingEnabled = true;
            this.logFilesLb.Location = new System.Drawing.Point(100, 28);
            this.logFilesLb.Name = "logFilesLb";
            this.logFilesLb.Size = new System.Drawing.Size(282, 69);
            this.logFilesLb.TabIndex = 0;
            this.logFilesLb.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Location = new System.Drawing.Point(235, 332);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(109, 31);
            this.OkBtn.TabIndex = 7;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(350, 332);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(109, 31);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // AddEditServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 375);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.logsAndConfigsGb);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEditServiceForm";
            this.Text = "Add/Edit Service";
            this.Load += new System.EventHandler(this.AddEditServiceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.logsAndConfigsGb.ResumeLayout(false);
            this.logsAndConfigsGb.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox logFilesLb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox configFilesLb;
        private System.Windows.Forms.Button removeConfigFileBtn;
        private System.Windows.Forms.Button removeLogFileBtn;
        private System.Windows.Forms.Button addConfigFileBtn;
        private System.Windows.Forms.Button addLogFileBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}