
using Models;
using Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
    public class WalletService
    {
        private static List<Wallet> Users = new List<Wallet>()
        {
            new Wallet(){Name ="wal1", Balance= 43.09m },
            new Wallet(){Name ="wal2",Balance =345 },
            new Wallet(){Name ="wal3", Balance= 395 },
            new Wallet(){Name ="wal4", Balance= 85 },
            new Wallet(){Name ="wal5", Balance= 4 }
            
        };
       
    public List<Wallet> GetWallets()
        {
            return Users.ToList();
        }
    }
}
