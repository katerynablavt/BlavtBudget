using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetsWPF.Wallets
{
    public class WalletsViewModel : IMainNavigetable
    {
        public MainNavigetableTypes Type
        {
            get
            {
                return MainNavigetableTypes.Wallets;
            }
        }

        public void ClearSensitiveData()
        {
          
        }
    }
}
