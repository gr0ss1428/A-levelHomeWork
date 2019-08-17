
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Array_Lib;

namespace Array_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;
            int selectedMenu = 0;
            History.NewGenArray(5);
            History.NewGenArray(6);
            History.NewGenArray(7);
            History.NewGenArray(8);
            History.NewGenArray(9);
            History.NewGenArray(10);
            const int ExitMainMenu = 3;
            do
            {
                selectedMenu = Menu(new List<string>() { "Новая матрица", "Печатать матрицу", $"История ({History.Count})", "Выход" }, ExitMainMenu,  null, false);
                switch (selectedMenu)
                {
                    case 0:
                        NewMatrix();
                        break;
                    case 1:
                        PrintMatrixMenu();
                        break;
                    case 2:
                        HistoryMatrix();
                        break;
                    case ExitMainMenu:
                        exit = true;
                        break;
                }
                if (selectedMenu == 3) exit = true;
            } while (!exit);
        }
        static void HistoryMatrix()
        {
            int selectedMenu = 0;
            bool exit = false;
            int ExitMenu = 0;
            do
            {
                List<string> menu = new List<string>();
                for (int i = 0; i < History.Count; i++)
                    menu.Add($"№{i + 1} Матрица {History.GetMatrixSizeByPos(i)}x{History.GetMatrixSizeByPos(i)}");
                menu.Add("Назад");
                ExitMenu = menu.Count - 1;
                selectedMenu = Menu(menu, ExitMenu, null, false);
                if (selectedMenu == ExitMenu)
                {
                    exit = true;
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    PrintMatrix(History.GetMatrixByPos(selectedMenu), false);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nВыбрать матрицу? Enter(выбор)");
                    if (Console.ReadKey(true).Key==ConsoleKey.Enter)
                    {
                        History.SetCurrentMatrix(selectedMenu);
                        exit = true;
                    }
                }
            }
            while (!exit);
        }
        static void PrintMatrixMenu()
        {
            int selectedMenu = 0;
            bool exit = false;
            const int ExitMenu = 3;
            bool colored = false;
            if (History.CurentMatrix == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Матрица не задана");
                Console.ReadKey();
            }
            else
            {
                int[,] matrix=null;//= new int[History.GetSizeCurrentMatrix(), History.GetSizeCurrentMatrix()];
                do
                {
                    selectedMenu = Menu(new List<string>() { "Транспонирование", "Верхняя треугольная матрица", "Нижняя треугольная матрица", "Назад" }, ExitMenu, matrix, colored, true);
                    if (matrix == null)
                    {
                        matrix= new int[History.GetCurrentMatrixSize(), History.GetCurrentMatrixSize()];
                    }
                    switch (selectedMenu)
                    {
                        case 0:
                            colored = true;
                            selectedMenu = Menu(new List<string>() { "Быстро", "Медленно", "Назад" }, ExitMenu,  null, colored, true);
                            if (selectedMenu == 0)
                            {
                                matrix = History.Transpose(History.CurentMatrix);
                            }
                            else if (selectedMenu == 1)
                            {
                                matrix = SlowTranspose(History.CurentMatrix);
                            }
                            break;
                        case 1:
                            colored = true;
                            selectedMenu = Menu(new List<string>() { "Быстро", "Медленно", "Назад" }, ExitMenu, null, colored, true);
                            if (selectedMenu == 0)
                            {
                                matrix = History.UpperTriangular(History.CurentMatrix);
                            }
                            else if (selectedMenu == 1)
                            {
                                matrix = SlowUpTriangular(History.CurentMatrix);
                            }
                            break;
                        case 2:
                            colored = true;
                            selectedMenu = Menu(new List<string>() { "Быстро", "Медленно", "Назад" }, ExitMenu, null, colored, true);
                            if (selectedMenu == 0)
                            {
                                matrix = History.LowerTriangular(History.CurentMatrix);
                            }
                            else if (selectedMenu == 1)
                            {
                                matrix = SlowDownTriangular(History.CurentMatrix);
                            }
                            break;
                        case ExitMenu:
                            exit = true;
                            break;
                    }
                } while (!exit);
            }
        }
        static void NewMatrix()
        {
            int clear = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            int sizeMatrix;
            do
            {
                do
                {
                    ClearLine(clear);
                    clear = 1;
                    Console.Write("Введите размер N>0 (NxN):");
                } while (!int.TryParse(Console.ReadLine(), out sizeMatrix));
            } while ( !(sizeMatrix>0));
            History.NewGenArray(sizeMatrix);
        }
        static int Menu(List<string> menu, int exitMenu,  int[,] workMatrix, bool colored, bool printMatrix = false)
        {
            int select = 0;
            string node;
            Console.Clear();
            for (int i = 0; i < menu.Count; i++)
            {
                if (select == i)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    node = $"-> {menu[i]}";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    node = $"   {menu[i]}";
                }
                Console.WriteLine(node);
            }
            bool bSelected = false;
            ConsoleKeyInfo Ckey;
            Console.SetCursorPosition(0, menu.Count + 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("↑↓ Enter(выбор) Esc (выход)");
            Console.SetCursorPosition(0, Console.CursorTop + 1);
            if (!printMatrix)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (History.GetCurrentMatrixSize() == 0) Console.WriteLine("Текущая матрица пуста");
                else
                {
                    Console.WriteLine($"Текущая матрица №{History.GetCurrentMatrixPosInHistory} {History.GetCurrentMatrixSize()}x{History.GetCurrentMatrixSize()}");
                }
            }
            else
            {
                if (History.GetCurrentMatrixSize() != 0)
                {
                    PrintMatrix(History.CurentMatrix, false);
                    Console.SetCursorPosition(0, Console.CursorTop + 1);
                }
                if (workMatrix != null)
                {
                    PrintMatrix(workMatrix, true);
                }
            }
            Console.SetCursorPosition(0, 0);
            Console.CursorVisible = false;
            do
            {
                Ckey = Console.ReadKey(true);
                if (Ckey.Key == ConsoleKey.Enter)
                {
                    bSelected = true;
                }
                else if (Ckey.Key == ConsoleKey.UpArrow)
                {
                    select--;
                    if (select < 0)
                    {
                        select = 0;
                        Console.SetCursorPosition(0, 0);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"-> {menu[select]}");
                    }
                    else
                    {
                        MenuUpDown(select, menu, 1);
                    }
                }
                else if (Ckey.Key == ConsoleKey.DownArrow)
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
                else if (Ckey.Key == ConsoleKey.Escape)
                {
                    select = exitMenu;
                    bSelected = true;
                }
            } while (!bSelected);
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
            Console.SetCursorPosition(0, selectLast);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, selectLast);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"   {menu[selectLast]}");
            Console.SetCursorPosition(0, select);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, select);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"-> {menu[select]}");
        }
        static void ClearLine(int clear = 0)
        {
            int cursor = Console.CursorTop - clear;
            Console.SetCursorPosition(0, cursor);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursor);
        }
        static void PrintMatrix(int[,] matrix, bool colored)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                    if (colored)
                    {
                        if (matrix[i, y] == 0) Console.ForegroundColor = ConsoleColor.Black;
                        else Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write($"{matrix[i, y].ToString("00")} ");
                    }
                    else Console.Write($"{matrix[i, y].ToString("00")} ");
                }
                Console.Write("\n");
            }
        }
        static int[,] SlowUpTriangular(int[,] matrix)
        {
            Console.SetCursorPosition(0, 7);
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                        if (y < i)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write($"{matrix[i, y].ToString("00")}");
                            Thread.Sleep(300);
                            matrix[i, y] = 0;
                            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                            Console.Write($"{matrix[i, y].ToString("00")}");
                            Thread.Sleep(300);
                            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.Write($"{matrix[i, y].ToString("00")} ");
                        }
                        else
                        {
                            Console.Write("\n");
                            break;
                        }
                }
            }
            return matrix;
        }
        static int[,] SlowDownTriangular(int[,] matrix)
        {
            int startTop = 7;
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i =0; i <matrix.GetLength(0); i++)
            {
                Console.SetCursorPosition(matrix.GetLength(0) * 2 + (matrix.GetLength(0) - 3), startTop+i);
                for (int y = matrix.GetLength(0)-1; y >=0; y--)
                {
                    if (y >i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write($"{matrix[i, y].ToString("00")}");
                        Thread.Sleep(300);
                        matrix[i, y] = 0;
                        Console.SetCursorPosition(Console.CursorLeft - 2, startTop + i);
                        Console.Write($"{matrix[i, y].ToString("00")}");
                        Thread.Sleep(300);
                        Console.SetCursorPosition(Console.CursorLeft - 2, startTop + i);
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write($"{matrix[i, y].ToString("00")} ");
                        Console.SetCursorPosition(Console.CursorLeft - 6, startTop + i);
                    }
                   else
                    {
                        break;
                    }
                }
            }
            return matrix;
        }
    static int[,] SlowTranspose(int[,] matrix)
        {
            int[,] tempMatrix = new int[matrix.GetLength(0), matrix.GetLength(0)];
            int consoleTop = 7;
            int consoleLeftTemp = 0;
            int consoleLeftMatrix = 0;
            Console.SetCursorPosition(0, consoleTop);
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int y = 0; y < matrix.GetLength(0); y++)
                {
                    tempMatrix[y, i] = matrix[i, y];
                    Console.SetCursorPosition(consoleLeftMatrix, consoleTop + i);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write($"{matrix[i, y].ToString("00")}");
                    Thread.Sleep(300);
                    Console.SetCursorPosition(Console.CursorLeft - 2, consoleTop + i);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($"{matrix[i, y].ToString("00")} ");
                    consoleLeftMatrix = Console.CursorLeft;
                    Console.SetCursorPosition(consoleLeftTemp, consoleTop + y+matrix.GetLength(0)+1);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Write($"{tempMatrix[y, i].ToString("00")}");
                    Thread.Sleep(300);
                    Console.SetCursorPosition(Console.CursorLeft - 2, consoleTop + y + matrix.GetLength(0)+1);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write($"{tempMatrix[y, i].ToString("00")} ");
                    consoleLeftTemp = Console.CursorLeft-3;
                }
                consoleLeftTemp += 3;
                consoleLeftMatrix = 0;
            }
            return tempMatrix;
        }
    }
}
