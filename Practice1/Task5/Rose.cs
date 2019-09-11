using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Rose:Flower
    {
        private string typeFlower;
        public override string Type
        {
            get
            {
                return typeFlower;
            }
        }

        public Rose(string type, double price, int count=1):base(price,count)
        {
            typeFlower = type;
        }
    }
}
