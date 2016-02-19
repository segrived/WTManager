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
            this.groupBox1.SuspendLayout();
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
            this.serviceNameCb.Size = new System.Drawing.Size(325, 21);
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
            this.serviceDisplayNameTb.Size = new System.Drawing.Size(326, 20);
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
            this.serviceGroupCb.Size = new System.Drawing.Size(325, 21);
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
            this.groupBox1.Size = new System.Drawing.Size(441, 114);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic service configuration";
            // 
            // AddEditServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 201);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddEditServiceForm";
            this.Text = "Add/Edit Service";
            this.Load += new System.EventHandler(this.AddEditServiceForm_Load);
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
    }
}