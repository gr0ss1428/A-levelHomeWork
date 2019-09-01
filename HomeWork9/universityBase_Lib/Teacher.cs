using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace universityBase_Lib
{
    public class Teacher : Passport
    {
        public uint MaxStudentsInGroup { get; private set; }
        public string Position { get; private set; }
        public Teacher(string name, string surname, uint age, string position, uint maxStusents) : base(name, surname, age)
        {
            MaxStudentsInGroup = maxStusents;
            Position = position;
        }
        public void ChangeMaxStudent(uint newValue)
        {
            MaxStudentsInGroup = newValue;
        }
       
    }
}
