using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_PASCAL
{
    class Pascal
    {
        //类别码
        private int type;
        //行列
        private int x;
        private int y;
        //词元
        private char[] text;
        private int num;

        //set get
        public int Type { get => type; set => type = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public char[] Text { get => text; set => text = value; }
        public int Num { get => num; set => num = value; }

        //构造方法
        public Pascal(int type, int x, int y, int num)
        {
            Type = type;
            X = x;
            Y = y;
            Num = num;
        }

        public Pascal(int type, int x, int y, char[] text)
        {
            Type = type;
            X = x;
            Y = y;
            Text = text;
        }

        public Pascal()
        {
            Type = INIT;
            X = 0;
            Y = 0;
            Text = new char[16];
            Num = 0;
        }

        public Pascal Clone()
        {
            return this.MemberwiseClone() as Pascal;
        }

        /// <summary>
        /// char[] 转为 string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string TextToStr(char [] text)
        {
            string str = new string(text);
            str = str.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace("\t", string.Empty).Replace("\0", string.Empty);
            return str;
        }

        /*错误代码*/
        /// <summary>
        /// 初始化
        /// </summary>
        public const int INIT = 0;

        /// <summary>
        /// 非法字符(符号、小写)错误
        /// </summary>
        public const int ISE = -1;

        /// <summary>
        /// 首字母数字错误
        /// </summary>
        public const int FDE = -2;

        /// <summary>
        /// 整数溢出错误
        /// </summary>
        public const int IO = -3;

        /// <summary>
        /// 变量字符串超出规定8个字符
        /// </summary>
        public const int STL = -4;

        /// <summary>
        /// 多行注释不完整
        /// </summary>
        public const int IR = -5;

        /*单词类别*/
        public const int ID = 101;
        public const int INT = 201;
        public const int FINISH = 301;
        public const int BEGIN = 302;
        public const int END = 303;
        public const int IF = 304;
        public const int THEN = 305;
        public const int ELSE = 306;
        public const int WHILE = 307;
        public const int DO = 308;
        public const int INTEGER = 309;
        public const int VAR = 310;
        public const int COL = 401;
        public const int COMMA = 402;
        public const int SEM = 403;
        public const int LT = 501;
        public const int LE = 502;
        public const int EQ = 503;
        public const int NE = 504;
        public const int GT = 505;
        public const int GE = 506;
        public const int ADD = 507;
        public const int SUB = 508;
        public const int MUL = 509;
        public const int DIV = 510;
        public const int ASS = 511;

    }
}
