﻿using BudgetsWPF.Authentication;
using BudgetsWPF.Navigation;
using Models.Wallets;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BudgetsWPF.Wallets
{
    public class WalletsViewModel : INotifyPropertyChanged, INavigatable<WalletsNavigatableTypes>
    {
        private Action _gotoWalletCreation;
        private Action _gotoTransactionCreation;
        private Action _update;

        private Action _categoryCreation;
        // private WalletService _service;
        private WalletDetailsViewModel _currentWallet;
        private TransactionDetailViewModel _currentTransaction;
        public ObservableCollection<WalletDetailsViewModel> Wallets { get; set; }
        public ObservableCollection<TransactionDetailViewModel> Transactions { get; set; }

        public WalletDetailsViewModel CurrentWallet
        {
            get
            {
                return _currentWallet;
            }
            set
            {
                _currentTransaction = null;
                _currentWallet = value;
                WalletService.CurrentWallet = _currentWallet?.Wallet;


                Transactions = new ObservableCollection<TransactionDetailViewModel>();

                if (_currentWallet != null)
                {
                    foreach (var transaction in _currentWallet.Wallet.GetAllTransactions(AuthService.CurrentUser))
                    {
                        Transactions.Add(new TransactionDetailViewModel(transaction, _update));
                    }
                }


                OnPropertyChanged(nameof(CurrentWallet));
                OnPropertyChanged(nameof(CurrentTransaction));
                OnPropertyChanged(nameof(Transactions));
                GoToTransactionCreation.RaiseCanExecuteChanged();
                RemoveWalletCommand.RaiseCanExecuteChanged();

            }
        }

        public TransactionDetailViewModel CurrentTransaction
        {
            get
            {
                return _currentTransaction;
            }
            set
            {
                _currentWallet = null;
                _currentTransaction = value;
                OnPropertyChanged(nameof(CurrentWallet));
                OnPropertyChanged(nameof(CurrentTransaction));
                RemoveTransactionCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand GoToWalletCreation { get; }
        public DelegateCommand GoToTransactionCreation { get; }

        public DelegateCommand GoToCategoryCreation { get; }

        public DelegateCommand RemoveWalletCommand { get; }

        public DelegateCommand RemoveTransactionCommand { get; }

        public WalletsViewModel(Action gotoWalletCreation, Action gotoTransactionCreation, Action categoryCreation, Action update)
        {
            Wallets = new ObservableCollection<WalletDetailsViewModel>();

            foreach (var wallet in AuthService.CurrentUser.Wallets)
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }

            _gotoWalletCreation = gotoWalletCreation;
            _gotoTransactionCreation = gotoTransactionCreation;
            _categoryCreation = categoryCreation;
            _update = update;
            GoToWalletCreation = new DelegateCommand(_gotoWalletCreation);
            GoToTransactionCreation = new DelegateCommand(_gotoTransactionCreation, IsSelectedWallet);
            GoToCategoryCreation = new DelegateCommand(_categoryCreation);
            RemoveWalletCommand = new DelegateCommand(RemoveWallet, IsSelectedWallet);
            RemoveTransactionCommand = new DelegateCommand(RemoveTransaction, IsSelectedTransaction);
        }


        private bool IsSelectedTransaction()
        {
            return CurrentTransaction != null;
        }
        private bool IsSelectedWallet()
        {
            return WalletService.CurrentWallet != null;
        }


        public async void RemoveTransaction()
        {
            TransService service = new TransService();
            WalletService.CurrentWallet.RemoveTransaction(AuthService.CurrentUser, CurrentTransaction.Transaction);
            await service.RemoveTransaction(CurrentTransaction.Transaction);
            Transactions.Remove(CurrentTransaction);
            OnPropertyChanged(nameof(Transactions));
            MessageBox.Show("Transaction was removed");
            Update();
        }

        public async void RemoveWallet()
        {

            WalletService service = new WalletService();
            DBWallet wallet = new DBWallet(_currentWallet.Guid, _currentWallet.Name, _currentWallet.Wallet.CurrBalance, _currentWallet.Description,
                    _currentWallet.Currency);
            await service.RemoveWallet(wallet);

            TransService tservice = new TransService();
            foreach (var transaction in _currentWallet.Wallet.GetAllTransactions(AuthenticationService.CurrentUser))
            {
                await tservice.RemoveTransaction(transaction);
            }

            AuthService.CurrentUser.Wallets.RemoveAll(x => x.Guid == wallet.Guid);
            MessageBox.Show("Wallet was removed");
            Update();
        }


        public WalletsNavigatableTypes Type
        {
            get
            {
                return WalletsNavigatableTypes.Wallet;
            }
        }

        public void ClearSensitiveData()
        {

        }

        public void Update()
        {
            Wallets = new ObservableCollection<WalletDetailsViewModel>();
            foreach (var wallet in AuthService.CurrentUser.Wallets)
            {
                Wallets.Add(new WalletDetailsViewModel(wallet));
            }
            OnPropertyChanged(nameof(Wallets));
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
