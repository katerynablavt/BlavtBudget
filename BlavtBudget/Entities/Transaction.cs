using System;
using System.Collections.Generic;
using System.Text;

namespace BlavtBudget.Entities
{
    public class Transaction : EntityBase
    {
        private static int InstanceCount;

        private int _id;
        private int _customerId;
        private int _walletId;
        private decimal _sum;
        private Currency _currency;
        private Category _category;
        private string _description;
        private DateTime _date;
        private List<object>? _files;

        public int Id { get => _id; set => _id = value; }
        public int CustomerId { get => _customerId; set => _customerId = value; }
        public int WalletId { get => _walletId; set => _walletId = value; }
        public decimal Sum { get => _sum; set => _sum = value; }
        public Currency Currency { get => _currency; set => _currency = value; }
        public Category Category { get => _category; set => _category = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public List<object> Files { get => _files; set => _files = value; }

        public Transaction(int customerId)
        {
            _customerId = customerId;
            _date = new DateTime();
            _files = new List<object>();
            _id = ++InstanceCount;
        }

        public Transaction(int customerId, int id, int walletId, decimal sum, Currency currency,
                             Category category, string description, DateTime date, List<object> files)
        {
            _customerId = customerId;
            _date = date;
            _id = id;
            _walletId = walletId;
            _currency= currency;
            _category= category;
            _description= description;
            _sum = sum;
            _files = files;
          
    }
     
        public override bool Validate()
        {
            var result = true;

            if (Id <= 0)
                    return false;
            if (_walletId <= 0)
                    return false;
            if (_customerId <= 0)
                    return false;
            if (Date == null)
                    return false;
            if (Sum < 0)
                    return false;
            //if (Enum.IsDefined(typeof(Currency), Currency))
            //    return false;

            return result;
           
        }
    }
}
