using Models.Wallets;
using System;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
       

        public Guid Guid {get;}
        public string FirstName { get; }
        public string LastName { get; }

        public string Email { get; }
        public string Login { get; }

        public List<Wallets.Wallet> Wallets { get; }
        public List<Wallets.Wallet> WalletsShared { get; }

        public List<Category> Categories { get; }

        public User(string name, string surname, string email, Guid guid, List<Category> categories)
        {
            FirstName = name;
            LastName = surname;
            Email = email;
            Guid = guid;
            Wallets = new List<Wallets.Wallet>();
            WalletsShared = new List<Wallets.Wallet>();

            if (!categories.Contains(Category.DefaultCategory)) categories.Add(Category.DefaultCategory);
            Categories = categories;
        }

        public User(string name, string surname, string email)
        {
            FirstName = name;
            LastName = surname;
            Email = email;
            Guid = new Guid();
            Wallets = new List<Wallets.Wallet>();
            WalletsShared = new List<Wallets.Wallet>();
            Categories = new List<Category>() { Category.DefaultCategory };
        }

        public Wallets.Wallet CreateNewWallet(string name,
                                   decimal startBalance,
                                   string description,
                                   string currency)
        {
            //create wallet and assign it to user
            Wallets.Wallet wallet = Wallets.Wallet.CreateWalletForUser(this, name, startBalance, description, currency, guid);
            return wallet;
        }

        public Wallets.Wallet CreateNewWallet(string name,
            decimal startBalance,
            string description,
            string currency, Guid guid)
        {
            //create wallet and assign it to user
            Wallets.Wallet wallet = Wallets.Wallet.CreateWalletForUser(this, name, startBalance, description, currency, guid);
            return wallet;
        }



        public void ShareWalletWithUser(Wallets.Wallet toShare, User user)
        {
            if (!Wallets.Contains(toShare)) throw new Exception("can not share wallet if you are not owner");
            if (user == this) throw new Exception("can not share wallet with owner");
            if (toShare is null) throw new Exception("user hasn't this wallet");
            if (user.WalletsShared.Contains(toShare)) throw new Exception("wallet has been already shared with this user");

            user.WalletsShared.Add(toShare);
        }

        public void SwitchCategoryPermission(Wallets.Wallet wallet, Category category)

        {
            if (!Wallets.Contains(wallet)) throw new Exception("can not switch categories if you are not owner");
            if (!Categories.Contains(category)) throw new Exception("user hasn't this category");
            if (wallet is null) throw new Exception("user hasn't this wallet");

            if (wallet.RestrictedCategories.Contains(category)) wallet.RestrictedCategories.Remove(category);
            else wallet.RestrictedCategories.Add(category);
        }

        public void AddTransaction(Wallets.Wallet wallet, Transaction transaction)

        {
            wallet.AddTransaction(this, transaction);
        }

        public void RemoveTransaction(Wallets.Wallet wallet, Transaction transaction)
        {
            wallet.RemoveTransaction(this, transaction);
        }

        public List<Transaction> Get10Transactions(Wallets.Wallet wallet, int start)
        {
            return wallet.Get10Transactions(this, start);
        }

        public decimal GetWalletBalance(Wallets.Wallet wallet)
        {
            return wallet.CurrBalance;
        }

        /// <summary>
        /// get profit for this wallet started from the first day of current month
        /// </summary>
        /// <returns>amount of profit</returns>
        public decimal GetThisMonthProfit(Wallets.Wallet wallet)
        {
            return wallet.MonthProfit(this);
        }

        /// <summary>
        /// get spends for this wallet started from the first day of current month
        /// </summary>
        /// <returns>amount of spends</returns>
        public decimal GetThisMonthSpends(Wallets.Wallet wallet)
        {
            return wallet.MonthSpends(this);
        }
    }
}
