using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseDriver.Model
{
    public class Genre
    {
        public Genre()
        {
            Games = new List<Game>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
