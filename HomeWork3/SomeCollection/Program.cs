using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector<int> vector = new Vector<int>();
            Vector<int> v2 = new Vector<int>();
            v2.PushBack(11);
            v2.PushBack(12);
            v2.PushBack(13);
            v2.PushBack(14);
            vector.PushBack(1);
            vector.PushBack(2);
            vector.PushBack(3);
            vector.PushBack(4);
            vector.RemoveAt(0);
            vector.PushBack(5);
            vector.PushBack(6);
            vector.PushBack(7);
            vector.RemoveAt(4);
            vector.PushBack(8);
            foreach (var x in vector)
            {
                Console.WriteLine(x.ToString());
            }
            vector.RemoveAt(1, 2);
            Console.WriteLine();
            foreach (var x in vector)
            {
                Console.WriteLine(x.ToString());
            }
            vector.PushBack(v2);
            Console.WriteLine();
            foreach (var x in vector)
            {
                Console.WriteLine(x.ToString());
            }
            vector.PushFront(100);
            vector.PushFront(200);
            Console.WriteLine();
            foreach (var x in vector)
            {
                Console.WriteLine(x.ToString());
            }
            vector.PushFront(v2);
            Console.WriteLine();
            foreach (var x in vector)
            {
                Console.WriteLine(x.ToString());
            }
            Console.ReadLine();
        }
    }
}
