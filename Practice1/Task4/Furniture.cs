using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Furniture: Product
    {
        public string Manufacturer { get; }

        public Furniture(string manuf,string name, int count, double price) : base(name, count, price)
        {
            Manufacturer = manuf;
        }

        public override string GetInfo()
        {
            return $"Название:{Name}, Производитель:{Manufacturer}, Кол-во:{Count}, Цена:{Price}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj is Furniture)
            {
                Furniture m = obj as Furniture;
                return (Manufacturer == m.Manufacturer && Name == m.Name && Price == m.Price);
            }
            return false;
        }
    }
}
