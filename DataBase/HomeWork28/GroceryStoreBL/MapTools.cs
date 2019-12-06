using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryStoreDAL;
using AutoMapper;
using AutoMapper.Mappers;

namespace GroceryStoreBL
{
    public class MapTools
    {
        public static TDestination MapTo<TSource, TDestination>(TSource modelFrom) where TDestination : class where TSource : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<TSource, TDestination>(modelFrom);
        }

        public static ICollection<TDestination> MapToCollection<TSource, TDestination>(ICollection<TSource> modelColl) where TDestination : class where TSource : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<ICollection<TSource>, ICollection<TDestination>>(modelColl);
        }

        public static TDestination MapToProductModel<TSource, TDestination>(TSource model) where TSource : class where TDestination : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductBl, Product>();
                cfg.CreateMap<JewerlyTypeBl, JewerlyType>();
                cfg.CreateMap<StoneBl, Stone>();

                cfg.CreateMap<Product, ProductBl>();
                cfg.CreateMap<JewerlyType, JewerlyTypeBl>();
                cfg.CreateMap<Stone, StoneBl>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<TSource, TDestination>(model);
        }

        public static ICollection<TDestination> MapToProductCollection<TSource, TDestination>(List<TSource> model) where TDestination : class where TSource : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductBl, Product>();
                cfg.CreateMap<JewerlyTypeBl, JewerlyType>();
                cfg.CreateMap<StoneBl, Stone>();

                cfg.CreateMap<Product, ProductBl>();
                cfg.CreateMap<JewerlyType, JewerlyTypeBl>();
                cfg.CreateMap<Stone, StoneBl>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<ICollection<TSource>, ICollection<TDestination>>(model);
        }
    }
}
