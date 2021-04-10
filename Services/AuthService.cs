
using Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
    public class AuthService
    {

        private static List<DBUser> Users = new List<DBUser>();
        public User Authenticate(AuthUser authUser)
        {
            if (String.IsNullOrWhiteSpace(authUser.Login) || String.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or password is empty!");
            var dbUser = Users.FirstOrDefault(user => user.Login == authUser.Login &&user.Password==authUser.Password);
            if (dbUser == null)
            {
               throw new Exception("Wrong Login or Password");
            }
            return new User(dbUser.Guid, dbUser.FirstName,dbUser.LastName, dbUser.Email, dbUser.Login);
        }
        public bool RegisterUser (RegistrationUser regUser)
        {
            var dbUser = Users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser !=null)
            {
               throw  new Exception("User already exist");
            }
            if (String.IsNullOrWhiteSpace(regUser.Login) || String.IsNullOrWhiteSpace(regUser.LastName) || String.IsNullOrWhiteSpace(regUser.Password))
                throw new ArgumentException("Login, password or LastName is empty!");

            dbUser = new DBUser(regUser.LastName+"first", regUser.LastName,regUser.LastName+"@gmail.com", regUser.Login, regUser.Password);
            Users.Add(dbUser);
            return true;
        }
    }
}
