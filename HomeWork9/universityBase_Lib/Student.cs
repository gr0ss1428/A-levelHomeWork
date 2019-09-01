using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace universityBase_Lib
{
    public class Student : Passport
    {
        public uint Group { get; private set; }
        public Student(string name, string surname, uint age, uint group) : base(name, surname, age)
        {
            Group = group;
        }
        public void ChangeGroup(uint group)
        {
            Group = group;
        }
    }
}
