using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDriver
{
    public class GenreRepository : IRepository<Genres>
    {
        public GenreRepository()
        {
        }

        public int Create(Genres model)
        {
            Genres genres;
            int res;
            using (GameStoriesEntities sqlConnection = new GameStoriesEntities())
            {
                genres = sqlConnection.Genres.Add(model);
                res = sqlConnection.SaveChanges();
            }
            return res == 0 ? 0 : genres.Id;
        }

        public Genres GetByName(string name)
        {
            Genres genres;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                genres = db.Genres.Where(i => i.Name == name).FirstOrDefault();
            }
            return genres;
        }

        public int Delete(Genres model)
        {
            int result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                result = db.SaveChanges();
            }
            return result;
        }

        public Genres GetById(int id)
        {
            Genres result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                result = db.Genres.Where(i => i.Id == id).FirstOrDefault();
            }
            return result;
        }

        public IEnumerable<Genres> GetAll()
        {
            List<Genres> genres;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                genres = db.Genres.ToList();
            }
            return genres;
        }

        public int Update(Genres model)
        {
            int result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                Genres genres = db.Genres.Where(i => i.Id == model.Id).FirstOrDefault();
                if (genres == null) return 0;

                genres = model;
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
