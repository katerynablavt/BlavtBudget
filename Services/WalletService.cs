
using DataStorage;
using Models;
using Models.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class WalletService
    {
        private static List<Wallet> Users = new List<Wallet>();
        private FileOfDataStorage<DBWallet> _storage = new FileOfDataStorage<DBWallet>();
        public static Wallet CurrentWallet;


        public async Task<User> LoadUserWallets(User user)
        {
            var transactService = new TransService();
            List<DBWallet> wallets = await _storage.GetAllAsyncForObject(user);
            foreach (var wallet in wallets)
            {
                Wallet wallet_cr = Wallet.CreateWalletForUser(user, wallet.Name, wallet.CurrBalance, wallet.Description, wallet.Currency, wallet.Guid);
                await transactService.LoadWalletTransactions(wallet_cr);

            }
            return user;
        }

        public async Task<bool> SaveUpdateWallet(User user, DBWallet wallet)
        {
            await _storage.AddOrUpdateAsyncForObject(wallet, user);
            return true;
        }

        public async Task<bool> RemoveWallet(DBWallet wallet)
        {
            var transactService = new TransService();

            await _storage.RemoveObj(wallet);
            return true;
        }
    }
}
