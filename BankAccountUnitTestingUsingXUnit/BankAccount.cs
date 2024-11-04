using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountUnitTestingUsingxUnit
{
    public class BankAccount
    {
        private double _balance;

        public BankAccount(double initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance must be positive");
            _balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Depositing amount must be positive");
            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawing amount must be positive");
            if (amount > _balance)
                throw new InsufficientFundsException("Insufficient funds");
            _balance -= amount;
        }

        public double GetBalance()
        {
            return _balance;
        }

        public void Transfer(BankAccount toAccount, double amount)
        {
            if (toAccount == null)
                throw new ArgumentException("Target account should not be null");
            Withdraw(amount);
            toAccount.Deposit(amount);
        }
    }

}
