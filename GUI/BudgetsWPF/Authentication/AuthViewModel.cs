using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF.Authentication
{
   public class AuthViewModel : BindableBase, IMainNavigetable
    {
        private List<IAuthNavigetable> _viewModels = new();
        private Action _signInSuccess;
        public IAuthNavigetable CurrentViewModel
        {
            get;
            private set;
        }

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

        public void Navigate (AuthNavigetableTypes type)
        {
            if (CurrentViewModel !=null&&CurrentViewModel.Type == type)
                return;

            IAuthNavigetable viewModel = null;
            foreach(var authnavigetable in _viewModels)
            {
                if (authnavigetable.Type==type)
                {
                    viewModel = authnavigetable;
                    break;
                }
            }
            if (viewModel == null)
            {
                viewModel = CreateViewModel(type);
                _viewModels.Add(viewModel);
            }
            viewModel.ClearSensitiveData();
            CurrentViewModel = viewModel;
            RaisePropertyChanged(nameof(CurrentViewModel));
        }

        private IAuthNavigetable CreateViewModel(AuthNavigetableTypes type)
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
    }
}
