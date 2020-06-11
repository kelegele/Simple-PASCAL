using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;


namespace Simple_PASCAL
{
    class Lexical
    {
        /// <summary>
        /// 保留字表
        /// </summary>
        public static string[] keywords = { "FINISH", "BEGIN", "END", "IF", "THEN", "ELSE", "WHILE", "DO", "INTEGER", "VAR" };

        /// <summary>
        /// 单分界符
        /// </summary>
        public static char[] singleword = { '+', '*', ';', ',' ,'=','(',')' };

        /// <summary>
        /// 双分界符首字符 
        /// </summary>
        public static char[] doubleword = { '>', '<', ':', '/' };

        /// <summary>
        /// 源码文件名
        /// </summary>
        private string codeFilePath;

        /// <summary>
        /// 词法分析结果输出文件
        /// </summary>
        public static string outputPath = Directory.GetCurrentDirectory() + "\\lexical.output";

        public Lexical(string filePath)
        {
            this.codeFilePath = filePath;
        }

        /// <summary>
        /// 开始词法分析
        /// </summary>
        /// <returns></returns>
        public Hashtable Run()
        {
            //输入字符数组
            char[] codeChars;

            //临时Pascal词元数组
            Pascal pascalWords;

            //Pascal词元数组 输出
            List<Pascal> pascals = new List<Pascal>();

            //输出结果
            Hashtable result = new Hashtable();

            //判断是否含有指定文件
            if (!File.Exists(codeFilePath))
            {
                //文件不存在！
                result.Add(Message.MSG, "文件不存在");
            }
            //读入源码文件流
            FileStream srcCodeFileStream = new FileStream(codeFilePath, FileMode.Open, FileAccess.Read);
            //定义存放文件信息的字节数组
            byte[] bytes = new byte[srcCodeFileStream.Length];
            //读取文件信息
            srcCodeFileStream.Read(bytes, 0, bytes.Length);

            //将得到的字节型数组重写编码为字符型数组
            codeChars = Encoding.UTF8.GetChars(bytes);

            //关闭流
            srcCodeFileStream.Close();

            //创建 输出词法分析结果流
            FileStream outFileStream = new FileStream(outputPath,
                FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

            //行列
            int row = 1;
            int col = 1;

            int length = codeChars.Length;
            int index = 0;

            while (index < length)
            {
                pascalWords = new Pascal();

                //注释标识
                bool remark = false;

                //换行符
                while (codeChars[index] == '\n')
                {
                    row++;
                    col = 1;
                    index++;
                    if (index == length)
                    {
                        index--;
                        break;
                    }
                }

                //空格 和 制表符
                while (codeChars[index] == ' ' || codeChars[index] == '\t')
                {
                    col++;
                    index++;
                    if (index == length)
                    {
                        index--;
                        break;
                    }
                }

                //字母
                if (char.IsLetter(codeChars[index]))
                {
                    //设定大写字母与数字组合是合法的，如果有小写字母或其他符号则是非法的
                    int k = 0;
                    pascalWords.Text[k++] = codeChars[index];
                    pascalWords.X = row;
                    pascalWords.Y = col;

                    //小写字母开头 ISE错误
                    if (char.IsLower(codeChars[index]) || IsChinese(codeChars[index]))
                    {
                        pascalWords.Type = Pascal.ISE;
                        info = "error：变量存在非法字符";
                    }

                    index++;//下一个char
                    col++;

                    //字母或数字字符且不包含空格、逗号、分号的标点符号
                    while (index < length && char.IsLetterOrDigit(codeChars[index]) && codeChars[index] != ' '
                        && codeChars[index] != '\t' && codeChars[index] != ','
                        && codeChars[index] != ';')
                    {
                        pascalWords.Text[k++] = codeChars[index];

                        //符号和小写，如果之前已经发现了错误，默认保留之前的错误
                        if ((pascalWords.Type != Pascal.ISE) &&
                            (char.IsPunctuation(codeChars[index]) || char.IsLower(codeChars[index]) 
                            || IsChinese(codeChars[index])))
                        {
                            pascalWords.Type = Pascal.ISE;
                            info = "error：变量存在非法字符";
                        }
                        index++;
                        col++;

                        if (index == length)
                        {
                            break;
                        }
                    }

                    if (pascalWords.Type != Pascal.ISE)
                    {
                        //合法标识符成立
                        pascalWords.Type = Type.ID;

                        //判断保留字
                        for (int m = 1; m <= 10; m++)
                        {
                            string text = new string(pascalWords.Text).Replace("\0", string.Empty);
                            if (keywords[m - 1].Equals(text))
                            {
                                //保留字
                                pascalWords.Type = 300 + m;
                                break;
                            }
                        }
                    }

                    //标识符长度不合适
                    if (k > 8)
                    {
                        pascalWords.Type = Pascal.STL;
                        info = "error：标识符长度不应大于8";
                    }
                }

                //数字
                else if (char.IsDigit(codeChars[index]))
                {
                    int sum;
                    int k = 0;
                    pascalWords = new Pascal();

                    pascalWords.Text[k++] = codeChars[index++];
                    pascalWords.X = row;
                    pascalWords.Y = col++;

                    //是否为字母或数字
                    while (char.IsLetterOrDigit(codeChars[index]))
                    {
                        pascalWords.Text[k++] = codeChars[index];
                        col++;

                        if (char.IsLetter(codeChars[index]))
                        {
                            //此时判定该值不为数值 为变量
                            pascalWords.Type = Pascal.FDE;
                            info = "error：变量首字母不应为数字";
                        }

                        index++;

                        if (index == length)
                        {
                            break;
                        }
                    }

                    if(pascalWords.Type != Pascal.FDE)
                    {
                        sum = int.Parse(pascalWords.TextToStr(pascalWords.Text));
                        if(sum > 65535)
                        {
                            pascalWords.Type = Pascal.IO;
                            info = "error：整数溢出 65535";
                        }
                        else
                        {
                            pascalWords.Type = Type.INT;
                            pascalWords.Num = sum;
                        }
                    }
                }

                //单分界符
                else if (singleword.Contains(codeChars[index]))
                {

                    switch (codeChars[index])
                    {
                        case '+':
                            pascalWords.Type = Type.ADD;
                            pascalWords.Text[0] = codeChars[index++];
                            pascalWords.X = row;
                            pascalWords.Y = col++;
                            break;
                        //case '-':
                        //    pascalWords.Type = Type.SUB;
                        //    pascalWords.Text[0] = codeChars[index++];
                        //    pascalWords.X = row;
                        //    pascalWords.Y = col++;
                        //    break;
                        case '*':
                            pascalWords.Type = Type.MUL;
                            pascalWords.Text[0] = codeChars[index++];
                            pascalWords.X = row;
                            pascalWords.Y = col++;
                            break;
                        case ';':
                            pascalWords.Type = Type.SEM;
                            pascalWords.Text[0] = codeChars[index++];
                            pascalWords.X = row;
                            pascalWords.Y = col++;
                            break;
                        case ',':
                            pascalWords.Type = Type.COMMA;
                            pascalWords.Text[0] = codeChars[index++];
                            pascalWords.X = row;
                            pascalWords.Y = col++;
                            break;
                        case '=':
                            pascalWords.Type = Type.EQ;
                            pascalWords.Text[0] = codeChars[index++];
                            pascalWords.X = row;
                            pascalWords.Y = col++;
                            break;
                        case '(':
                            pascalWords.Type = Type.LP;
                            pascalWords.Text[0] = codeChars[index++];
                            pascalWords.X = row;
                            pascalWords.Y = col++;
                            break;
                        case ')':
                            pascalWords.Type = Type.RP;
                            pascalWords.Text[0] = codeChars[index++];
                            pascalWords.X = row;
                            pascalWords.Y = col++;
                            break;
                        default:
                            Console.WriteLine("未知错误");
                            break;
                    }
                }

                //双分界符首字符
                else if (doubleword.Contains(codeChars[index]))
                {

                    //下一个字符
                    char next;

                    if(index + 1 < length)
                    {
                        next = codeChars[index + 1];
                    }
                    else
                    {
                        next = '\0';
                    }

                    switch (codeChars[index])
                    {
                        case '>':
                            if(next == '=') // >=
                            {
                                pascalWords.Text[0] = codeChars[index++];
                                pascalWords.Text[1] = next;
                                pascalWords.Type = Type.GE;
                                pascalWords.X = row;
                                pascalWords.Y = col++;
                            }
                            else // >
                            {
                                pascalWords.Text[0] = codeChars[index];
                                pascalWords.Type = Type.GT;
                                pascalWords.X = row;
                                pascalWords.Y = col;
                            }
                            break;
                        case '<':
                            if (next == '=') // <=
                            {
                                pascalWords.Text[0] = codeChars[index++];
                                pascalWords.Text[1] = next;
                                pascalWords.Type = Type.LE;
                                pascalWords.X = row;
                                pascalWords.Y = col++;
                            }
                            else if (next == '>') //<>
                            {
                                pascalWords.Text[0] = codeChars[index++];
                                pascalWords.Text[1] = next;
                                pascalWords.Type = Type.NE;
                                pascalWords.X = row;
                                pascalWords.Y = col++;
                            }
                            else // <
                            {
                                pascalWords.Text[0] = codeChars[index];
                                pascalWords.Type = Type.LT;
                                pascalWords.X = row;
                                pascalWords.Y = col;
                            }
                            break;
                        case ':':
                            if (next == '=') // :=
                            {
                                pascalWords.Text[0] = codeChars[index++];
                                pascalWords.Text[1] = next;
                                pascalWords.Type = Type.ASS;
                                pascalWords.X = row;
                                pascalWords.Y = col++;
                            }
                            else // :
                            {
                                pascalWords.Text[0] = codeChars[index];
                                pascalWords.Type = Type.SEM;
                                pascalWords.X = row;
                                pascalWords.Y = col;
                            }
                            break;
                        case '/':
                            if (next == '/') // 单行注释
                            {
                                remark = true;

                                do
                                {
                                    index++;
                                    col++;
                                } while (index < length && codeChars[index] != '\n');

                                index--;
                                col--;

                            }
                            else if( next == '*') //多行注释开始符
                            {
                                remark = true;
                                bool doneRemark = false; //多行注释成功标记

                                index += 2;// index->*.next
                                col += 2;

                                while (index < length)
                                {

                                    if (codeChars[index] == '\n')
                                    {
                                        row++;
                                        index++;
                                        col = 1;
                                        continue;
                                    }
                                    else if (codeChars[index] == '*')
                                    {
                                        //多行注释结束识别
                                        if (index + 1 < length)
                                        {
                                            next = codeChars[index + 1];
                                            if (codeChars[index] == '*' && next == '/')//多行结束
                                            {
                                                doneRemark = true;
                                                index ++;
                                                col ++;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            //*在最后一位
                                            info = "error: 多行注释未完整 缺少‘/’";
                                            pascalWords.Type = Pascal.IR;
                                            pascalWords.X = row;
                                            pascalWords.Y = col++;
                                            index++;
                                            remark = false;
                                            break;
                                        }
                                    }

                                    index++;
                                    col++;
                                }

                                if (!doneRemark && index == length 
                                    && pascalWords.Type == Pascal.INIT)//无结尾
                                {
                                    info = "error: 多行注释未完整 缺少‘*/’";
                                    pascalWords.Type = Pascal.IR;
                                    pascalWords.X = row;
                                    pascalWords.Y = col;
                                    remark = false;
                                }
                            }
                            else // /
                            {
                                //pascalWords.Type = Type.DIV;
                                pascalWords.Text[0] = codeChars[index++];
                                pascalWords.X = row;
                                pascalWords.Y = col++;
                                pascalWords.Type = Pascal.ISE;
                                info = "error：未匹配字符";
                            }
                            break;
                        default:
                            pascalWords.Text[0] = codeChars[index++];
                            pascalWords.X = row;
                            pascalWords.Y = col++;
                            pascalWords.Type = Pascal.ISE;
                            info = "error：未匹配字符";
                            break;
                    }
                    index++;
                    col++;
                }

                //结束符 # 处理
                else if ('#' == codeChars[index])
                {
                    pascalWords.Type = Type.FINISH;
                    pascalWords.Text[0] = codeChars[index];
                    pascalWords.X = row;
                    pascalWords.Y = col;

                    index = length;
                }

                else if (codeChars[index] == ' ' || codeChars[index] == '\t' || codeChars[index] == '\n')
                {
                    continue;
                }

                //未匹配字符
                else
                {
                    pascalWords.Text[0] = codeChars[index++];
                    pascalWords.X = row;
                    pascalWords.Y = col++;
                    pascalWords.Type = Pascal.ISE;
                    info = "error：未匹配字符";
                }

                if (!remark)
                {
                    //加入输出结果
                    pascals.Add(pascalWords);
                }

                if (pascalWords.Type != Pascal.INIT)
                {
                    //输出文档
                    OutputLog(pascalWords, outFileStream);
                }
                else
                {
                    pascalWords = null;
                }
            }

            //刷新缓冲区
            outFileStream.Flush();
            //关闭输出结果流
            outFileStream.Close();

            if(pascals.Count > 0)
            {
                result.Add(Message.KEY, Message.SUCCESS);
                result.Add(Message.MSG, "词法分析完成");
                result.Add(Message.VALUE, pascals);
            }
            else
            {
                result.Add(Message.KEY, Message.FAILURE);
                result.Add(Message.MSG, "词法分析失败！请检查");
            }


            return result;
        }

        //存储信息字符串
        string info = null;

        /// <summary>
        /// 根据类别码 输出词法分析报告
        /// </summary>
        /// <param name="pascal">Pascal</param>
        /// <param name="outFileStream">输出流</param>
        private void OutputLog(Pascal pascal, FileStream outFileStream)
        {
            string str = null;

            if (info != null)
            {
                str = info;
            }

            switch (pascal.Type)
            {
                case Type.ID:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[{pascal.Type},{info}] {str}\n";
                    break;
                case Type.FINISH:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.GE:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.GT:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.IF:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.INT:
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{pascal.Num}] \n";
                    break;
                case Type.INTEGER:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.LE:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.LT:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.MUL:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.NE:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.SEM:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                //case Type.SUB:
                //    info = pascal.TextToStr(pascal.Text);
                //    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                //    break;
                case Type.THEN:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.VAR:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.WHILE:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.ADD:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.ASS:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.BEGIN:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.COL:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.COMMA:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                //case Type.DIV:
                //    info = pascal.TextToStr(pascal.Text);
                //    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                //    break;
                case Type.DO:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.ELSE:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.END:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.EQ:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Pascal.IR:
                    info = $"({pascal.X},{pascal.Y}):\t{str} \n";
                    break;
                case Type.LP:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                case Type.RP:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t[ {pascal.Type } ,{info}] {str}\n";
                    break;
                default:
                    info = pascal.TextToStr(pascal.Text);
                    info = $"({pascal.X},{pascal.Y}):\t未识别字符类型 {info} ，{str} \n";
                    break;
            }

            //将字符串转换为字节数组
            byte[] bytes = Encoding.UTF8.GetBytes(info);

            //向文件中写入字节数组
            outFileStream.Position = outFileStream.Length;//指针移到最后
            outFileStream.Write(bytes, 0, bytes.Length);

            info = null;

        }

        /// <summary>
        /// 判断中文
        /// </summary>
        /// <param name="c">字符</param>
        /// <returns>bool</returns>
        public static bool IsChinese(char c)
        {
            return 0x4e00 <= c && c <= 0x9fbb;
        }
    }

}
