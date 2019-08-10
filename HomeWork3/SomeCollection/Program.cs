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
            v2.Add(11);
            v2.Add(12);
            v2.Add(13);
            v2.Add(14);
            vector.Add(1);
            vector.Add(2);
            vector.Add(3);
            vector.Add(4);
            vector.RemoveAt(0);
            vector.Add(5);
            vector.Add(6);
            vector.Add(7);
            vector.RemoveAt(4);
            vector.Add(8);
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
            vector.Add(v2);
            Console.WriteLine();
            foreach (var x in vector)
            {
                Console.WriteLine(x.ToString());
            }
            Console.ReadLine();
        }
    }
}
