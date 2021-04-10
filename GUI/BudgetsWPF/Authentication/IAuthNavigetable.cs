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
    public interface IAuthNavigetable
    {
        public AuthNavigetableTypes Type { get; }

        public void ClearSensitiveData();
    }
}
