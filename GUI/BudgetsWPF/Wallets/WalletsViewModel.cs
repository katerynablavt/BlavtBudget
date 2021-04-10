using BudgetsWPF.Authentication;
using BudgetsWPF.Navigation;
using Models.Wallets;
using Prism.Mvvm;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF.Wallets
{
    public class WalletsViewModel : BindableBase, INavigatable<MainNavigetableTypes>
    {
        private WalletService _service;
        private WalletDetailsViewModel _currentWallet;

        public ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }
        public WalletDetailsViewModel CurrentWallet
        {
            get
            {
                return _currentWallet;
            }
            set
            {
                _currentWallet = value;
                RaisePropertyChanged();
            }
        }

        public WalletsViewModel()
        {
            _service = new WalletService();
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
           foreach (var wallet in _service.GetWallets())
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
        }
        public MainNavigetableTypes Type
        {
            get
            {
                return MainNavigetableTypes.Wallets;
            }
        }

        public void ClearSensitiveData()
        {
          
        }
    }
}
