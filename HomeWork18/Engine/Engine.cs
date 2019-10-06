using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork18.FuelType;

namespace HomeWork18.Engine
{
    abstract class Engine
    {
        protected string version;
        protected Fuel fuel;
        public string Version { get => version; }
        public Fuel TypeFuel { get => fuel; }

        public Engine(Fuel fuel)
        {
            this.fuel = fuel;
        }

        public abstract void StartsUp();
    }
}
