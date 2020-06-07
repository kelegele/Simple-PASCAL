namespace Simple_PASCAL
{
    partial class MainInfoForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.labelInfo = new System.Windows.Forms.Label();
            this.panelText = new System.Windows.Forms.Panel();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.panelText.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.ForeColor = System.Drawing.Color.Red;
            this.labelInfo.Location = new System.Drawing.Point(3, 3);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(452, 120);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "info";
            this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelText
            // 
            this.panelText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelText.Controls.Add(this.linkLabel);
            this.panelText.Controls.Add(this.labelInfo);
            this.panelText.Location = new System.Drawing.Point(12, 12);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(458, 201);
            this.panelText.TabIndex = 0;
            // 
            // linkLabel
            // 
            this.linkLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.linkLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.Location = new System.Drawing.Point(8, 123);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(447, 67);
            this.linkLabel.TabIndex = 1;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "link";
            this.linkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel.Visible = false;
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // MainInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 225);
            this.Controls.Add(this.panelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainInfoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "提示消息";
            this.panelText.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Panel panelText;
        public System.Windows.Forms.LinkLabel linkLabel;
    }
}