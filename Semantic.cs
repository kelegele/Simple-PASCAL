using System;
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
        private Stack<Pascal> stack;

        /// <summary>
        /// 四元式标识
        /// </summary>
        private int NXQ;

        /// <summary>
        /// 符号表 {int id, int num }
        /// </summary>
        private Hashtable SymTable;

        /// <summary>
        /// 符号表变量编号 大于0
        /// </summary>
        private int P_INDEX;

        /// <summary>
        /// 符号表临时变量编号 小于0
        /// </summary>
        private int T_INDEX;

        /// <summary>
        /// 操作表 "0 J", "1 JT", "2 JF",  "3 <",  "4 >",  "5 =", "6 <=", "7 >=", "8 <>", "9 +", "10 *", "11 :="
        /// </summary>
        private static string[] OPs = { "J", "JT", "JF", "<", ">", "=", "<=", ">=", "<>", "+", "*", ":=" };


        private List<string[]> SemtArr;

        /// <summary>
        /// 空字符串
        /// </summary>
        private static string NULLStr = " -- ";

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
            P_INDEX = 0;
            T_INDEX = 0;
            SymTable = new Hashtable();
            SemtArr = new List<string[]>();
            this.stack = stack;

            //创建 输出词法分析结果流
            outFileStream = new FileStream(outputPath,
                FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        }

        /// <summary>
        /// 产生四元式 0 J, 1 J> ,2 J<,3 J=,4 +,5 *,6 := 
        /// </summary>
        /// <param name="op">操作符号编号</param>
        /// <param name="arg1">参数1</param>
        /// <param name="arg2">参数2</param>
        /// <param name="result">结果</param>
        /// <returns></returns>
        private int GEN(int op, string arg1, string arg2, string result)
        {
            string[] info = {NXQ.ToString(), OPs[op],arg1,arg2,result };
            // $"{NXQ}:({OPs[op]},{arg1},{arg2},{result}) \n";
            SemtArr.Add(info);

            return NXQ++;
        }

        public int NewLabel()
        {
            string[] info = { NXQ.ToString(), null, null, null, null };
            SemtArr.Add(info);
            return NXQ++;
        }

        /// <summary>
        /// 产生临时变量
        /// </summary>
        /// <returns></returns>
        private int NewTemp(int num )
        {
            T_INDEX--;

            SymTable.Add(T_INDEX,num);

            return T_INDEX;
        }

        /// <summary>
        /// 查符号表
        /// </summary>
        /// <param id="id"></param>
        /// <returns>有 返回 id 无 返回0</returns>
        private int LookUp(string name)
        {
            int index = 0;
            if (SymTable.ContainsKey(name))
            {
                index = (int)SymTable[name];
                return index;
            }

            return 0;
        }

        /// <summary>
        /// 登记符号表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int Enter(Pascal o)
        {
            P_INDEX++;
            SymTable.Add(P_INDEX, o);

            return P_INDEX;
        }

        /// <summary>
        /// 查、添符号表
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private int Entry(string name,Pascal pascal)
        {
            int i = LookUp(name);
            if (i != 0)
            {
                return i;
            }
            else
            {
                int index = Enter(pascal);
                SymTable.Add(name,index);
                return index;
            }
        }


        public void outFileStreamClose()
        {
            //刷新缓冲区
            outFileStream.Flush();
            //关闭输出结果流
            outFileStream.Close();
        }

        public void Print()
        {
            foreach (string[] o in SemtArr)
            {
                string info = $"{o[0]}:({o[1]},{o[2]},{o[3]},{o[4]}) \n";

                byte[] bytes = Encoding.UTF8.GetBytes(info);

                //向文件中写入字节数组
                outFileStream.Position = outFileStream.Length;//指针移到最后
                outFileStream.Write(bytes, 0, bytes.Length);
            }
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
        /// <变量>→<标识符> L→k
        /// </summary>
        private void Act_15()
        {
            Pascal t = stack.Pop();

            int findIndex = Entry(t.TextToStr(t.Text),t);
            Pascal r = (Pascal)SymTable[findIndex];
            Pascal l = new Pascal();

            l.Text = r.Text;
            l.Num = r.Num;
            
            stack.Push(l);
        }

        /// <summary>
        /// <因式>→<数字> K->i
        /// </summary>
        private void Act_14()
        {
            Pascal r = stack.Pop();
            Pascal l = new Pascal();

            l.Text = r.Text;
            l.Num = r.Num;

            stack.Push(l);
        }

        /// <summary>
        /// <因式>→(<算术表达式>)
        /// </summary>
        private void Act_13()
        {
            stack.Pop();
            Pascal r = stack.Pop();
            stack.Pop();

            Pascal l = new Pascal();
            l.Text = r.Text;
            l.Num = r.Num;

            stack.Push(l);

        }

        /// <summary>
        /// <因式>→<变量>
        /// </summary>
        private void Act_12()
        {
            Pascal r = stack.Pop();
            Pascal l = new Pascal();

            l.Text = r.Text;
            l.Num = r.Num;

            stack.Push(l);
        }

        /// <summary>
        /// <项>→<项>*<因式>
        /// </summary>
        private void Act_11()
        {
            Pascal r3 = stack.Pop();
            stack.Pop();
            Pascal r1 = stack.Pop();

            Pascal l = new Pascal();
            l.Num = r1.Num * r3.Num;

            l.Text = $"T{NewTemp(l.Num)}".ToCharArray();

            GEN(10, r1.TextToStr(r1.Text), r3.TextToStr(r3.Text), l.TextToStr(l.Text));

            stack.Push(l);
        }

        /// <summary>
        /// <项>→<因式>
        /// </summary>
        private void Act_10()
        {
            Pascal r = stack.Pop();
            Pascal l = new Pascal();

            l.Text = r.Text;
            l.Num = r.Num;

            stack.Push(l);
        }

        /// <summary>
        /// <算术表达式>→<算术表达式>+<项>
        /// </summary>
        private void Act_9()
        {
            Pascal r3 = stack.Pop();
            stack.Pop();
            Pascal r1 = stack.Pop();

            Pascal l = new Pascal();
            l.Num = r1.Num + r3.Num;
           
            l.Text = $"T{NewTemp(l.Num)}".ToCharArray();
            

            GEN(9, r1.TextToStr(r1.Text), r3.TextToStr(r3.Text), l.TextToStr(l.Text));

            stack.Push(l);
        }

        /// <summary>
        /// <算术表达式>→<项>
        /// </summary>
        private void Act_8()
        {
            Pascal r = stack.Pop();
            Pascal l = new Pascal();

            l.Text = r.Text;
            l.Num = r.Num;

            stack.Push(l);
        }

        /// <summary>
        /// <关系表达式>→<算术表达式><关系符><算术表达式>
        /// </summary>
        private void Act_7()
        {
            Pascal r3 = stack.Pop();
            Pascal r2 = stack.Pop();
            Pascal r1 = stack.Pop();
            Pascal l = new Pascal();

            int ret = -1;
            int c = -1;
            switch (r2.Type)
            {
                case Type.LT:
                    ret = (r1.Num < r3.Num) ? 1 : 0;
                    c = 3;
                    break;
                case Type.LE:
                    ret = (r1.Num <= r3.Num) ? 1 : 0;
                    c = 6;
                    break;
                case Type.EQ:
                    ret = (r1.Num == r3.Num) ? 1 : 0;
                    c = 5;
                    break;
                case Type.NE:
                    ret = (r1.Num != r3.Num) ? 1 : 0;
                    c = 8;
                    break;
                case Type.GT:
                    ret = (r1.Num > r3.Num) ? 1 : 0;
                    c = 4;
                    break;
                case Type.GE:
                    ret = (r1.Num >= r3.Num) ? 1 : 0;
                    c = 7;
                    break;
                default:
                    break;
            }

            l.Num = ret;

            //真假临时变量名字
            l.Text = $"T{NewTemp(l.Num)}".ToCharArray();
            int j = GEN(c, r1.TextToStr(r1.Text), r3.TextToStr(r3.Text), l.TextToStr(l.Text));
            l.Next = j;
            stack.Push(l);
        }

        /// <summary>
        /// <语句>→BEGIN<语句表>END
        /// </summary>
        private void Act_6()
        {
            stack.Pop();
            Pascal r2 = stack.Pop();
            stack.Pop();

            Pascal l = new Pascal();
            l.Next = r2.Next;
            stack.Push(l);
        }

        /// <summary>
        /// <语句>→WHILE<关系表达式>DO<语句>
        /// </summary>
        private void Act_5()
        {
            Pascal r4 = stack.Pop();
            Pascal r3 = stack.Pop();
            Pascal r2 = stack.Pop();
            Pascal r1 = stack.Pop();

            GEN(0, NULLStr, NULLStr, r2.Next.ToString());

            for (int j = 0; j < SemtArr.Count; j++)
            {
                string[] o = SemtArr[j];
                if (int.Parse(o[0]) == r3.TC)
                {
                    SemtArr[j][1] = OPs[1];
                    SemtArr[j][2] = r2.TextToStr(r2.Text);
                    SemtArr[j][3] = NULLStr;
                    SemtArr[j][4] = (r3.TC+2).ToString();
                }

                if (int.Parse(o[0]) == r3.FC)
                {
                    SemtArr[j][1] = OPs[2];
                    SemtArr[j][2] = r2.TextToStr(r2.Text);
                    SemtArr[j][3] = NULLStr;
                    SemtArr[j][4] = NXQ.ToString();
                }
            }


            r3.TC = r4.Next;
            r3.FC = NXQ;

            Pascal l = new Pascal();
            stack.Push(l);
        }

        /// <summary>
        /// <语句>→IF<关系表达式>THEN<语句>ELSE<语句>
        /// </summary>
        private void Act_4()
        {
            Pascal r6 = stack.Pop();
            Pascal r5 = stack.Pop();
            Pascal r4 = stack.Pop();
            Pascal r3 = stack.Pop();
            Pascal r2 = stack.Pop();
            Pascal r1 = stack.Pop();

            for (int j = 0;j < SemtArr.Count;j++)
            {
                string[] o = SemtArr[j];
                if (int.Parse(o[0]) == r3.TC)
                {
                    SemtArr[j][1] = OPs[1];
                    SemtArr[j][2] = r2.TextToStr(r2.Text);
                    SemtArr[j][3] = NULLStr;
                    SemtArr[j][4] = (r3.TC+2).ToString();
                }

                if (int.Parse(o[0]) == r3.FC)
                {
                    SemtArr[j][1] = OPs[2];
                    SemtArr[j][2] = r2.TextToStr(r2.Text);
                    SemtArr[j][3] = NULLStr;
                    SemtArr[j][4] = (r5.Next+1).ToString();
                }

                if(int.Parse(o[0]) == r5.Next)
                {
                    SemtArr[j][1] = OPs[0];
                    SemtArr[j][2] = NULLStr;
                    SemtArr[j][3] = NULLStr;
                    SemtArr[j][4] = NXQ.ToString();
                }
            }

            r3.TC = r4.Next;
            r3.FC = r6.Next;

            Pascal l = new Pascal();
            stack.Push(l);
        }

        /// <summary>
        /// <语句>→<变量>:=<算术表达式>
        /// </summary>
        private void Act_3()
        {
            Pascal r3 = stack.Pop();
            stack.Pop();
            Pascal r1 = stack.Pop();
            Pascal l = new Pascal();

            r1.Num = r3.Num;
            int index = Entry(r1.TextToStr(r1.Text),r1);
            r1 = (Pascal)SymTable[index];
            r1.Num = r3.Num;

            int j = GEN(11,r3.TextToStr(r3.Text),NULLStr,r1.TextToStr(r1.Text));

            l.Text = r1.Text;
            l.Num = r1.Num;
            l.Next = j;

            stack.Push(l);

        }

        /// <summary>
        /// <语句表>→<语句>;<语句表>
        /// </summary>
        private void Act_2()
        {
            stack.Pop();
            stack.Pop();
            Pascal r1 = stack.Pop();

            Pascal l = new Pascal();
            l.Next = r1.Next;
            stack.Push(l);
        }

        /// <summary>
        /// <语句表>→<语句>
        /// </summary>
        private void Act_1()
        {
            Pascal r1 = stack.Pop();

            Pascal l = new Pascal();
            l.Next = r1.Next;

            stack.Push(l);
        }

    }
}
