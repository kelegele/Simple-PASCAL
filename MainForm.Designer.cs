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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelInfo = new System.Windows.Forms.Label();
            this.richTextBoxMain = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonCompiling = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabelSemantic = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelFileNameInfo = new System.Windows.Forms.Label();
            this.linkLabelFileName = new System.Windows.Forms.LinkLabel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelParserResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveCode = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelLex = new System.Windows.Forms.Label();
            this.linkLabelLexResult = new System.Windows.Forms.LinkLabel();
            this.buttonOpenFile = new System.Windows.Forms.Button();
            this.saveCodeFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.labelLineCol = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelInfo
            // 
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelInfo.Location = new System.Drawing.Point(16, 11);
            this.labelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(247, 27);
            this.labelInfo.TabIndex = 0;
            this.labelInfo.Text = "请输入一段PASCAL源码：";
            // 
            // richTextBoxMain
            // 
            this.richTextBoxMain.AcceptsTab = true;
            this.richTextBoxMain.AutoWordSelection = true;
            this.richTextBoxMain.DetectUrls = false;
            this.richTextBoxMain.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMain.Location = new System.Drawing.Point(24, 46);
            this.richTextBoxMain.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBoxMain.Name = "richTextBoxMain";
            this.richTextBoxMain.Size = new System.Drawing.Size(775, 595);
            this.richTextBoxMain.TabIndex = 1;
            this.richTextBoxMain.TabStop = false;
            this.richTextBoxMain.Text = "";
            this.richTextBoxMain.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBoxMain_KeyUp);
            this.richTextBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.richTextBoxMain_MouseUp);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = ".pascal";
            // 
            // buttonCompiling
            // 
            this.buttonCompiling.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonCompiling.Location = new System.Drawing.Point(34, 544);
            this.buttonCompiling.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCompiling.Name = "buttonCompiling";
            this.buttonCompiling.Size = new System.Drawing.Size(154, 47);
            this.buttonCompiling.TabIndex = 3;
            this.buttonCompiling.Text = "开始编译";
            this.buttonCompiling.UseVisualStyleBackColor = true;
            this.buttonCompiling.Click += new System.EventHandler(this.buttonCompiling_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.buttonSaveCode);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.buttonCompiling);
            this.panel1.Controls.Add(this.buttonOpenFile);
            this.panel1.Location = new System.Drawing.Point(835, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(219, 595);
            this.panel1.TabIndex = 6;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label2);
            this.panel5.Controls.Add(this.linkLabelSemantic);
            this.panel5.Location = new System.Drawing.Point(16, 375);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(200, 100);
            this.panel5.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(15, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "语义分析结果：";
            // 
            // linkLabelSemantic
            // 
            this.linkLabelSemantic.AutoSize = true;
            this.linkLabelSemantic.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelSemantic.Location = new System.Drawing.Point(16, 17);
            this.linkLabelSemantic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelSemantic.MaximumSize = new System.Drawing.Size(160, 0);
            this.linkLabelSemantic.Name = "linkLabelSemantic";
            this.linkLabelSemantic.Size = new System.Drawing.Size(32, 18);
            this.linkLabelSemantic.TabIndex = 15;
            this.linkLabelSemantic.TabStop = true;
            this.linkLabelSemantic.Text = "...";
            this.linkLabelSemantic.Visible = false;
            this.linkLabelSemantic.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSemantic_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelFileNameInfo);
            this.panel2.Controls.Add(this.linkLabelFileName);
            this.panel2.Location = new System.Drawing.Point(16, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 100);
            this.panel2.TabIndex = 16;
            // 
            // labelFileNameInfo
            // 
            this.labelFileNameInfo.AutoSize = true;
            this.labelFileNameInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelFileNameInfo.Location = new System.Drawing.Point(14, 0);
            this.labelFileNameInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFileNameInfo.Name = "labelFileNameInfo";
            this.labelFileNameInfo.Size = new System.Drawing.Size(54, 20);
            this.labelFileNameInfo.TabIndex = 7;
            this.labelFileNameInfo.Text = "文件：";
            // 
            // linkLabelFileName
            // 
            this.linkLabelFileName.AutoSize = true;
            this.linkLabelFileName.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelFileName.Location = new System.Drawing.Point(15, 20);
            this.linkLabelFileName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelFileName.MaximumSize = new System.Drawing.Size(160, 0);
            this.linkLabelFileName.Name = "linkLabelFileName";
            this.linkLabelFileName.Size = new System.Drawing.Size(32, 18);
            this.linkLabelFileName.TabIndex = 8;
            this.linkLabelFileName.TabStop = true;
            this.linkLabelFileName.Text = "...";
            this.linkLabelFileName.Visible = false;
            this.linkLabelFileName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelFileName_LinkClicked);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelParserResult);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(19, 269);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 100);
            this.panel4.TabIndex = 18;
            // 
            // labelParserResult
            // 
            this.labelParserResult.AutoSize = true;
            this.labelParserResult.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelParserResult.ForeColor = System.Drawing.Color.Red;
            this.labelParserResult.Location = new System.Drawing.Point(16, 24);
            this.labelParserResult.MaximumSize = new System.Drawing.Size(160, 0);
            this.labelParserResult.Name = "labelParserResult";
            this.labelParserResult.Size = new System.Drawing.Size(40, 22);
            this.labelParserResult.TabIndex = 13;
            this.labelParserResult.Text = "...";
            this.labelParserResult.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(15, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "语法分析结果：";
            // 
            // buttonSaveCode
            // 
            this.buttonSaveCode.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonSaveCode.Location = new System.Drawing.Point(34, 489);
            this.buttonSaveCode.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveCode.Name = "buttonSaveCode";
            this.buttonSaveCode.Size = new System.Drawing.Size(154, 47);
            this.buttonSaveCode.TabIndex = 9;
            this.buttonSaveCode.Text = "另存为";
            this.buttonSaveCode.UseVisualStyleBackColor = true;
            this.buttonSaveCode.Click += new System.EventHandler(this.buttonSaveCode_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelLex);
            this.panel3.Controls.Add(this.linkLabelLexResult);
            this.panel3.Location = new System.Drawing.Point(16, 163);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 100);
            this.panel3.TabIndex = 17;
            // 
            // labelLex
            // 
            this.labelLex.AutoSize = true;
            this.labelLex.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLex.Location = new System.Drawing.Point(15, 0);
            this.labelLex.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLex.Name = "labelLex";
            this.labelLex.Size = new System.Drawing.Size(114, 20);
            this.labelLex.TabIndex = 10;
            this.labelLex.Text = "词法分析结果：";
            // 
            // linkLabelLexResult
            // 
            this.linkLabelLexResult.AutoSize = true;
            this.linkLabelLexResult.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelLexResult.Location = new System.Drawing.Point(15, 20);
            this.linkLabelLexResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabelLexResult.MaximumSize = new System.Drawing.Size(160, 0);
            this.linkLabelLexResult.Name = "linkLabelLexResult";
            this.linkLabelLexResult.Size = new System.Drawing.Size(32, 18);
            this.linkLabelLexResult.TabIndex = 11;
            this.linkLabelLexResult.TabStop = true;
            this.linkLabelLexResult.Text = "...";
            this.linkLabelLexResult.Visible = false;
            this.linkLabelLexResult.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelLexResult_LinkClicked);
            // 
            // buttonOpenFile
            // 
            this.buttonOpenFile.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonOpenFile.Location = new System.Drawing.Point(34, 4);
            this.buttonOpenFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenFile.Name = "buttonOpenFile";
            this.buttonOpenFile.Size = new System.Drawing.Size(154, 47);
            this.buttonOpenFile.TabIndex = 6;
            this.buttonOpenFile.Text = "从文件打开";
            this.buttonOpenFile.UseVisualStyleBackColor = true;
            this.buttonOpenFile.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // labelLineCol
            // 
            this.labelLineCol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLineCol.Font = new System.Drawing.Font("微软雅黑 Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelLineCol.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelLineCol.Location = new System.Drawing.Point(672, 645);
            this.labelLineCol.Name = "labelLineCol";
            this.labelLineCol.Size = new System.Drawing.Size(127, 34);
            this.labelLineCol.TabIndex = 7;
            this.labelLineCol.Text = "line-col";
            this.labelLineCol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1087, 688);
            this.Controls.Add(this.labelLineCol);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBoxMain);
            this.Controls.Add(this.labelInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simple-PASCAL";
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
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
        private System.Windows.Forms.LinkLabel linkLabelLexResult;
        private System.Windows.Forms.Label labelLex;
        private System.Windows.Forms.LinkLabel linkLabelSemantic;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLineCol;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelParserResult;
    }
}

