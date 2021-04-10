using BudgetsWPF.Authentication;
using BudgetsWPF.Navigation;
using BudgetsWPF.Wallets;

namespace BudgetsWPF
{
    public class MainViewModel : NavigationBase<MainNavigetableTypes>
    {
       
        public MainViewModel()
        {
            Navigate(MainNavigetableTypes.Auth);
        }

        
        protected override INavigatable<MainNavigetableTypes> CreateViewModel(MainNavigetableTypes type)
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
