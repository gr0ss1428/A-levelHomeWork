using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.AddDepartament(new Departament("Developer"));

            User user = new User("mail@gmail.com", "Ivanov Ivan");
            server.Subscribe(1, user);
            server.AddVacancy(1, new Vacancy("java", "Junior Java developer"));

            server.AddDepartament(new Departament("Qa"));
            server.AddVacancy(2, new Vacancy("Mobile Qa", "Junior mobile Qa"));
            Console.WriteLine();

            var allVacansy = server.GetAllVacansy();
            foreach (var key in allVacansy.Keys)
            {
                Console.WriteLine(key);
                foreach (var vacancy in allVacansy[key])
                    Console.WriteLine($"Id {vacancy.Id} Title {vacancy.Title}");
            }
            Console.ReadKey();
        }
    }
}
