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
            Service service = new Service(@"Data Source=ELEKTRA;Initial Catalog=GameStories;Integrated Security=True", 600, 60, 1980);

            PublisherModel publisher = new PublisherModel() { Name = "RIOT", License = "Qwer1234qwer" };
            res = service.CreatePublisher(publisher);
            PublisherModel publisher2 = new PublisherModel() { Name = "BLIZZARD", License = "12323" };
            res = service.CreatePublisher(publisher2);
            PublisherModel publisher3 = new PublisherModel() { Name = "Buka", License = "alflvj12345" };
            res = service.CreatePublisher(publisher3);

            res = service.CreatePublisher(publisher3);

            GenreModel genre1 = new GenreModel() { Name = "Shooter", Description = "Run and shoot" };
            res = service.CreateGenre(genre1);
            GenreModel genre2 = new GenreModel() { Name = "Adventure", Description = "Travel and seek" };
            res = service.CreateGenre(genre2);
            GenreModel genre3 = new GenreModel() { Name = "Strategy", Description = "Think and develop" };
            res = service.CreateGenre(genre3);
            GenreModel genre4 = new GenreModel() { Name = "simulation", Description = "It is Life" };
            res = service.CreateGenre(genre4);

            res = service.CreateGenre(genre3);

            GameModel game = new GameModel() { Name = "LOL", YearPublishing = 2009, GenreId = 3, PublicherId = 1 };
            res = service.CreateGame(game);

            GameModel game2 = new GameModel() { Name = "World of Warcraft", YearPublishing = 2004, GenreId = 2, PublicherId = 2 };
            res = service.CreateGame(game2);
            GameModel game3 = new GameModel() { Name = "Метро-2", YearPublishing = 2005, GenreId = 1, PublicherId = 3 };
            res = service.CreateGame(game3);

            res = service.CreateGame(game3);

            res = service.RemoveGenre(genre1);
            res = service.RemoveGenre(genre4);

            
            foreach (var g in service.GetAllGameByLicense("alflvj12345" ))
            {
                Console.WriteLine(g.Name);
            }
            Console.ReadKey();
        }
    }
}
