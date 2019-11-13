using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlExec
{
   public interface IControl<T>
    {
        ExeResult Create(T model);
        ExeResult Delete(T model);
        IEnumerable<T> GetAll();
        ExeResult GetById(int id, out T model);
        ExeResult GetByName(string name, out T model);
        ExeResult Update(T model);
    }
}
