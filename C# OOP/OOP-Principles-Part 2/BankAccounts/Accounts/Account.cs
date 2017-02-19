using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccounts
{
    public abstract class Account
    {
        protected Customer customer;
        protected double balance;
        protected double interestRate;

        public Account(Customer customer, double balance, double interestRate)
        {
            this.customer = customer;
            this.balance = balance;
            this.interestRate = interestRate;
        }

        public virtual double CalculateInterestAmount(int months)
        {
            return months * this.interestRate;
        }
    }
}
