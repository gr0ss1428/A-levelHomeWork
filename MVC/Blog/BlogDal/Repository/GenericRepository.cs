using NPoco;
using NPoco.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDal.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        void CreateBulk(IEnumerable<T> items);
        void Create(T item);
        T FindById(int id);
        T FindById(string id);
        IQueryProviderWithIncludes<T> Get();
        void Remove(T item);
        void Remove(int id);
        void Update(T item);
        void Dispose();
        List<T> GetDataWithQuery(string query, params object[] args);
        List<T> GetDataWithQuery(Sql sql);
        List<T> GetProperty<T>(string query, params object[] args);
        Page<T> GetDataByPage(long page, long itemPerPage, Sql sql);
        ICollection<T> GetAll();
    }

    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly IDatabase _db;
        public GenericRepository()
        {
            _db = new Database("DBBLOG");
        }
        public void Create(T item)
        {
            _db.Insert(item);
           
        }

        public void CreateBulk(IEnumerable<T> items)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            return _db.SingleById<T>(id);
        }

        public T FindById(string id)
        {
            throw new NotImplementedException();
        }

        public IQueryProviderWithIncludes<T> Get()
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GetAll()
        {
            return _db.Fetch<T>();
        }

        public Page<T> GetDataByPage(long page, long itemPerPage, Sql sql)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDataWithQuery(string query, params object[] args)
        {
            throw new NotImplementedException();
        }

        public List<T> GetDataWithQuery(Sql sql)
        {
            throw new NotImplementedException();
        }

        public List<T1> GetProperty<T1>(string query, params object[] args)
        {
            throw new NotImplementedException();
        }

        public void Remove(T item)
        {
            _db.Delete(item);
        }

        public void Remove(int id)
        {
            _db.Delete<T>(id);
        }

        public void Update(T item)
        {
            _db.Update(item);
        }
    }
}
