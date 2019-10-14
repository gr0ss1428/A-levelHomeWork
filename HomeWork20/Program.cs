using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork20
{
    class Program
    {
        static void Main(string[] args)
        {
            First();
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
            List<int> numberLst = FillList(10, -10, 10);

            foreach (var n in numberLst)
                Console.Write($"{n} ");

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
            if (first == null) Console.Write($"\nFirst positiv=null");
            else Console.Write($"\nFirst positiv={first}");

            if (lastNegative == 0) Console.WriteLine($", Last negative=null");
            else Console.WriteLine($", Last negative={lastNegative}");
            Console.WriteLine();

            string[] arrString = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            char symbol = 's';

            foreach (var n in arrString)
                Console.Write($"{n} ");

            var str =string.Join(" ", arrString.Where(s => s.ToUpperInvariant().First().ToString().Contains( symbol.ToString().ToUpperInvariant())));
            Console.WriteLine($"\nString at first char {symbol} : {str}");
        }

        static List<int> FillList(int count, int min, int max)
        {
            List<int> tmpList = new List<int>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
                tmpList.Add(random.Next(min, max + 1));
            return tmpList;
        }
    }
}
