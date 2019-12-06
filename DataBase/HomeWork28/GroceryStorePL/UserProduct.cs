using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStorePL
{
    public class UserProduct : ProductPl
    {
        new public ICollection<UserStone> Stones { get; set; }

        public UserProduct()
        {
            Stones = new List<UserStone>();
        }
    }
}
