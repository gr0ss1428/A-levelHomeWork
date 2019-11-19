using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ControlExec.Controls
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
            if (result != 0) return new ExeResult(new List<string>());
            else return new ExeResult(new List<string>() { Errormessage });
        }
    }
}
