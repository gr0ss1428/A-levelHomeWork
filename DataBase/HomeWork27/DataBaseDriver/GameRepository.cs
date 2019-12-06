using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDriver
{
    public class GamesRepository : IGamesRepository
    {
        public GamesRepository()
        {
        }

        public int Create(Games model)
        {
            Games games;
            int res;
            using (GameStoriesEntities sqlConnection = new GameStoriesEntities())
            {
                games = sqlConnection.Games.Add(model);
                res = sqlConnection.SaveChanges();
            }
            return res == 0 ? 0 : games.Id;
        }

        public int Delete(Games model)
        {
            int result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Games> GetAll()
        {
            List<Games> games;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                games = db.Games.ToList();
            }
            return games;
        }

        public Games GetById(int id)
        {
            Games result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                result = db.Games.Where(i => i.Id == id).FirstOrDefault();
            }
            return result;
        }

        public Games GetByName(string name)
        {
            Games result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                result = db.Games.Where(i => i.Name == name).FirstOrDefault();
            }
            return result;
        }

        public int Update(Games model)
        {
            int result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                Games games = db.Games.Where(i => i.Id == model.Id).FirstOrDefault();
                if (games == null) return 0;

                games = model;
                result = db.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Games> GetGamesByGenre(int GenresId)
        {
            List<Games> Games;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                Games = db.Games.Where(i => i.GenreId == GenresId).ToList();
            }
            return Games;
        }

        public IEnumerable<Games> GetGamesByPublisher(int PublishersId)
        {
            List<Games> Games;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                Games = db.Games.Where(i => i.PublicherId == PublishersId).ToList();
            }
            return Games;
        }
        public Games GetByNameYearPublishing(Games Games)
        {
            Games result;
            using (GameStoriesEntities db = new GameStoriesEntities())
            {
                result = db.Games.Where(i => i.Name == Games.Name).ToList().Where(x => x.YearPublishing == Games.YearPublishing).FirstOrDefault();
            }
            return result;
        }
    }
}
