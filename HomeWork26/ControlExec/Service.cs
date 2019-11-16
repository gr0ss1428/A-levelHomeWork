using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlExec.Controls;
using ControlExec.Model;
namespace ControlExec
{
    public class Service
    {
        private ControlGame controlGame;
        private readonly ControlGenre controlGenre;
        private readonly ControlPublisher controlPublisher;

        public Service(string connectionBaseStr, int maxDescriptionSize, int maxNameSize, int minValidYear)
        {
            controlPublisher = new ControlPublisher(connectionBaseStr, maxNameSize);
            controlGenre = new ControlGenre(connectionBaseStr, maxDescriptionSize, maxNameSize);
            controlGame = new ControlGame(connectionBaseStr, maxNameSize, minValidYear);
        }

        public ExeResult CreateGame(GameModel model)
        {
            ExeResult exeResult = ValidPublisherAndGanre(model);
            if (exeResult.IsError) return exeResult;
            GameModel game = controlGame.GetByNameYearPublishing(model);
            if (game != null) return new ExeResult(new List<string>() { "This game already exists" });

            return controlGame.Create(model);
        }

        public ExeResult CreateGenre(GenreModel model)
        {
            return controlGenre.Create(model);
        }

        public ExeResult CreatePublisher(PublisherModel model)
        {
            return controlPublisher.Create(model);
        }

        public ExeResult UpdateGenre(GenreModel model)
        {
            return controlGenre.Update(model);
        }

        public ExeResult UpdatePublisher(PublisherModel model)
        {
            return controlPublisher.Update(model);
        }

        public ExeResult UpdateGame(GameModel model)
        {
            ExeResult exeResult = ValidPublisherAndGanre(model);
            if (exeResult.IsError) return exeResult;
            if (exeResult.IsError) return exeResult;

            return controlGame.Update(model);
        }

        public ExeResult RemoveGenre(GenreModel model)
        {
            if (controlGame.GetByGenre(model.Id).Count() != 0) return new ExeResult(new List<string> { "This genre is used in game" });

            else return controlGenre.Delete(model);
        }

        public ExeResult RemovePublisher(PublisherModel model)
        {
            if (controlGame.GetByPublisher(model.Id).Count() != 0) return new ExeResult(new List<string> { "This publisher is used in game" });

            else return controlPublisher.Delete(model);
        }

        public ExeResult RemoveGame(GameModel model)
        {
            return controlGame.Delete(model);
        }

        public IEnumerable<GameModel> GetAllGame()
        {
            return controlGame.GetAll();
        }

        public IEnumerable<GenreModel> GetAllGenre()
        {
            return controlGenre.GetAll().AsParallel().Where(i => i.Name.Length <= controlGenre.MaxNameSize && i.Description.Length <=controlGenre.MaxDescriptionSize);
        }
        public IEnumerable<PublisherModel> GetAllPublisher()
        {
            return controlPublisher.GetAll().AsParallel().Where(i => i.Name.Length <= controlPublisher.MaxNameSize);
        }

        public IEnumerable<GameModel> GetAllGameByPublisher(int publisherId)
        {
            return controlGame.GetByPublisher(publisherId).AsParallel().Where(i => controlGame.AllValidation(i)).ToList();
        }

        public IEnumerable<GameModel> GetAllGameByGenre(int genreId)
        {
            return controlGame.GetByGenre(genreId).AsParallel().Where(i => controlGame.AllValidation(i)).ToList();
        }

        public IEnumerable<GameModel> GetAllGameByLicense(string license)
        {
            List<GameModel> games= controlGame.GetAll().AsParallel().Where(i => controlGame.AllValidation(i)).ToList();
            List<PublisherModel> publishers = controlPublisher.GetAll().ToList();
            publishers.RemoveAll(i => i.License != license);
            List<GameModel> gamesWithLicence = new List<GameModel>();
            foreach(var item in publishers)
            {
                gamesWithLicence.AddRange(games.AsParallel().Where(i=>i.PublicherId==item.Id));
            }
            return gamesWithLicence;
        }


        private ExeResult ValidPublisherAndGanre(GameModel model)
        {
            ExeResult result = new ExeResult(new List<string>());
            PublisherModel publisher;
            ExeResult exeResult = controlPublisher.GetById(model.PublicherId, out publisher);
            if (publisher == null) result.Message.Add("Unknown publisher");

            GenreModel genre;
            exeResult = controlGenre.GetById(model.GenreId, out genre);
            if (genre == null) result.Message.Add("Unknown genre");

            return result;
        }
    }
}
