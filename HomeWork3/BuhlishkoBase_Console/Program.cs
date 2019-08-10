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
            List<string> mainMenu = new List<string>() { "Добавить новый товар.", "Удалить товар.", "Добавить новый вид алкоголя.", "Показать склад.", "Изменить количество и цену.", "Выход." };

            int selectedMenu;

            do
            {



                selectedMenu = Menu("Добро пожаловать на склад Бухлишко", mainMenu);

                switch (selectedMenu)
                {
                    case 1:
                        addNewPosition();
                        break;
                    case 2:
                        delPosition();
                        break;
                    case 3:
                        addNewTypesAlcohol();
                        break;
                    case 4:
                        PrintBase();
                        break;
                    case 5:
                        EditPosition();
                        break;
                    case 6:
                        exit = true;
                        break;
                }

            } while (!exit);
        }
        static void EditPosition()
        {
            Console.Clear();
            bool exit = false;
            int selectType = 0;
            List<string> alcoholTypes;
            string types;
            uint newQuantity = 0;
            uint newPrice = 0;

            do
            {
                alcoholTypes = AlcoholBase.GetAlcoholTypesLst();
                for (int i = 0; i < alcoholTypes.Count; i++)
                {
                    alcoholTypes[i] = $"{alcoholTypes[i]} ({AlcoholBase.GetQuantityBottleInTypes(alcoholTypes[i])})";
                }
                alcoholTypes.Add("Назад.");
                selectType = Menu("Редактирование\nВыберите вид", alcoholTypes);
                if (selectType == alcoholTypes.Count)
                {
                    exit = true;
                }
                else
                {
                    types = AlcoholBase.GetAlcoholTypesLst()[selectType - 1];
                    var items = AlcoholBase.GetAlcoholItemsByTypesArr(types);
                    alcoholTypes.Clear();
                    if (items.Length != 0)
                    {
                        foreach (var bottle in items)
                        {
                            alcoholTypes.Add(AlcoholBase.GetItemStr(bottle));
                        }
                        alcoholTypes.Add("Назад.");
                        selectType = Menu("Выберите ", alcoholTypes);
                        Console.Clear();
                        Console.WriteLine(AlcoholBase.GetItemStr(items[selectType - 1]));
                        Console.Write("Введите новое количество:");
                        while(!uint.TryParse(Console.ReadLine(),out newQuantity))
                        {
                            ClearLine(1);
                            Console.Write("Введите новое количество:");
                        }
                        Console.Write("Введите новую цену:");
                        while (!uint.TryParse(Console.ReadLine(), out newPrice))
                        {
                            ClearLine(1);
                            Console.Write("Введите новую цену:");
                        }

                        items[selectType - 1].NewPrise(newPrice);
                        items[selectType - 1].NewValueQuantity(newQuantity);
                        addRunMenu(ref exit, "Другой выбор");
                        //AlcoholBase.EditPosition(types,selectType, newQuantity, newPrice);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Список пуст");
                        addRunMenu(ref exit, "Другой выбор");
                    }
                }

            } while (!exit);
        }
        static void delPosition()
        {
            Console.Clear();
            bool success = false;
            int selectType = 0;
            List<string> alcoholTypes;
            string types;
            do
            {
                alcoholTypes = AlcoholBase.GetAlcoholTypesLst();
                for (int i = 0; i < alcoholTypes.Count; i++)
                {
                    alcoholTypes[i] = $"{alcoholTypes[i]} ({AlcoholBase.GetQuantityBottleInTypes(alcoholTypes[i])})";
                }
                alcoholTypes.Add("Назад.");
                selectType = Menu("Удаление\nВыберите вид", alcoholTypes);
                if (selectType == alcoholTypes.Count)
                {
                    success = true;
                }
                else
                {
                    types = AlcoholBase.GetAlcoholTypesLst()[selectType - 1];
                    var items = AlcoholBase.GetAlcoholItemsByTypesArr(types);
                    alcoholTypes.Clear();
                    if (items.Length != 0)
                    {
                        foreach (var bottle in items)
                        {
                            alcoholTypes.Add(AlcoholBase.GetItemStr(bottle));
                        }
                        alcoholTypes.Add("Удалить все.");
                        alcoholTypes.Add("Назад.");
                        selectType = Menu("Выберите ", alcoholTypes);
                        if (selectType < alcoholTypes.Count - 1)
                        {
                            Console.WriteLine();
                            addRunMenu(ref success, "Вы уверены?");
                            if (!success)
                            {
                                ClearLine(1);
                                if (AlcoholBase.RemoveAlcohoBottleinBase(types, items[selectType - 1])) Console.WriteLine($"Успешно удалено.");
                                else Console.WriteLine($"Удалить не удалось.");
                            }
                            addRunMenu(ref success, "Удалить ещё");
                        }
                        else if (selectType == alcoholTypes.Count - 1)
                        {
                            Console.WriteLine();
                            addRunMenu(ref success, "Вы уверены?");
                            if (!success)
                            {
                                ClearLine(1);
                                if (AlcoholBase.RemoveAlcohoBottleAll(types)) Console.WriteLine($"Успешно удалено.");
                                else Console.WriteLine($"Удалить не удалось.");
                            }
                            addRunMenu(ref success, "Удалить ещё");
                        }

                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Список пуст");
                        addRunMenu(ref success, "Другой выбор");
                    }


                }

            } while (!success);
        }

        static void addNewPosition()
        {
            Console.Clear();
            bool success = false;
            int selectType = 0;
            List<string> alcoholTypes;
            do
            {
                alcoholTypes = AlcoholBase.GetAlcoholTypesLst();
                for (int i = 0; i < alcoholTypes.Count; i++)
                {
                    alcoholTypes[i] = $"{alcoholTypes[i]} ({AlcoholBase.GetQuantityBottleInTypes(alcoholTypes[i])})";
                }
                alcoholTypes.Add("Другой тип.");
                alcoholTypes.Add("Назад.");
                selectType = Menu("Добавление\nВыберите вид", alcoholTypes);
                if (selectType == alcoholTypes.Count)
                {
                    success = true;
                }
                else if (selectType == alcoholTypes.Count - 1)
                {
                    AlcoholBase.AddNewBottle(newBotlle());
                    Console.WriteLine($"Успешно добавлено.");
                    addRunMenu(ref success, "Добавить ещё");
                }
                else
                {
                    AlcoholBase.AddNewBottle(newBotlle(AlcoholBase.GetAlcoholTypesLst().ToArray()[selectType - 1]));
                    Console.WriteLine($"Успешно добавлено.");
                    addRunMenu(ref success, "Добавить ещё");
                }

            } while (!success);
        }
        static void PrintBase()
        {
            Console.Clear();
            List<string> lstType = AlcoholBase.GetAlcoholTypesLst();
            int countType = 1;


            foreach (var m in lstType)
            {
                Console.WriteLine($"{countType} {m}");
                var alcohol = AlcoholBase.GetAlcoholItemsByTypesArr(m);
                int countItems = 1;
                uint sum = 0;
                if (alcohol.Length != 0)
                {
                    sum = 0;
                    foreach (var bottle in alcohol)
                    {
                        Console.WriteLine($"  {countItems} {AlcoholBase.GetItemStr(bottle)}");
                        sum += bottle.PrisePosition;
                        countItems++;
                    }
                    Console.WriteLine($"\nОбщая сумма позиций:{sum}");
                }
                else Console.WriteLine("  Нет товара.");
                Console.WriteLine();
                countType++;

            }
            Console.WriteLine("\n\n\nНажмите любую кнопку для возврата назад.");
            Console.ReadKey();


        }

        static AlcoholBottle newBotlle(string nTypes = null)
        {

            string nName;
            string nManufacturer;
            double nAbvPercent;
            uint nKCal;
            uint nQuantity;
            uint nVolume;
            uint nPrice;


            Console.Clear();
            if (nTypes == null)
            {
                Console.Write("Введите вид:");
                nTypes = Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Вид:{nTypes}");
            }
            Console.Write("Введите Название:");
            nName = Console.ReadLine();
            Console.Write("Введите Производителя:");
            nManufacturer = Console.ReadLine();
            Console.Write("Введите содержание спирта %:");
            while (!double.TryParse(Console.ReadLine(), out nAbvPercent))
            {
                ClearLine(1);
                Console.Write("Введите содержание спирта %:");

            }
            Console.Write("Введите ккал:");
            while (!uint.TryParse(Console.ReadLine(), out nKCal))
            {
                ClearLine(1);
                Console.Write("Введите Ккал:");

            }
            Console.Write("Введите объем млл:");
            while (!uint.TryParse(Console.ReadLine(), out nVolume))
            {
                ClearLine(1);
                Console.Write("Введите объем млл:");

            }
            Console.Write("Введите объем количество:");
            while (!uint.TryParse(Console.ReadLine(), out nQuantity))
            {
                ClearLine(1);
                Console.Write("Введите объем количество:");

            }
            Console.Write("Введите объем цену:");
            while (!uint.TryParse(Console.ReadLine(), out nPrice))
            {
                ClearLine(1);
                Console.Write("Введите объем цену:");

            }


            return new AlcoholBottle(nTypes, nName, nManufacturer, nAbvPercent, nKCal, nVolume, nQuantity, nPrice); ;
        }
        static void addNewTypesAlcohol()
        {
            string typesAlc;
            bool success = false;
            do
            {
                Console.Clear();
                Console.Write("Укажите новый вид алкоголя: ");
                typesAlc = Console.ReadLine();
                success = AlcoholBase.newAlcoholTypes(typesAlc);
                if (success) Console.WriteLine("Новый вид успешно добавлен.");
                else Console.WriteLine("Такой вид уже есть.");
                addRunMenu(ref success, "Добавить ещё");

            } while (!success);



        }
        static void addRunMenu(ref bool exit, string messgae)
        {
            Console.Write($"{messgae} (y):");
            string nextRun = Console.ReadLine();
            if (nextRun == "y" || nextRun == "Y" || nextRun == "н" || nextRun == "Н")
            {
                exit = false;
            }
            else
            {
                exit = true;
            }
        }

        static int Menu(string message, List<string> menu)
        {

            int selectType = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(message);
                int count = 1;
                foreach (var m in menu)
                {
                    Console.WriteLine($"{count}){m}");
                    count++;
                }
                Console.Write("Selected (1-{0}):", menu.Count);

                while (!int.TryParse(Console.ReadLine(), out selectType))
                {
                    ClearLine(1);
                    Console.Write($"Selected (1-{menu.Count}):");
                }

            } while (!(selectType >= 1 && selectType <= menu.Count));
            return selectType;
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
