using BudgetsWPF.Authentication;
using BudgetsWPF.Wallets;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF
{
   public class MainViewModel : BindableBase
    {
        private List<IMainNavigetable> _viewModels = new();
        private Action _signInSuccess;
        public IMainNavigetable CurrentViewModel
        {
            get;
            private set;
        }
        public MainViewModel()
        {
         
            Navigate(MainNavigetableTypes.Auth);
        }

        public void Navigate (MainNavigetableTypes type)
        {
            if (CurrentViewModel !=null&&CurrentViewModel.Type == type)
                return;

            IMainNavigetable viewModel = null;
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

        private IMainNavigetable CreateViewModel(MainNavigetableTypes type)
        {
            if (type == MainNavigetableTypes.Auth)
            {
                return new AuthViewModel(() => Navigate(MainNavigetableTypes.Wallets));
            }
            else
            {
               return new WalletsViewModel();
            }
        }
    }
}
