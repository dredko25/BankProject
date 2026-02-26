using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class SavingAccount : BankAccount
    {
        public decimal InterestRate { get; set; }

        public SavingAccount(string owner, decimal interestRate = 0.01m) : base(owner + " (" + interestRate + "%)")
        {
            InterestRate = interestRate;
        }

        public override string Deposit(decimal amount)
        {
            if (amount <= 0)
                return "Deposit amount must be greater than zero.";
            else if (amount > 20000)
                return "AML Deposit limit reached.";
            else
            {
                decimal interestAmount = amount * (InterestRate / 100);
                Balance += amount + interestAmount;
                return $"Deposit: {amount} to account {AccNum}";
            }
        }
    }
}
