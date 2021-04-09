using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF
{
    public class User
    {
        public User(Guid guid, string firstName, string lastName, string email, string login = null)
        {
            Guid = guid;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
        }

        public Guid Guid {get;}
        public string FirstName { get; }
        public string LastName { get; }

        public string Email { get; }
        public string Login { get; }
    }
}
