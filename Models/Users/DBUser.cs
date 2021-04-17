using DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class DBUser : IStorable
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
        [JsonConstructor]
        public DBUser(Guid guid, string login, string password, string name, string surname, string email, List<Category> categories)
        {
            Guid = guid;
            Login = login;
            Password = password;
            FirstName = name;
            LastName = surname;
            Email = email;
            Categories = categories;
        }
        public Guid Guid { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public string Email { get; }
        public string Login { get; }
        public string Password { get; }
        public List<Category> Categories { get; set; }
    }
}
