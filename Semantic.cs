﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_PASCAL
{
    class Semantic
    {
        /// <summary>
        /// 语义栈引用语法分析语义栈
        /// </summary>
        private Stack<Pascal> Stack;

        /// <summary>
        /// 四元式标识
        /// </summary>
        private int NXQ;

        /// <summary>
        /// 符号表 {string name, 文法符号 }
        /// </summary>
        private Hashtable SymTable;

        /// <summary>
        /// 变量与算数表达式文法符号
        /// </summary>
        struct EV
        {
            public int PLACE;
        }

        /// <summary>
        /// 符号表变量编号 大于0
        /// </summary>
        private int P_INDEX;

        /// <summary>
        /// 符号表临时变量编号 小于0
        /// </summary>
        private int T_INDEX;

        /// <summary>
        /// 操作表 0 J, 1 J> ,2 <,3 J=,4 +,5 *,6 := 
        /// </summary>
        private static string[] OPs = {"J", "J>","J<","J=","+","*",":="};

        /// <summary>
        /// 空字符串
        /// </summary>
        private static string NULLStr = " - ";

        /// <summary>
        /// 语义分析四元式结果输出文件
        /// </summary>
        public static string outputPath = Directory.GetCurrentDirectory() + "\\semantic.output";

        /// <summary>
        /// 输出流
        /// </summary>
        private FileStream outFileStream;

        public Semantic(Stack<Pascal> stack)
        {
            NXQ = 1;
            P_INDEX = 1;
            T_INDEX = -1;
            SymTable = new Hashtable();
            Stack = stack;

            //创建 输出词法分析结果流
            outFileStream = new FileStream(outputPath,
                FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        }

        /// <summary>
        /// 产生四元式
        /// </summary>
        /// <param name="op">操作符号编号</param>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="result">结果</param>
        /// <returns></returns>
        private int GEN(int op, string arg1, string arg2, string result)
        {
            string info = $"{NXQ}:({OPs[op]},{arg1},{arg2},{result}) \n";

            byte[] bytes = Encoding.UTF8.GetBytes(info);

            //向文件中写入字节数组
            outFileStream.Position = outFileStream.Length;//指针移到最后
            outFileStream.Write(bytes, 0, bytes.Length);

            return NXQ++;
        }

        /// <summary>
        /// 产生临时变量
        /// </summary>
        /// <returns></returns>
        private int NewTemp()
        {
            EV eV;
            eV.PLACE = T_INDEX;
            SymTable.Add($"T{T_INDEX}",eV);

            return T_INDEX--;
        }

        /// <summary>
        /// 查符号表
        /// </summary>
        /// <param name="name"></param>
        /// <returns>有 返回 PLACE 无 返回0</returns>
        private int LookUp(string name)
        {
            if (SymTable.ContainsKey(name))
            {
                return ((EV)SymTable[name]).PLACE;
            }

            return 0;
        }

        /// <summary>
        /// 以name 登记符号表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int Enter(string name)
        {
            EV eV;
            eV.PLACE = P_INDEX;
            SymTable.Add(name,eV);

            return P_INDEX++;
        }

        /// <summary>
        /// 查、填符号表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int Entry(string name)
        {
            int i = LookUp(name);
            if (i != 0)
            {
                return i;
            }
            else
            {
                return Enter(name);
            }
        }


        public void outFileStreamClose()
        {
            //刷新缓冲区
            outFileStream.Flush();
            //关闭输出结果流
            outFileStream.Close();
        }

        /// <summary>
        /// 开始语义
        /// </summary>
        /// <param name="GrammarIndex">文法编号</param>
        public void startSemanticAct(int GrammarIndex)
        {
            
            switch (GrammarIndex)
            {
                case 1:
                    Act_1();
                    break;
                case 2:
                    Act_2();
                    break;
                case 3:
                    Act_3();
                    break;
                case 4:
                    Act_4();
                    break;
                case 5:
                    Act_5();
                    break;
                case 6:
                    Act_6();
                    break;
                case 7:
                    Act_7();
                    break;
                case 8:
                    Act_8();
                    break;
                case 9:
                    Act_9();
                    break;
                case 10:
                    Act_10();
                    break;
                case 11:
                    Act_11();
                    break;
                case 12:
                    Act_12();
                    break;
                case 13:
                    Act_13();
                    break;
                case 14:
                    Act_14();
                    break;
                case 15:
                    Act_15();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// <变量>→<标识符>
        /// </summary>
        private void Act_15()
        {
            Pascal pascal = Stack.Peek();
            string name = pascal.TextToStr(pascal.Text);
            Entry(name);
        }

        /// <summary>
        /// <因式>→<数字>
        /// </summary>
        private void Act_14()
        {
            Pascal pascal = Stack.Peek();
            string name = pascal.TextToStr(pascal.Text);
            Entry(name);
        }

        /// <summary>
        /// <因式>→(<算术表达式>)
        /// </summary>
        private void Act_13()
        {
        }

        /// <summary>
        /// <因式>→<变量>
        /// </summary>
        private void Act_12()
        {
        }

        /// <summary>
        /// <项>→<项>*<因式>
        /// </summary>
        private void Act_11()
        {
        }

        /// <summary>
        /// <项>→<因式>
        /// </summary>
        private void Act_10()
        {
        }

        /// <summary>
        /// <算术表达式>→<算术表达式>+<项>
        /// </summary>
        private void Act_9()
        {
        }

        /// <summary>
        /// <算术表达式>→<项>
        /// </summary>
        private void Act_8()
        {
        }

        /// <summary>
        /// <关系表达式>→<算术表达式><关系符><算术表达式>
        /// </summary>
        private void Act_7()
        {
        }

        /// <summary>
        /// <语句>→BEGIN<语句表>END
        /// </summary>
        private void Act_6()
        {
        }

        /// <summary>
        /// <语句>→WHILE<关系表达式>DO<语句>
        /// </summary>
        private void Act_5()
        {
        }

        /// <summary>
        /// <语句>→IF<关系表达式>THEN<语句>ELSE<语句>
        /// </summary>
        private void Act_4()
        {
        }

        /// <summary>
        /// <语句>→<变量>:=<算术表达式>
        /// </summary>
        private void Act_3()
        {

        }

        /// <summary>
        /// <语句表>→<语句>;<语句表>
        /// </summary>
        private void Act_2()
        {
        }

        /// <summary>
        /// <语句表>→<语句>
        /// </summary>
        private void Act_1()
        {
        }

    }
}
