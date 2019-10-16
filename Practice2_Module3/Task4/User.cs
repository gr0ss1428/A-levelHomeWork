using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    interface IUser
    {
        string Email { get; }
        string Name { get; }
        void Message(string message);
    }
    class User : IUser
    {
        private string email;
        private string name;
        private static int IdGen=1;
        public int Id { get; }
        public string Email { get => email; }
        public string Name { get => name; }

        public User(string email, string name)
        {
            this.email = email;
            this.name = name;
            Id = IdGen;
            IdGen++;
        }

        public void ChangeEmail(string email)
        {
            this.email = email;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
