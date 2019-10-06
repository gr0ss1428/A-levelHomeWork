using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork18.FuelType;
namespace HomeWork18.Engine
{
    class Electrical<TFuel> : Engine where TFuel : Electricity, new()
    {
        public Electrical() : base(new TFuel())
        {
            version = "Electrical";
        }

        public override void StartsUp()
        {
            Console.WriteLine("Rumbling like a kitten");
        }
    }
}
