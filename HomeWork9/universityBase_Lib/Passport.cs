using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace universityBase_Lib
{
    public class Passport
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public uint Age { get; private set; }
        public Passport(string name, string surname, uint age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}
