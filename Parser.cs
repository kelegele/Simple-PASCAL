using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections;

namespace Simple_PASCAL
{
    class Parser
    {
        /// <summary>
        /// ACTION
        /// </summary>
        private int[,] ACTION = Table.ACTION;

        /// <summary>
        /// GOTO
        /// </summary>
        private int [,] GOTO = Table.GOTO;

        /// <summary>
        /// 符号串
        /// </summary>
        private List<Pascal> SymList;

        /// <summary>
        /// 状态栈
        /// </summary>
        private Stack<int> StatusStack;

        /// <summary>
        /// 符号栈
        /// </summary>
        //private stack<Pascal> SymStack;

        /// <summary>
        /// 语义栈
        /// </summary>
        private Stack<Pascal> SemanticStack;

        /// <summary>
        /// 语音动作实例
        /// </summary>
        private Semantic SemanticAct;

        public Parser(List<Pascal> symList)
        {
            SymList = symList;
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            
            //SymStack = new stack<Pascal>();
            
            //状态栈初始化
            StatusStack = new Stack<int>();
            StatusStack.Push(0);

            //语义栈初始化
            SemanticStack = new Stack<Pascal>();
            Pascal stackTop = new Pascal();
            stackTop.Num = -1;
            stackTop.Text[0] = '-';
            SemanticStack.Push(stackTop);

            //语义分析初始化
            SemanticAct = new Semantic(SemanticStack);

            foreach (Pascal pascal in SymList)
            {
                pascal.Id = (int)Type.TypeToId[pascal.Type];
            }

        }

        /// <summary>
        /// 语法分析开始
        /// </summary>
        /// <returns></returns>
        public Hashtable Run()
        {
            //输出结果
            Hashtable result = new Hashtable();

            //接受
            bool accept = true;

            //语法错误处
            Pascal er = SymList[0]; ;

            int index = 0;
            int TopStat = StatusStack.Peek();
            int InpSym = SymList[index].Id;

            while (ACTION[TopStat,InpSym] != Table.ACC)//acc
            {
                if (ACTION[TopStat, InpSym] == Table.ERR)//err
                {
                    er = SymList[index];
                    accept = false;
                    break;
                }
                else if (ACTION[TopStat, InpSym] > 0)//移进
                {
                    StatusStack.Push(ACTION[TopStat, InpSym]);
                    int type = SymList[index].Type;
                    if (type == Type.THEN || type == Type.DO)
                    {
                        SymList[index].TC = SemanticAct.NewLabel();
                        SymList[index].FC = SemanticAct.NewLabel();
                    }

                    if (type == Type.ELSE )
                    {
                        SymList[index].Next = SemanticAct.NewLabel();

                    }

                    SemanticStack.Push(SymList[index]);


                    TopStat = StatusStack.Peek();
                    index++;
                    InpSym = SymList[index].Id;

                }
                else if (ACTION[TopStat, InpSym] < 0)//归约
                {
                    int reduceIndex = ACTION[TopStat, InpSym];
                    //语义动作
                    Act(-reduceIndex);

                    int sum = (int)Table.SumProdRight[ACTION[TopStat, InpSym]];
                    while(sum > 0)
                    {
                        StatusStack.Pop();//出栈 第i个产生式右部文法符号的个数
                        sum--;
                    }

                    TopStat = StatusStack.Peek();

                    int gotoPush = GOTO[TopStat, (int)Table.ProdIndex[reduceIndex]];
                    if(gotoPush == Table.ERR)
                    {
                        er = SymList[index];
                        accept = false;
                        break;
                    }

                    StatusStack.Push(gotoPush);
                }
                TopStat = StatusStack.Peek();
            }

            if (accept)
            {
                result.Add(Message.KEY, Message.SUCCESS);
                result.Add(Message.MSG, "语法分析ACCEPT!");
                result.Add(Message.VALUE, SymList);
            }
            else
            {
                result.Add(Message.KEY, Message.FAILURE);
                result.Add(Message.MSG, $"语法 ERROR, 行:{er.X},列:{er.Y}");
            }

            SemanticAct.Print();
            SemanticAct.outFileStreamClose();

            return result;
        }

        /// <summary>
        /// 语义动作
        /// </summary>
        private void Act(int index)
        {
            SemanticAct.startSemanticAct(index);
        }
    }
}
