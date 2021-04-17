using BudgetsWPF.Navigation;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF.Authentication
{
    public class AuthViewModel : NavigationBase<AuthNavigetableTypes>, INavigatable<MainNavigetableTypes>
    {
       
        private Action _signInSuccess;
        

        public MainNavigetableTypes Type
        {
            get
            {
                return MainNavigetableTypes.Auth;
            }
        }

        public AuthViewModel(Action signInSuccess)
        {
            _signInSuccess = signInSuccess;
            Navigate(AuthNavigetableTypes.SignIn);
        }

      
        protected override INavigatable<AuthNavigetableTypes> CreateViewModel(AuthNavigetableTypes type)
        {
            if (type == AuthNavigetableTypes.SignIn)
            {
                return new SignInViewModel(() => Navigate(AuthNavigetableTypes.SignUp), _signInSuccess);
            }
            else
            {
               return new SignUpViewModel(() =>Navigate(AuthNavigetableTypes.SignIn));
            }
        }

        public void ClearSensitiveData()
        {
            CurrentViewModel.ClearSensitiveData();
        }

        public void Update()
        {
            CurrentViewModel.Update();
        }
    }
}
