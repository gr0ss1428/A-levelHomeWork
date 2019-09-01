using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace universityBase_Lib
{
    public class Group
    {
        public Teacher Teacher { get; private set; }
        List<Student> lstStudents;
        public uint CurrentLength { get; private set; }
        public uint MaxLength
        {
            get
            {
                return Teacher?.MaxStudentsInGroup??0;
            }
        }
        public uint Number { get; private set; }
        public Group(uint number,Teacher teacher)
        {
            lstStudents = new List<Student>();
            CurrentLength = 0;
            Number = number;
            Teacher = teacher;
            
        }
        public bool AddStudent(Student student)
        {
            if (CurrentLength == MaxLength) return false;
            else
            {
                lstStudents.Add(student);
                CurrentLength++;
                return true;
            }
        }
        public void AddTeacher(Teacher teacher)
        {
            Teacher = teacher;
        }
        public uint GetFree()
        {
            return MaxLength - CurrentLength;
        }
    }
}
