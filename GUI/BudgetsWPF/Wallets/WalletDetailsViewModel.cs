﻿using Models.Wallets;
using Prism.Commands;
using Prism.Mvvm;
using Services;
using System;
using System.Windows;

namespace BudgetsWPF.Wallets
{
    public class WalletDetailsViewModel : BindableBase
    {
        private Wallet _wallet;


        public string Profit
        {
            get
            {
                return _wallet.MonthProfit(AuthService.CurrentUser).ToString("#.##");
            }
        }

        public string Spends
        {
            get
            {
                return _wallet.MonthSpends(AuthService.CurrentUser).ToString("#.##");
            }
        }

        public string NameErr { get; set; }
        public string Name
        {
            get
            {
                return _wallet.Name;
            }
            set
            {
                _wallet.Name = value;
                RaisePropertyChanged(nameof(DisplayName));
                UpdateWalletCommand.RaiseCanExecuteChanged();
            }
        }

        public Wallet Wallet
        {
            get
            {
                return _wallet;
            }
        }

        public Guid Guid
        {
            get
            {
                return _wallet.Guid;
            }

        }

        public DelegateCommand UpdateWalletCommand { get; }


        public string DescriptionErr { get; set; }
        public string Description
        {
            get
            {
                return _wallet.Description;
            }
            set
            {
                _wallet.Description = value;
                RaisePropertyChanged(nameof(DisplayName));
                UpdateWalletCommand.RaiseCanExecuteChanged();
            }
        }

        public string CurrBalance
        {
            get
            {
                return _wallet.CurrBalance.ToString("#.##");
            }

        }



        public string Currency
        {
            get
            {
                return _wallet.Currency;
            }
        }

        public string DisplayName
        {
            get
            {
                return $"{_wallet.Name} ({_wallet.CurrBalance:#.##} {_wallet.Currency})";
            }
        }

        public WalletDetailsViewModel(Wallet wallet)
        {
            _wallet = wallet;
            UpdateWalletCommand = new DelegateCommand(UpdateWallet, IsValid);
        }

        private bool IsValid()
        {
            bool valid = true;
            if (String.IsNullOrWhiteSpace(Name))
            {
                NameErr = "Name can't be empty";
                RaisePropertyChanged(nameof(NameErr));
                valid = false;
            }
            else if (Name.Length > 20)
            {
                NameErr = "Name can't be more than 20 symbols";
                RaisePropertyChanged(nameof(NameErr));
                valid = false;
            }
            else
            {
                NameErr = "";
                RaisePropertyChanged(nameof(NameErr));
            }

            if (String.IsNullOrWhiteSpace(Description))
            {
                DescriptionErr = "Description can't be empty";
                RaisePropertyChanged(nameof(DescriptionErr));
                valid = false;
            }
            else
            {
                DescriptionErr = "";
                RaisePropertyChanged(nameof(DescriptionErr));
            }

            return valid;
        }


        private async void UpdateWallet()
        {

            var service = new WalletService();
            try
            {
                DBWallet wallet = new DBWallet(_wallet.Guid, _wallet.Name, _wallet.CurrBalance, _wallet.Description,
                    _wallet.Currency);
                await service.SaveUpdateWallet(AuthService.CurrentUser, wallet);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update wallet failed: {ex.Message}");
                return;
            }

            MessageBox.Show($"Wallet updated");

        }
    }


}
