namespace Simple_PASCAL
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelInfo = new System.Windows.Forms.Label();
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonCompiling = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelFileName = new System.Windows.Forms.LinkLabel();
            this.labelFileNameInfo = new System.Windows.Forms.Label();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.buttonSaveCode = new System.Windows.Forms.Button();
            this.saveCodeFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.Location = new System.Drawing.Point(12, 9);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(198, 21);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "请输入一段PASCAL源码：";
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMain.Location = new System.Drawing.Point(18, 37);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.Size = new System.Drawing.Size(561, 415);
            this.richTextBoxMain.TabIndex = 1;
            this.richTextBoxMain.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = ".pascal";
            // 
            // buttonCompiling
            // 
            this.buttonCompiling.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCompiling.Location = new System.Drawing.Point(6, 369);
            this.buttonCompiling.Name = "buttonCompiling";
            this.buttonCompiling.Size = new System.Drawing.Size(110, 40);
            this.buttonCompiling.TabIndex = 3;
            this.buttonCompiling.Text = "开始编译";
            this.buttonCompiling.UseVisualStyleBackColor = true;
            this.buttonCompiling.Click += new System.EventHandler(this.buttonCompiling_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSaveCode);
            this.panel1.Controls.Add(this.linkLabelFileName);
            this.panel1.Controls.Add(this.buttonCompiling);
            this.panel1.Controls.Add(this.labelFileNameInfo);
            this.panel1.Controls.Add(this.buttonOpenFile);
            this.panel1.Location = new System.Drawing.Point(612, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(121, 412);
            this.panel1.TabIndex = 6;
            // 
            // linkLabelFileName
            // 
            this.linkLabelFileName.AutoSize = true;
            this.linkLabelFileName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelFileName.Location = new System.Drawing.Point(3, 87);
            this.linkLabelFileName.MaximumSize = new System.Drawing.Size(120, 0);
            this.linkLabelFileName.Name = "linkLabelFileName";
            this.linkLabelFileName.Size = new System.Drawing.Size(28, 14);
            this.linkLabelFileName.TabIndex = 8;
            this.linkLabelFileName.TabStop = true;
            this.linkLabelFileName.Text = "...";
            this.linkLabelFileName.Visible = false;
            this.linkLabelFileName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFileName_LinkClicked);
            // 
            // labelFileNameInfo
            // 
            this.labelFileNameInfo.AutoSize = true;
            this.labelFileNameInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFileNameInfo.Location = new System.Drawing.Point(1, 58);
            this.labelFileNameInfo.Name = "labelFileNameInfo";
            this.labelFileNameInfo.Size = new System.Drawing.Size(44, 17);
            this.labelFileNameInfo.TabIndex = 7;
            this.labelFileNameInfo.Text = "文件：";
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenFile.Location = new System.Drawing.Point(3, 3);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(110, 40);
            this.buttonOpenFile.TabIndex = 6;
            this.buttonOpenFile.Text = "从文件打开";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonSaveCode
            // 
            this.buttonSaveCode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSaveCode.Location = new System.Drawing.Point(6, 311);
            this.buttonSaveCode.Name = "buttonSaveCode";
            this.buttonSaveCode.Size = new System.Drawing.Size(110, 40);
            this.buttonSaveCode.TabIndex = 9;
            this.buttonSaveCode.Text = "另存为";
            this.buttonSaveCode.UseVisualStyleBackColor = true;
            this.buttonSaveCode.Click += new System.EventHandler(this.buttonSaveCode_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBoxMain);
            this.Controls.Add(this.labelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Simple-PASCAL";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.RichTextBox richTextBoxMain;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonCompiling;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabelFileName;
        private System.Windows.Forms.Label labelFileNameInfo;
        private System.Windows.Forms.Button buttonOpenFile;
        private System.Windows.Forms.Button buttonSaveCode;
        private System.Windows.Forms.SaveFileDialog saveCodeFileDialog;
    }
}

