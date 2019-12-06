using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStoreBL;
using AutoMapper;

namespace GroceryStorePL
{
    internal class MapTools
    {
        internal static decimal GetPrice(ProductBl product)
        {
            decimal stonrePrice = 0;
            foreach (var p in product.Stones)
            {
                stonrePrice += p.Price;
            }
            return stonrePrice + product.Price;
        }

        internal static DProduct MapToProductModel<SProduct, DProduct>(SProduct model)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductPl, ProductBl>();
                cfg.CreateMap<JewerlyTypePl, JewerlyTypeBl>();
                cfg.CreateMap<StonePl, StoneBl>();

                cfg.CreateMap<ProductBl, ProductPl>();
                cfg.CreateMap<JewerlyTypeBl, JewerlyTypePl>();
                cfg.CreateMap<StoneBl, StonePl>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<SProduct, DProduct>(model);
        }

        internal static UserProduct MapToUserProduct(ProductBl model)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductBl, UserProduct>();
                cfg.CreateMap<JewerlyTypeBl, JewerlyTypePl>().ForMember(j => j.Products, o => o.Ignore());
                cfg.CreateMap<StoneBl, UserStone>();
            });
            IMapper iMapper = config.CreateMapper();
            var res = iMapper.Map<ProductBl, UserProduct>(model);
            if (res != null)
            {
                res.JewerlyType.Products = null;
                res.Price = GetPrice(model);
            }
            return res;
        }
    }
}
