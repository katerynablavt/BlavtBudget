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
    public class WalletsViewModel : BindableBase, IMainNavigetable
    {
        private WalletService _service;
        private Wallet _currentWallet;

        public ObservableCollection<Wallet> Wallets { get; set; }
        public Wallet CurrentWallet
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
            Wallets = new ObservableCollection<Wallet>(_service.GetWallets());
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
