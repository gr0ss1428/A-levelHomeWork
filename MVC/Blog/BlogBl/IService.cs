using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogBl
{
   public interface IService<T> where T:class
    {
        T GetById(int id);
        ICollection<T> GetAll();
        void Update(T model);
        void Add(T model);
        void Delete(int id);
        void Delete(T model);
    }
}
