using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomCollection<Car> collection = new CustomCollection<Car>();
            for (int i = 0; i < 10; i++)
            {
                collection.PushBack(new Car("Black", "Lada", i + 1));
            }
            collection.PushFront(new Car("White", "Moskvich", 100));
            //collection.RemoveAt(100);
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
