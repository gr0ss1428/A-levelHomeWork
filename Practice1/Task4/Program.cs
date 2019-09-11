using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
   public interface IDisplay
    {
        void Print(string message);
    }

    public class Printing:IDisplay
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IBase mainBase = new Base(new Printing());
            mainBase.Add(new Material(100, 200, "Plywood", 100, 500));
            mainBase.Add(new Furniture("IKEA", "Sofa", 40, 8000));
            mainBase.Add(new Material(100, 20, "Timber", 50, 100));
            mainBase.Add(new Furniture("IKEA", "Stool", 200, 50));

            mainBase.PrintAll();
            mainBase.SortFurnitureFirst();
            mainBase.Add(new Furniture("IKEA", "Stool", 200, 50));
            mainBase.PrintAll();
            mainBase.Remove(new Furniture("IKEA", "Stool", 50, 50));
            mainBase.PrintAll();

            Console.ReadKey();
            
        }
    }
}
