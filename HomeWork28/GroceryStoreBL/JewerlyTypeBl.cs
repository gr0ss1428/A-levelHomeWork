using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreBL
{
    public class JewerlyTypeBl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductBl> Products { get; set; }

        public JewerlyTypeBl()
        {
            Products = new List<ProductBl>();
        }
    }
}
