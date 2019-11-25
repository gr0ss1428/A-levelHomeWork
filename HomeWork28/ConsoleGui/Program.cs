using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStorePL;

namespace ConsoleGui
{
    class Program
    {
        static void Main(string[] args)
        {

            Service st = new Service(10);
            ProductPl ring = new ProductPl()
            {
                JewerlyType = new JewerlyTypePl() { Name = "Ring" },
                Name = "Narya",
                Price = 100
            };
            List<StonePl> stones = new List<StonePl>();
            stones.Add(new StonePl() { Color = "Red", Price = 10, Name = "Ruby", Carat = 0.1M });
            stones.Add(new StonePl() { Color = "Blue", Price = 5, Name = "Topaz", Carat = 0.2M });
            ring.Stones = stones;
            st.Add(ref ring);

            ProductPl neck = new ProductPl()
            {
                JewerlyType = new JewerlyTypePl() { Name = "Necklace" },
                Name = "Viskonta",
                Price = 500
            };

            stones.Add(new StonePl() { Color = "Green", Price = 20, Name = "Emerald", Carat = 0.4M});
            stones.Add(new StonePl() { Color = "Yellow", Price = 25, Name = "Kunzite", Carat = 0.3M });

            neck.Stones = stones;
            st.Add(ref neck);
           
            UserProduct prod = st.GetProductById(1);
            ICollection<UserProduct> userProductsType = st.GetByType(1);
            
            foreach (var item in userProductsType)
            {
                Console.WriteLine($"id:{item.Id} Name:{item.Name} Stones:{item.Stones.Count} TypeName:{item.JewerlyType.Name}");
            }

            
            ICollection<UserProduct> userProductsStones = st.GetByStone(4);
            Console.WriteLine($"\nStone={userProductsStones.Count}");
            foreach (var item in userProductsStones)
            {
                Console.WriteLine($"id:{item.Id} Name:{item.Name} Stones:{item.Stones.Count} TypeName:{item.JewerlyType.Name}");
            }

            Console.ReadKey(true);
        }
    }
}
