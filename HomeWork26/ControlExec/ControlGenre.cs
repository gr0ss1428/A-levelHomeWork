using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlExec.Model;
using DataBaseDriver;
using DataBaseDriver.Model;


namespace ControlExec
{
    public class ControlGenre : IControl<GenreModel>
    {
        private readonly IRepository<Genre> _repository;
        public int MaxDescriptionSize { get; set; }
        public int MaxNameSize { get; set; }
        List<string> message;
        public ControlGenre(string connectionBaseStr, int maxDescriptionSize, int maxNameSize)
        {
            _repository = new GenreRepository(connectionBaseStr);
            message = new List<string>();
            MaxDescriptionSize = maxDescriptionSize;
            MaxNameSize = maxNameSize;
        }

        public ExeResult Create(GenreModel genreToDB)
        {
            message.Clear();
            ValidationNameSize(genreToDB);

            Genre genreTemp = _repository.GetByName(genreToDB.Name);
            if (genreTemp != null)
            {
                if (genreTemp.Name == genreToDB.Name)
                    message.Add("This Name already exists.");
            }

            if (message.Count != 0) return new ExeResult(true, message);

            var genre = ControlTools.MapTo<GenreModel, Genre>(genreToDB);
            var result = ControlTools.DbExec(_repository.Create, genre, "Genre not create");
            return result;
        }

        public ExeResult Update(GenreModel genreToDB)
        {
            message.Clear();
            //Нужна ли эта проверка
            //if (_genreRepository.GetById(genreToDB.Id) == null) message.Add("This genre is unknown.");

            ValidationNameSize(genreToDB);
            if (message.Count != 0) return new ExeResult(true, message);

            var genre = ControlTools.MapTo<GenreModel, Genre>(genreToDB);
            var result = ControlTools.DbExec(_repository.Update, genre, "Genre not update");
            return result;
        }

        public ExeResult Delete(GenreModel genreToDB)
        {
            // if (_genreRepository.GetById(genreToDB.Id) == null) return new ExeResult(true, new List<string>() { "This genre is unknown." });

            var genre = ControlTools.MapTo<GenreModel, Genre>(genreToDB);
            var result = ControlTools.DbExec(_repository.Delete, genre, "Genre not delete");
            return result;
        }

        public ExeResult GetById(int id, out GenreModel genreModel)
        {
            genreModel = ControlTools.MapTo<Genre, GenreModel>(_repository.GetById(id));
            if (genreModel == null) return new ExeResult(true, new List<string>() { "Unknown id" });
            return new ExeResult(false, null);
        }

        public ExeResult GetByName(string name, out GenreModel genreModel)
        {
            genreModel = ControlTools.MapTo<Genre, GenreModel>(_repository.GetByName(name));
            if (genreModel == null) return new ExeResult(true, new List<string>() { "Unknown name" });
            return new ExeResult(false, null);
        }

        public IEnumerable<GenreModel> GetAll()
        {
            List<GenreModel> genresModel = new List<GenreModel>();
            var result = _repository.GetAll();
            ParallelLoopResult res = Parallel.ForEach(result.Where(i => i.Name.Length <= MaxNameSize && i.Description.Length <= MaxDescriptionSize), item =>
              {
                  genresModel.Add(ControlTools.MapTo<Genre, GenreModel>(item));
              });

            //очень не красиво тута
            while (!res.IsCompleted) { };

            return genresModel;
        }
        private void ValidationNameSize(GenreModel genreModel)
        {
            if (genreModel.Name.Length > MaxNameSize) message.Add($"Long name >{MaxNameSize}.");
            if (genreModel.Description.Length > 600) message.Add($"Long description >{MaxDescriptionSize}.");
        }
    }
}
