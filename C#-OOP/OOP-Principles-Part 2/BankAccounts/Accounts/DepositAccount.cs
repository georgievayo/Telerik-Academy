using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class DepositAccount : Account, IDeposit, IWithdraw
    {
        public DepositAccount(Customer customer, double balance, double interestRate): base(customer, balance, interestRate)
        {

        }
        public override double CalculateInterestAmount(int months)
        {
            if (this.balance > 0 && this.balance < 1000)
            {
                return 0;
            }
            else
            {
                return base.CalculateInterestAmount(months);
            }
        }

        public void Deposit(double money)
        {
            this.balance += money;
        }

        public void Withdraw(double money)
        {
            this.balance -= money;
        }
    }
}
