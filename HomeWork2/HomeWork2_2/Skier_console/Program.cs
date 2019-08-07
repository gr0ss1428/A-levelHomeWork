using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skier_lib;
namespace Skier_console
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool exit = false;
            int selectMenu = 0;
            List<string> listMenu = new List<string>() { "1)Add skiers training.", "2)Print all calculation.", "3)Exit." };
            Dictionary<uint, List<SkierModel>> history = new Dictionary<uint, List<SkierModel>>();
            while (!exit)
            {
                
                do
                {
                    Console.Clear();
                    PrintMenu(listMenu);
                 
                    while (!int.TryParse(Console.ReadLine(), out selectMenu))
                    {
                        ClearLine(1);
                        Console.Write("Selected (1-3):");
                    }
                } while (!(selectMenu >= 1 && selectMenu <= 3));
                Console.Clear();
                switch (selectMenu)
                {
                    case 1:

                        AddSkiers(ref history, listMenu[selectMenu - 1],ref exit);
                        break;
                    case 2:
                        PrintAllTrain(history,ref exit);
                        break;
                    case 3:
                        exit = true;
                        break;

                }

            }

        }
        static void AddSkiers(ref Dictionary<uint, List<SkierModel>> history, string strSelectedMenu,ref bool exitApp)
        {
            bool exit = false;
            Console.WriteLine(strSelectedMenu);
            SkierModel skModel = new SkierModel();
            int clear = 0;
            uint id;
            uint distFirstDay;
            uint persentBoost;
            uint calcDay;
            uint calcDist;
            
           
                ClearLine(clear);
                if (clear == 0) Console.Write("Enter number Skiers:");
                else Console.Write("This number is exist, enter number:");
                clear = 1;
                while (!uint.TryParse(Console.ReadLine(), out id))
                {
                    ClearLine(clear);
                    Console.Write("Enter number Skiers:");
                }
            
            if(!history.ContainsKey(id)) history.Add(id, new List<SkierModel>());
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine(strSelectedMenu);
                Console.WriteLine("Number skies:{0}", id);

                Console.Write("Enter first day distance:");
                while (!uint.TryParse(Console.ReadLine(), out distFirstDay))
                {
                    ClearLine(1);
                    Console.Write("Enter first day distance:");
                }
                ClearLine(1);
                Console.WriteLine("First day distance: {0}", distFirstDay);
                clear = 0;

                do
                {
                    ClearLine(clear);
                    if (clear == 0) Console.Write("Enter persent BOOOOOST%:");
                    else Console.Write("Enter persent BOOOOOST%>0 and <=100:");
                    clear = 1;
                    while (!uint.TryParse(Console.ReadLine(), out persentBoost))
                    {
                        ClearLine(1);
                        Console.Write("Enter persent BOOOOOST%:");
                    }
                } while (!(persentBoost > 0 && persentBoost <= 100));
                ClearLine(1);
                Console.WriteLine("BOOST: {0}%", persentBoost);

                Console.Write("Enter run distance km:");
                while (!uint.TryParse(Console.ReadLine(), out calcDist))
                {
                    ClearLine(1);
                    Console.Write("Enter run distance km:");
                }
                calcDay = SkierTools.GetDayRunDistanse(distFirstDay, persentBoost, calcDist);
                Console.Clear();

                Console.WriteLine("Performance characteristics skier №{0}, first training {1}km, boost {2}%, enter distanse {3}km", id, distFirstDay, persentBoost, calcDist);
                Console.WriteLine("Skier runs the distance on day {0}", calcDay);
                history[id].Add(new SkierModel() { id = id, distFirstDay = distFirstDay, persentBoost = persentBoost, calcDist = calcDist, calcDay = calcDay });
                
                int selectMenu;
                bool exitThisMenu = false;
                while (!exitThisMenu)
                {
                    do
                    {
                        PrintMenu(new List<string>() { "1)New training", "2)Print history","3)Back","4)Exit" });
                       
                        while (!int.TryParse(Console.ReadLine(), out selectMenu))
                        {
                            ClearLine(1);
                            Console.Write("Selected (1-4):");
                        }
                    } while (!(selectMenu >= 1 && selectMenu <= 4));
                    if (selectMenu == 1)
                    { 
                        exitThisMenu = true;
                        Console.Clear();
                    }
                    else if (selectMenu == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Number skies:{0}", id);
                        if (history[id].Count != 0)
                        {
                            foreach (var h in SkierTools.ListFormatingStrHistory(history[id]))
                            {
                                Console.WriteLine("\t" + h);
                            }
                        }
                        else Console.WriteLine("The skier has not trained yet.");

                    }
                    else if (selectMenu == 3)
                    {
                        exitThisMenu = true;
                        exit = true;
                       // Console.Clear();
                    }
                    else if (selectMenu == 4)
                    {
                        exitThisMenu = true;
                        exit = true;
                        exitApp = true;
                        // Console.Clear();
                    }
                }

            }

        }
        static void PrintAllTrain(Dictionary<uint, List<SkierModel>> history,ref bool exitApp)
        {
            Console.Clear();
            Console.WriteLine("History all skiers:");
            
            if(history.Count==0) Console.WriteLine("\t\tHistory empty");
            else
            {
                foreach(var key in history.Keys)
                {
                    Console.WriteLine("Skier №{0} :",key);
                    if(history[key].Count==0) Console.WriteLine("lazy person");
                    else
                    {
                        foreach (var node in SkierTools.ListFormatingStrHistory(history[key]))
                        {
                            Console.WriteLine("\t"+node);
                        }
                    }
                }

            }
            int selectMenu = 0;
            do
            {
                PrintMenu(new List<string>() { "1)Back", "2)Exit" });
                while (!int.TryParse(Console.ReadLine(), out selectMenu))
                {
                    ClearLine(1);
                    Console.Write("Selected (1-2):");
                }
            } while (!(selectMenu >= 1 && selectMenu <= 2));
            if (selectMenu == 2) exitApp = true;

        }
        static void PrintMenu(List<string> menu)
        {
           

            foreach (var m in menu)
            {
                Console.WriteLine(m);
            }
            Console.Write("Selected (1-{0}):",menu.Count);


        }
        static void ClearLine(int clear)
        {
            int cursor = Console.CursorTop - clear;
            Console.SetCursorPosition(0, cursor);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, cursor);
        }
    }
}
