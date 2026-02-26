using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProject
{
    public class BankAccount
    {
        public string Owner {  get; set; }
        public Guid AccNum { get; set; } // Guid - глобальний унікальний ідентифікатор
        public decimal Balance { get; protected set; }

        public BankAccount(string owner, decimal balance = 0) // Конструктор
        {
            Owner = owner;
            AccNum = Guid.NewGuid();
            Balance = balance;
        }

        public virtual string Deposit(decimal amount)
        {
            if (amount <= 0)
                return "Deposit amount must be greater than zero.";
            else if (amount > 20000)
                return "AML Deposit limit reached.";
            else {
                Balance += amount;
                return $"Deposit: {amount} to account {AccNum}";
            }
        }
        public string Withdraw(decimal amount)
        {
            if (amount <= 0)
                return "Withdraw amount must be greater than zero.";
            else if (amount > Balance)
                return "You don`t have enough money.";
            else
            {
                Balance -= amount;
                return $"Withdraw: {amount} from account {AccNum}";
            }
        }
    }
}
