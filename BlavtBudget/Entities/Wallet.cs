using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BlavtBudget
{
    public enum Currency
    {
        grn,
        dollars
    }
    public class Wallet : EntityBase
    {
        private static int InstanceCount;

        private int _id;
        private string _walletname;
        private string? _description;
        private int _ownerId;
        private double _startBalance;
        private Currency _currency;

        private List<Category> _categories;
        private List<Customer>? _customerUsing;
        private List<Transaction> _transactions;

        public int WalletId
        {
            get { return _id; }
            private set { _id = value; }
        }

        public int CustomerOwnerId
        {
            get
            {
                return _ownerId;
            }
            set
            {
                _ownerId = value;
                HasChanges = true;
            }
        }
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                HasChanges = true;
            }
        }
        public string WalletName
        {
            get
            {
                return _walletname;
            }
            set
            {
                _walletname = value;
                HasChanges = true;
            }
        }

        public Currency Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
                HasChanges = true;
            }
        }
        public double StartBalance
        {
            get
            {
                return _startBalance;
            }
            set
            {
                _startBalance = value;
                HasChanges = true;
            }
        }
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
            protected set { }
        }

        public List<Customer> CustomerUsing
        {
            get
            {
                return _customerUsing;
            }
            protected set { }
        }

        public List<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
            protected set { }
        }
        public Wallet(int ownerId)
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
            _walletname = "Daphalt name";
            _currency = Currency.grn;
            _startBalance = 0;
            _ownerId = ownerId;

            _categories = new List<Category>();
            _customerUsing = new List<Customer>();
            _transactions = new List<Transaction>();        
        }
       
        public Wallet(int id, string walletname, string description,
                      int ownerId, double startBalance, Currency currency,
                      List<Category> categories, List<Customer> customerUsing, List<Transaction> transactions)
        {
            _id = id;
            _walletname = walletname;
            _description = description;
            _ownerId = ownerId;
            _startBalance = startBalance;
            _currency = currency;
            _categories = categories;
            _customerUsing = customerUsing;
            _transactions = transactions;
    }


        public override bool Validate()
        {
            var result = true;

            if (WalletId < 0)
                return false;
            if (String.IsNullOrWhiteSpace(WalletName))
                return false;
            if (CustomerOwnerId < 0)
                return false;
            if (StartBalance < 0)
                return false;
            //if (Enum.IsDefined(typeof(Currency), Currency))
            //    return false;

            return result;
        }

        public override string ToString()
        {
            return $"WalletId: {WalletId}\nWalletName: {WalletName}\nDescription: {Description}\nOwnerId: {CustomerOwnerId}" +
                $"\nStartBalance: {StartBalance}\nCurrency: {Currency}\nCustomerUsing: {CustomerUsing}" +
                $"\nCategories: {Categories}\nTransactions: {Transactions}";
        }
    }

}
