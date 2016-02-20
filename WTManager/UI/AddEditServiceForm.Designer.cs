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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.logsAndConfigsGb.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceNameCb
            // 
            this.serviceNameCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceNameCb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.serviceNameCb.FormattingEnabled = true;
            this.serviceNameCb.Location = new System.Drawing.Point(122, 21);
            this.serviceNameCb.Name = "serviceNameCb";
            this.serviceNameCb.Size = new System.Drawing.Size(445, 23);
            this.serviceNameCb.TabIndex = 0;
            this.serviceNameCb.SelectedIndexChanged += new System.EventHandler(this.serviceNameCb_SelectedIndexChanged);
            // 
            // serviceNameLbl
            // 
            this.serviceNameLbl.AutoSize = true;
            this.serviceNameLbl.Location = new System.Drawing.Point(11, 24);
            this.serviceNameLbl.Name = "serviceNameLbl";
            this.serviceNameLbl.Size = new System.Drawing.Size(47, 15);
            this.serviceNameLbl.TabIndex = 1;
            this.serviceNameLbl.Text = "Service:";
            // 
            // serviceDisplayNameTb
            // 
            this.serviceDisplayNameTb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceDisplayNameTb.Location = new System.Drawing.Point(122, 50);
            this.serviceDisplayNameTb.Name = "serviceDisplayNameTb";
            this.serviceDisplayNameTb.Size = new System.Drawing.Size(445, 23);
            this.serviceDisplayNameTb.TabIndex = 2;
            // 
            // serviceDisplayNameLbl
            // 
            this.serviceDisplayNameLbl.AutoSize = true;
            this.serviceDisplayNameLbl.Location = new System.Drawing.Point(11, 53);
            this.serviceDisplayNameLbl.Name = "serviceDisplayNameLbl";
            this.serviceDisplayNameLbl.Size = new System.Drawing.Size(81, 15);
            this.serviceDisplayNameLbl.TabIndex = 1;
            this.serviceDisplayNameLbl.Text = "Display name:";
            this.serviceDisplayNameLbl.Click += new System.EventHandler(this.serviceDisplayNameLbl_Click);
            // 
            // serviceGroupCb
            // 
            this.serviceGroupCb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceGroupCb.FormattingEnabled = true;
            this.serviceGroupCb.Location = new System.Drawing.Point(122, 79);
            this.serviceGroupCb.Name = "serviceGroupCb";
            this.serviceGroupCb.Size = new System.Drawing.Size(445, 23);
            this.serviceGroupCb.TabIndex = 0;
            // 
            // serviceGroupLbl
            // 
            this.serviceGroupLbl.AutoSize = true;
            this.serviceGroupLbl.Location = new System.Drawing.Point(11, 82);
            this.serviceGroupLbl.Name = "serviceGroupLbl";
            this.serviceGroupLbl.Size = new System.Drawing.Size(43, 15);
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
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(578, 112);
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
            this.logsAndConfigsGb.Location = new System.Drawing.Point(14, 132);
            this.logsAndConfigsGb.Name = "logsAndConfigsGb";
            this.logsAndConfigsGb.Padding = new System.Windows.Forms.Padding(8);
            this.logsAndConfigsGb.Size = new System.Drawing.Size(578, 199);
            this.logsAndConfigsGb.TabIndex = 6;
            this.logsAndConfigsGb.TabStop = false;
            this.logsAndConfigsGb.Text = "Logs and configs";
            // 
            // removeConfigFileBtn
            // 
            this.removeConfigFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeConfigFileBtn.Location = new System.Drawing.Point(517, 148);
            this.removeConfigFileBtn.Name = "removeConfigFileBtn";
            this.removeConfigFileBtn.Size = new System.Drawing.Size(50, 33);
            this.removeConfigFileBtn.TabIndex = 2;
            this.removeConfigFileBtn.Text = "-";
            this.removeConfigFileBtn.UseVisualStyleBackColor = true;
            this.removeConfigFileBtn.Click += new System.EventHandler(this.removeConfigFileBtn_Click);
            // 
            // removeLogFileBtn
            // 
            this.removeLogFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeLogFileBtn.Location = new System.Drawing.Point(517, 63);
            this.removeLogFileBtn.Name = "removeLogFileBtn";
            this.removeLogFileBtn.Size = new System.Drawing.Size(50, 33);
            this.removeLogFileBtn.TabIndex = 2;
            this.removeLogFileBtn.Text = "-";
            this.removeLogFileBtn.UseVisualStyleBackColor = true;
            this.removeLogFileBtn.Click += new System.EventHandler(this.removeLogFileBtn_Click);
            // 
            // addConfigFileBtn
            // 
            this.addConfigFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addConfigFileBtn.Location = new System.Drawing.Point(517, 109);
            this.addConfigFileBtn.Name = "addConfigFileBtn";
            this.addConfigFileBtn.Size = new System.Drawing.Size(50, 33);
            this.addConfigFileBtn.TabIndex = 2;
            this.addConfigFileBtn.Text = "+";
            this.addConfigFileBtn.UseVisualStyleBackColor = true;
            this.addConfigFileBtn.Click += new System.EventHandler(this.addConfigFileBtn_Click);
            // 
            // addLogFileBtn
            // 
            this.addLogFileBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addLogFileBtn.Location = new System.Drawing.Point(517, 24);
            this.addLogFileBtn.Name = "addLogFileBtn";
            this.addLogFileBtn.Size = new System.Drawing.Size(50, 33);
            this.addLogFileBtn.TabIndex = 2;
            this.addLogFileBtn.Text = "+";
            this.addLogFileBtn.UseVisualStyleBackColor = true;
            this.addLogFileBtn.Click += new System.EventHandler(this.addLogFileBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Config files:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
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
            this.configFilesLb.Size = new System.Drawing.Size(389, 79);
            this.configFilesLb.TabIndex = 0;
            this.configFilesLb.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // logFilesLb
            // 
            this.logFilesLb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logFilesLb.FormattingEnabled = true;
            this.logFilesLb.ItemHeight = 15;
            this.logFilesLb.Location = new System.Drawing.Point(122, 24);
            this.logFilesLb.Name = "logFilesLb";
            this.logFilesLb.Size = new System.Drawing.Size(389, 79);
            this.logFilesLb.TabIndex = 0;
            this.logFilesLb.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.Location = new System.Drawing.Point(332, 481);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(127, 36);
            this.OkBtn.TabIndex = 7;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(465, 481);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(127, 36);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 337);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox2.Size = new System.Drawing.Size(580, 134);
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
            this.label4.Location = new System.Drawing.Point(11, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data directory:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Browser URL:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(534, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(124, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(404, 23);
            this.textBox2.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(124, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(445, 23);
            this.textBox1.TabIndex = 0;
            // 
            // AddEditServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 529);
            this.Controls.Add(this.groupBox2);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label6;
    }
}