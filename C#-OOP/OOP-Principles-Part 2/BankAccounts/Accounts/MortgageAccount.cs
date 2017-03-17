using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public class MortgageAccount : Account, IDeposit
    {
        public MortgageAccount(Customer customer, double balance, double interestRate) : base(customer, balance, interestRate)
        {
        }

        public override double CalculateInterestAmount(int months)
        {
            if (this.customer is Company)
            {
                if (months <= 12)
                {
                    return 0.5;
                }
                else
                {
                    return 1/2 + (months - 12) * this.interestRate;
                }
            }
            else
            {
                if (months <= 6)
                {
                    return 0;
                }
                else
                {
                    return (months - 6) * this.interestRate;
                }
            }
        }

        public void Deposit(double money)
        {
            this.balance  += money;
        }
    }
}
