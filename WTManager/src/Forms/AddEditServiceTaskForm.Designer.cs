namespace WTManager.Forms
{
    partial class AddEditServiceTaskForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            WTManager.Controls.WtStyle.WtConfigurator.LabelRendererConfiguration labelRendererConfiguration1 = new WTManager.Controls.WtStyle.WtConfigurator.LabelRendererConfiguration();
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.serviceTaskCofiguration = new WTManager.Controls.WtStyle.WtConfigurator.WtConfigurator();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applyBtn.Location = new System.Drawing.Point(164, 361);
            this.applyBtn.Name = "applyBtn";
            this.applyBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.applyBtn.Size = new System.Drawing.Size(151, 30);
            this.applyBtn.TabIndex = 4;
            this.applyBtn.Text = "OK";
            this.applyBtn.UseVisualStyleBackColor = true;
            this.applyBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(321, 361);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cancelBtn.Size = new System.Drawing.Size(151, 30);
            this.cancelBtn.TabIndex = 5;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // serviceTaskCofiguration
            // 
            this.serviceTaskCofiguration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceTaskCofiguration.ControlFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serviceTaskCofiguration.FillLastControl = false;
            this.serviceTaskCofiguration.FillLastGroup = false;
            this.serviceTaskCofiguration.GroupTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serviceTaskCofiguration.HorizontalItemPadding = 5;
            this.serviceTaskCofiguration.ItemHeight = 22;
            labelRendererConfiguration1.LabelPostfix = ":";
            labelRendererConfiguration1.ShowLables = true;
            this.serviceTaskCofiguration.LabelConfiguration = labelRendererConfiguration1;
            this.serviceTaskCofiguration.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serviceTaskCofiguration.LabelWidth = 120;
            this.serviceTaskCofiguration.Location = new System.Drawing.Point(12, 12);
            this.serviceTaskCofiguration.Name = "serviceTaskCofiguration";
            this.serviceTaskCofiguration.PaddingBetweenItems = 12;
            this.serviceTaskCofiguration.Size = new System.Drawing.Size(460, 343);
            this.serviceTaskCofiguration.TabIndex = 6;
            // 
            // AddEditServiceTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 403);
            this.Controls.Add(this.serviceTaskCofiguration);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.cancelBtn);
            this.Name = "AddEditServiceTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/edit service scheduler task";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button applyBtn;
        private System.Windows.Forms.Button cancelBtn;
        private Controls.WtStyle.WtConfigurator.WtConfigurator serviceTaskCofiguration;
    }
}