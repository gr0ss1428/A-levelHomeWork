using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlExec.Model;
using DataBaseDriver;

namespace ControlExec.Controls
{
    internal class ControlGenre : IControl<GenreModel>
    {
        private readonly IRepository<Genres> _repository;
        public int MaxDescriptionSize { get; set; }
        public int MaxNameSize { get; set; }
        List<string> message;
        public ControlGenre( int maxDescriptionSize, int maxNameSize)
        {
            _repository = new GenreRepository();
            message = new List<string>();
            MaxDescriptionSize = maxDescriptionSize;
            MaxNameSize = maxNameSize;
        }

        public ExeResult Create(GenreModel genreToDB)
        {
            message.Clear();
            ValidationCharacterLenght(genreToDB);

            Genres genreTemp = _repository.GetByName(genreToDB.Name);
            if (genreTemp != null)
            {
                if (genreTemp.Name == genreToDB.Name)
                    message.Add("This Name already exists.");
            }

            if (message.Count != 0) return new ExeResult(message);

            var genre = ControlTools.MapTo<GenreModel, Genres>(genreToDB);
            genreToDB.Id = _repository.Create(genre);
            if (genreToDB.Id == 0) return new ExeResult(new List<string>() { "Genre not create" });

            return new ExeResult(new List<string>()); ;
        }

        public ExeResult Update(GenreModel genreToDB)
        {
            message.Clear();
            //Нужна ли эта проверка
            //if (_repository.GetById(genreToDB.Id) == null) message.Add("This genre is unknown.");

            ValidationCharacterLenght(genreToDB);
            if (message.Count != 0) return new ExeResult(message);

            var genre = ControlTools.MapTo<GenreModel, Genres>(genreToDB);
            var result = ControlTools.DbExec(_repository.Update, genre, "Genre not update");
            return result;
        }

        public ExeResult Delete(GenreModel genreToDB)
        {
            message.Clear();
            if (_repository.GetById(genreToDB.Id) == null) return new ExeResult(new List<string>() { "This genre is unknown." });

            var genre = ControlTools.MapTo<GenreModel, Genres>(genreToDB);
            var result = ControlTools.DbExec(_repository.Delete, genre, "Genre not delete");
            return result;
        }

        public ExeResult GetById(int id, out GenreModel genreModel)
        {
            message.Clear();
            genreModel = ControlTools.MapTo<Genres, GenreModel>(_repository.GetById(id));
            if (genreModel == null) return new ExeResult(new List<string>() { "Unknown id" });
            else ValidationCharacterLenght(genreModel);
            if (message.Count != 0) return new ExeResult(message);
            
            return new ExeResult(new List<string>());
        }

        public ExeResult GetByName(string name, out GenreModel genreModel)
        {
            message.Clear();
            genreModel = ControlTools.MapTo<Genres, GenreModel>(_repository.GetByName(name));
            if (genreModel == null) return new ExeResult(new List<string>() { "Unknown name" });
            else ValidationCharacterLenght(genreModel);
            if(message.Count!=0) return new ExeResult(message);
            
            return new ExeResult(new List<string>());
        }

        public IEnumerable<GenreModel> GetAll()
        {
            List<GenreModel> genresModel = new List<GenreModel>();
            var result = _repository.GetAll();
            ParallelLoopResult res = Parallel.ForEach(result, item =>
              {
                  genresModel.Add(ControlTools.MapTo<Genres, GenreModel>(item));
              });

            //очень не красиво тута
            while (!res.IsCompleted) { };

            return genresModel;
        }
        private void ValidationCharacterLenght(GenreModel genreModel)
        {
            if (genreModel.Name.Length > MaxNameSize) message.Add($"Long name >{MaxNameSize}.");
            if (genreModel.Description.Length > 600) message.Add($"Long description >{MaxDescriptionSize}.");
        }
    }
}
