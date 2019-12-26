using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BlogBl.BlModel;
using BlogMvc.Models;

namespace BlogMvc.Tools
{
    class MapperTools
    {
        public static TDestination MapTo<TSource, TDestination>(TSource modelSource) where TDestination : class where TSource : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<TSource, TDestination>(modelSource);
        }

        public static ICollection<TDestination> MapToCollection<TSource, TDestination>(ICollection<TSource> modelSource) where TDestination : class where TSource : class
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<ICollection<TSource>, ICollection<TDestination>>(modelSource);
        }

    }
}
