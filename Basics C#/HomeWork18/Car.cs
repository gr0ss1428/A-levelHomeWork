using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork18.Engine;
using HomeWork18.Wheels;
using HomeWork18.CarFactory;

namespace HomeWork18
{
    class Car
    {
        private string model;
        private Engine.Engine engine;
        private Wheels.Wheels wheels;

        public Car(CarFactory.CarFactory factory)
        {
            model = factory.Model;
            engine = factory.CreateEngine();
            wheels = factory.CreateWheels();
        }

        public void StartsUp()
        {
            engine.StartsUp();
        }

        public void Rolls()
        {
            wheels.Rolls();
        }

        public override string ToString()
        {
            return $"Model {model}, Engine {engine.Version} fuel {engine.TypeFuel.TypeFuel}, Wheels size {wheels.GetSize}";
        }
    }
}
