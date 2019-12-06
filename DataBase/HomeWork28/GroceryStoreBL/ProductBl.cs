using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreBL
{
    public class ProductBl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int JewerlyType_Id { get; set; }
        public JewerlyTypeBl JewerlyType { get; set; }
        public ICollection<StoneBl> Stones { get; set; }
        public decimal Price { get; set; }

        public ProductBl()
        {
            Stones = new List<StoneBl>();
        }
    }
}
