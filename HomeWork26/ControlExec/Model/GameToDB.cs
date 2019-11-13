using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlExec.Model
{
    public class GameToDB
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int YearPublishing { get; set; }
        public int GenreId { get; set; }
        public int PublicherId { get; set; }
    }
}
