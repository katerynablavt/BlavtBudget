
using DataStorage;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class AuthService
    {

        private static FileOfDataStorage<DBUser> _storage = new FileOfDataStorage<DBUser>();
        public static User CurrentUser;
        public async Task<User> Authenticate(AuthUser authUser)
        { 
            if (String.IsNullOrWhiteSpace(authUser.Login) || String.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or password is empty!");

            var users = await _storage.GetAllAsync();
            //    var dbUser = users.FirstOrDefault(user => user.Login == authUser.Login &&user.Password==authUser.Password);
            //    if (dbUser == null)
            //    {
            //       throw new Exception("Wrong Login or Password");
            //    }
            //    return new User(dbUser.Guid, dbUser.FirstName,dbUser.LastName, dbUser.Email, dbUser.Login);
            DBUser dbUser = null;
            try
            {
                dbUser = users.FirstOrDefault(user =>
                    user.Login == authUser.Login &&
                    Encryption.Decrypt(user.Password, authUser.Password) == authUser.Password);
                if (dbUser == null)
                    throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception("Wrong Login or Password");//UserException("Wrong Login or Password");
            }
            dbUser.Categories ??= new List<Category>();

            CurrentUser = new User(dbUser.FirstName, dbUser.LastName, dbUser.Email, dbUser.Guid, dbUser.Categories);
            return CurrentUser;
        }
        public async Task<bool> RegisterUser (RegistrationUser regUser)
        {
            var users = await _storage.GetAllAsync();
            var dbUser =  users.FirstOrDefault(user => user.Login == regUser.Login);
            if (dbUser !=null)
            {
               throw  new Exception("User already exist");
            }
            if (String.IsNullOrWhiteSpace(regUser.Login) ||
                String.IsNullOrWhiteSpace(regUser.Name) ||
                String.IsNullOrWhiteSpace(regUser.LastName) ||
                String.IsNullOrWhiteSpace(regUser.Password) ||
                String.IsNullOrWhiteSpace(regUser.Email)) 
                throw new ArgumentException("Login, password or LastName is empty!");

            dbUser = new DBUser(regUser.LastName+"first", regUser.LastName,regUser.LastName+"@gmail.com", regUser.Login, regUser.Password);
           await _storage.AddOrUpdateAsync(dbUser);
            return true;
        }
    }
}
