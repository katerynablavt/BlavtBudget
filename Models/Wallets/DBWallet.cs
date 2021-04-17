using DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models.Wallets
{
    public class DBWallet : IStorable
    {
        public DBWallet(string name, decimal startBalance, string description, string currency)
        {
            Guid = Guid.NewGuid();
            Name = name;
            CurrBalance = startBalance;
            Description = description;
            Currency = currency;
        }

        [JsonConstructor]
        public DBWallet(Guid guid, string name, decimal currBalance, string description, string currency)
        {
            Guid = guid;
            Name = name;
            CurrBalance = currBalance;
            Description = description;
            Currency = currency;
        }

        public DBWallet()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; }
        public string Name { get; set; }
        public decimal CurrBalance { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
    }
}
