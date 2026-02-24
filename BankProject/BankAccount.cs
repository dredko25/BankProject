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
        public decimal Balance { get; set; }

        public BankAccount(string owner, decimal balance = 0) // Конструктор
        {
            Owner = owner;
            AccNum = Guid.NewGuid();
            Balance = balance;
        }
    }
}
