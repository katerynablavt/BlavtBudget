using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF.Authentication
{
    public enum AuthNavigetableTypes
    {
        SignIn,
        SignUp
    }
    public enum MainNavigetableTypes
    {
        Auth,
        Wallets
    }
    public enum WalletsNavigatableTypes
    {
        Wallet,
        WalletCreation,
        TransactionCreation,
        CategoryCreation
    }

}
