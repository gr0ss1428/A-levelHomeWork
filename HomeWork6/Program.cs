using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
        static bool exitSceneGame;
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
                selectMenu = Menu(new List<string>() { "Новый взлет", "Выход" }, 1);
                if (selectMenu == 1) exit = true;
                else StartGame();

            } while (!exit);
        }
        static void StartGame()
        {
            score = 0;
            exitSceneGame = false;
            Thread thread=new Thread(new ThreadStart(ReadKeyThread));
            InitScene();
            thread.Start();
            do
            {
                if (crash)
                {
                    thread.Suspend();
                    InitScene();
                    thread.Resume();
                }

            } while (!exitSceneGame);
            timer.Dispose();
            thread.Abort();
        }
        static void ReadKeyThread()
        {
            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;
                if (key != ConsoleKey.Escape)
                {
                    helicopterUser.Wheel(key);
                }
                else exitSceneGame = true;
            } while (!exitSceneGame);
        }
        static void InitScene()
        {
            Console.Clear();
            Cave wall = new Cave(widthScreen - 1, 30, '#');
            stalactite = new Stalactite(widthScreen - 2, heightScreen - 6, 'X');
            helicopterUser = new Helicopter(widthScreen, heightScreen - 6);
            moveCount = 0;
            moveNexGen = stalactite.random.Next(10, 50);
            countFrame = 0;
            stalactite.NewGeneration();
            crash = false;
            timer = new Timer(NextFrame, null, 0, 100);
        }
        static void NextFrame(object ob)
        {

            countFrame++;
            //if(countFrame%2==0) 
            stalactite.Move();
            helicopterUser.Move();
            crash = helicopterUser.Crash(stalactite.GetFirstStalactiteCoord());
            if (crash)
            {
                timer.Dispose();
            }
            if (++moveCount >= moveNexGen)
            {
                moveCount = 0;
                moveNexGen = stalactite.random.Next(20, 50);
                stalactite.NewGeneration();
            }
            if (countFrame == 10) countFrame = 0;
            // 
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
