using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlExec.Model;
using DataBaseDriver;
using DataBaseDriver.Model;
using AutoMapper;

namespace ControlExec
{
    public class Control
    {
        private readonly IGenreRepository _genreRepository;

        public Control(string connectionBaseStr)
        {
            _genreRepository = new GenreDapper(connectionBaseStr);
        }

        public ExeResult CreateGenre(GenreToDB genreToDB)
        {
            if (genreToDB.Description.Length > 600) return new ExeResult(true, "Long description >600");

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GenreToDB, Genre>();
            });
            IMapper iMapper = config.CreateMapper();
            var genre= iMapper.Map<GenreToDB, Genre>(genreToDB);
            _genreRepository.Create(genre);
            return new ExeResult(false, string.Empty);
        }
    }
}
