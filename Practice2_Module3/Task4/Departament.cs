using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    
    class Departament
    {
        public int Id { get; }
        private List<Vacancy> vacanciesLst;
        private List<IUser> userLst;
        private static int idGen = 1;
        public int CountVacancy { get; private set; }
        public string Title { get; }
        private event Action<string> MessageToUsers;

        public Departament(string title)
        {
            vacanciesLst = new List<Vacancy>();
            userLst = new List<IUser>();
            Id = idGen;
            idGen++;
            Title = title;
            CountVacancy = 0;
        }

        public void AddVacancy(Vacancy vacancy)
        {
            vacanciesLst.Add(vacancy);
            CountVacancy++;
            MessageToUsers?.Invoke($"New vacancy {vacancy.Title}: {vacancy.Description}");
        }

        public bool RemoveVacancy(int id)
        {
            var vacancy = vacanciesLst.FirstOrDefault(i => i.Id == id);
            if (vacancy != null)
            {
                vacanciesLst.Remove(vacancy);
                CountVacancy--;
                MessageToUsers?.Invoke($"Remove vacancy {vacancy.Title}: {vacancy.Description}");
                return true;
            }
            return false;
        }

        public void Subscribe(IUser user)
        {
            userLst.Add(user);
            MessageToUsers += user.Message;
            
        }

        public bool Unsubscribe(IUser user)
        {
            if (userLst.Contains(user))
            {
                userLst.Remove(user);
                MessageToUsers -= user.Message;
                return true;
            }
            return false;
        }

        public IEnumerable<IUser> GetUsersSubscribe()
        {
            return userLst.ToArray();
        }

        public IEnumerable<Vacancy> GetVacancies()
        {
            return vacanciesLst.ToArray();
        }
    }
}
