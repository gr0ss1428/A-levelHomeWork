using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace ControlExec
{
    internal static class ControlTools
    {
        internal static T MapTo<F, T>(F modelFrom)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<F, T>();
            });
            IMapper iMapper = config.CreateMapper();
            return iMapper.Map<F, T>(modelFrom);
        }

        internal static ExeResult DbExec<T>(Func<T, int> func, T model, string Errormessage)
        {
            var result = func(model);
            if (result != 0) return new ExeResult(false, null);
            else return new ExeResult(true, new List<string>() { Errormessage });
        }
    }
}
