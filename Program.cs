using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_PASCAL
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }

    static class Message
    {
        /// <summary>
        /// result map key
        /// </summary>
        public const string KEY = "key";

        /// <summary>
        /// result map msg
        /// </summary>
        public const string MSG = "msg";

        /// <summary>
        /// result map value
        /// </summary>
        public const string VALUE = "value";

        /// <summary>
        /// KEY SUCCESS
        /// </summary>
        public const int SUCCESS = 1;

        /// <summary>
        /// KEY FAILURE
        /// </summary>
        public const int FAILURE = -1;
    }

    static class Table
    {
        public static int ERR = -1000;
        public static int ACC = 0;

        /// <summary>
        /// ACTION表 说明：移进 SX => +X ；归约 RX => -X ；接受 ACC  => 0 ;  报错 ERR => -1000									
        /// </summary>
        public static int[,] ACTION = new int[44, 17]
        {
            {ERR,4,ERR,ERR,5,ERR,6,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ACC},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,-1,ERR,ERR,ERR,13,ERR,ERR,ERR,ERR,-1},
            {14,ERR,-12,-12,ERR,-12,ERR,-12,ERR,-12,ERR,-12,-12,-12,ERR,-12,-12},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,4,ERR,ERR,5,ERR,6,ERR,ERR,ERR,12,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,21,ERR,ERR,ERR,39,ERR,ERR,ERR},
            {ERR,ERR,-8,-8,ERR,-8,ERR,-8,ERR,-8,ERR,-8,22,-8,ERR,-8,-8},
            {ERR,ERR,-10,-10,ERR,-10,ERR,-10,ERR,-10,ERR,-10,-10,-10,ERR,-10,-10},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,ERR,-14,-14,ERR,-14,ERR,-14,ERR,-14,ERR,-14,-14,-14,ERR,-14,-14},
            {-15,ERR,-15,-15,ERR,-15,ERR,-15,ERR,-15,ERR,-15,-15,-15,ERR,-15,-15},
            {ERR,4,ERR,ERR,5,ERR,6,ERR,ERR,ERR,12,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,ERR,27,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,-10,-10,ERR,-10,ERR,-10,ERR,-10,ERR,-10,-10,-10,ERR,-10,-10},
            {ERR,ERR,-12,-12,ERR,-12,ERR,-12,ERR,-12,ERR,-12,-12,-12,ERR,-12,-12},
            {ERR,ERR,ERR,ERR,ERR,37,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,30,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {31,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,39,ERR,34,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,-2,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,-2},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,-1,ERR,ERR,ERR,13,ERR,ERR,ERR,ERR,-1},
            {ERR,ERR,ERR,-3,ERR,ERR,ERR,-3,ERR,ERR,ERR,-3,ERR,ERR,ERR,ERR,-3},
            {ERR,4,ERR,ERR,5,ERR,6,ERR,ERR,ERR,12,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,-6,ERR,ERR,ERR,-6,ERR,ERR,ERR,-6,ERR,ERR,ERR,ERR,-6},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,ERR,-7,ERR,ERR,-7,ERR,ERR,ERR,ERR,ERR,ERR,ERR,39,ERR,ERR,-7},
            {ERR,ERR,-11,-11,ERR,-11,ERR,-11,ERR,-11,ERR,-11,-11,-11,ERR,-11,-11},
            {ERR,ERR,-13,-13,ERR,-13,ERR,-13,ERR,-13,ERR,-13,-13,-13,ERR,-13,-13},
            {ERR,ERR,ERR,40,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,-7,ERR,ERR,-7,ERR,ERR,ERR,ERR,ERR,ERR,ERR,39,ERR,ERR,-7},
            {ERR,4,ERR,ERR,5,ERR,6,ERR,ERR,ERR,12,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,-3,ERR,ERR,ERR,-3,ERR,ERR,ERR,-3,ERR,39,ERR,ERR,-3},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR,11,ERR,12,ERR,ERR,ERR,10,ERR,ERR},
            {ERR,4,ERR,ERR,5,ERR,6,ERR,ERR,ERR,12,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,-9,-9,ERR,-9,ERR,-9,ERR,-9,ERR,-9,22,-9,ERR,-9,-9},
            {ERR,ERR,ERR,-4,ERR,ERR,ERR,-4,ERR,ERR,ERR,-4,ERR,ERR,ERR,ERR,-4},
            {ERR,ERR,ERR,-5,ERR,ERR,ERR,-5,ERR,ERR,ERR,-5,ERR,ERR,ERR,ERR,-5}
        };

        /// <summary>
        /// GOTO表 	
        /// </summary>
        public static int[,] GOTO = new int[44, 8]
        {
            {ERR,1,2,ERR,7,8,9,3},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,15,7,8,16,17},
            {ERR,ERR,ERR,18,7,8,16,17},
            {ERR,19,2,ERR,ERR,ERR,ERR,20},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,23,8,9,17},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,24,25,ERR,ERR,ERR,ERR,20},
            {ERR,ERR,ERR,ERR,38,8,16,17},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,29,7,8,16,17},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,32,8,9,17},
            {ERR,ERR,ERR,ERR,ERR,ERR,33,17},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,35,ERR,ERR,ERR,ERR,20},
            {ERR,ERR,ERR,ERR,36,8,16,17},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,38,8,16,17},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,43,ERR,ERR,ERR,ERR,20},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,41,9,17},
            {ERR,ERR,42,ERR,ERR,ERR,ERR,20},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR},
            {ERR,ERR,ERR,ERR,ERR,ERR,ERR,ERR}
        };

        /// <summary>
        /// 产生式右部单词数
        /// </summary>
        public static Hashtable SumProdRight = new Hashtable()
        {
            {ACC ,1},{-1 ,1},{-2,3},{-3,3},{-4,6},{-5,4},{ -6,3},{-7 ,3},
            { -8,1},{ -9,3},{ -10,1},{ -11,3},{ -12,1},{-13,3},{ -14,1},{ -15,1}
        };

        /// <summary>
        /// 产生式左部
        /// </summary>
        public static Hashtable ProdIndex = new Hashtable()
        {
            {-1 ,1},{-2,1},{-3,2},{-4,2},{-5,2},{ -6,2},{-7 ,3},
            {-8,4},{ -9,4},{ -10,5},{ -11,5},{ -12,6},{-13,6},{ -14,6},{ -15,7}
        };
    }

    /// <summary>
    /// 类别码
    /// </summary>
    static class Type
    {
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
        public const int LP = 404;
        public const int RP = 405;
        public const int LT = 501;
        public const int LE = 502;
        public const int EQ = 503;
        public const int NE = 504;
        public const int GT = 505;
        public const int GE = 506;
        public const int ADD = 507;
        public const int MUL = 508;
        public const int ASS = 509;

        /// <summary>
        /// 根据类别码获取ACTIONTable ID
        /// </summary>
        public static Hashtable TypeToId = new Hashtable()
        {
            {ID,10},{INT,8},{FINISH,16},{BEGIN,6},{END,7},{IF,1},{THEN,2},{ELSE,3},{WHILE,4},
            { DO,5},{COL,11},{SEM,11},{LP,14},{RP,15},{LT,9},{LE,9},{EQ,9},{NE,9},{GT,9},{GE,9},
            { ADD,13},{MUL,12},{ASS,0}

        };
    }
}
