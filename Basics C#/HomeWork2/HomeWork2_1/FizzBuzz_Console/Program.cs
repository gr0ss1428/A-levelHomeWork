using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FizzBuzz_Lib;
namespace FizzBuzz_Console
{
    class Program
    {
        public const uint defaultDivider1 = 3;
        public const uint defaultDivider2 = 5;
        public const int defaultStart = 1;
        public const int defaultEnd = 100;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;
            int selectMenu = 0;
            string strSelectedMenu = String.Empty;
            int end;
            int start;
            uint divider1;
            uint divider2;
            while (!exit)
            {
                PrintMenu();
                do
                {
                    PrintMenu();
                    while (!int.TryParse(Console.ReadLine(), out selectMenu))
                    {
                        ClearLine(1);
                        Console.Write("Selected (1-5):");
                    }
                } while (!(selectMenu >= 1 && selectMenu <= 5));
                Console.Clear();
                switch (selectMenu)
                {
                    case 1:
                        strSelectedMenu = "Default";
                        Console.WriteLine("{0} ({1}...{2})/({3}|{4})", strSelectedMenu, defaultStart, defaultEnd, defaultDivider1, defaultDivider2);
                        WriteFizzBuzz(defaultStart, defaultEnd, defaultDivider1, defaultDivider2);
                        break;
                    case 2:
                        strSelectedMenu = "Optional 1";
                        Console.WriteLine("{0} (start...end)/({1}|{2})",strSelectedMenu, defaultDivider1,defaultDivider2);
                        Optional1(strSelectedMenu, out start,out end,defaultDivider1.ToString(),defaultDivider2.ToString());
                        Console.Clear();
                        Console.WriteLine("{0} ({1}...{2})/({3}|{4})",strSelectedMenu, start, end,defaultDivider1,defaultDivider2);
                        WriteFizzBuzz(start, end, defaultDivider1,defaultDivider2);
                        break;
                    case 3:
                        strSelectedMenu = "Optional 2";
                        Console.WriteLine("{0} ({1}...{2})/(Divider1|Divider2)",strSelectedMenu, defaultStart,defaultEnd);
                        Optional2(strSelectedMenu, out divider1,out divider2);
                        Console.Clear();
                        Console.WriteLine("{0} ({1}...{2})/({3}|{4})",strSelectedMenu, defaultStart, defaultEnd,divider1,divider2);
                        WriteFizzBuzz(defaultStart, defaultEnd, divider1, divider2);
                        break;
                    case 4:
                        strSelectedMenu = "Optional 3";
                        Console.WriteLine("{0} (start...end)/((Divider1|Divider2))",strSelectedMenu);
                        Optional1(strSelectedMenu,out start, out end, "Divider1", "Divider2");
                        Console.Clear();
                        Console.WriteLine("{0} ({1}...{2})/(Divider1|Divider2)",strSelectedMenu, start, end);
                        Optional2(strSelectedMenu,out divider1, out divider2,start,end);
                        Console.Clear();
                        Console.WriteLine("{0} ({1}...{2})/({3}|{4})",strSelectedMenu, start, end, divider1, divider2);
                        WriteFizzBuzz(start, end, divider1, divider2);
                        break;
                    case 5:
                        exit = true;
                        break;

                }
                if (!exit)
                {
                    Console.Write("New run? (y):");
                    string nextRun = Console.ReadLine();
                    if (nextRun == "y" || nextRun == "Y" || nextRun == "н" || nextRun == "Н")
                    {
                        Console.Clear();
                    }
                    else
                    {
                        exit = true;
                    }
                }
            }

        }
        static void WriteFizzBuzz(int? start, int? end, uint? divider1, uint? divider2, uint column = 20)
        {
            foreach (var node in FizzBuzzTools.FizzBuzzLstString(start, end, divider1, divider2, column))
            {
                Console.WriteLine(node);
            }
        }
        static void PrintMenu()
        {
            Console.Clear();
            string strMenu =String.Format("1)Default ({0}...{1})/({2}|{3}).\n2)Optional 1 (start...end)/({2}|{3}).\n3)Optional 2 ({0}...{1})/(Divider1|Divider2).\n" +
                "4)Optional 1 + Optional 2 (start...end)/(Divider1|Divider2).\n5)Exit", defaultStart,defaultEnd,defaultDivider1,defaultDivider2);
            Console.WriteLine(strMenu);
            Console.Write("Selected (1-5):");
        }
        static void ClearLine(int clear)
        {
            int cursor=Console.CursorTop-clear;
            Console.SetCursorPosition(0, cursor);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursor);
        }
        static void Optional1(string strSelectedMenu,out int start,out int end,string divider1,string divider2)
        {
            
            int clear = 0;
            Console.Write("Enter start:");
            while(!int.TryParse(Console.ReadLine(),out start))
            {
                ClearLine(1);
                Console.Write("Enter start:");
                
            }
            Console.Clear();
            Console.WriteLine("{0} ({1}...end)/({2}|{3})",strSelectedMenu,start,divider1,divider2);
            Console.Write("Enter end (start!=end):");
            do
            {
                ClearLine(clear);
                clear = 1;
                Console.Write("Enter end (start!=end):");
                while(!int.TryParse(Console.ReadLine(),out end))
                {
                    ClearLine(clear);
                    Console.Write("Enter end (start!=end):");
                }
            } while (!(start != end));
           

        }
        static void Optional2(string strSelectedMenu, out uint divider1,out uint divider2, int start = defaultStart, int end = defaultEnd)
        {
            GetDividerFromUser("Divider1",out divider1,end);
            Console.Clear();
            Console.WriteLine("{0} ({1}...{2})/({3}|{4})",strSelectedMenu, start,end, divider1, "Divider2");
            GetDividerFromUser("Divider2", out divider2, end);
        }
        static void GetDividerFromUser(string mark,out uint divider,int end,uint min=1)
        {
            bool check = false;
            int clear = 0;
            divider = 0;
            do
            {
                ClearLine(clear);
                if (clear == 0) Console.Write("Enter {0} >{1} and <{2} (must be prime number):",mark, min, Math.Abs(end));
                else Console.Write("Enter {0} >{2} (must be prime number, {1} not prime or <={2} or >{3}):",mark, divider,min, Math.Abs(end));
                clear = 1;
                while (!uint.TryParse(Console.ReadLine(), out divider))
                {
                    ClearLine(clear);
                    Console.Write("Enter {0} >{2} (must be prime number, {1} not prime or <={2} or >{3}):", mark, divider, min, Math.Abs(end));
                }
                if (divider != min) check = FizzBuzzTools.PrimeNumber(divider);
                if (divider > Math.Abs(end)) check = false;
            } while (!check);
        }
    }
}
