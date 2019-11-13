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
            ExeResult res;
            ControlGenre controlGenre = new ControlGenre(@"Data Source=ELEKTRA;Initial Catalog=GameStories;Integrated Security=True",600,60);
             res=controlGenre.Create(new GenreModel() { Description = "Think", Name = "Strategy" });

            controlGenre.Update(new GenreModel() { Id =7, Description = "Shoot and run and die", Name = "Shooter" });

            GenreModel genre;
            res= controlGenre.GetById(9,out genre);

            Console.ReadKey();

            controlGenre.Delete(new GenreModel() { Id = 7, Description = "Shoot and run and die", Name = "Shooter" });
        }
    }
}
