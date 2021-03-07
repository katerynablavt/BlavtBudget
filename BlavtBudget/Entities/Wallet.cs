using System;
using System.Collections.Generic;
using System.Linq;
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
        private List<Customer>? _customerUsing ;
        private List<Transaction> _transactions ;

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


        //public List<Transaction> Load (int from = 0, int to = 10)
        //{
        //    var result = new List<Transaction>();
        //    var sorted = _transactions.OrderBy(x => x.Date).ToList();

        //    for (int i = from; i < to; i++)
        //    {
        //        if (i < sorted.Count)
        //        {
        //            result.Add(sorted[i]);
        //        }
        //    }

        //    return result;
        //}

        // temp method
        public void AddUser(Customer customer)
        {
            if (customer.Id > 0)
            {
                _customerUsing.Add(customer);
            }
        }

        // temp method
        public void RemoveUser(Customer customer)
        {
            foreach (var user in _customerUsing)
            {
                if (user == customer)
                {
                    _customerUsing.Remove(customer);
                }
            }
        }

        public void AddTransaction(Transaction transaction)
        {
            if (transaction.Id > 0)
            {
                _transactions.Add(transaction);
            }
        }

        public void RemoveTransaction(Transaction transaction)
        {
            foreach (var user in _transactions)
            {
                if (user == transaction)
                {
                    _transactions.Remove(transaction);
                }
            }
        }
        public void AddCategory(Category category)
        {
            if (category.Id > 0)
            {
                _categories.Add(category);
            }
        }
        public void RemoveCategory(Category category)
        {
            foreach (var user in _categories)
            {
                if (user == category)
                {
                    _categories.Remove(category);
                }
            }
        }

    }

}
