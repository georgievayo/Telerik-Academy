using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class LoanAccount : Account, IDeposit
    {
        public LoanAccount(Customer customer, double balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public override double CalculateInterestAmount(int months)
        {
            if (this.customer is Individual)
            {
                if (months <= 3)
                {
                    return 0;
                }
                else
                {
                    return (months - 3) * this.interestRate;
                }
            }
            else
            {
                if (months <= 2)
                {
                    return 0;
                }
                else
                {
                    return (months - 2) * this.interestRate;
                }
            }
        }

        public void Deposit(double money)
        {
            this.balance += money;
        }
    }
}
