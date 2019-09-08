using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace universityBase_Lib
{
    public class Manager
    {
        Dictionary<uint, Group> groups;
        List<Teacher> teachers;
        List<Student> students;
        
        public int CurrentCount
        {
            get
            {
                return groups.Count;
            }
        }
        
        public Manager()
        {
            groups = new Dictionary<uint, Group>();
            students = new List<Student>();
            teachers = new List<Teacher>();
        }
        
        public bool NewGroup(uint number,Teacher teacher)
        {
            if (!groups.ContainsKey(number))
            {
                groups.Add(number,new Group(number,teacher));
                return true;
            }
            return false;
        }
        
        public void NewTeaher(Teacher teacher)
        {
            teachers.Add(teacher);
        }
        
        public bool NewStudent(Student student)
        {
            if(groups.ContainsKey(student.Group))
            {
                bool succes = groups[student.Group].AddStudent(student);
                if(succes) students.Add(student);
                return succes;
            }
            return false;
        }
        
        public uint [] GetGroups()
        {
            return groups.Keys.ToArray();
        }
        
        public Group[] GetGroupsOb()
        {
            return groups.Values.ToArray();
        }
        
        public IEnumerable<Teacher> GetTeacherArr(string pos="ВСЕ")
        {
            // если юзаешь елсе обварачивай в фигурные скобки - хороший тон. Тернарный оператор бы тут юзал 
            if (pos =="ВСЕ") return teachers.ToArray();
            else return teachers.ToArray().Where((t) => t.Position == pos);
        }
        
        public IEnumerable<Student> GetStudentsArr(object group)  // плохая идея юхать тут оbject нельзя например использховать для всех груп 0 или хотябы сделать тут nullable type
        {
            if(group=="ВСЕ") // ты в этот метод можешь отправить че угодно упадешь тут например если не сможешь кастануть к стринге
            {
                return students.ToArray();
            }            
            else 
            {
                var ugroup = (uint)group;  // тут тоже можешь упасть 
                return students.ToArray().Where(g => g.Group == ugroup);
            }
        }
        public bool ValidNumGroup(uint num)
        {
            return groups.ContainsKey(num);
        }
    }
}
