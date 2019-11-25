using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreDAL
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int JewerlyType_Id { get; set; }
        public JewerlyType JewerlyType { get; set; }
        public ICollection<Stone> Stones { get; set; }
        public decimal Price { get; set; }

        public Product()
        {
            Stones = new List<Stone>();
        }
    }
}
