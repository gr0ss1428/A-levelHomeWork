using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork18.FuelType;

namespace HomeWork18.Engine
{
    class EngineV6<TFuel> : Engine where TFuel:Fuel ,new ()
    {
        public EngineV6():base(new TFuel())
        {
            version = "V6";
        }

        public override void StartsUp()
        {
            Console.WriteLine("Brrr dum dum dum");
        }
    }
}
