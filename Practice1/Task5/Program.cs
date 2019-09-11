using System;

namespace Task5
{
    public interface IDisplay
    {
        void PrintInfo(string message);
    }

    public class Display : IDisplay
    {
        public void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Bouquet bouquet = new Bouquet(new Display());
            bouquet.Add(new Rose("Rose", 1, 5));
            bouquet.Add(new Tulip("Tulip", 2));
            bouquet.Add(new Rose("Rose", 1));
            bouquet.Add(new Clove("Clove", 10, 4));
            bouquet.Add(new Tulip("Tulip", 5));
            var fl = new Clove("Clove", 10, 6);
            bouquet = bouquet + fl;

            bouquet.GetInfo();
            Console.ReadKey();
        }
    }
}