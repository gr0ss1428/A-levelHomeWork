using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork17
{
    class Car
    {
        public string Color { get; }
        public int Number { get; }
        public string Model { get; }
        
        public Car(string color, string model, int number)
        {
            Color = color;
            Number = number;
            Model = model;
        }
        
        public override string ToString()
        {
            return $"Model: {Model}, Color: {Color}, Number: {Number}";
        }
    }
}
