using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Vacancy
    {
        public int Id { get; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        private static int idGen=1;
        public Vacancy(string title, string description)
        {
            Title = title;
            Description = description;
            Id = idGen;
            idGen++;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vacancy)
                return Title.Equals(((Vacancy)obj).Title) && Description.Equals(((Vacancy)obj).Description);
            return false;
        }
    }
}
