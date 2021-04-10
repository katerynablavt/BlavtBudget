using Prism.Mvvm;
using System;
using System.Collections.Generic;

namespace BudgetsWPF.Navigation
{
    public abstract class NavigationBase<TObject> :BindableBase where TObject :Enum
    {
        private List<INavigatable<TObject>> _viewModels = new();
        private Action _signInSuccess;
        public INavigatable<TObject> CurrentViewModel
        {
            get;
            private set;
        }
        protected NavigationBase()
        {

           
        }

        public void Navigate(TObject type)
        {
            if (CurrentViewModel != null && CurrentViewModel.Type.Equals(type))
                return;

            INavigatable<TObject> viewModel = null;
            foreach (var authnavigetable in _viewModels)
            {
                if (authnavigetable.Type.Equals( type))
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

        protected abstract INavigatable<TObject> CreateViewModel(TObject type);
    }
}
