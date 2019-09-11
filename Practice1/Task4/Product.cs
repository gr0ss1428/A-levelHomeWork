using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Task4
{
    public abstract class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }

        public Product(string name, int count, double price)
        {
            Name = name;
            Price = price;
            Count = count;
        }

        public abstract string GetInfo();

    }
}
