using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreDAL
{
    public class JewerlyType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

        public JewerlyType()
        {
            Products = new List<Product>();
        }
    }
}
