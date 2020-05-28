using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_PASCAL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        string filePath;
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = this.openFileDialog;
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;

            if (File.Exists(filePath))
            {
                richTextBoxMain.Text = File.ReadAllText(filePath);
                linkLabelFileName.Text = filePath;
                linkLabelFileName.Visible = true;
            }
        }

        private void linkLabelFileName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelFileName.LinkVisited = true;
            Process.Start(filePath);
        }


        //       取得WinForm应用程序的根目录方法
        //       1、Environment.CurrentDirectory.ToString();//获取或设置当前工作目录的完全限定路径
        //       2、Application.StartupPath.ToString();//获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称
        //       3、Directory.GetCurrentDirectory();//获取应用程序的当前工作目录
        //       4、AppDomain.CurrentDomain.BaseDirectory;//获取基目录，它由程序集冲突解决程序用来探测程序集
        //       5、AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取或设置包含该应用程序的目录的名称

        string saveFilePath = Directory.GetCurrentDirectory() + "\\code.src";
        private void buttonCompiling_Click(object sender, EventArgs e)
        {
            //文本框为空
            if (richTextBoxMain.Text.Length == 0)
            {
                //空代码 提示输入
                MainInfoForm lexicalInfo = new MainInfoForm();
                lexicalInfo.ShowDialog();
            }
            else
            {
                saveCode(saveFilePath);
                Lexical lexical = new Lexical(saveFilePath);
                Hashtable result = lexical.Run();

                List<Pascal> resultOfLexical;
                if ((int)result[Lexical.KEY] == Lexical.SUCCESS)
                {
                    resultOfLexical = (List<Pascal>)result[Lexical.VALUE];

                    MainInfoForm lexicalInfo = new MainInfoForm();
                    lexicalInfo.ShowDialog();
                }
                else
                {
                    resultOfLexical = null;

                }
            }
        }

        private void buttonSaveCode_Click(object sender, EventArgs e)
        {
            string userPath = saveFilePath;

            //点了保存按钮进入
            if (saveCodeFileDialog.ShowDialog() == DialogResult.OK)
            {
                userPath = saveCodeFileDialog.FileName.ToString(); //获得文件路径
            }
            saveCode(userPath);
        }

        private void saveCode(string saveFilePath)
        {
            string srcCode = richTextBoxMain.Text;

            //创建 FileStream 类的实例
            FileStream fileStream = new FileStream(saveFilePath, FileMode.Create);
            //将字符串转换为字节数组
            byte[] bytes = Encoding.UTF8.GetBytes(srcCode);
            //向文件中写入字节数组
            fileStream.Write(bytes, 0, bytes.Length);
            //刷新缓冲区
            fileStream.Flush();
            //关闭流
            fileStream.Close();

        }
    }
}
