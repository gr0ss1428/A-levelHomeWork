using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork18.FuelType;
using HomeWork18.CarFactory;
using HomeWork18.Engine;
using HomeWork18.Wheels;
namespace HomeWork18
{
    // С именами папок и базовых классов не красиво получилося
    class Program
    {
        static void Main(string[] args)
        {
            Car lada = new Car(new LadaFactory<EngineV6<Petrol>,Wheels15AllTerrain>("110"));
            Console.WriteLine(lada.ToString());
            lada.StartsUp();
            lada.Rolls();
            Console.WriteLine();

            Car mers = new Car(new Mercedes<EngineV8<Diesel>, Wheels15AllTerrain>("170D"));
            Console.WriteLine(mers.ToString());
            mers.StartsUp();
            mers.Rolls();
            Console.WriteLine();

            Car tesla = new Car(new Tesla<Electrical<Electricity>, Wheels15>("model S"));
            Console.WriteLine(tesla.ToString());
            tesla.StartsUp();
            tesla.Rolls();

            Console.ReadKey();
        }
    }
}
