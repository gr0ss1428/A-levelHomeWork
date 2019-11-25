using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStorePL
{
   public class StonePl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Carat { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductPl> Products { get; set; }

        public StonePl()
        {
            Products = new List<ProductPl>();
        }
    }
}
