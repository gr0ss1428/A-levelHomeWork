using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreBL
{
   public class StoneBl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Carat { get; set; }
        public decimal Price { get; set; }
        public ICollection<ProductBl> Products { get; set; }

        public StoneBl()
        {
            Products = new List<ProductBl>();
        }
    }
}
