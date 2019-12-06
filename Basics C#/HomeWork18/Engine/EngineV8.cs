using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork18.FuelType;
namespace HomeWork18.Engine
{
    class EngineV8<TFuel> : Engine where TFuel : Fuel, new()
    {
        public EngineV8() : base(new TFuel())
        {
            version = "V8";
        }

        public override void StartsUp()
        {
            Console.WriteLine("Brrr, i am V8");
        }
    }
}
