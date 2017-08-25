using WTManager.Controls.WtStyle.WtConfigurator;

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
            WTManager.Controls.WtStyle.WtConfigurator.LabelRendererConfiguration labelRendererConfiguration1 = new WTManager.Controls.WtStyle.WtConfigurator.LabelRendererConfiguration();
            WTManager.Controls.WtStyle.WtConfigurator.LabelRendererConfiguration labelRendererConfiguration2 = new WTManager.Controls.WtStyle.WtConfigurator.LabelRendererConfiguration();
            this.applyBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.basicConfigurationEditor = new WTManager.Controls.WtStyle.WtConfigurator.WtConfigurator();
            this.servicesConfigurationEditor = new WTManager.Controls.WtStyle.WtConfigurator.WtConfigurator();
            this.SuspendLayout();
            // 
            // applyBtn
            // 
            this.applyBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.applyBtn.Location = new System.Drawing.Point(464, 519);
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
            this.cancelBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cancelBtn.Location = new System.Drawing.Point(621, 519);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.cancelBtn.Size = new System.Drawing.Size(151, 30);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // basicConfigurationEditor
            // 
            this.basicConfigurationEditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.basicConfigurationEditor.BoldGroupNames = false;
            this.basicConfigurationEditor.ControlFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.basicConfigurationEditor.FillLastControl = false;
            this.basicConfigurationEditor.FillLastGroup = true;
            this.basicConfigurationEditor.GroupTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.basicConfigurationEditor.HorizontalItemPadding = 5;
            this.basicConfigurationEditor.ItemHeight = 22;
            labelRendererConfiguration1.LabelPostfix = ":";
            labelRendererConfiguration1.ShowLables = true;
            this.basicConfigurationEditor.LabelConfiguration = labelRendererConfiguration1;
            this.basicConfigurationEditor.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.basicConfigurationEditor.LabelWidth = 140;
            this.basicConfigurationEditor.Location = new System.Drawing.Point(12, 12);
            this.basicConfigurationEditor.Name = "basicConfigurationEditor";
            this.basicConfigurationEditor.PaddingBetweenItems = 12;
            this.basicConfigurationEditor.Size = new System.Drawing.Size(428, 501);
            this.basicConfigurationEditor.TabIndex = 1;
            // 
            // servicesConfigurationEditor
            // 
            this.servicesConfigurationEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.servicesConfigurationEditor.BoldGroupNames = false;
            this.servicesConfigurationEditor.ControlFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.servicesConfigurationEditor.FillLastControl = true;
            this.servicesConfigurationEditor.FillLastGroup = true;
            this.servicesConfigurationEditor.GroupTitleFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.servicesConfigurationEditor.HorizontalItemPadding = 5;
            this.servicesConfigurationEditor.ItemHeight = 22;
            labelRendererConfiguration2.LabelPostfix = ":";
            labelRendererConfiguration2.ShowLables = false;
            this.servicesConfigurationEditor.LabelConfiguration = labelRendererConfiguration2;
            this.servicesConfigurationEditor.LabelFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.servicesConfigurationEditor.LabelWidth = 120;
            this.servicesConfigurationEditor.Location = new System.Drawing.Point(446, 12);
            this.servicesConfigurationEditor.Name = "servicesConfigurationEditor";
            this.servicesConfigurationEditor.PaddingBetweenItems = 12;
            this.servicesConfigurationEditor.Size = new System.Drawing.Size(326, 501);
            this.servicesConfigurationEditor.TabIndex = 2;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.servicesConfigurationEditor);
            this.Controls.Add(this.basicConfigurationEditor);
            this.Controls.Add(this.applyBtn);
            this.Controls.Add(this.cancelBtn);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WTManager Configuration";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button applyBtn;
        private WtConfigurator basicConfigurationEditor;
        private WtConfigurator servicesConfigurationEditor;
    }
}