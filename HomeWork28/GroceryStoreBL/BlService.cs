using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStoreDAL;
using System.Data.Entity;

namespace GroceryStoreBL
{
    public class BlService
    {
        private Repository<DataContext> _Repository { get; }
        public BlService()
        {
            _Repository = new Repository<DataContext>(new DataContext());
        }

        public ProductBl AddProduct(ProductBl model)
        {
            Product mapRes = MapTools.MapToProductModel<ProductBl,Product>(model);
            if (mapRes.JewerlyType != null)
            {
                if (mapRes.JewerlyType.Name != string.Empty)
                {
                    var jType = _Repository.GetEntity<JewerlyType>().FirstOrDefault(j => j.Name == mapRes.JewerlyType.Name);
                    if (jType != null) mapRes.JewerlyType = jType;
                }
                else if (mapRes.JewerlyType_Id > 0)
                {
                    var jType = _Repository.GetEntity<JewerlyType>().FirstOrDefault(j => j.Id == mapRes.JewerlyType_Id);
                    if (jType != null) mapRes.JewerlyType = jType;
                }
            }
            mapRes = _Repository.Add(mapRes);

            return MapTools.MapToProductModel<Product,ProductBl>(mapRes);
        }

        public ProductBl GetById(int id)
        {
            var result = _Repository.GetEntity<Product>().Include(j => j.JewerlyType).Include(s => s.Stones).FirstOrDefault(p => p.Id == id);
            return MapTools.MapToProductModel<Product,ProductBl>(result);
        }

        public ICollection<ProductBl> GetByType(int Id)
        {
            var result = _Repository.GetEntity<Product>().Where(i => i.JewerlyType_Id == Id).Include(j => j.JewerlyType).Include(s => s.Stones);

            return MapTools.MapToProductCollection<Product,ProductBl>(result.ToList());
        }

        public ICollection<ProductBl> GetByStone(int count)
        {
            var result = _Repository.GetEntity<Product>().Include(j => j.JewerlyType).Include(s => s.Stones).Where(p=>p.Stones.Count==count);
            return MapTools.MapToProductCollection<Product, ProductBl>(result.ToList());
        }


    }
}
