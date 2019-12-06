using System.Collections.Generic;

namespace DataBaseDriver
{
    public interface IGamesRepository
    {
        int Create(Games model);
        int Delete(Games model);
        IEnumerable<Games> GetAll();
        Games GetById(int id);
        Games GetByName(string name);
        Games GetByNameYearPublishing(Games Games);
        IEnumerable<Games> GetGamesByGenre(int GenresId);
        IEnumerable<Games> GetGamesByPublisher(int PublishersId);
        int Update(Games model);
    }
}