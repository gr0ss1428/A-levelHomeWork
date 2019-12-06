using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork18.CarFactory
{
    class Mercedes<TEngine, TWheels> : CarFactory
        where TEngine : Engine.Engine, new()
        where TWheels : Wheels.Wheels, new()
    {
        public Mercedes(string model)
        {
           this.model = $"Mercedes ({model})";
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
