using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF
{
    public enum MainNavigetableTypes
    {
        Auth,
        Wallets
    }
    public interface IMainNavigetable
    {
        public MainNavigetableTypes Type { get; }

        public void ClearSensitiveData();
    }
}
