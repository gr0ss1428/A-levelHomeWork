using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        /*
         * 
         * Тут полная дичь
         * знаю что это не делается на событиях но мы проходили события
         * 
         */
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            generator.StartGeniration();

            Collector collector1 = new Collector(100,"Collector1", generator);
            collector1.Subscribe();
          
            Console.ReadKey();
        }
    }
}
