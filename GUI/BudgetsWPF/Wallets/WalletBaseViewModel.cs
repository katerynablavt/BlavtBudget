using BudgetsWPF.Authentication;
using BudgetsWPF.Categories;
using BudgetsWPF.Navigation;
using BudgetsWPF.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF.Wallets
{
    public class WalletBaseViewModel : NavigationBase<WalletsNavigatableTypes>, INavigatable<MainNavigetableTypes>
    {

        public WalletBaseViewModel()
        {
            Navigate(WalletsNavigatableTypes.Wallet);
        }

        protected override INavigatable<WalletsNavigatableTypes> CreateViewModel(WalletsNavigatableTypes type)
        {
            if (type == WalletsNavigatableTypes.Wallet)
            {
                return new WalletsViewModel(() => Navigate(WalletsNavigatableTypes.WalletCreation), () => Navigate(WalletsNavigatableTypes.TransactionCreation), () => Navigate(WalletsNavigatableTypes.CategoryCreation), () => Navigate(WalletsNavigatableTypes.Wallet));
            }
            else if (type == WalletsNavigatableTypes.WalletCreation)
            {
                return new WalletCreateViewModel(() => Navigate(WalletsNavigatableTypes.Wallet));
            }
            else if (type == WalletsNavigatableTypes.CategoryCreation)
            {
                return new CategoryViewModel(() => Navigate(WalletsNavigatableTypes.Wallet));
            }
            else
            {
                return new TransactionCreateViewModel(() => Navigate(WalletsNavigatableTypes.Wallet));
            }
        }

        public MainNavigetableTypes Type
        {
            get
            {
                return MainNavigetableTypes.Auth;
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
