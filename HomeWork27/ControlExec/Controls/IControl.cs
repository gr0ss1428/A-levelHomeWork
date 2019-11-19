using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlExec.Controls
{
    public interface IControl<T> where T : class
    {
        ExeResult Create(T model);
        ExeResult Delete(T model);
        IEnumerable<T> GetAll();
        ExeResult GetById(int id, out T model);
        ExeResult GetByName(string name, out T model);
        ExeResult Update(T model);
    }
}
