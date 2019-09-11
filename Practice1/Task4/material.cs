using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Material : Product
    {
        public double Height { get; }
        public double Width { get; }

        public Material(double width, double height, string name, int count, double price) : base(name, count, price)
        {
            Height = height;
            Width = width;
        }

        public override string GetInfo()
        {
            return $"Название:{Name}, Ширина:{Width}, Высота:{Height}, Кол-во:{Count}, Цена:{Price}\n";
        }

        public override bool Equals(object obj)
        {
            if (obj is Material)
            {
                Material m = obj as Material;
                return (Height == m.Height && Width == m.Width && Name == m.Name && Price == m.Price);
            }
            return false;
        }
    }
}
