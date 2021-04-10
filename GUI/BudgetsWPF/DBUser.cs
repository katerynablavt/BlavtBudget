using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF
{
    public class DBUser
    {

        public DBUser( string firstName, string lastName, string email, string login, string password)
        {
            Guid = new Guid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Login = login;
            Password = password;
        }
        public Guid Guid { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public string Email { get; }
        public string Login { get; }
        public string Password { get; }
    }
}
