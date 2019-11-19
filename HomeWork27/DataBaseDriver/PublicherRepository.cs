using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDriver
{
    public class PublicherRepository : IRepository<Publishers>
    {


        public PublicherRepository()
        {

        }

        public int Create(Publishers model)
        {
            Publishers publishers;
            int res;
            using (GameStoriesEntities sqlConnection = new GameStoriesEntities())
            {
                publishers = sqlConnection.Publishers.Add(model);
                res = sqlConnection.SaveChanges();
            }
            return res == 0 ? 0 : publishers.Id;
        }

        public int Delete(Publishers model)
        {
            int result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Publishers> GetAll()
        {
            List<Publishers> publishers;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                publishers = db.Publishers.ToList();
            }
            return publishers;
        }

        public Publishers GetById(int id)
        {
            Publishers result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                result = db.Publishers.Where(i => i.Id == id).FirstOrDefault();
            }
            return result;
        }

        public Publishers GetByName(string name)
        {
            Publishers publishers;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                publishers = db.Publishers.Where(i => i.Name == name).FirstOrDefault();
            }
            return publishers;
        }

        public int Update(Publishers model)
        {
            int result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                Publishers publisher = db.Publishers.Where(i => i.Id == model.Id).FirstOrDefault();
                if (publisher == null) return 0;

                publisher = model;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
