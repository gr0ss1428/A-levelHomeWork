using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Server
    {
        List<Departament> departamentsLst;
        public Server()
        {
            departamentsLst = new List<Departament>();
        }

        public bool AddDepartament(Departament departament)
        {
            if (departamentsLst.FirstOrDefault(i => i.Title == departament.Title) == null)
            {
                departamentsLst.Add(departament);
            }
            return false;
        }

        public bool AddVacancy(int idDepartament, Vacancy vacancy)
        {
            Departament departament = GetDepartamentById(idDepartament);
            if (departament != null)
            {
                departament.AddVacancy(vacancy);
                return true;
            }
            return false;
        }

        public void Subscribe(int idDepartament, IUser user)
        {
            GetDepartamentById(idDepartament)?.Subscribe(user);
        }

        public void Unsubscribe(int idDepartament, IUser user)
        {
            GetDepartamentById(idDepartament)?.Unsubscribe(user);
        }

        public IDictionary<string, IEnumerable<Vacancy>> GetAllVacansy()
        {
            return departamentsLst.Where(i => i.CountVacancy != 0).GroupBy(k => k.Title).ToDictionary(k => k.Key, v => departamentsLst.FirstOrDefault(i => i.Title == v.Key).GetVacancies());
        }

        private Departament GetDepartamentById(int id)
        {
            return departamentsLst.FirstOrDefault(i => i.Id == id);
        }
    }
}
