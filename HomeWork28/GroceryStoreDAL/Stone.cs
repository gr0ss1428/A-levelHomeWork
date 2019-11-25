using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreDAL
{
   public class Stone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal Carat { get; set; }
        public decimal Price { get; set; }
        public ICollection<Product> Products { get; set; }

        public Stone()
        {
            Products = new List<Product>();
        }
    }
}
