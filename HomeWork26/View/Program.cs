using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlExec;
using ControlExec.Model;
namespace View
{
    class Program
    {
        static void Main(string[] args)
        {
            Control control = new Control(@"Data Source=ELEKTRA;Initial Catalog=GameStories;Integrated Security=True");
            control.CreateGenre(new GenreToDB() { Description = "Shoot and run", Name = "Shooter2" });
        }
    }
}
