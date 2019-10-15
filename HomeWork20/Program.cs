using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork20
{
    class Provider
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            First();

            Second();

            Three();
            Console.ReadKey();
        }

        /*
        First, FirstOrDefault, last, LastOrDefault, Single
        Набор целых чисел (List). Показать первый положительный и последний отрицательный
        Расширим предыдущую задачу. Вернуть null в случае отсутствия одного из искомых элементов.
        Есть некоторый символ и есть набор строк. Если в наборе есть один элемент начинающийся с С, то показать его. Пустая строка - если таких элементов нет. Если таких строк несколько, то вернуть строку из них.
        Усложняем задание
        обработать ситуацию с ошибкой в предыдущем примере (когда она будет и почему)
        Реестр символа должен быть не важен.
        */
        static void First()
        {
            Console.WriteLine("First");
            List<int> numberLst = FillList(10, -10, 10);
            Console.WriteLine("Task 1)---------");
            PrintList(numberLst);

            Func<int?> firstPositiv = () =>
            {
                try
                {
                    return numberLst.First(i => i >= 0);
                }
                catch (InvalidOperationException)
                {
                    return null;
                }
            };
            var lastNegative = numberLst.LastOrDefault(i => i < 0);

            var first = firstPositiv();
            if (first == null) Console.Write($"First positiv=null");
            else Console.Write($"First positiv={first}");

            if (lastNegative == 0) Console.WriteLine($", Last negative=null");
            else Console.WriteLine($", Last negative={lastNegative}");
            Console.WriteLine();

            Console.WriteLine("Task 2)---------");
            List<string> lstStrings = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            char symbol = 's';

            PrintList(lstStrings);

            var str = string.Join(" ", lstStrings.Where(s => s.ToUpperInvariant().First().ToString().Contains(symbol.ToString().ToUpperInvariant())));
            Console.WriteLine($"String at first char {symbol} : {str}");
            Console.WriteLine();
        }

        /*
        Where, Distinct
        Есть набор чисел. Вернем все четные, удалим повторы
        Reverse
        Есть число D и лист целых чисел. Найти первый элемент, больший чем D. Вернуть все четные и положительные числа, поменяв их порядок следования
        Concat, DefaultIfEmpty
        Есть число. Есть два листа чисел. Сделать новый лист из элементов больших чем число (из первой последовательности) и элементов меньших числа (из второй). Если таких элементов нет - подставить некоторую константу.
        */
        static void Second()
        {
            Console.WriteLine("Second");
            List<int> numbers = FillList(10, 0, 10);

            Console.WriteLine("Task 1)---------");
            PrintList(numbers);
            var result = numbers.Where(i => i % 2 == 0 && i != 0).Distinct();
            PrintList(result);
            Console.WriteLine();

            Console.WriteLine("Task 2)---------");
            numbers = FillList(10, -10, 10);
            PrintList(numbers);
            int d = 5;
            var num = numbers.FirstOrDefault(i => i > d);
            if (num == 0) Console.WriteLine("Does not contain ");
            else Console.WriteLine($"First >{d} = {num}");
            Console.WriteLine();

            Console.WriteLine("Task 3)---------");
            PrintList(numbers);
            var result2 = numbers.Where(i => i > 0 && i % 2 == 0).Reverse();
            if (result2.Count() == 0) Console.WriteLine("Does not contain ");
            else PrintList(result2);
            Console.WriteLine();

            Console.WriteLine("Task 4)---------");
            List<int> lstNumbers1 = FillList(10, -5, 10);
            List<int> lstNumbers2 = FillList(10, -10, 5);
            int number = 5;
            PrintList(lstNumbers1);
            PrintList(lstNumbers2);
            Console.WriteLine(number);

            List<int> lstResult = new List<int>();
            lstResult.AddRange(lstNumbers1.Where(i => i > number).DefaultIfEmpty(-100));
            //разделитель между коллекциями
            lstResult.Add(1000);
            lstResult.AddRange(lstNumbers2.Where(i => i < number).DefaultIfEmpty(-100));
            PrintList(lstResult);
            Console.WriteLine();
        }

        /*
        GroupBy, ToDictionary
        Есть поставщики, и есть сумма за их поставки. Каждая поставка имеет дату.
        string Name double Amount DateTime Date
        сделать группированную коллекцию типа
        Name (key)
        value
         Общая сумма поставок
         Дата первой поставки
         Дата последней поставки
        Не показывать "пустых" поставщиков
        Не показывать "пустых" поставщиков на этапе работе с исходной коллекцией
        */
        static void Three()
        {
            Console.WriteLine("Three");
            List<Provider> lstProvider = new List<Provider>();
            lstProvider.Add(new Provider() { Name = "FirstCo", Amount = 100, Date = DateTime.Now.AddDays(1) });
            lstProvider.Add(new Provider() { Name = "FirstCo", Amount = 200, Date = DateTime.Now.AddDays(2) });
            lstProvider.Add(new Provider() { Name = "FirstCo", Amount = 300, Date = DateTime.Now.AddDays(3) });
            lstProvider.Add(new Provider() { Name = "SecondCo", Amount = 300, Date = DateTime.Now.AddDays(1) });
            lstProvider.Add(new Provider() { Name = "SecondCo", Amount = 300, Date = DateTime.Now.AddDays(3) });
            lstProvider.Add(new Provider() { Name = "SecondCo", Amount = 300, Date = DateTime.Now.AddDays(3) });
            lstProvider.Add(new Provider() { Name = "ThreeCo" });
            lstProvider.Add(new Provider() { Name = "FourCo" });
            var resultDictionary = (from item in lstProvider
                                    group item by item.Name).ToDictionary(k => k.Key, v => new
                                    {
                                        Sum = lstProvider.Where(i => i.Name == v.Key).Sum(s => s.Amount),
                                        First = lstProvider.Where(i => i.Name == v.Key).Min(d => d.Date),
                                        Last = lstProvider.Where(i => i.Name == v.Key).Max(d => d.Date)
                                    });

            foreach (var key in resultDictionary.Keys)
            {
                if (resultDictionary[key].Sum != 0)
                {
                    Console.WriteLine(key);
                    Console.Write($" Sum= {resultDictionary[key].Sum}, First supply:{resultDictionary[key].First}, Last supply:{resultDictionary[key].Last}");
                    Console.WriteLine();
                }
            }
        }

        static List<int> FillList(int count, int min, int max)
        {
            List<int> tmpList = new List<int>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
                tmpList.Add(random.Next(min, max + 1));
            return tmpList;
        }

        static void PrintList<T>(IEnumerable<T> lst)
        {
            foreach (var n in lst)
                Console.Write($"{n} ");
            Console.WriteLine();
        }
    }
}
