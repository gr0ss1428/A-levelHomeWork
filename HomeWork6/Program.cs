using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using History;
namespace HomeWork6
{
    enum Movement
    {
        FIX,
        DOWN,
        UP
    }
    class Program
    {
        static Timer timer;
        static Stalactite stalactite;
        static int moveCount;
        static int moveNexGen;
        static Helicopter helicopterUser;
        static int countFrame;
        static bool crash;
        static int widthScreen = 121;
        static int heightScreen = 36;
        static int score;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.SetWindowSize(widthScreen, heightScreen);
            Console.SetBufferSize(widthScreen, heightScreen);
            Console.CursorVisible = false;
            int selectMenu = 0;
            bool exit = false;
            do
            {
                selectMenu = Menu(new List<string>() { "Новый взлет", "Лучшие", "Выход" }, 2);
                switch (selectMenu)
                {
                    case 0:
                        StartGame();
                        break;
                    case 1:
                        DrawHistory();
                        break;
                    case 2:
                        exit = true;
                        break;
                }
            } while (!exit);
        }
        static void StartGame()
        {
            score = 0;
            bool exit = false;
            Thread thread = new Thread(new ThreadStart(ReadKeyThread));
            int life = 3;
            string name = GetName();
            if (name.Length == 0) name = "Инкогнито";

            Keyboard();
            InitScene(life);

            thread.IsBackground = true;
            thread.Start();

            do
            {
                if (crash)
                {
                    InitScene(--life);
                }
                if (!thread.IsAlive)
                {
                    exit = true;
                }
            } while ((!exit && life > 0));

            timer.Dispose();

            Console.Clear();
            Console.SetCursorPosition(widthScreen / 2 - 5, heightScreen / 2 - 5);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Вы набрали {score}");

            HistoryArr.AddResult(score, name);
            if (thread.IsAlive)
            {
                thread.Abort();//не вытаскивает из  Console.ReadKey(true) exeptuon вознимает после нажатия клавиши
                while (thread.IsAlive)//знаючто это не правильно но не знаю как ещё вытащит из ожидания клавиши и сделать вид что мы ожидаем клавишу для продолжения
                {
                }
            }
            else Console.ReadKey();
        }
        static void DrawHistory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            if (HistoryArr.LengthHistory == 0)
            {
                Console.SetCursorPosition(widthScreen / 2 - 5, heightScreen / 2 - 10);
                Console.Write($"Ещё никто не летал");
            }
            else
            {
                for (int i = 0; i < HistoryArr.LengthHistory; i++)
                {
                    Console.SetCursorPosition(widthScreen / 2 - 5, heightScreen / 2 - 10 + i);
                    Console.Write($"{i + 1} {HistoryArr.GetHistoryByPosStr(i)}");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(widthScreen / 2 - 15, heightScreen - 2);
            Console.Write("Для возврата нажмите любую кнопку");
            Console.ReadKey();
            Console.ResetColor();
        }
        static void ReadKeyThread()
        {
            ConsoleKey key;
            bool exit = false;
            do
            {
                key = Console.ReadKey(true).Key;// Зайдя сюда не выйдешь никогда
                if (key != ConsoleKey.Escape)
                {
                    helicopterUser.Wheel(key);
                }
                else exit = true;
            } while (!exit);
        }
        static string GetName()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(widthScreen / 2 - 10, heightScreen / 2 - 5);
            Console.Write("Имя пилота: ");
            return Console.ReadLine();
        }
        static void Keyboard()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            List<string> key = new List<string>() { "↓ Штурвал на себя мы взлетаем.", "↑ Штурвал от себя мы падаем", "(Esc)Выход" };
            for (int i = 0; i < key.Count; i++)
            {
                Console.SetCursorPosition(widthScreen / 2 - 10, heightScreen / 2 - 5 + i);
                Console.Write(key[i]);
            }
            Console.SetCursorPosition(widthScreen / 2 - 10, heightScreen - 2);
            Console.Write("Для старта нажмите любую кнопку");
            Console.ReadKey();
            Console.ResetColor();
        }
        static void InitScene(int life)
        {
            Console.Clear();
            Console.CursorVisible = false;

            Cave wall = new Cave(widthScreen - 1, 30, '#', ConsoleColor.DarkYellow);
            stalactite = new Stalactite(widthScreen - 2, heightScreen - 6, 'X', ConsoleColor.DarkYellow);
            helicopterUser = new Helicopter(widthScreen, heightScreen - 6, ConsoleColor.Green);

            moveCount = 0;
            moveNexGen = stalactite.random.Next(25, 50);
            countFrame = 0;
            stalactite.NewGeneration();
            crash = false;
            DrawLife(life);
            timer = new Timer(NextFrame, null, 0, 50);
        }
        static void DrawLife(int life)
        {
            Console.SetCursorPosition(widthScreen - 15, heightScreen - 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"ЛиФе: ");
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < life; i++)
                Console.Write("♥");
            Console.SetCursorPosition(widthScreen/2-3, heightScreen - 2);
            Console.Write($"v0.09");
            Console.ForegroundColor = ConsoleColor.Black;
        }
        static void DrawScore()
        {
            Console.SetCursorPosition(2, heightScreen - 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"СкоRе: {score}");
            Console.ForegroundColor = ConsoleColor.Black;
        }
        static void NextFrame(object ob)
        {
            countFrame++;
            if (countFrame % 2 == 0) score += stalactite.Move();
            helicopterUser.Move();
            DrawScore();
            crash = helicopterUser.Crash(stalactite.GetFirstStalactiteCoord());
            if (crash)
            {
                timer.Dispose();
            }
            if (++moveCount >= moveNexGen)
            {
                moveCount = 0;
                moveNexGen = stalactite.random.Next(25, 50);
                stalactite.NewGeneration();
            }
            if (countFrame == 10) countFrame = 0;
        }
        static int Menu(List<string> menu, int exit)
        {
            int select = 0;
            string node;
            bool exitMenu = false;
            ConsoleKey Ckey;
            Console.Clear();
            for (int i = 0; i < menu.Count; i++)
            {
                if (select == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    node = $"*{menu[i]}";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    node = $" {menu[i]}";
                }
                Console.SetCursorPosition(widthScreen / 2 - 5, heightScreen / 2 - 5 + i);
                Console.WriteLine(node);
            }
            Console.SetCursorPosition(widthScreen / 2 - 14, heightScreen - 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("↑↓ Enter(выбор) Esc (выход)");

            do
            {
                Ckey = Console.ReadKey(true).Key;
                if (Ckey == ConsoleKey.Enter)
                {
                    exitMenu = true;
                }
                else if (Ckey == ConsoleKey.Escape)
                {
                    select = exit;
                    exitMenu = true;
                }
                else if (Ckey == ConsoleKey.DownArrow)
                {
                    select++;
                    if (select >= menu.Count)
                    {
                        select = menu.Count - 1;
                    }
                    else
                    {
                        MenuUpDown(select, menu, 0);
                    }
                }
                else if (Ckey == ConsoleKey.UpArrow)
                {
                    select--;
                    if (select < 0)
                    {
                        select = 0;
                    }
                    else
                    {
                        MenuUpDown(select, menu, 1);
                    }
                }
            } while (!exitMenu);
            return select;
        }
        static void MenuUpDown(int select, List<string> menu, int upDown)
        {
            int selectLast = 0;
            if (upDown == 0)
            {
                selectLast = select - 1;
            }
            else
            {
                selectLast = select + 1;
            }
            Console.SetCursorPosition(widthScreen / 2 - 5, heightScreen / 2 - 5 + selectLast);
            Console.Write(new string(' ', menu[selectLast].Length));
            Console.SetCursorPosition(widthScreen / 2 - 5, heightScreen / 2 - 5 + selectLast);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($" {menu[selectLast]}");
            Console.SetCursorPosition(widthScreen / 2 - 5, heightScreen / 2 - 5 + select);
            Console.Write(new string(' ', menu[select].Length));
            Console.SetCursorPosition(widthScreen / 2 - 5, heightScreen / 2 - 5 + select);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"*{menu[select]}");
        }
    }
}
