using System;

namespace BudgetsWPF.Authentication
{
    public class AuthService
    {
        public User Authenticate(AuthUser authUser)
        {
            if (string.IsNullOrWhiteSpace(authUser.Login) || string.IsNullOrWhiteSpace(authUser.Password))
                throw new ArgumentException("Login or password is empty!");

            return new User(Guid.NewGuid(), "kate", "blavt", "gmail.com", "apple");
        }
    }
}
