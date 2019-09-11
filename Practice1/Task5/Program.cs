using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    public interface IDisplay
    {
        void PrintInfo(string message);
    }

    public class Display:IDisplay
    {
        public void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IBouquet bouquet = new Bouquet(new Display());
            bouquet.Add(new Rose("Rose", 1,5));
            bouquet.Add(new Tulip("Tulip", 2));
            bouquet.Add(new Rose("Rose", 1));
            bouquet.Add(new Clove("Clove",10,4));
            bouquet.Add(new Tulip("Tulip", 5));

            bouquet.GetInfo();
            Console.ReadKey();
        }
    }
}
