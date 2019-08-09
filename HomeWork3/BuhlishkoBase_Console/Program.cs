using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alcohol_Lib;
namespace BuhlishkoBase_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;
            List<string> mainMenu = new List<string>() { "1)Добавить новый товар.","2)Удалить товар.","3)Добавить новый вид алкоголя.","4)Показать склад.","5)Изменить количество товара.","6)Выход." };
            int selectedMenu;
            do
            {
               
                do
                {
                    Console.Clear();
                    PrintMenu("Добро пожаловать на склад Бухлишко",mainMenu);
                    while (!int.TryParse(Console.ReadLine(), out selectedMenu))
                    {
                        ClearLine(1);
                        Console.Write($"Selected (1-{mainMenu.Count}):");
                    }
                } while (!(selectedMenu >= 1 && selectedMenu <= mainMenu.Count));

                switch(selectedMenu)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        exit = true;
                        break;
                    case 6:
                        exit = true;
                        break;
                }

            } while(!exit);
        }
        static void PrintMenu(string message,List<string> menu)
        {
            Console.WriteLine(message);
            foreach (var m in menu)
            {
                Console.WriteLine(m);
            }
            Console.Write("Selected (1-{0}):", menu.Count);


        }
        static void ClearLine(int clear=0)
        {
            int cursor = Console.CursorTop - clear;
            Console.SetCursorPosition(0, cursor);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursor);
        }
    }
}
