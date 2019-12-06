using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork18.CarFactory
{

    class Tesla<TEngine, TWheels> : CarFactory
     // Вот тут не совсем красиво мне надо ограничеть мотор но и при этом ограничеьб и топливо не передавать же тут ещё и топливо в параметрах
        where TEngine : Engine.Electrical<FuelType.Electricity>, new()
        where TWheels : Wheels.Wheels, new()
    {
        public Tesla(string model)
        {
            this.model = $"Tesla ({model})";
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
