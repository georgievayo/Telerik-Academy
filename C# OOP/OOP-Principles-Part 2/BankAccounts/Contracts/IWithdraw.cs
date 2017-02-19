using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public interface IWithdraw
    {
        void Withdraw(double money);
    }
}
