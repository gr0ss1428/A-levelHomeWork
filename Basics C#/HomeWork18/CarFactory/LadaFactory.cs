using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork18.Engine;
using HomeWork18.Wheels;

namespace HomeWork18.CarFactory
{
    class LadaFactory<TEngine, TWheels> : CarFactory
        where TEngine : Engine.Engine, new()
        where TWheels : Wheels.Wheels, new()
    {
        public LadaFactory(string model)
        {
            this.model = $"Lada ({model})";
        }

        public override Engine.Engine CreateEngine()
        {
            return new TEngine();
        }

        public override Wheels.Wheels CreateWheels()
        {
            return new TWheels();
        }
    }
}
