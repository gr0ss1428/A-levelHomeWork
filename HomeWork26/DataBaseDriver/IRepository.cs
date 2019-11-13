using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDriver.Model;
namespace DataBaseDriver
{
    public interface IRepository<T>
    {
        int Create(T model);
        T GetByName(string name);
        int Update(T model);
        int Delete(T model);
        T GetById(int id);
        List<T> GetAll();
    }
}
