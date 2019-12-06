using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductStock
{
    public class SProduct : BaseProduct
    {
        public string Name { get; }
        public int Price { get; set; }
        public double Volume { get; set; }
        public SProduct(string name,int price,double volume,int validDay, DateTime? dt = null) : base(validDay, dt)
        {
            Name = name;
            Price = price;
            Volume = volume;
        }
    }
}
