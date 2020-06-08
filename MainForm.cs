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
        /// <summary>
        /// 单词串
        /// </summary>
        List<Pascal> wordList;

        /// <summary>
        /// 源程序文件
        /// </summary>
        private string srcFilePath;

        /// <summary>
        /// 保存源程序文件 供词法分析使用
        /// </summary>
        private static string saveFilePath = Directory.GetCurrentDirectory() + "\\code.src";
        //       取得WinForm应用程序的根目录方法
        //       1、Environment.CurrentDirectory.ToString();//获取或设置当前工作目录的完全限定路径
        //       2、Application.StartupPath.ToString();//获取启动了应用程序的可执行文件的路径，不包括可执行文件的名称
        //       3、Directory.GetCurrentDirectory();//获取应用程序的当前工作目录
        //       4、AppDomain.CurrentDomain.BaseDirectory;//获取基目录，它由程序集冲突解决程序用来探测程序集
        //       5、AppDomain.CurrentDomain.SetupInformation.ApplicationBase;//获取或设置包含该应用程序的目录的名称

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = this.openFileDialog;
            openFileDialog.ShowDialog();
            srcFilePath = openFileDialog.FileName;

            if (File.Exists(srcFilePath))
            {
                richTextBoxMain.Text = File.ReadAllText(srcFilePath);
                linkLabelFileName.Text = srcFilePath;
                linkLabelFileName.Visible = true;
            }
        }

        private void linkLabelFileName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFile(linkLabelFileName,srcFilePath);
        }
        
        private void buttonCompiling_Click(object sender, EventArgs e)
        {
            //文本框为空
            if (richTextBoxMain.Text.Length == 0)
            {
                //空代码 提示输入
                MainInfoForm info = new MainInfoForm();
                info.labelInfo.Text = "输入代码不能为空";
                info.ShowDialog();

                return;
            }

            saveCode(saveFilePath);

            if (!runLexical())
            {
                //词法分析失败或存在错误词法
                return;
            }

            if(!runParser())
            {
                //语法错误
                return;
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

        /// <summary>
        /// 保存源码
        /// </summary>
        /// <param name="saveFilePath">目录 文件名</param>
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

        /// <summary>
        /// 获取文本中(行和列)--光标--坐标位置的调用方法
        /// </summary>
        private void Ranks()
        {
            /*  得到光标行第一个字符的索引，
             *  即从第1个字符开始到光标行的第1个字符索引*/
            int index = richTextBoxMain.GetFirstCharIndexOfCurrentLine();
            /*  得到光标行的行号,第1行从0开始计算，习惯上我们是从1开始计算，所以+1。 */
            int line = richTextBoxMain.GetLineFromCharIndex(index) + 1;
            /*  SelectionStart得到光标所在位置的索引
             *  再减去
             *  当前行第一个字符的索引
             *  = 光标所在的列数(从0开始)  */
            int column = richTextBoxMain.SelectionStart - index + 1;
            /*  选择打印输出的控件  */
            this.labelLineCol.Text = string.Format("行:{0} 列:{1}", line.ToString(), column.ToString());
        }

        private void richTextBoxMain_KeyUp(object sender, KeyEventArgs e)
        {
            Ranks();
        }

        private void richTextBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            Ranks();
        }

        private void linkLabelLexResult_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFile(linkLabelLexResult,Lexical.outputPath);
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="linkLabel">链接label</param>
        /// <param name="fileName">文件名</param>
        private void openFile(LinkLabel linkLabel, string fileName)
        {
            linkLabel.Visible = true;
            linkLabel.LinkVisited = true;
            Process.Start(fileName);
        }

        /// <summary>
        /// 词法分析
        /// </summary>
        private bool runLexical()
        {
            Lexical lexical= new Lexical(saveFilePath);
            Hashtable result = lexical.Run();

            bool ret = true;

            if ((int)result[Message.KEY] == Message.SUCCESS)
            {
                ret = true;

                wordList = (List<Pascal>)result[Message.VALUE];

                foreach (Pascal pascal in wordList)
                {
                    if(pascal.Type < 0)
                    {
                        ret = false;
                        break;
                    }
                }

                MainInfoForm info = new MainInfoForm();
                info.labelInfo.Text = ret?"词法分析完成，结果在文件："
                    :"词法分析完成，存在词法错误，在文件中查看：";
                info.linkLabel.Text = Lexical.outputPath;
                info.linkLabel.Visible = true;
                info.ShowDialog();

                
                linkLabelLexResult.Text = Lexical.outputPath;
                linkLabelLexResult.Visible = true;
            }
            else
            {
                ret = false;

                wordList = null;
                MainInfoForm info = new MainInfoForm();
                info.labelInfo.Text = "词法分析失败！";
                info.ShowDialog();
            }

            return ret;
        }

        private bool runParser()
        {
            bool ret = true;
            Parser parser = new Parser(wordList);

            Hashtable result = parser.Run();

            //accept
            if ((int)result[Message.KEY] == Message.SUCCESS) 
            {
                ret = true;
                wordList = (List<Pascal>)result[Message.VALUE];

                MainInfoForm info = new MainInfoForm();
                info.labelInfo.Text = (string)result[Message.MSG];
                info.ShowDialog();

                linkLabelSemantic.Text = Semantic.outputPath;
                linkLabelSemantic.Visible = true;
            }
            else //error
            {
                ret = false;

                MainInfoForm info = new MainInfoForm();
                info.labelInfo.Text = (string)result[Message.MSG];
                info.ShowDialog();
            }

            labelParserResult.Text = (string)result[Message.MSG];
            labelParserResult.Visible = true;

            return ret;
        }

        private void linkLabelSemantic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFile(linkLabelSemantic, Semantic.outputPath);
        }
    }
}
