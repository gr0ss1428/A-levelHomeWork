using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleFizzBazz2.FizzBuzzAlg;
namespace ConsoleFizzBazz2
{
    class Program
    {
        static void Main(string[] args)
        {
            Control control = Control.GetControl();
            bool exit = false;
            int select = 0;
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                select = Menu(new List<string>() { "New calculate.", "Exit." });
                switch (select)
                {
                    case 1:
                        NewCalculate(control);
                        break;
                    case 2:
                        exit = true;
                        break;
                }
            } while (!exit);
        }

        static void NewCalculate(Control control)
        {
            bool exit = false;
            int end;
            int threads;
            TimeSpan timeSpanNoThreads;
            TimeSpan timeSpanAsync;
            TimeSpan timeSpanThreads;
            do
            {
                Console.Clear();
                end = IntParse("Enter end value:",100000000);
                Console.Clear();
                threads = IntParse("Enter threads count:",5);

                Console.Clear();
                timeSpanNoThreads = StartFB(control, "No threads", end, new FizzBuzz(), true);
                timeSpanAsync = StartFB(control, "Async", end, new FizzBuzzAsync(threads), true);
                timeSpanThreads = StartFB(control, "Threads", end, new FizzBuzzThread(threads), false);

                Console.SetCursorPosition(0, Console.CursorTop + 2);
                Console.WriteLine("Press enter(new run)/eny key(exit)");
                if (Console.ReadKey(true).Key != ConsoleKey.Enter)
                {
                    exit = true;
                }
            } while (!exit);
        }

        static TimeSpan StartFB(Control control, string label, int end, FizzBuzz fizzBuzz, bool printLine)
        {
            Console.WriteLine(label);
            control.StartFizzBuzz(end, fizzBuzz);
            Console.WriteLine($"\r{control.Time.ToString()}");
            if (printLine) Console.WriteLine("-----------------------------");

            return control.Time;
        }

        static int Menu(List<string> menu)
        {
            int selectType = 0;
            Console.Clear();
            int count = 1;
            foreach (var m in menu)
            {
                Console.WriteLine($"{count}) {m}");
                count++;
            }

            int clear = 0;
            bool intParse = false;
            do
            {
                ClearLine(clear);
                Console.Write($"Selected (1-{menu.Count}):");
                clear = 1;
                intParse = int.TryParse(Console.ReadLine(), out selectType);
            } while (!(selectType >= 1 && selectType <= menu.Count) || !intParse);

            return selectType;
        }

        static int IntParse(string label,int def)
        {
            bool intParse = false;
            int clear = 0;
            int value;
            do
            {
                Console.WriteLine($"Default value:{def}, press enter(default)");
                ClearLine(clear);
                Console.Write(label);
                clear = 1;

                string strValue = Console.ReadLine();
                if (strValue != string.Empty)
                {
                    intParse = int.TryParse(strValue, out value);
                }
                else
                {
                    value = def;
                    intParse = true;
                }

            } while (!intParse);

            return value;
        }

        static void ClearLine(int clear = 0)
        {
            int cursor = Console.CursorTop - clear;
            Console.SetCursorPosition(0, cursor);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursor);
        }
    }
}
