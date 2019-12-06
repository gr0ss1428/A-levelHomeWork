using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryStoreDAL
{
    public class Repository<TDbContext> where TDbContext : DbContext
    {
        private TDbContext _Context { get; }

        public Repository(TDbContext context)
        {
            _Context = context;
        }

        public TEntity Add<TEntity>(TEntity model) where TEntity : class
        {
            TEntity result = _Context.Set<TEntity>().Add(model);
            int changes = _Context.SaveChanges();
            return changes == 0 ? null : result;
        }

        public IQueryable<TEntity> GetEntity<TEntity>() where TEntity : class
        {
            return _Context.Set<TEntity>();
        }

    }
}
