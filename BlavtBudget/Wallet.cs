using System;
using System.Collections.Generic;
using System.Text;

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
        private string _description;
        private double __startBalance;
        private List<Category> _categories;
        private List<Customer> _customerUsing;
        private List<Transactions> _transactions;
        private int _ownerId;
        private Currency _currency;

        public int Id
        {
            get { return _id; }
            private set { _id = value; }
        }
       
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
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

        public Currency Currency { get; set; }
        public Wallet()
        {
          //  _name = "Daphalt name";
            _categories = new List<Category>();
            _customerUsing = new List<Customer>();
           // _currency = 
            IsNew = true;
            InstanceCount += 1;
            _id = InstanceCount;
        }
       
    
        public Wallet(int id, string name, List<Category> categories, List<Customer> customerUsing, int ownerId)
        {
            _id = id;
            _name = name;
            _categories = categories;
            _customerUsing = customerUsing;
            _ownerId = ownerId;
        }


        public override bool Validate()
        {
            var result = true;

            if (Id <= 0)
                result = false;
            if (Name == null)
                result = false;
            if (Items == null || Items.Count == 0)
                result = false;
            if (Address == null)
                result = false;
            if (CustomerId <= 0)
                result = false;

            return result;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Date: {Date}";
        }
    }

}
