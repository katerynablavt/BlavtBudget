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
        private List<Wallet> _wallets;
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

        public List<Wallet> Wallet 
        { 
            get 
            {
                return _wallets;
            } 
        }
        public List<Category> Categories
        {
            get
            {
                return _categories;
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
            _wallets = new List<Wallet>();
            _categories = new List<Category>();
        }
        public Customer(int id, string lastName, string firstName, string email, List<Category> categories, List<Wallet> wallets, int type)
        {
            _id = id;
            _lastName = lastName;
            _firstName = firstName;
            _email = email;
            _wallets = wallets;
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
    }
}
