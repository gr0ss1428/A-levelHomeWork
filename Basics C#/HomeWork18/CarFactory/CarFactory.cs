using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeWork18.Engine;
using HomeWork18.Wheels;

namespace HomeWork18.CarFactory
{
    abstract class CarFactory
    {
        protected string model;
        public string Model { get => model; }
        
        public abstract Engine.Engine CreateEngine();

        public abstract Wheels.Wheels CreateWheels();
    }
}
