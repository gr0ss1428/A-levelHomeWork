using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Clove:Flower
    {
        private string typeFlower;

        public override string Type
        {
            get
            {
                return typeFlower;
            }
        }

        public Clove(string type, double price, int count = 1) : base(price, count)
        {
            typeFlower = type;
        }
    }
}
