using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStorePL
{
    public class ProductPl
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int JewerlyType_Id { get; set; }
        public JewerlyTypePl JewerlyType { get; set; }
        public ICollection<StonePl> Stones { get; set; }
        public decimal Price { get; set; }

        public ProductPl()
        {
            Stones = new List<StonePl>();
        }
    }
}
