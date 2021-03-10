using BlavtBudget.Entities;
using System;
using System.Collections.Generic;

namespace BlavtBudget
{
    public class Customer : EntityBase
    {
        private static int InstanceCount;

        private int _id;
        private string _lastName;
        private string _firstName;
        private string _email;
        private List<Wallet> _ownWallets;
        private List<Wallet> _sharedWallets;
        private List<Category> _categories;
        private int _type; //active or deleted


        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                HasChanges = true;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                HasChanges = true;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                HasChanges = true;
            }
        }
        public string FullName
        {
            get
            {
                var result = LastName;
                if (!String.IsNullOrWhiteSpace(FirstName))
                {
                    if (!String.IsNullOrWhiteSpace(LastName))
                    {
                        result += ", ";
                    }
                    result += FirstName;
                }
                return result;
            }
        }

        public List<Wallet> OwnWallet 
        { 
            get 
            {
                return _ownWallets;
            } 
        }
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
        }
        public List<Wallet> SharedWallets
        {
            get
            {
                return _sharedWallets;
            }
        }

        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                HasChanges = true;
            }
        }

      

        public Customer()
        {
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
            _ownWallets = new List<Wallet>();
            _sharedWallets = new List<Wallet>();
            _categories = new List<Category>();
        }
        public Customer(int id, string lastName, string firstName, string email, List<Category> categories, List<Wallet> wallets, List<Wallet> swallets, int type)
        {
            _id = id;
            _lastName = lastName;
            _firstName = firstName;
            _email = email;
            _ownWallets = wallets;
            _sharedWallets = swallets;
            _categories = categories;
            _type = type;
        }


        public override bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (String.IsNullOrWhiteSpace(LastName))
                result = false;
            if (String.IsNullOrWhiteSpace(Email))
                result = false;

            return result;
        }

        public override string ToString()
        {
            return FullName;
        }

        // temp method
        public void AddUser(Customer customer, Wallet wallet)
        {
            if (Id == wallet.CustomerOwnerId)
            {
                wallet.CustomerUsing.Add(customer);
            }
        }

        // temp method
        public void RemoveUser(Customer customer, Wallet wallet)
        {
            if (Id == wallet.CustomerOwnerId)
            {

                foreach (var user in wallet.CustomerUsing)
                {
                    if (user == customer)
                    {
                        wallet.CustomerUsing.Remove(customer);
                    }
                }
            }
        }

        public void EdditTransactionSum(Transaction transaction, decimal sum)
        {
            if (Id == transaction.CustomerId&& transaction.Id>0)
            {
                transaction.Sum = sum;
            }
        }
        public void EdditTransactionDescription(Transaction transaction, string desccription)
        {
            if (Id == transaction.CustomerId && transaction.Id > 0)
            {
                transaction.Description = desccription;
            }
        }
        public void EdditTransactionFiles(Transaction transaction, List<object> files)
        {
            if (Id == transaction.CustomerId && transaction.Id > 0)
            {
                transaction.Files = files;
            }
        }

        public void RemoveTransaction(Transaction transaction, Wallet wallet)
        {
            if (Id == wallet.CustomerOwnerId && transaction.Id > 0)
            {
                foreach (var user in wallet.Transactions)
                {
                    if (user == transaction)
                    {
                        wallet.Transactions.Remove(transaction);
                        wallet.StartBalance -= transaction.Sum;
                    }
                }
            }
        }
        public void AddCategory(Category category, Wallet wallet)
        {
            if (Id == wallet.CustomerOwnerId && category.Id > 0)
            {
                wallet.Categories.Add(category);
            }
        }
        public void RemoveCategory(Category category, Wallet wallet)
        {
            if (Id == wallet.CustomerOwnerId && category.Id > 0)
            {
                foreach (var user in wallet.Categories)
                {
                    if (user == category)
                    {
                        wallet.Categories.Remove(category);
                    }
                }
            }
        }

    }
}
