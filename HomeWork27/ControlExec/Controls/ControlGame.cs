using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlExec.Model;
using DataBaseDriver;


namespace ControlExec.Controls
{
    internal class ControlGame : IControl<GameModel>
    {
        private readonly IGamesRepository _repository;
        public int MaxNameSize { get; set; }
        public int MinValidYear { get; set; }

        public ControlGame( int maxNameSize, int validYear)
        {
            MaxNameSize = maxNameSize;
            _repository = new GamesRepository();
            MinValidYear = validYear;
        }

        public ExeResult Create(GameModel model)
        {

            ExeResult exRes = AllValidationWithErrorMessge(model);
            if (exRes.IsError) return exRes;

            var game = ControlTools.MapTo<GameModel, Games>(model);
            model.Id = _repository.Create(game);
            if (model.Id == 0) return new ExeResult(new List<string>() { "Game not create" });

            return new ExeResult(new List<string>()); ;
        }

        public ExeResult Delete(GameModel model)
        {
            if (_repository.GetById(model.Id) == null) return new ExeResult(new List<string>() { "This game is unknown." });

            var game = ControlTools.MapTo<GameModel, Games>(model);
            var result = ControlTools.DbExec(_repository.Delete, game, "Game not delete");
            return result;
        }

        public IEnumerable<GameModel> GetAll()
        {
            List<GameModel> gameModel = new List<GameModel>();
            var result = _repository.GetAll();
            ParallelLoopResult res = Parallel.ForEach(result, item =>
                   {
                       gameModel.Add(ControlTools.MapTo<Games, GameModel>(item));
                   });

            //очень не красиво тута
            while (!res.IsCompleted) { };

            return gameModel.AsParallel().Where(i => AllValidation(i));
        }

        public ExeResult GetById(int id, out GameModel model)
        {
            model = ControlTools.MapTo<Games, GameModel>(_repository.GetById(id));
            if (model == null)
            {
                return new ExeResult(new List<string>() { "Unknown id" });
            }
            ExeResult exRes = AllValidationWithErrorMessge(model);
            if (exRes.IsError)
            {
                model = null;
                return exRes;
            }

            return new ExeResult(new List<string>());
        }

        public ExeResult GetByName(string name, out GameModel model)
        {
            model = ControlTools.MapTo<Games, GameModel>(_repository.GetByName(name));
            if (model == null) return new ExeResult(new List<string>() { "Unknown name" });

            ExeResult exRes = AllValidationWithErrorMessge(model);
            if (exRes.IsError)
            {
                model = null;
                return exRes;
            }

            return new ExeResult(null);
        }

        public ExeResult Update(GameModel model)
        {
            ExeResult exRes = AllValidationWithErrorMessge(model);
            if (exRes.IsError) return exRes;

            var game = ControlTools.MapTo<GameModel, Games>(model);
            exRes = ControlTools.DbExec(_repository.Update, game, "Game not update");
            return exRes;
        }

        public IEnumerable<GameModel> GetByGenre(int genreId)
        {
            List<GameModel> gameModel = new List<GameModel>();
            var result = _repository.GetGamesByGenre(genreId);
            ParallelLoopResult res = Parallel.ForEach(result, item =>
            {
                gameModel.Add(ControlTools.MapTo<Games, GameModel>(item));
            });

            //очень не красиво тута
            while (!res.IsCompleted) { };

            return gameModel;
        }

        public IEnumerable<GameModel> GetByPublisher(int publisherId)
        {
            List<GameModel> gameModel = new List<GameModel>();
            var result = _repository.GetGamesByPublisher(publisherId);
            ParallelLoopResult res = Parallel.ForEach(result, item =>
            {
                gameModel.Add(ControlTools.MapTo<Games, GameModel>(item));
            });

            //очень не красиво тута
            while (!res.IsCompleted) { };

            return gameModel;
        }

        public GameModel GetByNameYearPublishing(GameModel model)
        {
            Games game = ControlTools.MapTo<GameModel, Games>(model);
            return ControlTools.MapTo<Games, GameModel>(_repository.GetByNameYearPublishing(game));
        }

        public bool ValidationYear(GameModel model)
        {
            return model.YearPublishing >= MinValidYear && model.YearPublishing <= DateTime.Now.Year;
        }

        public bool AllValidation(GameModel model)
        {
            return model.Name.Length < MaxNameSize && ValidationYear(model);
        }

        private ExeResult AllValidationWithErrorMessge(GameModel model)
        {
            List<string> mes = new List<string>();
            if (model.Name.Length > MaxNameSize) mes.Add($"Long name >{MaxNameSize}.");
            if (!ValidationYear(model)) mes.Add($"Invalid year <{MinValidYear}or>{DateTime.Now.Year}.");

            if (mes.Count != 0) return new ExeResult(mes);
            return new ExeResult(new List<string>());
        }
    }
}
