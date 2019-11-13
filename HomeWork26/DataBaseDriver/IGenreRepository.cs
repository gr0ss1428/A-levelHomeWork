using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseDriver.Model;
namespace DataBaseDriver
{
    public interface IGenreRepository
    {
        Genre Create(Genre genre);
        void Update(Genre genre);
        void Delete(Genre genre);
        Genre GetById(int id);
    }
}
