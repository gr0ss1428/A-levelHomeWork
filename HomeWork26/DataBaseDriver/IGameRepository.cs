using System.Collections.Generic;
using DataBaseDriver.Model;

namespace DataBaseDriver
{
    public interface IGameRepository
    {
        int Create(Game model);
        int Delete(Game model);
        IEnumerable<Game> GetAll();
        Game GetById(int id);
        Game GetByName(string name);
        Game GetByNameYearPublishing(Game game);
        IEnumerable<Game> GetGameByGenre(int genreId);
        IEnumerable<Game> GetGameByPublisher(int publisherId);
        int Update(Game model);
    }
}